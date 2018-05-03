using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Core.Cache
{
    public class MemoryCacheManager:ICacheManager
    {
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        protected ObjectCache Cache
        {
            get { return MemoryCache.Default; }
        }
        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return (T)Cache.GetCacheItem(key).Value;
        }
        /// <summary>
        /// 设置缓存项
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime"></param>
        public void Set(string key, object data, long cacheTime)
        {
            if (data == null)
                return;
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromSeconds(cacheTime);
            Cache.Set(new CacheItem(key, data), policy);
        }
        /// <summary>
        /// 判断内容缓存中是否存在这个Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool HasKey(string key)
        {
            return Cache.Contains(key);
        }
        /// <summary>
        /// 移除缓存项
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// 批量移除所有缓存项
        /// </summary>
        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }

        public void Save()
        {

        }

        public void SaveAsync()
        {

        }
    }
}
