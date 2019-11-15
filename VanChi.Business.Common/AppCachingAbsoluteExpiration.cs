using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Common
{
    /// <summary>
    /// Caching Absolute Expiration
    /// </summary>
    public class AppCachingAbsoluteExpiration
    {
        /// <summary>
        /// Default 1 day
        /// </summary>
        public static DateTimeOffset Default = DateTime.Now.AddDays(1);
        /// <summary>
        /// None Expiration
        /// </summary>
        public static DateTimeOffset NoneExpiration = DateTimeOffset.MaxValue;
    }
}
