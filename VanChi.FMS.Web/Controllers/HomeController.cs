using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VanChi.FMS.Web.Controllers
{
    public class TextBoxModal
    {
        [Required(ErrorMessage = "Value is required")]
        public string firstname { get; set; }
    }
    public class HomeController : Controller
    {
        TextBoxModal textbox = new TextBoxModal();
        // GET: TextboxFor
        public ActionResult TextboxFor()
        {
            textbox.firstname = "John";
            return View(textbox);
        }
        [HttpPost]
        public ActionResult TextboxFor(TextBoxModal model)
        {
            //posted value is obtained from the model
            textbox.firstname = model.firstname;
            return View(textbox);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}