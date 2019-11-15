using AutoMapper;
using VanChi.Business.Common;
using VanChi.Business.DTO;
using VanChi.Logs;
using VanChi.Data;
using VanChi.Repository.Interface;
using VanChi.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Concrete.ObjectBusiness
{
    public class UserInfoBusiness : BaseObjectBusiness
    {
        #region Variables

        #endregion

        #region Constructor
        public UserInfoBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion
        
        #region Method

        public async Task<UserInfo> AuthLogin(string userName, string password)
        {
            string strEncryptPassword = CipherUtility.GetMd5Hash(password);
            return await this.UnitOfWork.GetSingle<UserInfo>(x => x.UserName.ToLower().EndsWith(userName.ToLower()) && x.Password == strEncryptPassword);
        }
        public async Task<Tuple<int, IList<UserInfoDTO>>> GetListUserCMS(string searchString, int? page)
        {
            int total = 0;
            var pageNumber = page ?? 0;
            int pageSize = 20;
            var iquery = this.UnitOfWork.GetAll<UserInfo>().Where(x => x.IsCustomer != true);
            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrWhiteSpace(searchString))
            {
                iquery = iquery.Where(x => x.UserName.Contains(searchString) ||
                  x.Email.Contains(searchString)
                  || x.HomePhone.Contains(searchString));
            }
            total = iquery.Count();
            var data = await iquery.OrderBy(x => x.UserName).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var dto = Mapper.Map<List<UserInfoDTO>>(data);
            return new Tuple<int, IList<UserInfoDTO>>(total, dto);

        }
        public UserInfoDTO GetById(string userName)
        {
            var result = new UserInfoDTO();
            try
            {
                Dictionary<string, object> m_Param = new Dictionary<string, object>()
                {
                    {"@userName", userName}
                };
                var ds = this.UnitOfWork.ExecuteQuery(AppStoredProcedure.SP_UserInfo_GetById, m_Param);
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        result.ParseData(ds.Tables[0].Rows[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Business.Concrete.ObjectBusiness-UserInfoBusiness-GetById()", ex);
                result = null;
            }
            return result;
        }
        public async Task<UserInfoDTO> GetByUserName(string userName)
        {
            try
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    var iquery = await this.UnitOfWork.GetSingle<UserInfo>(x => x.UserName == userName);
                    if (iquery != null)
                    {
                        var result = Mapper.Map<UserInfoDTO>(iquery);
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }
            return null;
        }
        public async Task<UserInfoDTO> GetByUserCode(string userCode)
        {
            try
            {
                if (!string.IsNullOrEmpty(userCode))
                {
                    var iquery = await this.UnitOfWork.GetSingle<UserInfo>(x => x.UserCode.ToLower() == userCode.Trim().ToLower());
                    if (iquery != null)
                    {
                        var result = Mapper.Map<UserInfoDTO>(iquery);
                        return result;
                    }
                }

            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }
            return null;
        }
        //public async Task<UserInfoCustomerDTO> GetByUserNameCustomerId(string userName, Guid customerId)
        //{
        //    try
        //    {
        //        var result = new UserInfoCustomerDTO();
        //        await Task.Run(() =>
        //          {
        //              result = this.UnitOfWork.GetAll<Customer>()
        //                                               .Where(x => x.Id == customerId)
        //                                               .Join(this.UnitOfWork.GetAll<UserInfo>()
        //                                               .Where(x => x.UserName == userName),
        //                                               (c => c.Code),
        //                                               (u => u.UserCode),
        //                                               (c, u) => new { c, u })
        //                                               .OrderByDescending(x => x.c.CreateDate)
        //                                               .Select(x => new UserInfoCustomerDTO
        //                                               {
        //                                                   CustomerId = x.c.Id,
        //                                                   PhoneNumber = x.c.Hotline,
        //                                                   Email = x.c.Email,
        //                                                   UserCode = x.c.Code,
        //                                                   UserName = x.u.UserName,
        //                                                   IsActive = x.u.IsActive
        //                                               }).FirstOrDefault();
        //          });
        //        if (!string.IsNullOrEmpty(result?.UserName))
        //            return result;
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
        //        throw ex;
        //    }
        //}
        //public async Task<UserInfoDTO> GetByCustomerId(Guid customerId)
        //{
        //    try
        //    {
        //        var result = new UserInfoDTO();
        //        await Task.Run(() =>
        //        {
        //            if (customerId != Guid.Empty)
        //            {
        //                var iquery = this.UnitOfWork.GetAll<Customer>()
        //                        .Where(x => x.Id == customerId)
        //                        .Join(this.UnitOfWork.GetAll<UserInfo>(),
        //                        (c => c.Code),
        //                        (u => u.UserCode),
        //                        (c, u) => new { c, u })
        //                        .OrderByDescending(x => x.c.CreateDate)
        //                        .Select(x => x.u)
        //                        .FirstOrDefault();
        //                if (iquery != null)
        //                    result = Mapper.Map<UserInfoDTO>(iquery);
        //            }
        //        });
        //        return result;

        //    }
        //    catch (Exception ex)
        //    {
        //        InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
        //        throw;
        //    }
        //}
        public IQueryable<UserInfoTerminalDTO> GetAllTerminal()
        {
            try
            {               
                return GetAllUserInRole(AppUserRole.Terminal);
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }           
        }
        public IQueryable<UserInfoTerminalDTO> GetAllUserInRole(AppUserRole appRole)
        {
            try
            {
                var _appRole = appRole.ToString();
                return this.UnitOfWork.GetAll<Role>().Where(x => x.RoleName.ToLower() == _appRole.ToLower())
                              .Join(this.UnitOfWork.GetAll<UserRole>(),
                                    r => r.RoleID,
                                    ur => ur.RoleID,
                                    (r, ur) => new { ur.UserName })
                              .Join(this.UnitOfWork.GetAll<UserInfo>(),
                                usrRole => usrRole.UserName,
                                user => user.UserName,
                                (role, user) => new UserInfoTerminalDTO
                                {
                                    Email = user.Email,
                                    PhoneNumber = user.Mobile,
                                    UserName = user.UserName,
                                    Name = user.FullName
                                });

            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }
        }
        //public async Task<bool> ActiveAcountByQA(UserPasswordDTO dto, List<CustomerQADTO> lstQA)
        //{
        //    var dbTransaction = this.UnitOfWork.BeginTransaction();
        //    try
        //    {
        //        bool result = false;
        //        var entity = await this.UnitOfWork.GetSingle<UserInfo>(x => x.UserName == dto.UserName);
        //        if (entity != null)
        //        {
        //            result = await new CustomerQABusiness(this.UnitOfWork).InsertToList(lstQA);
        //            if (result)
        //            {
        //                result = await this.ActiveAcount(entity?.UserName);
        //                if (result)
        //                {
        //                    entity.Password = CipherUtility.GetMd5Hash(dto.NewPassword);
        //                    result = await this.UnitOfWork.UpdateEntityAsync(entity);
        //                    //if (result)
        //                    //{
        //                    //  var AddUSerRole=  await new UserRoleBusiness(this.UnitOfWork).InsertToActiveAcount(entity.UserName, AppLoginRole.RoleCustomerID);
        //                    //}
        //                }
        //            }
        //            if (result)
        //            {
        //                dbTransaction.Commit();
        //            }
        //            else
        //            {
        //                dbTransaction.Rollback();
        //            }
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        dbTransaction.Rollback();
        //        InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
        //        throw;
        //    }


        //}
        //public async Task<bool> ForgotPasswordAcountWithQA(UserPasswordDTO dto, CustomerQAMoreDTO dtoQA)
        //{
        //    var dbTransaction = this.UnitOfWork.BeginTransaction();
        //    try
        //    {
        //        bool result = false;
        //        var entity = await this.UnitOfWork.GetSingle<UserInfo>(x => x.UserName == dto.UserName);
        //        if (entity != null)
        //        {
        //            //get ALL to Delete Question OLD customer 
        //            result = await new CustomerQABusiness(this.UnitOfWork).DeleteEntityByCustomerId(dtoQA.CustomerId);
        //            //Insert new question and answer
        //            if (result)
        //            {
        //                result = await new CustomerQABusiness(this.UnitOfWork).InsertToList(dtoQA.LstQA);
        //                if (result)
        //                {
        //                    entity.Password = CipherUtility.GetMd5Hash(dto.NewPassword);
        //                    result = await this.UnitOfWork.UpdateEntityAsync(entity);
        //                }
        //            }
        //            if (result)
        //            {
        //                dbTransaction.Commit();
        //            }
        //            else
        //            {
        //                dbTransaction.Rollback();
        //            }
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        dbTransaction.Rollback();
        //        InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
        //        throw;
        //    }


        //}
        //public async Task<bool> ChangePasswordAcountWithQA(ChangPasswordDTO dto, CustomerQAMoreDTO dtoQA)
        //{
        //    var dbTransaction = this.UnitOfWork.BeginTransaction();
        //    try
        //    {
        //        bool result = false;
        //        var entity = await this.UnitOfWork.GetSingle<UserInfo>(x => x.UserName == dto.UserName);
        //        if (entity != null)
        //        {
        //            //get ALL to Delete Question OLD customer 
        //            result = await new CustomerQABusiness(this.UnitOfWork).DeleteEntityByCustomerId(dtoQA.CustomerId);
        //            //Insert new question and answer
        //            if (result)
        //            {
        //                result = await new CustomerQABusiness(this.UnitOfWork).InsertToList(dtoQA.LstQA);
        //                if (result)
        //                {
        //                    result = await ChangePassword(dto);
        //                }
        //            }
        //            if (result)
        //            {
        //                dbTransaction.Commit();
        //            }
        //            else
        //            {
        //                dbTransaction.Rollback();
        //            }
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        dbTransaction.Rollback();
        //        InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
        //        throw;
        //    }


        //}
        public async Task<bool> CreatePasswordAcount(UserPasswordDTO dto)
        {
            try
            {
                bool result = false;
                var entity = await this.UnitOfWork.GetSingle<UserInfo>(x => x.UserName == dto.UserName);
                if (entity != null)
                {
                    entity.Password = CipherUtility.GetMd5Hash(dto.NewPassword);
                    result = await this.UnitOfWork.UpdateEntityAsync(entity);
                }
                return result;
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }


        }
        public async Task<bool> ActiveAcount(string userName)
        {
            try
            {
                var entity = await this.UnitOfWork.GetSingle<UserInfo>(x => x.UserName == userName);
                entity.IsActive = true;
                return await this.UnitOfWork.UpdateEntityAsync(entity);
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }

        }
        public async Task<bool> ChangePassword(ChangPasswordDTO dto)
        {
            try
            {
                bool result = false;
                var OldPasswordTemp = CipherUtility.GetMd5Hash(dto.OldPassword);
                var entity = await this.UnitOfWork.GetSingle<UserInfo>(x => x.UserName == dto.UserName && x.Password == OldPasswordTemp);
                if (entity != null)
                {
                    entity.Password = CipherUtility.GetMd5Hash(dto.NewPassword);
                    result = await this.UnitOfWork.UpdateEntityAsync(entity);
                }
                return result;
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }

        }
        public async Task<bool> CheckPassword(string userName, string password)
        {
            try
            {
                bool result = false;
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    var passSQL = CipherUtility.GetMd5Hash(password);
                    var iquery = await this.UnitOfWork.GetSingle<UserInfo>(x => x.UserName == userName
                    && x.Password == passSQL);
                    if (!string.IsNullOrEmpty(iquery?.UserName))
                        result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }

        }
        public async Task<bool> CheckLoginUserByCustomer(string userName)
        {
            try
            {
                bool result = false;
                var iquery = await this.UnitOfWork.GetSingle<UserInfo>(x => x.UserName == userName);
                if (iquery != null)
                {
                    bool active = iquery.IsActive ?? false;
                    bool customer = iquery.IsCustomer ?? false;
                    if (customer == true && active == true)
                    {
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }
        public async Task<bool> Insert(UserInfoDTO dto)
        {
            try
            {
                var entity = Mapper.Map<UserInfo>(dto);
                entity.Password = CipherUtility.GetMd5Hash(entity.Password);
                var result = await this.UnitOfWork.InsertEntityAsync(entity);
                if (result != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }

        }
        public async Task<bool> Update(UserInfoDTO dto)
        {
            try
            {
                var entity = await this.UnitOfWork.GetSingle<UserInfo>(x => x.UserName == dto.UserName);
                //Not change password
                var pws = entity.Password;
                entity = Mapper.Map(dto, entity);
                entity.Password = pws;
                return await this.UnitOfWork.UpdateEntityAsync(entity);
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }


        }

        #endregion
    }
}
