using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Core.Cache
{
    /// <summary>
    /// 总后台缓存接口
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// 根据Key获取缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 设置缓存对象
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="data">缓存数据</param>
        /// <param name="cacheTime">缓存时间</param>
        void Set(string key, object data, long cacheTime);

        /// <summary>
        /// 判断Key是否被缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool HasKey(string key);

        /// <summary>
        /// 从缓存移除
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        void Clear();

        /// <summary>
        /// 保存数据DB文件到硬盘
        /// </summary>
        void Save();

        /// <summary>
        /// 异步保存数据DB文件到硬盘
        /// </summary>
        void SaveAsync();
    }
}
