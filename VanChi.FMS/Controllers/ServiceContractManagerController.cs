using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VanChi.FMS.Controllers
{
    public class ServiceContractManagerController : Controller
    {
        // GET: ServiceContractManager
        public ActionResult Index()
        {
            return View();
        }

        // GET: ServiceContractManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceContractManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceContractManager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceContractManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceContractManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceContractManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceContractManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
