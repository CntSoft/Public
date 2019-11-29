using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Syncfusion.EJ2.Popups;
namespace VanChi.FMS.App.Controllers
{
    public partial class DialogController : Controller
    {
        public ActionResult DialogFeatures()
        {
            List<DialogDialogButton> buttons = new List<DialogDialogButton>() { };
            buttons.Add(new DialogDialogButton() { Click = "dlgButtonClick", ButtonModel = new DefaultButtonModel() { content = "LEARN ABOUT SYNCFUSION, INC.", isPrimary = true } });
            ViewBag.DefaultButtons = buttons;
            return View();
        }
		public class DefaultButtonModel
        {
            public string content { get; set; }
            public bool isPrimary { get; set; }
        }
    }
}
