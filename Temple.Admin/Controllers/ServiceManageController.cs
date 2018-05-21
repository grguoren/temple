using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.Admin.Models;
using Temple.Domain;
using Temple.IService;

namespace Temple.Admin.Controllers
{
    public class ServiceManageController : BaseController
    {
        readonly IUserInfoService userse;
        public ServiceManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;
        }

        public ActionResult List()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        public ActionResult Add(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "修改功德項目" : "添加功德項目";
            ViewBag.NewDataId = id.HasValue ? id.Value : 0;
            return View();
        }

        public ActionResult PictureList()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }

        public ActionResult PictureAdd(int? id)
        {
            ViewBag.PageTitle = id.HasValue ? "修改祭拜圖片" : "添加祭拜圖片";
            ViewBag.NewDataId = id.HasValue ? id.Value : 0;
            return View();
        }

        public ActionResult DaoRu()
        {
            #region
            DataSet dst = new DataSet();
            try
            {
                dst = ExecleDs(Server.MapPath("/signuser.xls"), "xiuzhen");
            }
            catch (Exception ee)
            {
                Response.Write(ee.Message);
                Response.End();
                return null;
            }

            

            #endregion
            return View();
        }

        protected DataSet ExecleDs(string filenameurl, string table)
        {

            DataSet ds = new DataSet();

            string strConn = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + filenameurl + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
            OleDbConnection conn = new OleDbConnection(strConn);

            conn.Open();

            string tableName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0][2].ToString().Trim();

            OleDbDataAdapter odda = new OleDbDataAdapter("select * from [" + tableName + "]", conn);

            odda.Fill(ds, table);

            return ds;

        }

      
    }
}
