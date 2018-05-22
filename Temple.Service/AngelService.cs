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
    public partial class AngelService : IAngelService
    {
        private readonly IRepository<Angel> _angelRepository; //聖示護法
        private readonly IRepository<Make_inquiries> _inquiriesRepository; 

        public AngelService(IUnitOfWork unitofwork)
        {
            this._angelRepository = unitofwork.Repository<Angel>();
            this._inquiriesRepository = unitofwork.Repository<Make_inquiries>();
        }

        #region 聖示護法
        public IPagedList<Angel> GetAngelList(int page, int size)
        {
            var query = this._angelRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Angel> list = new PagedList<Angel>(query, page, size);
            return list;
        }

        public bool AddAngel(Angel info)
        {
            if (_angelRepository.Entities.Where(x => x.Name == info.Name).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._angelRepository.Insert(info) > 0;
            }
        }

        public bool DeleteAngel(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._angelRepository.Delete(id) > 0;
        }

        public bool UpdateAngel(Angel info)
        {
            return this._angelRepository.Update(info) > 0;
        }

        public Angel GetAngelByID(int id)
        {
            return this._angelRepository.GetByKey(id);
        }
        #endregion

        #region 叩問作業
        public IPagedList<Make_inquiries> GetInquiriesList(int page, int size)
        {
            var query = this._inquiriesRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Make_inquiries> list = new PagedList<Make_inquiries>(query, page, size);
            return list;
        }

        public bool AddInquiries(Make_inquiries info)
        {
            return this._inquiriesRepository.Insert(info) > 0;

        }

        public bool DeleteInquiries(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._inquiriesRepository.Delete(id) > 0;
        }

        public bool UpdateInquiries(Make_inquiries info)
        {
            return this._inquiriesRepository.Update(info) > 0;
        }

        public Make_inquiries GetInquiriesByID(int id)
        {
            return this._inquiriesRepository.GetByKey(id);
        }
        #endregion

    }
}
