using AutoMapper;
using VanChi.Business.Concrete.ObjectBusiness;
using VanChi.Business.DTO;
using VanChi.Business.Interface;
using VanChi.Data;
using VanChi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VanChi.Business.Concrete
{
    public partial class Business : IBusiness
    {
        #region Resource

        public Dictionary<string, ResourceDTO> Resource_GetAll()
        {
            return new ResourceBusiness(this.UnitOfWork).GetAll();
        }

        public bool Resource_Delete(List<string> lstResourceId)
        {
            return new ResourceBusiness(this.UnitOfWork).Delete(lstResourceId);
        }

        #endregion

        #region SystemLog

        public List<SystemLogDTO> SystemLog_GetPaging(out int total, string keyWord, string module, int userFunction, int eventResult, string dateFrom, string dateTo, int pageIndex, int pageSize)
        {
            return new SystemLogBusiness(this.UnitOfWork).GetPaging(out total, keyWord, module, userFunction, eventResult, dateFrom, dateTo, pageIndex, pageSize);
        }

        #endregion

        #region UserInfo
        public UserInfoDTO UserInfo_GetById(string userName)
        {
            return new UserInfoBusiness(this.UnitOfWork).GetById(userName);
        }

        #endregion

        #region SystemSetting

        public async Task<SystemSettingDTO> SystemSetting_GetById(string setId)
        {
            return await new SystemSettingBusiness(this.UnitOfWork).GetById(setId);
        }
        public async Task<string> SystemSetting_GetValue(string setId)
        {
            return await new SystemSettingBusiness(this.UnitOfWork).GetValue(setId);
        }
        public async Task<bool> SystemSetting_Update(List<SystemSettingDTO> dto)
        {
            return await new SystemSettingBusiness(this.UnitOfWork).Update(dto);
        }
        public string SystemSetting_GetValue_Sync(string setId)
        {
            return new SystemSettingBusiness(this.UnitOfWork).GetValue_Sync(setId);
        }

        #endregion

        #region Menu
        public IQueryable<Menu> Menu_GetAll()
        {
            return new MenuBusiness(this.UnitOfWork).GetAll();
        }
        public IQueryable<Menu> Menu_GetListMenuByRoleName(List<string> lstRoleName)
        {
            return new MenuBusiness(this.UnitOfWork).GetListMenuByRoleName(lstRoleName);
        }
       public IQueryable<Menu> Menu_GetListSubMenu(List<Guid> lstMenuId)
        {
            return new MenuBusiness(this.UnitOfWork).GetListSubMenu(lstMenuId);
        }
        public async Task<List<NameMenuRoleDTO>> Menu_GetListMenuByRoleId(List<Guid> lstRole)
        {
            return await new MenuBusiness(this.UnitOfWork).GetListMenuByRoleId(lstRole);
        }
       public async Task<bool> Menu_Insert(List<Menu> lstEntity)
        {
            return await new MenuBusiness(this.UnitOfWork).Insert(lstEntity);
        }
        #endregion

    }
}
