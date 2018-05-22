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
    /// 鸞友會員 與被保舉人
    /// </summary>
    public partial  interface IMemberService
    {
        #region 鸞友會員作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Member> GetMemberList(int page, int size);

        /// <summary>
        /// 添加新鸞友會員
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddMember(Member info);

        /// <summary>
        /// 删除鸞友會員
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeleteMember(int id);

        /// <summary>
        /// 更新鸞友會員
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdateMember(Member info);

        /// <summary>
        /// 根据ID获取鸞友會員
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Member GetMemberByID(int id);
        #endregion

        #region 被保舉人作業
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Practitioner> GetPractitionerList(int page, int size);

        /// <summary>
        /// 添加新被保舉人
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddPractitioner(Practitioner info);

        /// <summary>
        /// 删除被保舉人
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeletePractitioner(int id);

        /// <summary>
        /// 更新被保舉人
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdatePractitioner(Practitioner info);

        /// <summary>
        /// 根据ID获取被保舉人
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Practitioner GetPractitionerByID(int id);
        #endregion

        #region 鸞友與被保舉人關聯表
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        IPagedList<Practitioner_member_Relation> GetPractitionerMemberList(int page, int size);

        /// <summary>
        /// 添加鸞友與被保舉人關聯
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool AddPractitionerMember(Practitioner_member_Relation info);

        /// <summary>
        /// 删除鸞友與被保舉人關聯
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool DeletePractitionerMember(int id);

        /// <summary>
        /// 更新鸞友與被保舉人關聯
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        bool UpdatePractitionerMember(Practitioner_member_Relation info);

        /// <summary>
        /// 根据ID获取鸞友與被保舉人關聯
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Practitioner_member_Relation GetPractitionerMemberByID(int id);
        #endregion
    }
}
