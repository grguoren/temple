using Temple.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Temple.Admin.Common
{
    public class CityCache
    {
        public const string Type = "/City/";// /CurrentUser/Guid
        public const int Expires = 360000;//缓存有效期 6个小时 滑动过期
        public const CacheItemPriority Priority = CacheItemPriority.Default; //缓存优先级 Default

        //public static void Insert(string type,int id, List<City> obj)
        //{
        //    CacheDependency cd = null;
        //    CacheHelper<List<City>>.Insert(Type + type + "/" + id, obj, cd, Expires, Priority);
        //}

        //public static void Delete(string type, int id)
        //{
        //    CacheHelper<List<City>>.Remove(Type + type + "/" + id);
        //}

        //public static List<City> Get(string type, int id)
        //{
        //    return CacheHelper<List<City>>.Get(Type + type + "/" + id);
        //}

        //public static bool IsExist(string type, int id)
        //{
        //    return CacheHelper<List<City>>.IsExist(Type + type + "/" + id);
        //}
    }
}