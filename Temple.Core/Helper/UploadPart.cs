using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.OSS;
using System.IO;
using Aliyun.OSS.Common;

namespace System
{
    public class UploadPart
    {
        const string accessKeyId = "LTAIn07UwJRln5Ay"; //芳华
        const string accessKeySecret = "YhfASPZ7pO6hjcIIN31ckGOBJGrATP";
        const string endpoint = "http://oss-cn-shenzhen.aliyuncs.com";  //yktedu.oss-cn-shenzhen-internal.aliyuncs.com 内网

        /// <summary>
        /// 在OSS中创建一个新的存储空间。
        /// </summary>
        /// <param name="bucketName">要创建的存储空间的名称</param>
        public void CreateBucket(string bucketName)
        {
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            try
            {
                var bucket = client.CreateBucket(bucketName);

                Console.WriteLine("Create bucket succeeded.");

                Console.WriteLine("Name:{0}", bucket.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create bucket failed, {0}", ex.Message);
            }
        }
        /// <summary>
        /// 上传指定的文件到指定的OSS的存储空间
        /// </summary>
        /// <param name="bucketName">指定的存储空间名称</param>
        /// <param name="key">文件的在OSS上保存的名称</param>
        /// <param name="fileToUpload">指定上传文件的本地路径</param>
        public void PutObject(string bucketName, string key, string fileToUpload)
        {
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);

            try
            {
                var result = client.PutObject(bucketName, key, fileToUpload);

                Console.WriteLine("Put object succeeded");
                Console.WriteLine("ETag:{0}", result.ETag);
            }
            catch (Exception es)
            {
                Console.WriteLine("Put object failed, {0}", es.Message);
            }
        }

        /// <summary>
        /// 上传文件流
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="key"></param>
        /// <param name="content"></param>
        public void PutObject(string bucketName, string key,Stream content)
        {
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);

            try
            {
                var result = client.PutObject(bucketName, key, content);

                Console.WriteLine("Put object succeeded");
                Console.WriteLine("ETag:{0}", result.ETag);
            }
            catch (Exception es)
            {
                Console.WriteLine("Put object failed, {0}", es.Message);
            }
        }

        /// <summary>
        /// 从指定的OSS存储空间中获取指定的文件
        /// </summary>
        /// <param name="bucketName">要获取的文件所在的存储空间名称</param>
        /// <param name="key">要获取的文件在OSS上的名称</param>
        /// <param name="fileToDownload">本地存储下载文件的目录<param>
        public void GetObject(string bucketName, string key, string fileToDownload)
        {
            try
            {
                var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
                var _object = client.GetObject(bucketName, key);

                //将从OSS读取到的文件写到本地
                using (var requestStream = _object.Content)
                {
                    byte[] buf = new byte[1024];
                    using (var fs = File.Open(fileToDownload, FileMode.OpenOrCreate))
                    {
                        var len = 0;
                        while ((len = requestStream.Read(buf, 0, 1024)) != 0)
                        {
                            fs.Write(buf, 0, len);
                        }
                    }
                }
            }
            catch (Exception es)
            {
                Console.WriteLine("Get object failed, {0}", es.Message);
            }
        }

        /// <summary>
        /// 删除指定的文件
        /// </summary>   
        /// <param name="bucketName">文件所在存储空间的名称</param>
        /// <param name="key">待删除的文件名称</param>
        public void DeleteObject(string bucketName, string key)
        {
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            try
            {
                client.DeleteObject(bucketName, key);
                Console.WriteLine("Delete object succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete object failed, {0}", ex.Message);
            }
        }
        public  void ImageProcess(string bucketName, string key, string process)
        {
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            try
            {
               // client.PutObject(bucketName, key, content);
                // 图片缩放
                //  var process = "image/resize,m_fixed,w_100,h_100";
                var ossObject = client.GetObject(new GetObjectRequest(bucketName, key, process));
               
            }
            catch (OssException ex)
            {
                throw ex;
                //Console.WriteLine("Failed with error code: {0}; Error info: {1}. \nRequestID:{2}\tHostID:{3}",
                //    ex.ErrorCode, ex.Message, ex.RequestId, ex.HostId);
            }
            catch (Exception ex)
            {
                throw ex;
                //Console.WriteLine("Failed with error info: {0}", ex.Message);
            }
        }

        /// <summary>
        /// 列出指定存储空间的文件列表
        /// </summary>
        /// <param name="bucketName">存储空间的名称</param>
        public ObjectListing ListObjects(string bucketName)
        {
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
          
            try
            {
                var listObjectsRequest = new ListObjectsRequest(bucketName);
                var result = client.ListObjects(listObjectsRequest);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("List object failed, {0}", ex.Message);
                return null;
            }
         
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        public  void Getpath(string bucketName, string key)
        {
            var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
            try
            {
                var result = client.GetObject(bucketName, key);
                Console.WriteLine("下载的文件成功，名称是：{0}，长度：{1}", result.Key, result.Metadata.ContentLength);
            }
            catch (Exception ex)
            {
                Console.WriteLine("下载文件失败.原因：{0}", ex.Message);
            }
        }

    }
}
