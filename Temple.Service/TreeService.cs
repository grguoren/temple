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
    public partial class TreeService : ITreeService
    {
        private readonly IRepository<Tree_planting> _treeRepository; //原靈樹植種
        private readonly IRepository<Tree_maintenance> _maintenanceRepository; //原靈樹養護
        private readonly IRepository<Tree_planting_Installment> _installmentRepository; //原靈樹植種分期付款

        public TreeService(IUnitOfWork unitofwork)
        {
            this._treeRepository = unitofwork.Repository<Tree_planting>();
            this._maintenanceRepository = unitofwork.Repository<Tree_maintenance>();
            this._installmentRepository = unitofwork.Repository<Tree_planting_Installment>();
        }

        #region 原靈樹植種
        public IPagedList<Tree_planting> GetTreePlantList(int page, int size)
        {
            var query = this._treeRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Tree_planting> list = new PagedList<Tree_planting>(query, page, size);
            return list;
        }

        public bool AddTreePlant(Tree_planting info)
        {
            return this._treeRepository.Insert(info) > 0;  
        }

        public bool DeleteTreePlant(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._treeRepository.Delete(id) > 0;
        }

        public bool UpdateTreePlant(Tree_planting info)
        {
            return this._treeRepository.Update(info) > 0;
        }

        public Tree_planting GetTreePlantByID(int id)
        {
            return this._treeRepository.GetByKey(id);
        }
        #endregion

        #region 原靈樹養護
        public IPagedList<Tree_maintenance> GetTreeMaintenanceList(int page, int size)
        {
            var query = this._maintenanceRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Tree_maintenance> list = new PagedList<Tree_maintenance>(query, page, size);
            return list;
        }

        public bool AddTreeMaintenance(Tree_maintenance info)
        {
             return this._maintenanceRepository.Insert(info) > 0;  
        }

        public bool DeleteTreeMaintenance(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._maintenanceRepository.Delete(id) > 0;
        }

        public bool UpdateTreeMaintenance(Tree_maintenance info)
        {
            return this._maintenanceRepository.Update(info) > 0;
        }

        public Tree_maintenance GetTreeMaintenanceByID(int id)
        {
            return this._maintenanceRepository.GetByKey(id);
        }
        #endregion

        #region 原靈樹植種分期付款
        public IPagedList<Tree_planting_Installment> GetTreeInstallmentList(int page, int size)
        {
            var query = this._installmentRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Tree_planting_Installment> list = new PagedList<Tree_planting_Installment>(query, page, size);
            return list;
        }

        public bool AddTreeInstallment(Tree_planting_Installment info)
        {
            return this._installmentRepository.Insert(info) > 0;
        }

        public bool DeleteTreeInstallment(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._installmentRepository.Delete(id) > 0;
        }

        public bool UpdateTreeInstallment(Tree_planting_Installment info)
        {
            return this._installmentRepository.Update(info) > 0;
        }

        public Tree_planting_Installment GetTreeInstallmentByID(int id)
        {
            return this._installmentRepository.GetByKey(id);
        }
        #endregion

    }
}
