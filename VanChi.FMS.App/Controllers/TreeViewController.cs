using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.EJ2.Navigations;
using VanChi.FMS.App.Models;

namespace VanChi.FMS.App.Controllers
{
    public class TreeViewController : Controller
    {
        // GET: TreeView
        public ActionResult Index()
        {
            List<object> treedata = new List<object>();
            treedata.Add(new
            {
                id = 5,
                name = "Discover Music",
                hasChild = true,
                expanded = true,
                htmlAttribute = new Dictionary<string, string>() { { "class", "remove rename" } }

            });
            treedata.Add(new
            {
                id = 6,
                pid = 5,
                name = "Hot Singles",

            });
            treedata.Add(new
            {
                id = 7,
                pid = 5,
                name = "Rising Artists"
            });

            treedata.Add(new
            {
                id = 4,
                pid = 5,
                name = "Live Music"
            });
            ViewBag.dataSource = treedata;
            List<object> menuItems = new List<object>();
            menuItems.Add(new
            {
                text = "Add New Item",
            });
            menuItems.Add(new
            {
                text = "Rename Item",
            });
            menuItems.Add(new
            {
                text = "Remove Item",
            });
            ViewBag.menuItems = menuItems;
            return View();
        }
        TreeViewFieldsSettings fields = new TreeViewFieldsSettings();

        public ActionResult DefaultFunctionalities()
        {
            TreeviewModel treevireModel = new TreeviewModel();
            fields.DataSource = treevireModel.getTreeviewModel();
            fields.HasChildren = "HasChild";
            fields.Expanded = "Expanded";
            fields.Id = "Id";
            fields.ParentID = "PId";
            fields.Text = "Name";
            ViewBag.fields = fields;
            return View();
        }
        public ActionResult DragDrop()
        {
            List<object> treedata = new List<object>();
            treedata.Add(new
            {
                id = 1,
                name = "ASP.NET MVC Team",
                hasChild = true,
                expanded = true
            });
            treedata.Add(new
            {
                id = 2,
                pid = 1,
                name = "Smith",
                is_selected = true

            });
            treedata.Add(new
            {
                id = 3,
                pid = 1,
                name = "Johnson",
                is_selected = true
            });

            treedata.Add(new
            {
                id = 4,
                pid = 1,
                name = "Anderson"
            });
            treedata.Add(new
            {
                id = 6,
                hasChild = true,
                name = "Windows Team",

            });
            treedata.Add(new
            {
                id = 7,
                pid = 6,
                name = "Clark"

            });
            treedata.Add(new
            {
                id = 8,
                pid = 6,
                name = "Wright"
            });
            treedata.Add(new
            {
                id = 9,
                pid = 6,
                name = "Lopez"
            });
            treedata.Add(new
            {
                id = 10,
                hasChild = true,
                name = "Web Team"
            });
            treedata.Add(new
            {
                id = 11,
                pid = 10,
                name = "Joshua",

            });
            treedata.Add(new
            {
                id = 12,
                pid = 10,
                name = "Matthew"
            });
            treedata.Add(new
            {
                id = 13,
                pid = 10,
                name = "David"
            });
            treedata.Add(new
            {
                id = 14,
                hasChild = true,
                name = "Build Team"
            });
            treedata.Add(new
            {
                id = 15,
                pid = 14,
                name = "Ryan"

            });
            treedata.Add(new
            {
                id = 16,
                pid = 14,
                name = "Justin",

            });
            treedata.Add(new
            {
                id = 17,
                pid = 14,
                name = "Robert"

            });
            treedata.Add(new
            {
                id = 18,
                hasChild = true,
                name = "WPF Team"

            });
            treedata.Add(new
            {
                id = 19,
                pid = 18,
                name = "Brown"

            });
            treedata.Add(new
            {
                id = 20,
                pid = 18,
                name = "Johnson"
            });
            treedata.Add(new
            {
                id = 21,
                pid = 18,
                name = "Miller"
            });

            ViewBag.dataSource = treedata;
            return View();
        }
        public ActionResult NodeEdit()
        {
            List<object> treedata = new List<object>();
            treedata.Add(new
            {
                id = 1,
                name = "Discover Music",
                hasChild = true,
                expanded = true
            });
            treedata.Add(new
            {
                id = 2,
                pid = 1,
                name = "Hot Singles",

            });
            treedata.Add(new
            {
                id = 3,
                pid = 1,
                name = "Rising Artists"
            });

            treedata.Add(new
            {
                id = 4,
                pid = 1,
                name = "Live Music"
            });
            treedata.Add(new
            {
                id = 5,
                hasChild = true,
                name = "Sales and Events",

            });
            treedata.Add(new
            {
                id = 6,
                pid = 5,
                name = "100 Albums - $5 Each",
            });
            treedata.Add(new
            {
                id = 7,
                pid = 5,
                name = "Hip-Hop and R&B Sale"
            });
            treedata.Add(new
            {
                id = 8,
                pid = 5,
                name = "CD Deals"
            });
            treedata.Add(new
            {
                id = 10,
                hasChild = true,
                name = "Categories"
            });
            treedata.Add(new
            {
                id = 11,
                pid = 10,
                name = "Bestselling Albums",

            });
            treedata.Add(new
            {
                id = 12,
                pid = 10,
                name = "New Releases"
            });
            treedata.Add(new
            {
                id = 13,
                pid = 10,
                name = "Bestselling Songs"
            });
            treedata.Add(new
            {
                id = 14,
                hasChild = true,
                name = "MP3 Albums"
            });
            treedata.Add(new
            {
                id = 15,
                pid = 14,
                name = "Rock"

            });
            treedata.Add(new
            {
                id = 16,
                name = "Gospel",
                pid = 14,

            });
            treedata.Add(new
            {
                id = 17,
                pid = 14,
                name = "Latin Music"

            });
            treedata.Add(new
            {
                id = 18,
                pid = 14,
                name = "Jazz"

            });
            treedata.Add(new
            {
                id = 19,
                hasChild = true,
                name = "More in Music"

            });
            treedata.Add(new
            {
                id = 20,
                pid = 19,
                name = "Music Trade-In"
            });
            treedata.Add(new
            {
                id = 21,
                name = "Redeem a Gift Card",
                pid = 19
            });
            treedata.Add(new
            {
                id = 22,
                pid = 19,
                name = "Band T-Shirts"

            });


            ViewBag.dataSource = treedata;
            return View();
        }
    }
}