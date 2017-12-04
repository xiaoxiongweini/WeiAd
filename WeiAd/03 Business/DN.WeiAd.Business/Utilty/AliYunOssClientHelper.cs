using Aliyun.OSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business.Utilty
{
    /// <summary>
    /// OSS服务器
    /// </summary>
    public class AliYunOssClientHelper
    {

       static  OssClient ossClient = new OssClient(Config.AppConfig.AliYunEndpoint, Config.AppConfig.AliYunAccessKeyId, Config.AppConfig.AliYunAccessKeySecret);

        /// <summary>
        /// 新增文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="fullPath">文件地址，本地绝对路径</param>
        /// <returns></returns>
        public static string PutObject(string fileName,string fullPath)
        {
            //conf.ConnectionLimit = 512;  //HttpWebRequest最大的并发连接数目
            //conf.MaxErrorRetry = 3;     //设置请求发生错误时最大的重试次数
            //conf.ConnectionTimeout = 300;  //设置连接超时时间
            //conf.SetCustomEpochTicks(customEpochTicks);        //设置自定义基准时间

            string url = "";
            string fileToUpload = fullPath;
            var resutl = ossClient.PutObject(Config.AppConfig.AliYunBucketName, fileName, fileToUpload);
            url = Config.AppConfig.AliYunDomain + fileName;

            return url;
        }
    }
}
