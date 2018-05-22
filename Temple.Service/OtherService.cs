using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temple.Core.Data;
using Temple.Core.Pager;
using Temple.Domain;
using Temple.IService;

namespace Temple.Service
{
    public partial class OtherService : IOtherService
    {
        private readonly IRepository<Member_Good_project> _mgoodServiceRepository; //鸞友功德服務
        private readonly IRepository<China_time> _chinaTimeRepository; //中國時辰服務

        public OtherService(IUnitOfWork unitofwork)
        {
            this._mgoodServiceRepository = unitofwork.Repository<Member_Good_project>();
            this._chinaTimeRepository = unitofwork.Repository<China_time>();
        }

        #region 鸞友功德服務
        public IPagedList<Member_Good_project> GetMemGoodServiceList(int page, int size)
        {
            var query = this._mgoodServiceRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Member_Good_project> list = new PagedList<Member_Good_project>(query, page, size);
            return list;
        }

        public bool AddMemGoodService(Member_Good_project info)
        {
            return this._mgoodServiceRepository.Insert(info) > 0;
            
        }

        public bool DeleteMemGoodService(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._mgoodServiceRepository.Delete(id) > 0;
        }

        public bool UpdateMemGoodService(Member_Good_project info)
        {
            return this._mgoodServiceRepository.Update(info) > 0;
        }

        public Member_Good_project GetMemGoodServiceByID(int id)
        {
            return this._mgoodServiceRepository.GetByKey(id);
        }
        #endregion

        #region 中國時辰作業
        public IPagedList<China_time> GetChinaTimeList(int page, int size)
        {
            var query = this._chinaTimeRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<China_time> list = new PagedList<China_time>(query, page, size);
            return list;
        }

        public bool AddChinaTime(China_time info)
        {
            return this._chinaTimeRepository.Insert(info) > 0;

        }

        public bool DeleteChinaTime(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._chinaTimeRepository.Delete(id) > 0;
        }

        public bool UpdateChinaTime(China_time info)
        {
            return this._chinaTimeRepository.Update(info) > 0;
        }

        public China_time GetChinaTimeByID(int id)
        {
            return this._chinaTimeRepository.GetByKey(id);
        }
        #endregion
    }
}
