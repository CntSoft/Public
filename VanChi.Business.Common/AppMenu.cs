using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Common
{
    public sealed class AppMenu
    {
        public enum MenuStatus : byte
        {
            None = 0,
            IsMenu = 1,
            IsCustomer = 2,
            IsMenuOrPublic = 3,
            IsPublic = 4
        }
    }
}
