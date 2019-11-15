using AutoMapper;
using VanChi.Business.Common;
using VanChi.Business.DTO;
using VanChi.Business.Interface;
using VanChi.Logs;
using VanChi.FMS.Web.Common;
using VanChi.FMS.Web.Models;
using VanChi.Data;
using Spire.Doc;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.HtmlConverter;
using Spire.Presentation;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace VanChi.FMS.Web.Controllers
{
    /// <summary>
    /// Controller cơ sở
    /// </summary>
    //[BaseAuthorize(Roles = AppLoginRole.ALL)]
    public abstract class BaseController : Controller
    {
        #region Properties     

        protected IBusiness Business;

        /// <summary>
        /// Lưu trữ thông tin của người dùng đang đăng nhập
        /// </summary>
        public AccountInfo UserContext
        {
            get { return Session[Constant.Session_AccountInfo] as AccountInfo; }
            set { Session[Constant.Session_AccountInfo] = value; }
        }
        protected const byte STATUS_ACTIVE = (byte)AppValues.ActiveFag.StatusActive;
        protected const byte STATUS_DELETE = (byte)AppValues.ActiveFag.StatusDelete;
        #endregion

        #region Constructors
        public BaseController(IBusiness business)
        {
            this.Business = business;
            #region Language

            string languageCode = (System.Web.HttpContext.Current.Request.Url.Segments != null && System.Web.HttpContext.Current.Request.Url.Segments.Length > 1) ? System.Web.HttpContext.Current.Request.Url.Segments[1].Replace("/", string.Empty) : string.Empty;

            if (!string.IsNullOrEmpty(languageCode))
            {
                switch (languageCode)
                {
                    case Constant.Language_Vietnamese:
                        App.CacheProvider.SetLocalLanguage(AppLanguageCode.Vietnamese);
                        break;
                    case Constant.Language_English:
                        App.CacheProvider.SetLocalLanguage(AppLanguageCode.English);
                        break;
                    case Constant.Language_French:
                        App.CacheProvider.SetLocalLanguage(AppLanguageCode.French);
                        break;
                    case Constant.Language_Japanese:
                        App.CacheProvider.SetLocalLanguage(AppLanguageCode.Japanese);
                        break;
                    case Constant.Language_Chinese:
                        App.CacheProvider.SetLocalLanguage(AppLanguageCode.Chinese);
                        break;
                    case Constant.Language_Russian:
                        App.CacheProvider.SetLocalLanguage(AppLanguageCode.Russian);
                        break;
                    default:
                        break;
                }
            }

            #endregion
        }

        #endregion

        #region Events
        protected override void Initialize(RequestContext requestContext)
        {
            try
            {
                base.Initialize(requestContext);

                //if (UserContext == null && User != null)
                //{
                //    var userInfo = this.Business.Shared_GetItem<UserInfoDTO, UserInfo>(x => x.UserName.ToLower().EndsWith(User.Identity.Name.ToLower()));
                //    if (userInfo != null)
                //    {
                //        UserContext = new AccountInfo(userInfo.UserName, userInfo.FullName);
                //    }
                //}
                //App.DicResources = App.CacheProvider.Get<Dictionary<string, ResourceDTO>>(Constant.Cache_EDO);
                //if (App.DicResources == null)
                //{
                //    App.DicResources = this.Business.Resource_GetAll();
                //    App.CacheProvider.Set(Constant.Cache_EDO, AppCachingAbsoluteExpiration.NoneExpiration, () => App.DicResources);
                //}

                CultureInfo objCulture = CultureInfo.CreateSpecificCulture(App.Culture);
                objCulture.DateTimeFormat.ShortDatePattern = App.DatePattern;
                objCulture.NumberFormat.NumberDecimalSeparator = ",";
                objCulture.NumberFormat.NumberGroupSeparator = ".";
                Thread.CurrentThread.CurrentCulture = objCulture;
                Thread.CurrentThread.CurrentUICulture = objCulture;
            }
            catch { }
        }

        #endregion

        #region Methods
        #region Log File
        protected void InsertToLogFile(Controller controller, Exception ex)
        {
            try
            {
                Type myType = typeof(BaseController);
                string _project = myType.Namespace;
                string _controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                string _actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                Logging.LogError($"{_project}-{_controllerName}-{_actionName}()", ex);
            }
            catch { }

        }

        #endregion



        #endregion
    }
}
