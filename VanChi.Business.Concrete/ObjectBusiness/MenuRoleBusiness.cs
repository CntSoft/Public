using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanChi.Repository.Interface;
using VanChi.Data;
using System.Reflection;
using VanChi.Business.Common;
using VanChi.Business.DTO;
using System.Data.Entity;

namespace VanChi.Business.Concrete.ObjectBusiness
{
    public class MenuRoleBusiness : BaseObjectBusiness
    {
        #region Variables
        #endregion

        #region Constructor
        public MenuRoleBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Method

        public async Task<List<MenuRoleDTO>> GetByRoleId(Guid roleId)
        {
            try
            {
                return await this.UnitOfWork.GetAll<MenuRole>().Where(x => x.RoleId == roleId)
                  .Select(x => new MenuRoleDTO
                  {
                      MenuId = x.MenuId,
                      UserName = x.UserName,
                      RoleId = x.RoleId
                  }).ToListAsync();

            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }

        }
        public bool DeleteByRoleId(string roleId)
        {
            try
            {
                if (!string.IsNullOrEmpty(roleId))
                {
                    Dictionary<string, object> m_Param = new Dictionary<string, object>()
                    {
                        {"@roleId", roleId}
                    };
                    if (!this.UnitOfWork.ExecuteNonQuery(AppStoredProcedure.SP_MenuRole_DeleteByRoleId, m_Param))
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
            }
            return false;
        }
        public async Task<bool> Insert(Guid roleId, List<Guid> lstMenuID)
        {
            bool result = false;
            try
            {
                if (lstMenuID.Count > 0 && roleId != Guid.Empty)
                {
                    var lstEntity = new List<MenuRole>();
                    foreach (var item in lstMenuID)
                    {
                        lstEntity.Add(new MenuRole
                        {
                            Id = Guid.NewGuid(),
                            RoleId = roleId,
                            MenuId = item,
                            CreateDate = DateTime.Now,
                            UpdateDate = DateTime.Now
                        });
                    }
                    var data = await this.UnitOfWork.InsertToListEntityAsync(lstEntity);
                    if (data.Count > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }

            return result;
        }

        #endregion
    }
}
