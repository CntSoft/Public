using AutoMapper;
using VanChi.Business.Common;
using VanChi.Business.DTO;
using VanChi.Logs;
using VanChi.Data;
using VanChi.Repository.Interface;
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
    public class SystemSettingBusiness: BaseObjectBusiness
    {
        #region Variables
        #endregion

        #region Constructors
        public SystemSettingBusiness(IUnitOfWork unitOfWork):base(unitOfWork)
        {
        }
        #endregion

        #region Method

        public async Task<SystemSettingDTO> GetById(string setId)
        {
            var result = new SystemSettingDTO();
            try
            {
                var query = await this.UnitOfWork.GetSingle<SystemSetting>(x => x.SettingId == setId);
                if (query != null)
                {
                    result = Mapper.Map<SystemSettingDTO>(query);
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Business.Concrete.ObjectBusiness-SystemSettingBusiness-GetById()", ex);
            }
            return result;
        }
        public async Task<string> GetValue(string setId)
        {
            string result = string.Empty;
            try
            {
                var query = await this.UnitOfWork.GetSingle<SystemSetting>(x => x.SettingId == setId);
                if (query != null)
                {
                    result = query.Value;
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Business.Concrete.ObjectBusiness-SystemSettingBusiness-GetValue()", ex);
            }
            return result;
        }
        public async Task<bool> Update(List<SystemSettingDTO> lstsettingDTO)
        {
            try
            {
                bool result = false;
                for(int i = 0; i < lstsettingDTO.Count; i++ )
                {
                    string settingId = lstsettingDTO[i].SettingId;
                    var entity = await this.UnitOfWork.GetSingle<SystemSetting>(x => x.SettingId == settingId);
                    entity.Value = lstsettingDTO[i].Value;
                    result = await UnitOfWork.UpdateEntityAsync(entity);
                    if (result == false)
                        break;
                }
                return result;
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                return false;
            }
        }
        public string GetValue_Sync(string setId)
        {
            string result = string.Empty;
            try
            {
                Dictionary<string, object> m_Param = new Dictionary<string, object>()
                {
                    {"@id", setId},
                };
                var query =  this.UnitOfWork.ExecuteQuery(AppStoredProcedure.SP_SystemSetting_GetValue, m_Param);
                if (query != null)
                {
                    var setDTO = new SystemSettingDTO();
                    setDTO.ParseData(query.Tables[0].Rows[0]);
                    result = setDTO.Value;
                }
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
            }
            return result;
        }

        #endregion
    }
}
