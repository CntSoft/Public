using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VanChi.Business.Interface;
using VanChi.Logs;

namespace VanChi.FMS.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Properties     
        protected IBusiness Business;
        #endregion

        #region Constructors
        public BaseController(IBusiness business)
        {
            this.Business = business;
        }

        #endregion

        #region Events
        protected override void Initialize(RequestContext requestContext)
        {
            try
            {
                base.Initialize(requestContext);
                CultureInfo objCulture = CultureInfo.CreateSpecificCulture("");
                objCulture.DateTimeFormat.ShortDatePattern = "";
                objCulture.NumberFormat.NumberDecimalSeparator = ",";
                objCulture.NumberFormat.NumberGroupSeparator = ".";
                Thread.CurrentThread.CurrentCulture = objCulture;
                Thread.CurrentThread.CurrentUICulture = objCulture;
            }
            catch { }
        }

        #endregion

        #region Methods
        #endregion
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
    }
}