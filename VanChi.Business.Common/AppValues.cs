using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Common
{
    public sealed class AppValues
    {        

        public enum ActiveFag : byte
        {
            StatusActive = 0,
            StatusDeactive = 1,
            StatusDelete = 2
        }

        public enum TokenType : byte
        {
            SMS = 0,
            TOKEN = 1
        }

        public const byte STATUS_ACTIVE = (byte)AppValues.ActiveFag.StatusActive;
    }
}
