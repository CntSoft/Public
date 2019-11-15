using VanChi.Business.Common;
using VanChi.Logs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VanChi.Business.DTO
{
    public class BaseDTO
    {
        public BaseDTO()
        {
            Id = Guid.Empty;
            URL = string.Empty;
            Description = string.Empty;
            CreateBy = string.Empty;
            UpdateBy = string.Empty;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            ActiveFag = (int)AppValues.ActiveFag.StatusActive;
        }
        public Guid Id { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public AppValues.ActiveFag ActiveFag { get; set; }
        public bool ParseData(DataRow dr)
        {
            try
            {
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    string _colName = dr.Table.Columns[i].ColumnName;
                    PropertyInfo _prop = this.GetType().GetProperty(_colName);
                    if (!(dr[_colName] is DBNull) && _prop != null)
                    {
                        _prop.SetValue(this, dr[_colName], null);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Business.DTO-BaseDTO-ParseData", ex);
                return false;
            }
        }
    }


    public class FileDTO
    {
        public string Name { get; set; }
        public byte[] FileAttach { get; set; }
        public string FileExt { get; set; }
        public string FileSize { get; set; }
        public int FileOrder { get; set; }
    }

    public class MailDTO:HostDTO
    {
        public string Title { get; set; }
        /// <summary>
        /// Default BLCode
        /// </summary>
        public string Code1 { get; set; }
        /// <summary>
        /// Default DO Code
        /// </summary>
        public string Code2 { get; set; }
        public string UpdateBy { get; set; }
        public string BodyHtml { get; set; }
        public string ToMail { get; set; }
        public List<string> LstToMail { get; set; }
        public string CCMail { get; set; }
        public string FileOnline { get; set; }
        public string FileAttach { get; set; }
        public string Consignee { get; set; }
        public string Notify { get; set; }
        public string Comment { get; set; }
        public bool IsSendMail { get; set; }
        public AppType.SenderOfMail SenderOfMail { get; set; }
        public MailDTO()
        {
            IsSendMail = true;
            this.LstToMail = new List<string>();
        }
    }

    public class StatusDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string CustomerCode { get; set; }
        public byte ByteStatus { get; set; }
        public int IntStatus { get; set; }
        public string Comment { get; set; }
        public string UpdateBy { get; set; }
        public bool IsCustomer { get; set; }    
        public StatusDTO()
        {
            this.IsCustomer = true;
        }   
    }

   public class HostDTO
    {
        public string URL { get; set; }
        public string Host
        {
            get
            {
                return HttpContext.Current.Request.Url.Authority;
            }
        }
    }

}
