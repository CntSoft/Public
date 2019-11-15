using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Common
{
    /// <summary>
    /// User
    /// </summary>
    public enum AppUserRole
    {
        SystemAdmin = 0,
        MSC_Counter = 1,
        MSC_CollectionTeam = 2,
        MSC_ImportTeam = 3,
        MSC_LogTeam = 4,
        Terminal = 5,
        ICD = 6,
        Customer = 7,
        Temporary = 8,
        Anonymous = 9,
        Notify=10
    }

    public sealed class AppLoginRole
    {
        /// <summary>
        /// SystemAdmin,MSC_Counter,MSC_CollectionTeam,MSC_ImportTeam,MSC_LogTeam,Terminal,ICD,Customer
        /// </summary>
        public const string ALL = "SystemAdmin,MSC_Counter,MSC_CollectionTeam,MSC_ImportTeam,MSC_LogTeam,Terminal,ICD,Customer";
        /// <summary>
        /// Temporary
        /// </summary>
        public const string TEMPORARY = "Temporary";

        public readonly static Guid RoleCustomerID = new Guid("11111111-1111-1111-1111-111111111110");
        public readonly static Guid RoleAdminID = new Guid("11111111-1111-1111-1111-111111111111");
    }
}
