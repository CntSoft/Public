using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanChi.FMS.Web.Models
{
    public class JsonModel
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int recordsTotal { get; set; }
        public int pageTotal { get; set; }
        public object data { get; set; }
        public JsonModel(int _pageIndex, int _total, object _data)
        {
            this.pageIndex = _pageIndex;
            this.pageSize = App.PageSize;
            this.recordsTotal = _total;
            this.pageTotal = (_total % this.pageSize == 0) ? _total / this.pageSize : _total / this.pageSize + 1;
            this.data = _data;
        }
        public JsonModel(){}
    }
}