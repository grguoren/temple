using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Domain.Model
{
    public class RecruitModel
    {
        #region Model
        /// <summary>
        /// rId
        /// </summary>
        public int rId { get; set; }

        /// <summary>
        /// rTitle
        /// </summary>
        public string rTitle { get; set; }

        /// <summary>
        /// rDate
        /// </summary>
        public DateTime? rDate { get; set; }

        /// <summary>
        /// rSalary
        /// </summary>
        public string rSalary { get; set; }

        /// <summary>
        /// rCityId
        /// </summary>
        public int? rCityId { get; set; }

        /// <summary>
        /// rCpId
        /// </summary>
        public int? rCpId { get; set; }

        /// <summary>
        /// rProvince
        /// </summary>
        public int? rProvince { get; set; }

        /// <summary>
        /// IsClose
        /// </summary>
        public int? IsClose { get; set; }

        /// <summary>
        /// rDescription
        /// </summary>
        public string rDescription { get; set; }

        /// <summary>
        /// rContent
        /// </summary>
        public string rContent { get; set; }

        /// <summary>
        /// rUid
        /// </summary>
        public int? rUid { get; set; }

        /// <summary>
        /// rEduc
        /// </summary>
        public string rEduc { get; set; }

        /// <summary>
        /// rGenre
        /// </summary>
        public int? rGenre { get; set; }

        /// <summary>
        /// rNumber
        /// </summary>
        public int? rNumber { get; set; }

        /// <summary>
        /// IsTop
        /// </summary>
        public int? IsTop { get; set; }

        /// <summary>
        /// rwelfare
        /// </summary>
        public string rwelfare { get; set; }

        public string area { get; set; }

        public string uname { get; set; }

        public string urealname { get; set; }

        public int resumeNum { get; set; }


        public DateTime? rTopBeginTime { get; set; }

        public DateTime? rTopEndTime { get; set; }

        public int uTop { get; set; }
        #endregion Model
    }
}
