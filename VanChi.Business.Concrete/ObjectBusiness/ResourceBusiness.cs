using VanChi.Business.Common;
using VanChi.Business.DTO;
using VanChi.Logs;
using VanChi.Data;
using VanChi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Concrete.ObjectBusiness
{
    public class ResourceBusiness
    {
        #region Variables

        private IUnitOfWork UnitOfWork;

        #endregion

        #region Constructors
        public ResourceBusiness(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        #endregion

        #region Method

        public Dictionary<string, ResourceDTO> GetAll()
        {
            var lstResult = new Dictionary<string, ResourceDTO>();
            try
            {
                var ds = this.UnitOfWork.ExecuteQuery(AppStoredProcedure.SP_Resource_GetAll, null);
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var resource = new ResourceDTO();
                        if (resource.ParseData(ds.Tables[0].Rows[i]))
                        {
                            if (resource != null)
                            {
                                lstResult.Add(resource.ResourceID, resource);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Business.Concrete.ObjectBusiness-ResourceBusiness-GetAll()", ex);
                lstResult = null;
            }
            return lstResult;
        }
        public bool Delete(List<string> lstResourceId)
        {
            try
            {
                for (int i = 0; i <= lstResourceId.Count() - 1; i++)
                {
                    if (!string.IsNullOrEmpty(lstResourceId[i].ToString()))
                    {
                        Dictionary<string, object> m_Param = new Dictionary<string, object>()
                        {
                            {"@resourceId", lstResourceId[i].ToString()}
                        };
                        this.UnitOfWork.ExecuteNonQuery(AppStoredProcedure.SP_Resource_Delete, m_Param);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Business.Concrete.ObjectBusiness-ResourceBusiness-Delete()", ex);
            }
            return false;
        }

        #endregion
    }
}
