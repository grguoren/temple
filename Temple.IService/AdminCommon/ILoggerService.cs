using Temple.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.IService
{
    public partial interface ILoggerService
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        bool AddLog(Logger log);

        /// <summary>
        /// 分页获取操作日志
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        List<Logger> GetLogList(int page, int size, out int count, string keyword, string desp);
    }
}
