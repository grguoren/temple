using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

namespace Temple.Core.Tools
{
    public class UploadHelper
    {
        /// <summary>
        /// 网络访问类
        /// </summary>
        private RequestHelper request = null;

        /// <summary>
        /// 判断源图宽度
        /// </summary>
        public string CheckWidth { get; set; }

        /// <summary>
        /// 上传路径
        /// </summary>
        public string Dir { get; set; }

        /// <summary>
        /// 上传地址
        /// </summary>
        public string PostUrl { get; set; }

        /// <summary>
        /// 引用
        /// </summary>
        public string Referer { get; set; }

        /// <summary>
        /// 水印文字
        /// </summary>
        public string WaterMark { get; set; }

        /// <summary>
        /// 水印文字大小
        /// </summary>
        public string FontSize { get; set; }

        //按类型设置图片大小
        private int big_width = 0;
        private int big_height = 0;
        private int small_width = 150;
        private int small_height = 100;
        private string fileName;

        public UploadHelper()
        {
            this.request = new RequestHelper();
            this.FontSize = "10";
        }

        /// <summary>
        /// 设置上传后原始图片尺寸及缩略图尺寸
        /// </summary>
        /// <param name="big_width"></param>
        /// <param name="big_height"></param>
        /// <param name="small_width"></param>
        /// <param name="small_height"></param>
        public void SetImageSize(int big_width, int big_height, int small_width, int small_height)
        {
            this.big_width = big_width;
            this.big_height = big_height;
            this.small_width = small_width;
            this.small_height = small_height;
        }
        public string OssUploadFileByte(byte[] fileByte, string _filename)
        {
            string result = string.Empty;

            if (fileByte.Count() > 0)
            {
                try
                {

                    string baseFileString = Convert.ToBase64String(fileByte);

                    var _UploadPart = new UploadPart();


                    //_UploadPart.PutObject("yktvideo", _filename, new MemoryStream(fileByte));

                    _UploadPart.PutObject("yktedu", _filename, new MemoryStream(fileByte));
                    return "http://yun.zhihucn.com/" + _filename;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    GC.Collect();
                }
            }
            return null;

        }


        /// <summary>
        /// 上传图片或其他
        /// </summary>
        /// <param name="pic_upload"></param>
        /// <param name="_filename"></param>
        /// <returns></returns>
        public string OssUpload(HttpPostedFileBase pic_upload, string _filename)
        {
            string result = string.Empty;
            _filename = _filename.ToLower();
            if (pic_upload != null)
            {
                try
                {



                    // 将文件流转换成Base64字符串
                    pic_upload.InputStream.Seek(0, SeekOrigin.Begin);
                    Stream stream = pic_upload.InputStream;
                    BinaryReader br = new BinaryReader(stream);
                    byte[] fileByte = br.ReadBytes((int)stream.Length);
                    string baseFileString = Convert.ToBase64String(fileByte);

                    var _UploadPart = new UploadPart();


                    //_UploadPart.PutObject("yktvideo", _filename, new MemoryStream(fileByte));

                    _UploadPart.PutObject("yktedu", _filename, new MemoryStream(fileByte));
                    return "http://yun.zhihucn.com/" + _filename;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    GC.Collect();
                }
            }
            return null;          

        }

        /// <summary>
        /// 上传视频
        /// </summary>
        /// <param name="pic_upload"></param>
        /// <param name="_filename"></param>
        /// <returns></returns>
        public string OssUploadVideo(HttpPostedFileBase pic_upload, string _filename)
        {
            string result = string.Empty;

            if (pic_upload != null)
            {
                try
                {



                    // 将文件流转换成Base64字符串
                    pic_upload.InputStream.Seek(0, SeekOrigin.Begin);
                    Stream stream = pic_upload.InputStream;
                    BinaryReader br = new BinaryReader(stream);
                    byte[] fileByte = br.ReadBytes((int)stream.Length);
                    string baseFileString = Convert.ToBase64String(fileByte);

                    var _UploadPart = new UploadPart();


                    _UploadPart.PutObject("yktvideo", _filename, new MemoryStream(fileByte));

                    //_UploadPart.PutObject("yktedu", _filename, new MemoryStream(fileByte));
                    return "http://video.zhihucn.com/" + _filename;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    GC.Collect();
                }
            }
            return null;

        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="pic_upload"></param>
        /// <returns></returns>
        public string UploadImage(HttpPostedFileBase pic_upload)
        {
            string result = string.Empty;

            if (pic_upload != null)
            {
                this.fileName = Guid.NewGuid().ToString() + Path.GetExtension(pic_upload.FileName);


                // 将文件流转换成Base64字符串
                pic_upload.InputStream.Seek(0, SeekOrigin.Begin);
                Stream stream = pic_upload.InputStream;
                BinaryReader br = new BinaryReader(stream);
                byte[] fileByte = br.ReadBytes((int)stream.Length);
                string baseFileString = Convert.ToBase64String(fileByte);
                if (fileByte.Length == 0)
                { result = "0|上传失败"; }
                else
                {
                    MemoryStream ms = new MemoryStream(fileByte);
                    Bitmap bmp = new Bitmap(ms);
                    int sourceHeight = bmp.Height;
                    int sourceWidth = bmp.Width;
                    if (string.IsNullOrEmpty(CheckWidth))
                    {
                        CheckWidth = "0";
                    }
                    if ((CheckWidth != "0") && (sourceHeight != 400 || sourceWidth != 400))
                    {
                        result = "4|上传的图片大小超过400*400的限制，请重新上传!";
                    }
                    else
                    {
                        string postData = string.Format("data={0}&fileName={1}&path={2}&big_width={3}&big_height={4}&small_width={5}&small_height={6}&watermark={7}&fontsize={8}",
                            baseFileString.Replace("+", "%2B"), fileName, Dir, big_width, big_height, small_width, small_height, this.WaterMark, this.FontSize);

                        result = this.request.ResponseToString(this.request.doPost(PostUrl, postData, this.Referer));
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 上传视频
        /// </summary>
        /// <param name="pic_upload"></param>
        /// <returns></returns>
        public string UploadVideo(HttpPostedFileBase pic_upload)
        {
            string result = string.Empty;

            if (pic_upload != null)
            {
                try
                {
                    this.fileName = Guid.NewGuid().ToString() + Path.GetExtension(pic_upload.FileName);


                    // 将文件流转换成Base64字符串
                    pic_upload.InputStream.Seek(0, SeekOrigin.Begin);
                    Stream stream = pic_upload.InputStream;
                    BinaryReader br = new BinaryReader(stream);
                    byte[] fileByte = br.ReadBytes((int)stream.Length);
                    string baseFileString = Convert.ToBase64String(fileByte);

                    string postData = string.Format("data={0}&fileName={1}&path={2}&big_width={3}&big_height={4}&small_width={5}&small_height={6}&watermark={7}&fontsize={8}",
                        baseFileString.Replace("+", "%2B"), fileName, Dir, big_width, big_height, small_width, small_height, this.WaterMark, this.FontSize);

                    result = this.request.ResponseToString(this.request.doPost(PostUrl, postData, this.Referer));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return result;
        }

    }
}