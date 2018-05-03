using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Caching;

namespace Temple.Admin.Common
{
    /// <summary>
    /// 缓存操作基类
    /// </summary>
    public class CacheHelper<T>
    {
        private static readonly System.Web.Caching.Cache _cache = HttpRuntime.Cache; //缓存实例

        /// <summary>
        /// 构造方法
        /// </summary>
        public CacheHelper()
        {

        }

        /// <summary>
        /// 创建/修改Cache - 永不过期 同时优先级设置为最高,但缓存依赖发生改变的时候,会自动移除
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <param name="value">Cacha值</param>
        /// <param name="dependencies">缓存依赖/依赖发生改变的时候,会自动移除</param>
        public static void Insert(string key, object value, CacheDependency dependencies)
        {
            DateTime dt = DateTime.MaxValue;//永不过期的时间
            _cache.Insert(key, value, dependencies, dt, Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, null);
        }

        /// <summary>
        /// 创建/修改Cache - 永不过期 同时优先级设置为最高,但缓存依赖发生改变的时候,会自动移除
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <param name="value">Cacha值</param>
        /// <param name="dependencies">缓存依赖/依赖发生改变的时候,会自动移除</param>
        /// <param name="removeCallback">缓存删除前的回调方法,可用作通知</param>
        public static void Insert(string key, object value, CacheDependency dependencies, CacheItemRemovedCallback removeCallback)
        {
            DateTime dt = DateTime.MaxValue;//永不过期的时间
            _cache.Insert(key, value, dependencies, dt, Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, removeCallback);
        }

        /// <summary>
        /// 创建/修改Cache -  绝对过期
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <param name="value">Cacha值</param>
        /// <param name="dependencies">缓存依赖/依赖发生改变的时候,会自动移除</param>
        /// <param name="expiresTime">过期时间</param>
        /// <param name="priority">优先级</param>
        public static void Insert(string key, object value, CacheDependency dependencies, DateTime expiresTime, CacheItemPriority priority)
        {
            _cache.Insert(key, value, dependencies, expiresTime, Cache.NoSlidingExpiration, priority, null);
        }

        /// <summary>
        /// 创建/修改Cache -  绝对过期
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <param name="value">Cacha值</param>
        /// <param name="dependencies">缓存依赖/依赖发生改变的时候,会自动移除</param>
        /// <param name="expiresTime">过期时间</param>
        /// <param name="priority">优先级</param>
        /// <param name="removeCallback">缓存删除前的回调方法,可用作通知</param>
        public static void Insert(string key, object value, CacheDependency dependencies, DateTime expiresTime, CacheItemPriority priority, CacheItemRemovedCallback removeCallback)
        {
            _cache.Insert(key, value, dependencies, expiresTime, Cache.NoSlidingExpiration, priority, removeCallback);
        }

        /// <summary>
        /// 创建/修改Cache - 滑动过期
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <param name="value">Cacha值</param>
        /// <param name="dependencies">缓存依赖/依赖发生改变的时候,会自动移除</param>
        /// <param name="expiresSeconds">过期秒数</param>
        /// <param name="priority">优先级</param>
        public static void Insert(string key, object value, CacheDependency dependencies, int expiresSeconds, CacheItemPriority priority)
        {
            TimeSpan ts = TimeSpan.FromSeconds(expiresSeconds);
            _cache.Insert(key, value, dependencies, Cache.NoAbsoluteExpiration, ts, priority, null);
        }

        /// <summary>
        /// 创建/修改Cache - 滑动过期
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <param name="value">Cacha值</param>
        /// <param name="dependencies">缓存依赖/依赖发生改变的时候,会自动移除</param>
        /// <param name="expiresSeconds">过期秒数</param>
        /// <param name="priority">优先级</param>
        /// <param name="removeCallback">缓存删除前的回调方法,可用作通知</param>
        public static void Insert(string key, object value, CacheDependency dependencies, int expiresSeconds, CacheItemPriority priority, CacheItemRemovedCallback removeCallback)
        {
            TimeSpan ts = TimeSpan.FromSeconds(expiresSeconds);
            _cache.Insert(key, value, dependencies, Cache.NoAbsoluteExpiration, ts, priority, removeCallback);
        }

        /// <summary>
        /// 根据Cache键移除缓存对象
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <returns></returns>
        public static bool Remove(string key)
        {
            if (IsExist(key))
            {
                _cache.Remove(key);
                return true;
            }
            return false; //不存在 ? 或者失败
        }

        /// <summary>
        /// 根据Cache键获得缓存对象的Cache值
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <returns></returns>
        public static T Get(string key)
        {
            if (IsExist(key))
            {
                return (T)_cache[key];
            }
            return default(T);
        }

        public static T Get(string key, Func<T> getData, DateTime expiresTime)
        {
            T val = Get(key);
            if (val == null)
            {
                val = getData();
                if (val != null)
                {
                    Insert(key, val, null, expiresTime, CacheItemPriority.Default);
                }
            }
            return val;
        }

        /// <summary>
        /// 根据Cache键判断是否存在该缓存对象
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <returns>是否存在</returns>
        public static bool IsExist(string key)
        {
            if (_cache[key] != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取当前缓存的类型
        /// </summary>
        /// <param name="key">Cache键</param>
        /// <returns></returns>
        public static Type GetType(string key)
        {
            if (IsExist(key))
            {
                return _cache[key].GetType();
            }
            return default(Type);
        }

        /// <summary>
        /// 获得所有的缓存对象集合
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetList()
        {
            Dictionary<string, string> list = null;
            if (_cache.Count > 0)
            {
                IDictionaryEnumerator enumerator = _cache.GetEnumerator();
                if (enumerator != null)
                {
                    list = new Dictionary<string, string>();
                    while (enumerator.MoveNext())
                    {
                        list.Add(Convert.ToString(enumerator.Key), Convert.ToString(enumerator.Value));
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获得所有的缓存对象集合
        /// </summary>
        /// <returns></returns>
        private static IDictionaryEnumerator GetCaches()
        {
            IDictionaryEnumerator enumerator = null;
            if (_cache.Count > 0)
            {
                enumerator = _cache.GetEnumerator();
            }
            return enumerator;
        }

        /// <summary>
        /// 根据缓存KEY开头字符串找到匹配的缓存并删除
        /// </summary>
        /// <param name="startKey"></param>
        public static void RemoveByStartKey(string startKey)
        {
            Dictionary<string, string> caches = GetList();
            List<KeyValuePair<string, string>> list = caches.Where(x => x.Key.StartsWith(startKey)).ToList();
            foreach (KeyValuePair<string, string> item in list)
            {
                Remove(item.Key);
            }
        }
    }
}