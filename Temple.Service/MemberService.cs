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
    public partial class MemberService : IMemberService
    {
        private readonly IRepository<Member> _memberRepository; //鸞友會員
        private readonly IRepository<Practitioner> _practitionerRepository; //被保舉人
        private readonly IRepository<Practitioner_member_Relation> _practitionerMemberRepository; //鸞友與被保舉人關聯表

        public MemberService(IUnitOfWork unitofwork)
        {
            this._memberRepository = unitofwork.Repository<Member>();
            this._practitionerRepository = unitofwork.Repository<Practitioner>();
            this._practitionerMemberRepository = unitofwork.Repository<Practitioner_member_Relation>();
        }

        #region 彎友
        public IPagedList<Member> GetMemberList(int page, int size)
        {
            var query = this._memberRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Member> list = new PagedList<Member>(query, page, size);
            return list;
        }

        public bool AddMember(Member info)
        {
            if (_memberRepository.Entities.Where(x => x.Code == info.Code).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._memberRepository.Insert(info) > 0;
            }
        }

        public bool DeleteMember(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._memberRepository.Delete(id) > 0;
        }

        public bool UpdateMember(Member info)
        {
            return this._memberRepository.Update(info) > 0;
        }

        public Member GetMemberByID(int id)
        {
            return this._memberRepository.GetByKey(id);
        }
        #endregion

        #region 被保舉人
        public IPagedList<Practitioner> GetPractitionerList(int page, int size)
        {
            var query = this._practitionerRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Practitioner> list = new PagedList<Practitioner>(query, page, size);
            return list;
        }

        public bool AddPractitioner(Practitioner info)
        {
            if (_practitionerRepository.Entities.Where(x => x.Code == info.Code).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._practitionerRepository.Insert(info) > 0;
            }
        }

        public bool DeletePractitioner(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._practitionerRepository.Delete(id) > 0;
        }

        public bool UpdatePractitioner(Practitioner info)
        {
            return this._practitionerRepository.Update(info) > 0;
        }

        public Practitioner GetPractitionerByID(int id)
        {
            return this._practitionerRepository.GetByKey(id);
        }
        #endregion

        #region 鸞友與被保舉人關聯
        public IPagedList<Practitioner_member_Relation> GetPractitionerMemberList(int page, int size)
        {
            var query = this._practitionerMemberRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Practitioner_member_Relation> list = new PagedList<Practitioner_member_Relation>(query, page, size);
            return list;
        }

        public bool AddPractitionerMember(Practitioner_member_Relation info)
        {
            if (_practitionerMemberRepository.Entities.Where(x => x.Member_id == info.Member_id && x.Practitioner_id == info.Practitioner_id).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return this._practitionerMemberRepository.Insert(info) > 0;
            }
        }

        public bool DeletePractitionerMember(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._practitionerMemberRepository.Delete(id) > 0;
        }

        public bool UpdatePractitionerMember(Practitioner_member_Relation info)
        {
            return this._practitionerMemberRepository.Update(info) > 0;
        }

        public Practitioner_member_Relation GetPractitionerMemberByID(int id)
        {
            return this._practitionerMemberRepository.GetByKey(id);
        }
        #endregion
    }
}
