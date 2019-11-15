using VanChi.Business.Common;
using VanChi.FMS.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanChi.FMS.Web.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        [ExDisplay(typeof(BaseModel), "CreateBy", "Người tạo", "Create By")]
        public string CreateBy { get; set; }
        [ExDisplay(typeof(BaseModel), "UpdateBy", "Người cập nhật", "Update By")]
        public string UpdateBy { get; set; }
        [ExDisplay(typeof(BaseModel), "Create Date", "Ngày tạo")]
        public DateTime CreateDate { get; set; }
        [ExDisplay(typeof(BaseModel), "Update Date", "Ngày cập nhật")]
        public DateTime UpdateDate { get; set; }
        public AppValues.ActiveFag ActiveFag { get; set; }
        public string ActionType { get; set; }
        public BaseModel()
        {
            this.Id = Guid.Empty;
            this.URL = String.Empty;
            this.Description = String.Empty;
            this.CreateBy = String.Empty;
            this.UpdateBy = String.Empty;
            this.CreateDate = DateTime.Now;
            this.UpdateDate = DateTime.Now;
            this.ActionType = string.Empty;
            this.ActiveFag = (int)AppValues.ActiveFag.StatusActive;
        }
        public string DisplayCreateDate
        {
            get
            {
                if (!string.IsNullOrEmpty(CreateDate.ToString()))
                {
                    return DateTime.Parse(CreateDate.ToString()).ToString(App.DatePattern);
                }
                return string.Empty;
            }
        }

        public string DisplayUpdateDate
        {
            get
            {
                if (!string.IsNullOrEmpty(UpdateDate.ToString()))
                {
                    return DateTime.Parse(UpdateDate.ToString()).ToString(App.DatePattern);
                }
                return string.Empty;
            }
        }
    }
    public class BaseImageModel : BaseModel
    {
        public string ImageURL { get; set; }
        public BaseImageModel()
            : base()
        {
            this.ImageURL = String.Empty;
        }
    }
    public class BaseLangCodeModel : BaseImageModel
    {
        public string LangCode { get; set; }
        public BaseLangCodeModel()
            : base()
        {
            this.LangCode = String.Empty;
        }
    }
    public class DropdownListModel
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public sealed class BaseViewURL
    {
        
        private static string RedirectBaseURL(string folder, string url)
        {
            string baseURL = "~/Views/Template/" + folder + "/" + url + ".cshtml";
            return baseURL;
        }

        public static string BaseSharedURL(string url)
        {
            string baseURL = "~/Views/Shared/" + url + ".cshtml";
            return baseURL;
        }
        #region Password
        public static string PasswodURL(string url)
        {
            string baseURL = RedirectBaseURL("Password", url);
            return baseURL;
        }

        #endregion
    }

   
}