/*
 * Created: ntChien
 * Date: 27/10/2017
 * Description: http://www.codeproject.com/Articles/786332/ASP-NET-MVC-with-Unity-Dependency-Injection
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanChi.Common
{
    public enum CacheTimes
    {
        OneMinute = 1,
        OneHour = 60,
        TwoHours = 120,
        SixHours = 360,
        TwelveHours = 720,
        OneDay = 1440
    }
    public enum GenericMessages
    {
        warning,
        danger,
        success,
        info
    }
    public enum NumberFormat
    {
        Auto,
        Number,
        Currency,
        CurrencyIllusion,
        CurrencyABS
    }
}