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
        #region Resource

        Dictionary<string, ResourceDTO> Resource_GetAll();
        bool Resource_Delete(List<string> lstResourceId);

        #endregion

        #region SystemLog

        List<SystemLogDTO> SystemLog_GetPaging(out int total, string keyWord, string module, int userFunction, int eventResult, string dateFrom, string dateTo, int pageIndex, int pageSize);

        #endregion

        #region UserInfo
        UserInfoDTO UserInfo_GetById(string userName);

        #endregion

        #region SystemSetting

        Task<SystemSettingDTO> SystemSetting_GetById(string setId);
        Task<string> SystemSetting_GetValue(string setId);
        string SystemSetting_GetValue_Sync(string setId);
        Task<bool> SystemSetting_Update(List<SystemSettingDTO> dto);

        #endregion

        #region Menu
        IQueryable<Menu> Menu_GetAll();
        IQueryable<Menu> Menu_GetListMenuByRoleName(List<string> lstRoleName);
        IQueryable<Menu> Menu_GetListSubMenu(List<Guid> lstMenuId);
        Task<List<NameMenuRoleDTO>> Menu_GetListMenuByRoleId(List<Guid> lstRole);
        Task<bool> Menu_Insert(List<Menu> lstEntity);
        #endregion
    }
}
