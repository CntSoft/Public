using VanChi.Business.Common;
using VanChi.Logs;
using VanChi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VanChi.Business.Concrete.ObjectBusiness
{
    public class BaseObjectBusiness
    {
        #region Variables
        protected IUnitOfWork UnitOfWork;
        protected const byte STATUS_ACTIVE = (byte)AppValues.ActiveFag.StatusActive;
        protected const byte STATUS_DELETE = (byte)AppValues.ActiveFag.StatusDelete;
        #endregion

        #region Constructors
        public BaseObjectBusiness(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        #endregion

        #region Method
        protected void InsertToLogFile(string method, Exception ex)
        {
            try
            {
                //Type servicess = typeof(T);  
                var services = this.GetType();
                string _service = services.FullName;
                Logging.LogError($"{_service}-{method}()", ex);
            }
            catch { }

        }
        #endregion
        public string ToUnsignString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            input = input.ToLower().Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            input = input.Replace(".", "-");
            input = input.Replace(".", "-");
            input = input.Replace(" ", "-");
            input = input.Replace(";", "-");
            input = input.Replace(":", "-");
            input = input.Replace("  ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(System.Text.NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            while (str2.Contains("--"))
            {
                str2 = str2.Replace("--", "-").ToLower();
            }
            return str2;
        }

    }
}
