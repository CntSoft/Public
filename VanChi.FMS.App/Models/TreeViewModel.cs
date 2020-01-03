﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanChi.FMS.App.Models
{
    public class TreeviewModel
    {
        public string Id { get; set; }
        public string PId { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
        public bool Count { get; set; }

        public List<TreeviewModel> getTreeviewModel()
        {
            List<TreeviewModel> localData1 = new List<TreeviewModel>();
            localData1.Add(new TreeviewModel { Id = "t1", Name = "ASP.NET MVC Team", HasChild = true, Expanded = true });
            localData1.Add(new TreeviewModel { Id = "t2", PId = "t1", Name = "Smith" });
            localData1.Add(new TreeviewModel { Id = "t3", PId = "t1", Name = "Johnson", Selected = true });
            localData1.Add(new TreeviewModel { Id = "t4", PId = "t1", Name = "Anderson" });
            localData1.Add(new TreeviewModel { Id = "t5", HasChild = true, Name = "Windows Team", Expanded = true });
            localData1.Add(new TreeviewModel { Id = "t6", PId = "t5", Name = "Clark" });
            localData1.Add(new TreeviewModel { Id = "t7", PId = "t5", Name = "Wright" });
            localData1.Add(new TreeviewModel { Id = "t8", PId = "t5", Name = "Lopez" });
            return localData1;
        }
    }
}