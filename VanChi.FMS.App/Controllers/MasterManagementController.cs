using Syncfusion.EJ2.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Http;
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
            return View();
        }
        public ActionResult UrlAdaptor()
        {
            return View();
        }
        public ActionResult ServicesDatasource(DataManagerRequest dm)
        {
            IEnumerable DataSource = Orders.GetAllRecords();
            DataOperations operation = new DataOperations();
            List<string> str = new List<string>();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<Orders>().Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);         //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
            //return View();
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
        public ActionResult Insert([FromBody]CRUDModel<Orders> value)
        {
           
            return Json(value.Value);
        }
        public ActionResult Update(ExpandoObject value)
        {
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public void Remove([FromBody]CRUDModel<Orders> Value)
        {
            
        }
        #endregion
    }
}