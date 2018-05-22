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
    public partial class CourseService : ICourseService
    {
        private readonly IRepository<Education_course> _courseRepository; //證道仙佛歷程

        public CourseService(IUnitOfWork unitofwork)
        {
            this._courseRepository = unitofwork.Repository<Education_course>();
        }

        #region 證道仙佛歷程
        public IPagedList<Education_course> GetCourseList(int page, int size)
        {
            var query = this._courseRepository.Entities;

            query = query.OrderByDescending(x => x.Id);
            IPagedList<Education_course> list = new PagedList<Education_course>(query, page, size);
            return list;
        }

        public bool AddCourse(Education_course info)
        {
            return this._courseRepository.Insert(info) > 0;
            
        }

        public bool DeleteCourse(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("ID不能小于等于0");
            }
            return this._courseRepository.Delete(id) > 0;
        }

        public bool UpdateCourse(Education_course info)
        {
            return this._courseRepository.Update(info) > 0;
        }

        public Education_course GetCourseByID(int id)
        {
            return this._courseRepository.GetByKey(id);
        }
        #endregion
    }
}
