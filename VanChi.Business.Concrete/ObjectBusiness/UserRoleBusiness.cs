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
    public class UserRoleBusiness : BaseObjectBusiness
    {
        #region Variables

        #endregion

        #region Constructor
        public UserRoleBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Method
        public async Task<List<UserRoleDTO>> GetByUserName(string username)
        {

            List<UserRoleDTO> result = new List<UserRoleDTO>();
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    Dictionary<string, object> m_Param = new Dictionary<string, object>()
                    {
                        {"@username", username.ToString()}
                    };
                    var ds = await this.UnitOfWork.ExecuteQueryAsync(AppStoredProcedure.SP_UserRole_GetByUserName, m_Param);
                    if (ds != null)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            var temp = new UserRoleDTO();
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
        public async Task<int> CountByUserRole(string username, Guid roleId)
        {

            int result = 0;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    Dictionary<string, object> m_Param = new Dictionary<string, object>()
                        {
                            {"@userName", username.ToString()},
                            {"@roleId", roleId}
                        };
                    var ds = await this.UnitOfWork.ExecuteQueryAsync(AppStoredProcedure.SP_UserRole_CountByUserRole, m_Param);
                    if (ds != null)
                    {
                        result = (int)ds.Tables[0].Rows[0][0];
                    }

                }
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);               
            }
            return result;
        }
        public async Task<bool> InsertToActiveAcount(string username, Guid roleId)
        {
            try
            {
                bool result = false;
                if (roleId != Guid.Empty)
                {
                    Dictionary<string, object> m_Param = new Dictionary<string, object>()
                        {
                            {"@userName", username.ToString()},
                            {"@roleId", roleId}
                        };
                    var checkCountUserRole = await CountByUserRole(username, roleId);
                    if (checkCountUserRole <= 0)
                    {
                        result = await this.UnitOfWork.ExecuteNonQueryAsync(AppStoredProcedure.SP_UserRole_InsertByActive, m_Param);
                    }
                    else
                    {
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
            }
            return false;
        }
        public bool Insert(string username, List<string> lstRoleId)
        {
            try
            {
                for (int i = 0; i <= lstRoleId.Count() - 1; i++)
                {
                    if (!string.IsNullOrEmpty(lstRoleId[i].ToString()))
                    {
                        Dictionary<string, object> m_Param = new Dictionary<string, object>()
                        {
                            {"@username", username.ToString()},
                            {"@roleId", lstRoleId[i].ToString()}
                        };
                        if (!this.UnitOfWork.ExecuteNonQuery(AppStoredProcedure.SP_UserRole_Insert, m_Param))
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
        public bool DeleteByUserName(string username)
        {
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    Dictionary<string, object> m_Param = new Dictionary<string, object>()
                    {
                        {"@username", username.ToString()}
                    };
                    if (!this.UnitOfWork.ExecuteNonQuery(AppStoredProcedure.SP_UserRole_DeleteByUserName, m_Param))
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

        #endregion
    }
}
