using AutoMapper;
using VanChi.Business.Common;
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
        #region User
        public async Task<UserInfo> UserInfo_AuthLogin(string userName, string password)
        {
            return await new UserInfoBusiness(this.UnitOfWork).AuthLogin(userName, password);
        }
        public async Task<Tuple<int, IList<UserInfoDTO>>> UserInfo_GetUserCMSToList(string searchString, int? page)
        {
            return await new UserInfoBusiness(this.UnitOfWork).GetListUserCMS(searchString, page);
        }
        public async Task<UserInfoDTO> UserInfo_GetByUserName(string userName)
        {
            return await new UserInfoBusiness(this.UnitOfWork).GetByUserName(userName);
        }
        public async Task<UserInfoDTO> UserInfo_GetByUserCode(string userCode)
        {
            return await new UserInfoBusiness(this.UnitOfWork).GetByUserCode(userCode);
        }
        //public async Task<UserInfoCustomerDTO> UserInfo_GetByUserNameCustomerId(string userName, Guid customerId)
        //{
        //    return await new UserInfoBusiness(this.UnitOfWork).GetByUserNameCustomerId(userName, customerId);
        //}
        //public async Task<UserInfoDTO> UserInfo_GetByCustomerId(Guid customerId)
        //{
        //    return await new UserInfoBusiness(this.UnitOfWork).GetByCustomerId(customerId);
        //}
       public IQueryable<UserInfoTerminalDTO> UserInfo_GetAllUserInRole(AppUserRole appRole)
        {
            return new UserInfoBusiness(this.UnitOfWork).GetAllUserInRole(appRole);
        }
        public IQueryable<UserInfoTerminalDTO> UserInfo_GetAllTerminal()
        {
            return  new UserInfoBusiness(this.UnitOfWork).GetAllTerminal();
        }
        public async Task<bool> UserInfo_ActiveAcount(string userName)
        {
            return await new UserInfoBusiness(this.UnitOfWork).ActiveAcount(userName);
        }
        public async Task<bool> UserInfo_ChangePassword(ChangPasswordDTO dto)
        {
            return await new UserInfoBusiness(this.UnitOfWork).ChangePassword(dto);
        }
        //public async Task<bool> UserInfo_ActiveAcountByQA(UserPasswordDTO dto, List<CustomerQADTO> lstQA)
        //{
        //    return await new UserInfoBusiness(this.UnitOfWork).ActiveAcountByQA(dto, lstQA);
        //}
        public async Task<bool> UserInfo_CreatePasswordAcount(UserPasswordDTO dto)
        {
            return await new UserInfoBusiness(this.UnitOfWork).CreatePasswordAcount(dto);
        }
        //public async Task<bool> UserInfo_ForgotPasswordWithQA(UserPasswordDTO dtoUser, CustomerQAMoreDTO dtoQA)
        //{
        //    return await new UserInfoBusiness(this.UnitOfWork).ForgotPasswordAcountWithQA(dtoUser, dtoQA);
        //}
        //public async Task<bool> UserInfo_ChangePasswordWithQA(ChangPasswordDTO dtoUser, CustomerQAMoreDTO dtoQA)
        //{
        //    return await new UserInfoBusiness(this.UnitOfWork).ChangePasswordAcountWithQA(dtoUser, dtoQA);
        //}
        public async Task<bool> UserInfo_CheckPassword(string userName, string password)
        {
            return await new UserInfoBusiness(this.UnitOfWork).CheckPassword(userName, password);
        }
        public async Task<bool> UserInfo_CheckLoginUserByCustomer(string userName)
        {
            return await new UserInfoBusiness(this.UnitOfWork).CheckLoginUserByCustomer(userName);
        }
        public async Task<bool> UserInfo_Insert(UserInfoDTO dto)
        {
            return await new UserInfoBusiness(this.UnitOfWork).Insert(dto);
        }
        public async Task<bool> UserInfo_Update(UserInfoDTO dto)
        {
            return await new UserInfoBusiness(this.UnitOfWork).Update(dto);
        }
        #endregion

        #region Role

        public async Task<List<RoleDTO>> Role_GetAll()
        {
            return await new RoleBusiness(this.UnitOfWork).GetAll();
        }
        public async Task<List<string>> FunctionName_GetAllByRoleID(string roleId)
        {
            return await new RoleBusiness(this.UnitOfWork).GetFuncNameToListByRoleID(roleId);
        }
        public List<string> RoleName_GetAllByUserName(string username)
        {
            return new RoleBusiness(this.UnitOfWork).GetRoleNameToListByUserName(username);
        }
        public async Task<List<string>> RoleName_GetAllByUserNameAsync(string username)
        {
            return await new RoleBusiness(this.UnitOfWork).GetRoleNameToListByUserNameAsync(username);
        }
        #endregion

        #region User role
        public async Task<List<UserRoleDTO>> UserRole_GetByUserName(string username)
        {
            return await new UserRoleBusiness(this.UnitOfWork).GetByUserName(username);
        }
        public async Task<bool> UserRole_InsertToActiveAcount(string username, Guid roleID)
        {
            bool result = false;
            result =await new UserRoleBusiness(this.UnitOfWork).InsertToActiveAcount(username, roleID);
            return result;
        }
        public async Task<bool> UserRole_Insert(string username, List<string> lstRoleID)
        {
            bool result = false;
            await Task.Run(() =>
            {
                result = new UserRoleBusiness(this.UnitOfWork).Insert(username, lstRoleID);
            });
            return result;
        }
        public async Task<bool> UserRole_DeleteByUserName(string username)
        {
            bool result = false;
            await Task.Run(() =>
            {
                result = new UserRoleBusiness(this.UnitOfWork).DeleteByUserName(username);
            });
            return result;
        }
        #endregion
        #region Role function
        public async Task<List<RoleFunctionDTO>> RoleFunction_GetByRoleId(string roleId)
        {
            return await new RoleFunctionBusiness(this.UnitOfWork).GetRoleFuncToListByRoleId(roleId);
        }
        public async Task<bool> RoleFunction_DeleteByRoleId(string roleId)
        {
            bool result = false;
            await Task.Run(() =>
            {
                result = new RoleFunctionBusiness(this.UnitOfWork).DeleteByRoleId(roleId);
            });
            return result;
        }
       
        public async Task<bool> RoleFunction_Insert(Guid roleId, List<string> lstFunctionID)
        {
            bool result = false;
            await Task.Run(() =>
            {
                result = new RoleFunctionBusiness(this.UnitOfWork).Insert(roleId, lstFunctionID);
            });
            return result;

        }
        #endregion

        #region Menu Role
       public async Task<List<MenuRoleDTO>> MenuRole_GetByRoleId(Guid roleId)
        {
            return await new MenuRoleBusiness(this.UnitOfWork).GetByRoleId(roleId);
        }
        public async Task<bool> MenuRole_Insert(Guid roleId, List<Guid> lstMenuID)
        {
            return await new MenuRoleBusiness(this.UnitOfWork).Insert(roleId, lstMenuID);
        }
        public async Task<bool> MenuRole_DeleteByRoleId(string roleId)
        {
            bool result = false;
            await Task.Run(() =>
            {
                result = new MenuRoleBusiness(this.UnitOfWork).DeleteByRoleId(roleId);
            });
            return result;
        }
        #endregion
    }
}
