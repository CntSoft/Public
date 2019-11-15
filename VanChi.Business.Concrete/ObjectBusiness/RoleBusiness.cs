using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanChi.Repository.Interface;
using VanChi.Business.DTO;
using VanChi.Data;
using System.Data.Entity;
using VanChi.Business.Common;
using System.Reflection;

namespace VanChi.Business.Concrete.ObjectBusiness
{
    public class RoleBusiness : BaseObjectBusiness
    {
        #region Variables

        #endregion

        #region Constructor
        public RoleBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Method

        public async Task<List<RoleDTO>> GetAll()
        {
            var iquery = await this.UnitOfWork.GetAll<Role>().ToListAsync();
            return AutoMapper.Mapper.Map<List<RoleDTO>>(iquery);
        }
        public async Task<List<string>> GetFuncNameToListByRoleID(string roleId)
        {
            var result = new List<string>();
            try
            {
                Dictionary<string, object> m_Param = new Dictionary<string, object>()
                {
                    {"@roleID", roleId}
                };
                var ds = await this.UnitOfWork.ExecuteQueryAsync(AppStoredProcedure.SP_FunctionName_GetAllByRoleID, m_Param);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    result.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                result = null;
            }
            return result;
        }
        public List<string> GetRoleNameToListByUserName(string username)
        {
            var result = new List<string>();
            try
            {
                Dictionary<string, object> m_Param = new Dictionary<string, object>()
                {
                    {"@username", username}
                };
                var ds = this.UnitOfWork.ExecuteQuery(AppStoredProcedure.SP_RoleName_GetAllByUserName, m_Param);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    result.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                result = null;
            }
            return result;
        }
        public async Task<List<string>> GetRoleNameToListByUserNameAsync(string username)
        {
            var result = new List<string>();
            try
            {
                Dictionary<string, object> m_Param = new Dictionary<string, object>()
                {
                    {"@username", username}
                };
                var ds = await this.UnitOfWork.ExecuteQueryAsync(AppStoredProcedure.SP_RoleName_GetAllByUserName, m_Param);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    result.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                result = null;
            }
            return result;
        }

        #endregion
    }
}
