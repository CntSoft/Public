using VanChi.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VanChi.FMS.Web.Common;

namespace VanChi.FMS.Web.Common
{
    public partial class Constant
    {
        /// <summary>
        /// AccountInfo
        /// </summary>
        public const string Session_AccountInfo = "AccountInfo";
        /// <summary>
        /// OfficalLetter
        /// </summary>
        public const string Session_OfficalLetter = "OfficalLetter";
        /// <summary>
        /// AuthorizationLetter
        /// </summary>
        public const string Session_AuthorizationLetter = "AuthorizationLetter";

        public const string SESION_LISTROLE_ID_USER = "ListRoleId";

        public const string SESION_LISTFUNCTION_ID_USER = "ListFunctionId";
        public const string SESION_LISTMENUROLE_ID_USER = "ListMenuRoleId";

        public const string SESION_PAYMENTCODE_ID_USER = "PaymentCode";
        public const string SESION_RETURNCONTAINERCODE_ID_USER = "ReturnContainer";

        public static readonly List<Guid> ROLE_ACCESS_DENIED = new List<Guid>
        {
            //new Guid(AppLoginRole.RoleAdminID.ToString()), //SystemAdmin
            //new Guid(AppLoginRole.RoleCustomerID.ToString()) //Customer
        };

        public static string TEXT_NOT_EDITABLE = string.Format(@"<span class='label label-danger'>{0}</span>", ResourceManagement.GetResourceText("SystemResourceID.NotEditable", "Không thể chỉnh sửa", "Not editable"));
    }
}