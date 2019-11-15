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
    public class SystemLogBusiness
    {
        #region Variables

        private IUnitOfWork UnitOfWork;

        #endregion

        #region Constructors
        public SystemLogBusiness(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        #endregion

        #region Method
        public List<SystemLogDTO> GetPaging(out int total, string keyWord, string module, int userFunction, int eventResult, string dateFrom, string dateTo, int pageIndex, int pageSize)
        {
            total = 0;
            var lstResult = new List<SystemLogDTO>();
            try
            {
                Dictionary<string, object> m_Param = new Dictionary<string, object>()
                {
                    {"@keyWord", keyWord},
                    {"@module", module},
                    {"@userFunction", userFunction},
                    {"@eventResult", eventResult},
                    {"@dateFrom", dateFrom},
                    {"@dateTo", dateTo},
                    {"@pageIndex", pageIndex},
                    {"@pageSize", pageSize}
                };
                var ds = this.UnitOfWork.ExecuteQuery(AppStoredProcedure.SP_SystemLog_GetPaging, m_Param);
                if (ds != null)
                {
                    total = int.Parse(ds.Tables[1].Rows[0][0].ToString());
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var result = new SystemLogDTO();
                        if (result.ParseData(ds.Tables[0].Rows[i]))
                        {
                            if (result != null)
                            {
                                lstResult.Add(result);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Business.Concrete.ObjectBusiness-SystemLogBusiness-GetPaging()", ex);
                lstResult = null;
            }
            return lstResult;
        }

        #endregion
    }
}
