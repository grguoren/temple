using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temple.Core.Pager;
using Temple.Domain;

namespace Temple.IService
{
    /// <summary>
    /// 原靈樹植種
    /// </summary>
    public partial interface ITreeService
    {
        #region 原靈樹植種
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Tree_planting> GetTreePlantList(int page, int size);

        /// <summary>
        /// 添加新原靈樹植種
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddTreePlant(Tree_planting info);

        /// <summary>
        /// 删除原靈樹植種
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteTreePlant(int id);

        /// <summary>
        /// 更新原靈樹植種
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateTreePlant(Tree_planting info);

        /// <summary>
        /// 根据ID获取原靈樹植種
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Tree_planting GetTreePlantByID(int id);
        #endregion

        #region 原靈樹養護
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Tree_maintenance> GetTreeMaintenanceList(int page, int size);

        /// <summary>
        /// 添加新原靈樹養護
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddTreeMaintenance(Tree_maintenance info);

        /// <summary>
        /// 删除原靈樹養護
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteTreeMaintenance(int id);

        /// <summary>
        /// 更新原靈樹養護
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateTreeMaintenance(Tree_maintenance info);

        /// <summary>
        /// 根据ID获取原靈樹養護
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Tree_maintenance GetTreeMaintenanceByID(int id);
        #endregion

        #region 原靈樹植種分期付款
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Tree_planting_Installment> GetTreeInstallmentList(int page, int size);

        /// <summary>
        /// 添加原靈樹植種分期付款
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddTreeInstallment(Tree_planting_Installment info);

        /// <summary>
        /// 删除原靈樹植種分期付款
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteTreeInstallment(int id);

        /// <summary>
        /// 更新原靈樹植種分期付款
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateTreeInstallment(Tree_planting_Installment info);

        /// <summary>
        /// 根据ID获取原靈樹植種分期付款
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Tree_planting_Installment GetTreeInstallmentByID(int id);
        #endregion
    }
}
