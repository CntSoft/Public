using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VanChi.FMS.Web.Common;

namespace VanChi.FMS.Web.MVC
{
    public static class UserHelper
    {
        public static MvcHtmlString PickUser(this HtmlHelper helper, string elementId, string users, string type = "single")
        {
            // This will use for multiple generate recaptcha
            StringBuilder builderTemp = new StringBuilder();
            users = !string.IsNullOrEmpty(users) ? users : string.Empty;
            string m_ApplicationPath = HttpContext.Current.Request.ApplicationPath + '/';
            m_ApplicationPath = m_ApplicationPath.Replace("//", "/");
            string urlUserInfoGetByUserName = Constant.Controller_SystemManagement + "/" + Constant.Action_UserInfo_GetByUserName;
            string pickuser = string.Format("<span class='checkUser'><img class='imgUserChecker' src='{0}Content/Images/pickuser.png' elementId='{1}' onclick=\"lacviet_services.checkPickUser(this, '{0}{2}', '{3}')\"/></span>", m_ApplicationPath, elementId, urlUserInfoGetByUserName, type);
            // Generate div container
            builderTemp.AppendFormat(@"<div class='chosen-container chosen-container-multi' style='width: 300px;' title=''>
                                <div class='input-group'>
                                            <ul class='chosen-choices' id=userSelect{0}>
                                                <li class='search-field'>
                                                    <input type='text' autocomplete='off' id='userInput{0}' value='{1}' elementId='{0}'>
                                                </li>
                                            </ul>
                                            <input type='hidden' value='' id='{0}' name='{0}' />
                                            {2}
                                        </div>
                                        </div>", elementId, users, pickuser);

            return new MvcHtmlString(builderTemp.ToString());
        }
        public static MvcHtmlString PickGroup(this HtmlHelper helper, string elementId, string groups)
        {
            // This will use for multiple generate recaptcha
            StringBuilder builderTemp = new StringBuilder();
            groups = !string.IsNullOrEmpty(groups) ? groups : string.Empty;
            string m_ApplicationPath = HttpContext.Current.Request.ApplicationPath + '/';
            m_ApplicationPath = m_ApplicationPath.Replace("//", "/");
            string pickuser = string.Format("<span class='checkUser'><img class='imgUserChecker' src='{0}Content/Images/pickuser.png' elementId='{1}' onclick='checkGroup(this)'/></span>", m_ApplicationPath, elementId);
            // Generate div container
            builderTemp.AppendFormat(@"<div class='chosen-container chosen-container-multi' style='width: 396px;' title=''>
                                            <ul class='chosen-choices' id=userSelect{0}>
                                                <li class='search-field'>
                                                    <input type='text' autocomplete='off' id='userInput{0}' value='{1}'>
                                                </li>
                                            </ul>
                                            {2}
                                            <input type='hidden' value='' id='{0}' name='{0}' />
                                        </div>", elementId, groups, pickuser);

            return new MvcHtmlString(builderTemp.ToString());
        }
        public static MvcHtmlString PickPrinciple(this HtmlHelper helper, string elementId, string groups)
        {
            // This will use for multiple generate recaptcha
            StringBuilder builderTemp = new StringBuilder();
            groups = !string.IsNullOrEmpty(groups) ? groups : string.Empty;
            string m_ApplicationPath = HttpContext.Current.Request.ApplicationPath + '/';
            m_ApplicationPath = m_ApplicationPath.Replace("//", "/");
            string pickuser = string.Format("<span class='checkUser'><img class='imgUserChecker' src='{0}Content/Images/pickuser.png' elementId='{1}' onclick='checkPrinciple(this)'/></span>", m_ApplicationPath, elementId);
            // Generate div container
            builderTemp.AppendFormat(@"<div class='chosen-container chosen-container-multi' style='width: 396px;' title=''>
                                            <ul class='chosen-choices' id=userSelect{0}>
                                                <li class='search-field'>
                                                    <input type='text' autocomplete='off' id='userInput{0}' value='{1}'>
                                                </li>
                                            </ul>
                                            {2}
                                            <input type='hidden' value='' id='{0}' name='{0}' />
                                        </div>", elementId, groups, pickuser);

            return new MvcHtmlString(builderTemp.ToString());
        }
    }
}