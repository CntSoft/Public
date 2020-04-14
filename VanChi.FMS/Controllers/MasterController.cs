﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VanChi.FMS.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        // GET: Master/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Master/Create
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

        // GET: Master/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Master/Edit/5
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

        // GET: Master/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Master/Delete/5
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
        #region Service contract manager
        public ActionResult ServiceContractManager()
        {
            return View();
        }
        public ActionResult AddSupplier()
        {
            return PartialView("_AddSupplier");
        }
        #endregion
    }
}
