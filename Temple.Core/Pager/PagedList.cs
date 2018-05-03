using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Temple.Core.Pager
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList()
        {
        }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int total = source.Count();
            this.TotalCount = total;
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            if (pageIndex < 1)
                pageIndex = 1;
            var itemIndex = (pageIndex - 1) * pageSize;
            this.AddRange(source.Skip(itemIndex).Take(pageSize).ToList());
        }

        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            TotalCount = source.Count;
            PageIndex = pageIndex;
            if (pageIndex < 1)
                pageIndex = 1;
            var itemIndex = (pageIndex - 1) * pageSize;
            this.AddRange(source.Take(pageSize).Skip(itemIndex).ToList());
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalItemCount)
        {
            AddRange(source);
            TotalCount = totalItemCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        #region IPagedList Members

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get { return (int)Math.Ceiling(TotalCount / (double)PageSize); } }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }

        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage
        {
            get { return (this.PageIndex * this.PageSize) <= this.TotalCount; }
        }

        public int StartRecordIndex { get { return (PageIndex - 1) * PageSize + 1; } }
        public int EndRecordIndex { get { return TotalCount > PageIndex * PageSize ? PageIndex * PageSize : TotalCount; } }

        #endregion
    }
}
