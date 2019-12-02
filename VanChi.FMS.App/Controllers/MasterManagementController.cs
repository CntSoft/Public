using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VanChi.FMS.App.Models;

namespace VanChi.FMS.App.Controllers
{
    public class MasterManagementController : Controller
    {
        // GET: MasterManagement
        public ActionResult Index()
        {
            return View();
        }
        #region Services
        public ActionResult Services()
        {
            var order = OrdersDetails.GetAllRecords();
            ViewBag.datasource = order;
            return View();
        }
        public ActionResult Editpartial(DialogTemplateModel value)
        {
            var order = OrdersDetails.GetAllRecords();
            ViewBag.datasource = order;
            return PartialView("_DialogEditpartial", value);
        }

        public ActionResult AddPartial()
        {
            var order = OrdersDetails.GetAllRecords();
            ViewBag.datasource = order;
            return PartialView("_DialogAddpartial");
        }
        #endregion
    }
}