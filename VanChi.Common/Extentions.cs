using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;

namespace VanChi.Common
{
    public static class Extensions
    {
        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> list, Func<T, TKey> lookup) where TKey : struct
        {
            return list.Distinct(new StructEqualityComparer<T, TKey>(lookup));
        }
        //     <nav>
        //   <ul class="pagination">
        //     <li class="disabled"><a href="#" aria-label="Previous"><span aria-hidden="true">«</span></a></li>
        //     <li class="active"><a href="#">1 <span class="sr-only">(current)</span></a></li>
        //     <li><a href="#">2</a></li>
        //     <li><a href="#">3</a></li>
        //     <li><a href="#">4</a></li>
        //     <li><a href="#">5</a></li>
        //     <li><a href="#" aria-label="Next"><span aria-hidden="true">»</span></a></li>
        //  </ul>
        //</nav>

        public static MvcHtmlString PagerGET(this HtmlHelper helper, int currentPage, int pageSize, int totalItemCount, object routeValues,int groupSize, string actionOveride = null, string controllerOveride = null)
        {
            // how many pages to display in each page group const  	
            var cGroupSize = groupSize;
            var pageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);

            if (pageCount <= 0)
            {
                return null;
            }

            // cleanup any out bounds page number passed  	
            currentPage = Math.Max(currentPage, 1);
            currentPage = Math.Min(currentPage, pageCount);

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var containerdiv = new TagBuilder("nav");
            var container = new TagBuilder("ul");
            container.AddCssClass("pagination");
            var actionName = !string.IsNullOrEmpty(actionOveride) ? actionOveride : helper.ViewContext.RouteData.GetRequiredString("action");
            var controllerName = !string.IsNullOrEmpty(controllerOveride) ? controllerOveride : helper.ViewContext.RouteData.GetRequiredString("controller");

            // calculate the last page group number starting from the current page  	
            // until we hit the next whole divisible number  	
            var lastGroupNumber = currentPage;
            while ((lastGroupNumber % cGroupSize != 0)) lastGroupNumber++;

            // correct if we went over the number of pages  	
            var groupEnd = Math.Min(lastGroupNumber, pageCount);

            // work out the first page group number, we use the lastGroupNumber instead of  	
            // groupEnd so that we don't include numbers from the previous group if we went  	
            // over the page count  	
            var groupStart = lastGroupNumber - (cGroupSize - 1);

            // if we are past the first page  	
            if (currentPage > 1)
            {
                var previousli = new TagBuilder("li");
                var previous = new TagBuilder("a");
                previous.SetInnerText("«");
                previous.AddCssClass("previous");
                var routingValues = new RouteValueDictionary(routeValues) { { "p", currentPage - 1 } };
                previous.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routingValues));
                previousli.InnerHtml = previous.ToString();
                container.InnerHtml += previousli;
            }

            // if we have past the first page group  	
            if (currentPage > cGroupSize)
            {
                var previousDotsli = new TagBuilder("li");
                var previousDots = new TagBuilder("a");
                previousDots.SetInnerText("...");
                previousDots.AddCssClass("previous-dots");
                var routingValues = new RouteValueDictionary(routeValues) { { "p", groupStart - cGroupSize } };
                previousDots.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routingValues));
                previousDotsli.InnerHtml = previousDots.ToString();
                container.InnerHtml += previousDotsli.ToString();
            }

            for (var i = groupStart; i <= groupEnd; i++)
            {
                var pageNumberli = new TagBuilder("li");
                pageNumberli.AddCssClass(((i == currentPage)) ? "active" : "p");
                var pageNumber = new TagBuilder("a");
                pageNumber.SetInnerText((i).ToString());
                var routingValues = new RouteValueDictionary(routeValues) { { "p", i } };
                pageNumber.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routingValues));
                pageNumberli.InnerHtml = pageNumber.ToString();
                container.InnerHtml += pageNumberli.ToString();
            }

            // if there are still pages past the end of this page group  	
            if (pageCount > groupEnd)
            {
                var nextDotsli = new TagBuilder("li");
                var nextDots = new TagBuilder("a");
                nextDots.SetInnerText("...");
                nextDots.AddCssClass("next-dots");
                var routingValues = new RouteValueDictionary(routeValues) { { "p", groupEnd + 1 } };
                nextDots.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routingValues));
                nextDotsli.InnerHtml = nextDots.ToString();
                container.InnerHtml += nextDotsli.ToString();
            }

            // if we still have pages left to show  	
            if (currentPage < pageCount)
            {
                var nextli = new TagBuilder("li");
                var next = new TagBuilder("a");
                next.SetInnerText("»");
                next.AddCssClass("next");
                var routingValues = new RouteValueDictionary(routeValues) { { "p", currentPage + 1 } };
                next.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routingValues));
                nextli.InnerHtml = next.ToString();
                container.InnerHtml += nextli.ToString();
            }
            containerdiv.InnerHtml = container.ToString();
            return MvcHtmlString.Create(containerdiv.ToString());
        }
        public static MvcHtmlString PagerPOST(this HtmlHelper helper, int currentPage, int pageSize, int totalItemCount, object routeValues,int groupSize, string actionOveride = null, string controllerOveride = null)
        {
            // how many pages to display in each page group const  	
            var cGroupSize = groupSize;
            var pageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);

            if (pageCount <= 0)
            {
                return null;
            }

            // cleanup any out bounds page number passed  	
            currentPage = Math.Max(currentPage, 1);
            currentPage = Math.Min(currentPage, pageCount);

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var containerdiv = new TagBuilder("nav");
            var container = new TagBuilder("ul");
            container.AddCssClass("pagination");
            var actionName = !string.IsNullOrEmpty(actionOveride) ? actionOveride : helper.ViewContext.RouteData.GetRequiredString("action");
            var controllerName = !string.IsNullOrEmpty(controllerOveride) ? controllerOveride : helper.ViewContext.RouteData.GetRequiredString("controller");

            // calculate the last page group number starting from the current page  	
            // until we hit the next whole divisible number  	
            var lastGroupNumber = currentPage;
            while ((lastGroupNumber % cGroupSize != 0)) lastGroupNumber++;

            // correct if we went over the number of pages  	
            var groupEnd = Math.Min(lastGroupNumber, pageCount);

            // work out the first page group number, we use the lastGroupNumber instead of  	
            // groupEnd so that we don't include numbers from the previous group if we went  	
            // over the page count  	
            var groupStart = lastGroupNumber - (cGroupSize - 1);

            // if we are past the first page  	
            if (currentPage > 1)
            {
                var previousli = new TagBuilder("li");
                var previous = new TagBuilder("a");
                previous.SetInnerText("«");
                previous.AddCssClass("previous");
                var routingValues = new RouteValueDictionary(routeValues) { { "p", currentPage - 1 } };

                //previous.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routingValues));

                previous.MergeAttribute("href", "#");
                previousli.MergeAttribute("onclick", "SearchData" + controllerName + "(" + (currentPage - 1)+ ")");
                previousli.InnerHtml = previous.ToString();
                container.InnerHtml += previousli;
            }

            // if we have past the first page group  	
            if (currentPage > cGroupSize)
            {
                var previousDotsli = new TagBuilder("li");
                var previousDots = new TagBuilder("a");
                previousDots.SetInnerText("...");
                previousDots.AddCssClass("previous-dots");
                var routingValues = new RouteValueDictionary(routeValues) { { "p", groupStart - cGroupSize } };
                previousDots.MergeAttribute("href", "#");
                previousDots.MergeAttribute("onclick", "SearchData"+ controllerName+"("+(groupStart - cGroupSize) + ")");
                previousDotsli.InnerHtml = previousDots.ToString();
                container.InnerHtml += previousDotsli.ToString();
            }

            for (var i = groupStart; i <= groupEnd; i++)
            {
                var pageNumberli = new TagBuilder("li");
                pageNumberli.AddCssClass(((i == currentPage)) ? "active" : "p");
                var pageNumber = new TagBuilder("a");
                pageNumber.SetInnerText((i).ToString());
                var routingValues = new RouteValueDictionary(routeValues) { { "p", i } };
                pageNumber.MergeAttribute("href", "#");
                pageNumber.MergeAttribute("onclick", "SearchData" + controllerName + "(" + i + ")");
                pageNumberli.InnerHtml = pageNumber.ToString();
                container.InnerHtml += pageNumberli.ToString();
            }

            // if there are still pages past the end of this page group  	
            if (pageCount > groupEnd)
            {
                var nextDotsli = new TagBuilder("li");
                var nextDots = new TagBuilder("a");
                nextDots.SetInnerText("...");
                nextDots.AddCssClass("next-dots");
                var routingValues = new RouteValueDictionary(routeValues) { { "p", groupEnd + 1 } };
                //nextDots.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routingValues));
                nextDots.MergeAttribute("href","#");
                nextDots.MergeAttribute("onclick", "SearchData" + controllerName + "(" + (groupEnd + 1) + ")");
                nextDotsli.InnerHtml = nextDots.ToString();
                container.InnerHtml += nextDotsli.ToString();
            }

            // if we still have pages left to show  	
            if (currentPage < pageCount)
            {
                var nextli = new TagBuilder("li");
                var next = new TagBuilder("a");
                next.SetInnerText("»");
                next.AddCssClass("next");
                var routingValues = new RouteValueDictionary(routeValues) { { "p", currentPage + 1 } };
                next.MergeAttribute("onclick", "SearchData" + controllerName + "(" + (currentPage + 1) + ")");
                next.MergeAttribute("href", "#");
                //next.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routingValues));
                nextli.InnerHtml = next.ToString();
                container.InnerHtml += nextli.ToString();
            }
            containerdiv.InnerHtml = container.ToString();
            return MvcHtmlString.Create(containerdiv.ToString());
        }
        public static MvcHtmlString RenderBootstrapTabContent(this HtmlHelper helper, string currentTabName,
            HelperResult content, bool isDefaultTab = false, string tabNameToSelect = "")
        {
            if (helper == null)
                throw new ArgumentNullException("helper");

            if (string.IsNullOrEmpty(tabNameToSelect))
                tabNameToSelect = helper.GetSelectedTabName();

            if (string.IsNullOrEmpty(tabNameToSelect) && isDefaultTab)
                tabNameToSelect = currentTabName;

            var tag = new TagBuilder("div")
            {
                InnerHtml = content.ToHtmlString(),
                Attributes =
                {
                    new KeyValuePair<string, string>("class", string.Format("tab-pane{0}", tabNameToSelect == currentTabName ? " active" : "")),
                    new KeyValuePair<string, string>("id", string.Format("{0}", currentTabName))
                }
            };

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
        public static MvcHtmlString RenderBootstrapTabHeader(this HtmlHelper helper, string currentTabName,
            string title, bool isDefaultTab = false, string tabNameToSelect = "", string customCssClass = "")
        {
            if (helper == null)
                throw new ArgumentNullException("helper");

            if (string.IsNullOrEmpty(tabNameToSelect))
                tabNameToSelect = helper.GetSelectedTabName();

            if (string.IsNullOrEmpty(tabNameToSelect) && isDefaultTab)
                tabNameToSelect = currentTabName;

            var a = new TagBuilder("a")
            {
                Attributes =
                {
                    new KeyValuePair<string, string>("data-tab-name", currentTabName),
                    new KeyValuePair<string, string>("href", string.Format("#{0}", currentTabName)),
                    new KeyValuePair<string, string>("data-toggle", "tab"),
                },
                InnerHtml = title
            };
            var liClassValue = "";
            if (tabNameToSelect == currentTabName)
            {
                liClassValue = "active";
            }
            if (!String.IsNullOrEmpty(customCssClass))
            {
                if (!String.IsNullOrEmpty(liClassValue))
                    liClassValue += " ";
                liClassValue += customCssClass;
            }

            var li = new TagBuilder("li")
            {
                Attributes =
                {
                    new KeyValuePair<string, string>("class", liClassValue),
                },
                InnerHtml = a.ToString(TagRenderMode.Normal)
            };

            return MvcHtmlString.Create(li.ToString(TagRenderMode.Normal));
        }
        public static string GetSelectedTabName(this HtmlHelper helper)
        {
            //keep this method synchornized with
            //"SaveSelectedTab" method of \Administration\Controllers\BaseAdminController.cs
            var tabName = string.Empty;
            const string dataKey = "abs.selected-tab-name";

            if (helper.ViewData.ContainsKey(dataKey))
                tabName = helper.ViewData[dataKey].ToString();

            if (helper.ViewContext.Controller.TempData.ContainsKey(dataKey))
                tabName = helper.ViewContext.Controller.TempData[dataKey].ToString();

            return tabName;
        }
        public static MvcHtmlString DateTimeDefault(this HtmlHelper helper, MvcHtmlString name, object htmlAttributes)
        {
             //< div class="input-prepend input-group">
             //                       <span class="add-on input-group-addon">
             //                           <i class="glyph-icon icon-calendar"></i>
             //                       </span>
             //                       <input type = "text" class="bootstrap-datepicker form-control" value="02/16/12" data-date-format="mm/dd/yy">
             //                   </div>

            //Creating input control using TagBuilder class.
            TagBuilder datetime = new TagBuilder("input");
            datetime.Attributes.Add("type", "text");
            //Merging the other attributes passed in the attribute.
            datetime.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            //Creating span1 control using TagBuilder class.
            TagBuilder span2 = new TagBuilder("span");
            span2.Attributes.Add("class", "glyphicon glyphicon-calendar");
            TagBuilder span = new TagBuilder("span");
            span.Attributes.Add("class", "input-group-addon");
            //
            //Creating span2 control using TagBuilder class.

            span.InnerHtml += span2;
            //

            //Creating div control using TagBuilder class.
            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("input-group date");
            div.Attributes.Add("id", name.ToHtmlString());

            div.InnerHtml = datetime.ToString();
            div.InnerHtml += span.ToString();
            div.InnerHtml += div.ToString(TagRenderMode.SelfClosing);
            MvcHtmlString t = MvcHtmlString.Create(div.ToString(TagRenderMode.Normal));
            return t;
        }
    }
    class StructEqualityComparer<T, TKey> : IEqualityComparer<T> where TKey : struct
    {

        Func<T, TKey> lookup;

        public StructEqualityComparer(Func<T, TKey> lookup)
        {
            this.lookup = lookup;
        }

        public bool Equals(T x, T y)
        {
            return lookup(x).Equals(lookup(y));
        }

        public int GetHashCode(T obj)
        {
            return lookup(obj).GetHashCode();
        }
    }
}