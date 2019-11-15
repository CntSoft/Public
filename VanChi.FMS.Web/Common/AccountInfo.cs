using AutoMapper;
using VanChi.Business.Common;
using VanChi.Business.DTO;
using VanChi.FMS.Web.Controllers;
using VanChi.FMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace VanChi.FMS.Web.Common
{
    public class AccountInfo
    {
        #region Properties

        /// <summary>
        /// Tài khoản đăng nhập hệ thống
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Tên tài khoản
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Địa chỉ IP máy tính đang truy cập
        /// </summary>
        public string IpAddress { get; set; }
        public List<MenuDTO> Permission { get; set; }

        #endregion

        #region Constructors
        public AccountInfo()
        {
            this.UserName = Constant.Anonymous;
            this.FullName = Constant.Anonymous;
            this.IpAddress = GetClientIpAddress();
        }
        public AccountInfo(string userId, string fullName)
        {
            this.UserName = userId;
            this.FullName = fullName;
            this.IpAddress = GetClientIpAddress();
            this.Permission = GetPermission(userId);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Ghi lược sử nhật ký hệ thống
        /// </summary>
        /// <param name="module">Tên phân hệ</param>
        /// <param name="action">Thao tác</param>
        /// <param name="eventResult">Kết quả</param>
        /// <param name="source">Tên method</param>
        /// <param name="transData">Dữ liệu</param>
        /// <returns>Ghi lược sử thành công</returns>
        public async Task<bool> WriteApplicationLog(AppModule module, AppAction action, AppEventResult eventResult, string source, string transData)
        {
            try
            {
                SystemLogModel sysLog = new SystemLogModel();
                sysLog.LogId = Guid.NewGuid();
                sysLog.Module = module.ToString();
                sysLog.UserId = this.UserName;
                sysLog.UserFunction = (int)action;
                sysLog.EventResult = (int)eventResult;
                sysLog.FuncDateTime = DateTime.Now;
                sysLog.Source = source;
                sysLog.Transdata = transData;
                sysLog.WSName = this.IpAddress;
                return await DependencyResolver.Current.GetService<SystemManagementController>().SystemLogInsertAsync(sysLog);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lấy địa chỉ IP của client
        /// </summary>
        /// <returns>Địa chỉ IP</returns>
        private string GetClientIpAddress()
        {
            try
            {
                HttpRequest contextRequest = HttpContext.Current.Request;
                string strIpList = contextRequest.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!string.IsNullOrEmpty(strIpList))
                {
                    return strIpList.Split(',')[0];
                }
                return contextRequest.ServerVariables["REMOTE_ADDR"];
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Lấy quyền của người dùng đang đăng nhập
        /// </summary>
        /// <returns></returns>
        private List<MenuDTO> GetPermission(string userId)
        {
            var lstDto = new List<MenuDTO>();
            try
            {
                var business = Autofac.GetBusiness();
                if (!string.IsNullOrEmpty(userId))
                {
                    //get role userName
                    var lstRoleName = business.RoleName_GetAllByUserName(userId);
                    //Get all menu
                    var iquery = business.Menu_GetAll();
                    //Check role user
                    if (lstRoleName.Contains(AppUserRole.SystemAdmin.ToString()))
                    {
                        //Add all menu            
                        lstDto = Mapper.Map(iquery, lstDto);
                    }
                    else
                    {
                        //Add menu by role
                        var iqueryRole = business.Menu_GetListMenuByRoleName(lstRoleName);
                        lstDto = Mapper.Map(iqueryRole, lstDto);
                        var parentId = iqueryRole.Where(x => x.ParentId == null).Select(x => x.Id).ToList();
                        var iquerySubMenu = business.Menu_GetListSubMenu(parentId)
                            .Where(x => x.IsParent == true).ToList();
                        var lstSubDto = Mapper.Map<List<MenuDTO>>(iquerySubMenu);
                        if (lstSubDto.Count > 0)
                        {
                            lstDto.AddRange(lstSubDto);

                            #region Add  parrent       

                            //Check menu sub not parent
                            var checkNotFindParent = lstDto.Where(x => x.ParentId != null && x.IsParent == false).ToList();
                            foreach (var item in checkNotFindParent)
                            {
                                var checkAddParent = lstDto.Where(x => item.ParentId == x.Id && x.ParentId == null).Count();
                                if (checkAddParent <= 0)
                                {
                                    //Add parent
                                    var parent = iquery.Where(x => x.ParentId == null && x.Id == item.ParentId).FirstOrDefault();
                                    if (parent != null)
                                    {
                                        lstDto.Add(Mapper.Map<MenuDTO>(parent));
                                    }
                                    else
                                    {
                                        //Add parent sub
                                        var parentSub = iquery.Where(x => x.ParentId != null && x.Id == item.ParentId).FirstOrDefault();
                                        if (parentSub != null)
                                        {
                                            lstDto.Add(Mapper.Map<MenuDTO>(parentSub));
                                            //Add parent sub
                                            var parentTemp = iquery.Where(x => x.ParentId == null && x.Id == parentSub.ParentId).FirstOrDefault();
                                            if (parentTemp != null)
                                            {
                                                lstDto.Add(Mapper.Map<MenuDTO>(parentTemp));
                                            }
                                        }

                                    }
                                }
                            }

                            #endregion
                        }
                        //Append Role is public
                        var iqueryRoleAllowAnonymous = iquery.Where(x => x.MenuStatus == (byte)AppMenu.MenuStatus.IsMenuOrPublic
                        || x.MenuStatus == (byte)AppMenu.MenuStatus.IsPublic);
                        var rolePublic = Mapper.Map<List<MenuDTO>>(iqueryRoleAllowAnonymous);
                        if (rolePublic.Count > 0) lstDto.AddRange(rolePublic);
                    }
                }
            }
            catch { }
            return lstDto;
        }

        /// <summary>
        /// Kiểm tra người dùng đang đăng nhập có quyền hay không
        /// </summary>
        /// <param name="strFunction">Tên quyền</param>
        /// <returns></returns>
        public bool HavePermission(params AppFunction[] funcs)
        {
            //foreach (AppFunction func in funcs)
            //{
            //    if (this.Permission.Where(x => x.Id == func.ToString()).FirstOrDefault() != null)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        #endregion
    }
}