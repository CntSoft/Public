using VanChi.Business.Common;
using System;
using System.Runtime.Caching;

namespace VanChi.FMS.Web.Common
{
    public class CacheService : ICacheService
    {
        public void Set<T>(string cacheKey, DateTimeOffset absoluteExpiration, Func<T> getItemCallback) where T : class
        {
            T item = getItemCallback();
            if (item != null)
            {
                if (MemoryCache.Default.Contains(cacheKey))
                {
                    MemoryCache.Default.Set(cacheKey, item, absoluteExpiration);
                }
                else
                {
                    MemoryCache.Default.Add(cacheKey, item, absoluteExpiration);
                }
            }
        }
        public T Get<T>(string cacheKey) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            return item;
        }
        public bool Remove(string cacheKey)
        {
            try
            {
                MemoryCache.Default.Remove(cacheKey);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SetLocalLanguage(AppLanguageCode languageCode)
        {
            string key = Constant.Cache_LocalLanguage;
            if (MemoryCache.Default.Contains(key))
            {
                MemoryCache.Default.Set(key, languageCode, AppCachingAbsoluteExpiration.NoneExpiration);
            }
            else
            {
                MemoryCache.Default.Add(key, languageCode, AppCachingAbsoluteExpiration.NoneExpiration);
            }
            return true;
        }
        public AppLanguageCode GetLocalLanguage()
        {
            try
            {
                string key = Constant.Cache_LocalLanguage;
                object item = MemoryCache.Default.Get(key);
                if (item == null) return AppLanguageCode.English;
                else return (AppLanguageCode)item;
            }
            catch
            {
                return AppLanguageCode.English;
            }
        }
    }
    interface ICacheService
    {
        void Set<T>(string cacheKey, DateTimeOffset absoluteExpiration, Func<T> getItemCallback) where T : class;
        T Get<T>(string cacheKey) where T : class;
    }
}