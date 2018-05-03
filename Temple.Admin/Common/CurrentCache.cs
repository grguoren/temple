using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using Temple.Admin.Models.LoginMember;

namespace Temple.Admin.Common
{
    /// <summary>
    /// 当前用户缓存类
    /// </summary>
    public class CurrentCache
    {
        public const string Type = "/Current/";// /CurrentUser/Guid
        public const int Expires = 360000;//缓存有效期 6个小时 滑动过期
        public const CacheItemPriority Priority = CacheItemPriority.Default; //缓存优先级 Default

        public static void Insert(int id, CurrentModel obj)
        {
            CacheDependency cd = null;
            CacheHelper<CurrentModel>.Insert(Type + id, obj, cd, Expires, Priority);
        }

        public static void Delete(int id)
        {
            CacheHelper<CurrentModel>.Remove(Type + id);
        }

        public static CurrentModel Get(int id)
        {
            return CacheHelper<CurrentModel>.Get(Type + id);
        }

        public static bool IsExist(int id)
        {
            return CacheHelper<CurrentModel>.IsExist(Type + id);
        }

        //public static void Delete(long id)
        //{
        //    CacheHelper<CurrentModel>.RemoveByStartKey(Type + id);
        //}
    }
}