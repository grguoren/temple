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
    public partial class FestivalService : IFestivalService
    {
        private readonly IRepository<Festival> _festivalRepository; //法會
        private readonly IRepository<Festival_service> _festivalServiceRepository; //法會

        public FestivalService(IUnitOfWork unitofwork)
        {
            this._festivalRepository = unitofwork.Repository<Festival>();
            this._festivalServiceRepository = unitofwork.Repository<Festival_service>();
        }

        #region 法會
        public IPagedList<Festival> GetFestivalList(int page, int size)
        {
            var query = this._festivalRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Festival> list = new PagedList<Festival>(query, page, size);
            return list;
        }

        public bool AddFestival(Festival info)
        {
            if (_festivalRepository.Entities.Where(x => x.Code == info.Code).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._festivalRepository.Insert(info) > 0;
            }
        }

        public bool DeleteFestival(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._festivalRepository.Delete(id) > 0;
        }

        public bool UpdateFestival(Festival info)
        {
            return this._festivalRepository.Update(info) > 0;
        }

        public Festival GetFestivalByID(int id)
        {
            return this._festivalRepository.GetByKey(id);
        }
        #endregion


        #region 法會服務項目
        public IPagedList<Festival_service> GetFestivalServiceList(int page, int size)
        {
            var query = this._festivalServiceRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Festival_service> list = new PagedList<Festival_service>(query, page, size);
            return list;
        }

        public bool AddFestivalService(Festival_service info)
        {
            if (_festivalServiceRepository.Entities.Where(x => x.Festival_Id == info.Festival_Id && x.Service_name_id == info.Service_name_id).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._festivalServiceRepository.Insert(info) > 0;
            }
        }

        public bool DeleteFestivalService(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._festivalServiceRepository.Delete(id) > 0;
        }

        public bool UpdateFestivalService(Festival_service info)
        {
            return this._festivalServiceRepository.Update(info) > 0;
        }

        public Festival_service GetFestivalServiceByID(int id)
        {
            return this._festivalServiceRepository.GetByKey(id);
        }
        #endregion


    }
}
