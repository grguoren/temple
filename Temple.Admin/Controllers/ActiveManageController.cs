using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Temple.Core.Tools;
using Temple.Domain;
using Temple.IService;

namespace Temple.Admin.Controllers
{
    public class ActiveManageController : BaseController
    {
         // GET: /Article/
        readonly IUserInfoService userse;
        public ActiveManageController(IUserInfoService _userse)
            : base(_userse)
        {
            userse = _userse;

        }

        /// <summary>
        /// 门票列表
        /// </summary>
        /// <returns></returns>
        public ActionResult LiveTicket()
        {
            ViewBag.ReplyName = currentMember.UserName;
            return View();
        }
       
        public string SaveLivePic(string basebyte, int id)
        {
            try
            {
                string pgname = Guid.NewGuid() + ".png";
                try
                {
                    string byteStr = basebyte;//data:image/jpg;base64,         
                    int delLength = byteStr.IndexOf(',') + 1;
                    string str = byteStr.Substring(delLength, byteStr.Length - delLength);

                    byte[] arr = Convert.FromBase64String(str);

                    UploadHelper upload = new UploadHelper();

                    string url = upload.OssUploadFileByte(arr, pgname);
                    string[] result = url.Split('|');
                    if (string.IsNullOrEmpty(result[0]))
                    {
                        return "0|网络繁忙,请稍后在试！";
                    }
                    else
                    {
                       
                        return "1|" + result[0] + "|已提交成功";  //result[1]为返回图片的URL地址
                    }


                }
                catch (Exception)
                {
                    return "0|失败";
                }


            }
            catch (Exception ex)
            {
                return "0|失败";
            }
        }

        /// <summary>
        /// 导入门票
        /// </summary>
        /// <returns></returns>
        public ActionResult DaoRuLive()
        {
            #region
            DataSet dst = new DataSet();
            try
            {
                dst = ExecleDs(Server.MapPath("/livevideo.xls"), "xiuzhen");
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
            //RegistryKey reg_TypeGuessRows = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Jet\4.0\Engines\Excel");
            //reg_TypeGuessRows.SetValue("TypeGuessRows", 5000); //修改注册表 解决数字与字母混用的问题。

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
