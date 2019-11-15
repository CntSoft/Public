using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanChi.Repository.Interface;
using VanChi.Business.Common;
using System.Reflection;
using VanChi.Business.DTO;

namespace VanChi.Business.Concrete.ObjectBusiness
{
    public class RoleFunctionBusiness : BaseObjectBusiness
    {
        #region Variables

        #endregion

        #region Constructor
        public RoleFunctionBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Method

        public async Task<List<RoleFunctionDTO>> GetRoleFuncToListByRoleId(string roleId)
        {

            var result = new List<RoleFunctionDTO>();
            try
            {
                if (!string.IsNullOrEmpty(roleId))
                {
                    Dictionary<string, object> m_Param = new Dictionary<string, object>()
                    {
                        {"@roleId", roleId.ToString()}
                    };
                    var ds = await this.UnitOfWork.ExecuteQueryAsync(AppStoredProcedure.SP_RoleFunction_GetByRoleId, m_Param);
                    if (ds != null)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            var temp = new RoleFunctionDTO();
                            temp.ParseData(ds.Tables[0].Rows[i]);
                            result.Add(temp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                result = null;
            }
            return result;
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
                    if (!this.UnitOfWork.ExecuteNonQuery(AppStoredProcedure.SP_RoleFunction_DeleteByRoleId, m_Param))
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
        public bool Insert(Guid roleId, List<string> lstFunctionId)
        {
            try
            {
                for (int i = 0; i <= lstFunctionId.Count() - 1; i++)
                {
                    if (!string.IsNullOrEmpty(lstFunctionId[i].ToString()))
                    {
                        Dictionary<string, object> m_Param = new Dictionary<string, object>()
                        {
                            {"@roleId", roleId.ToString()},
                            {"@functionId", lstFunctionId[i].ToString()}
                        };
                        if (!this.UnitOfWork.ExecuteNonQuery(AppStoredProcedure.SP_RoleFunction_Insert, m_Param))
                            return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
            }
            return false;
        }

        #endregion
    }
}
