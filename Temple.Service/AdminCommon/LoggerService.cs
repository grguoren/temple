using Temple.Core.Data;
using Temple.Domain;
using Temple.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Service
{
    public partial class LoggerService : ILoggerService
    {
        private readonly IRepository<Logger> _loggerRepository;

        public LoggerService(IUnitOfWork unitofwork)
        {
            this._loggerRepository = unitofwork.Repository<Logger>();
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool AddLog(Logger log)
        {
            try
            {
                return _loggerRepository.Insert(log) > 0;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                return false;
            }
        }

        /// <summary>
        /// 分页获取操作日志
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public List<Logger> GetLogList(int page, int size, out int count, string keyword,string desp)
        {
            var query = _loggerRepository.Entities;
            if(!string.IsNullOrEmpty(desp))
            {
                query = query.Where(x=>x.Remark == desp);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Param.Contains(keyword));
            }
            query = query.OrderByDescending(x => x.CreateTime);
            count = query.Count();
            query = query.Take(size * page).Skip(size * (page - 1));
            return query.ToList();
        }
    }
}
