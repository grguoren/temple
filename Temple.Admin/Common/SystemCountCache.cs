using Temple.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Temple.Admin.Common
{
    public class SystemCountCache
    {
        public const string Type = "/SystemCount/";// /CurrentUser/Guid
        public const int Expires = 360000;//缓存有效期 6个小时 滑动过期
        public const CacheItemPriority Priority = CacheItemPriority.Default; //缓存优先级 Default

        public static void Insert(string type, CacheCount obj)
        {
            CacheDependency cd = null;
            CacheHelper<CacheCount>.Insert(Type + type + "/", obj, cd, Expires, Priority);
        }

        public static void Delete(string type)
        {
            CacheHelper<CacheCount>.Remove(Type + type + "/");
        }

        public static CacheCount Get(string type)
        {
            return CacheHelper<CacheCount>.Get(Type + type + "/");
        }

        public static bool IsExist(string type)
        {
            return CacheHelper<CacheCount>.IsExist(Type + type + "/");
        }
    }
}