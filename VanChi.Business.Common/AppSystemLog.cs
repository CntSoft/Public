using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Common
{
    /// <summary>
    /// Action
    /// </summary>
    public enum AppAction
    {
        Login = 0,
        Insert = 1,
        Update = 2,
        Delete = 3,
        Import = 4,
        Export = 5,
        OTP = 6,
        Active = 7,
        Check = 8
    }
    /// <summary>
    /// Event Result
    /// </summary>
    public enum AppEventResult
    {
        Fail = 0,
        Success = 1
    }
}
