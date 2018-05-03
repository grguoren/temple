using Temple.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Temple.Admin.Common
{
    public class SystemCountBrandCache
    {
        public const string Type = "/SystemCountBrand/";// /CurrentUser/Guid
        public const int Expires = 360000;//缓存有效期 6个小时 滑动过期
        public const CacheItemPriority Priority = CacheItemPriority.Default; //缓存优先级 Default

        public static void Insert(string type, List<CacheCountBrand> obj)
        {
            CacheDependency cd = null;
            CacheHelper<List<CacheCountBrand>>.Insert(Type + type + "/", obj, cd, Expires, Priority);
        }

        public static void Delete(string type)
        {
            CacheHelper<List<CacheCountBrand>>.Remove(Type + type + "/");
        }

        public static List<CacheCountBrand> Get(string type)
        {
            return CacheHelper<List<CacheCountBrand>>.Get(Type + type + "/");
        }

        public static bool IsExist(string type)
        {
            return CacheHelper<List<CacheCountBrand>>.IsExist(Type + type + "/");
        }
    }
}