using VanChi.Business.Common;
using VanChi.Business.DTO;
using VanChi.Data;
using VanChi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Interface
{
    public partial interface IBusiness
    {
        #region User Info
        Task<UserInfo> UserInfo_AuthLogin(string userName, string password);
        Task<Tuple<int, IList<UserInfoDTO>>> UserInfo_GetUserCMSToList(string searchString, int? page);      
        Task<UserInfoDTO> UserInfo_GetByUserName(string userName);
        Task<UserInfoDTO> UserInfo_GetByUserCode(string userCode);
        //Task<UserInfoCustomerDTO> UserInfo_GetByUserNameCustomerId(string userName, Guid customerId);
        //Task<UserInfoDTO> UserInfo_GetByCustomerId(Guid customerId);
        IQueryable<UserInfoTerminalDTO> UserInfo_GetAllTerminal();
        IQueryable<UserInfoTerminalDTO> UserInfo_GetAllUserInRole(AppUserRole appRole);
        Task<bool> UserInfo_CreatePasswordAcount(UserPasswordDTO dto);
        /// <summary>
        /// Create password, Active account, Inser QA for customer
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="lstQA"></param>
        /// <returns></returns>
        //Task<bool> UserInfo_ActiveAcountByQA(UserPasswordDTO dto,List<CustomerQADTO> lstQA);
        //Task<bool> UserInfo_ForgotPasswordWithQA(UserPasswordDTO dtoUser, CustomerQAMoreDTO dtoQA);
        //Task<bool> UserInfo_ChangePasswordWithQA(ChangPasswordDTO dtoUser, CustomerQAMoreDTO dtoQA);
        Task<bool> UserInfo_ChangePassword(ChangPasswordDTO lstDto);
        Task<bool> UserInfo_ActiveAcount(string userName);
        Task<bool> UserInfo_CheckPassword(string userName, string password);
        Task<bool> UserInfo_CheckLoginUserByCustomer(string userName);
        Task<bool> UserInfo_Insert(UserInfoDTO dto);
        Task<bool> UserInfo_Update(UserInfoDTO dto);
        #endregion

        #region ROLE
        Task<List<RoleDTO>> Role_GetAll();       
        Task<List<string>> FunctionName_GetAllByRoleID(string roleId);
        List<string> RoleName_GetAllByUserName(string username);
        Task<List<string>> RoleName_GetAllByUserNameAsync(string username);
        #endregion

        #region UserRole
        Task<List<UserRoleDTO>> UserRole_GetByUserName(string username);
        Task<bool> UserRole_InsertToActiveAcount(string username, Guid roleID);
        Task<bool> UserRole_Insert(string UserName, List<string> lstRoleID);
        Task<bool> UserRole_DeleteByUserName(string username);
        #endregion
        #region ROLE FUNCTION
        Task<List<RoleFunctionDTO>> RoleFunction_GetByRoleId(string roleId);     
        Task<bool> RoleFunction_DeleteByRoleId(string roleId);
        Task<bool> RoleFunction_Insert(Guid roleId, List<string> lstFunctionID);
        #endregion
        #region Menu Role
        Task<bool> MenuRole_Insert(Guid roleId, List<Guid> lstMenuID);
        Task<bool> MenuRole_DeleteByRoleId(string roleId);
        Task<List<MenuRoleDTO>> MenuRole_GetByRoleId(Guid roleId);
        #endregion

    }
}
