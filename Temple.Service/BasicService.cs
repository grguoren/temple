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
    public partial class BasicService : IBasicService
    {
        private readonly IRepository<Payment_item> _paymentRepository; //付款方式
        private readonly IRepository<Title> _titleRepository; //稱謂
        private readonly IRepository<Accounting_unit> _accountRepository; //入帳單位
        private readonly IRepository<Service_name> _serviceRepository; //服務項目
        private readonly IRepository<Good_project> _goodRepository; //功德項目
        private readonly IRepository<Worship_pictures> _picturesRepository; //祭拜圖片
        private readonly IRepository<Good_project_service> _goodserviceRepository; //功德服務項目

        public BasicService(IUnitOfWork unitofwork)
        {
            this._paymentRepository = unitofwork.Repository<Payment_item>();
            this._titleRepository = unitofwork.Repository<Title>();
            this._accountRepository = unitofwork.Repository<Accounting_unit>();
            this._serviceRepository = unitofwork.Repository<Service_name>();
            this._goodRepository = unitofwork.Repository<Good_project>();
            this._picturesRepository = unitofwork.Repository<Worship_pictures>();
            this._goodserviceRepository = unitofwork.Repository<Good_project_service>();
        }

        #region 付款方式 
        public IPagedList<Payment_item> GetPaymentList(int page, int size)
        {
            var query = this._paymentRepository.Entities;
           
            query = query.OrderByDescending(x => x.Id);
            IPagedList<Payment_item> list = new PagedList<Payment_item>(query, page, size);
            return list;
        }

        public bool AddPayment(Payment_item info)
        {
            if (_paymentRepository.Entities.Where(x => x.Code == info.Code).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._paymentRepository.Insert(info) > 0;
            }
        }

        public bool DeletePayment(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._paymentRepository.Delete(id) > 0;
        }

        public bool UpdatePayment(Payment_item info)
        {
            return this._paymentRepository.Update(info) > 0;
        }

        public Payment_item GetPaymentByID(int id)
        {
            return this._paymentRepository.GetByKey(id);
        }
        #endregion

        #region 稱謂
        public IPagedList<Title> GetTitleList(int page, int size)
        {
            var query = this._titleRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Title> list = new PagedList<Title>(query, page, size);
            return list;
        }

        public bool AddTitle(Title info)
        {
            if (_titleRepository.Entities.Where(x => x.Code == info.Code).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._titleRepository.Insert(info) > 0;
            }
        }

        public bool DeleteTitle(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._titleRepository.Delete(id) > 0;
        }

        public bool UpdateTitle(Title info)
        {
            return this._titleRepository.Update(info) > 0;
        }

        public Title GetTitleByID(int id)
        {
            return this._titleRepository.GetByKey(id);
        }
        #endregion

        #region 入帳單位
        public IPagedList<Accounting_unit> GetAccountList(int page, int size)
        {
            var query = this._accountRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Accounting_unit> list = new PagedList<Accounting_unit>(query, page, size);
            return list;
        }

        public bool AddAccount(Accounting_unit info)
        {
            if (_accountRepository.Entities.Where(x => x.Code == info.Code).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._accountRepository.Insert(info) > 0;
            }
        }

        public bool DeleteAccount(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._accountRepository.Delete(id) > 0;
        }

        public bool UpdateAccount(Accounting_unit info)
        {
            return this._accountRepository.Update(info) > 0;
        }

        public Accounting_unit GetAccountByID(int id)
        {
            return this._accountRepository.GetByKey(id);
        }
        #endregion

        #region 服務項目
        public IPagedList<Service_name> GetServiceList(int page, int size)
        {
            var query = this._serviceRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Service_name> list = new PagedList<Service_name>(query, page, size);
            return list;
        }

        public bool AddService(Service_name info)
        {
            if (_serviceRepository.Entities.Where(x => x.Code == info.Code).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._serviceRepository.Insert(info) > 0;
            }
        }

        public bool DeleteService(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._serviceRepository.Delete(id) > 0;
        }

        public bool UpdateService(Service_name info)
        {
            return this._serviceRepository.Update(info) > 0;
        }

        public Service_name GetServiceByID(int id)
        {
            return this._serviceRepository.GetByKey(id);
        }
        #endregion

        #region 功德項目
        public IPagedList<Good_project> GetGoodList(int page, int size)
        {
            var query = this._goodRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Good_project> list = new PagedList<Good_project>(query, page, size);
            return list;
        }

        public bool AddGood(Good_project info)
        {
            if (_goodRepository.Entities.Where(x => x.Code == info.Code).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._goodRepository.Insert(info) > 0;
            }
        }

        public bool DeleteGood(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._goodRepository.Delete(id) > 0;
        }

        public bool UpdateGood(Good_project info)
        {
            return this._goodRepository.Update(info) > 0;
        }

        public Good_project GetGoodByID(int id)
        {
            return this._goodRepository.GetByKey(id);
        }
        #endregion

        #region 祭拜圖片
        public IPagedList<Worship_pictures> GetPictureList(int page, int size)
        {
            var query = this._picturesRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Worship_pictures> list = new PagedList<Worship_pictures>(query, page, size);
            return list;
        }

        public bool AddPicture(Worship_pictures info)
        {
            if (_picturesRepository.Entities.Where(x => x.Code == info.Code).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._picturesRepository.Insert(info) > 0;
            }
        }

        public bool DeletePicture(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._picturesRepository.Delete(id) > 0;
        }

        public bool UpdatePicture(Worship_pictures info)
        {
            return this._picturesRepository.Update(info) > 0;
        }

        public Worship_pictures GetPictureByID(int id)
        {
            return this._picturesRepository.GetByKey(id);
        }
        #endregion

        #region 功德服務項目
        public IPagedList<Good_project_service> GetGoodServiceList(int page, int size)
        {
            var query = this._goodserviceRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Good_project_service> list = new PagedList<Good_project_service>(query, page, size);
            return list;
        }

        public bool AddGoodService(Good_project_service info)
        {
            if (_goodserviceRepository.Entities.Where(x => x.Good_project_id == info.Good_project_id && x.Service_name_id == info.Service_name_id).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._goodserviceRepository.Insert(info) > 0;
            }
        }

        public bool DeleteGoodService(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._goodserviceRepository.Delete(id) > 0;
        }

        public bool UpdateGoodService(Good_project_service info)
        {
            return this._goodserviceRepository.Update(info) > 0;
        }

        public Good_project_service GetGoodServiceByID(int id)
        {
            return this._goodserviceRepository.GetByKey(id);
        }
        #endregion

    }
}
