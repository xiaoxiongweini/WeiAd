using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business
{
    /// <summary>
    /// 异常处理日志
    /// </summary>
    public class ErrorBLL
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ex"></param>
        /// <param name="entity"></param>
        public static void Add<T>(Exception ex,T entity)
        {
            //写入到本地磁盘中

            try
            {
                ExceptionLog log = new ExceptionLog();
                log.Message = ex.Message;
                log.Type = entity.GetType().ToString();
                log.ObjJson = DN.Framework.Utility.Serializer.SerializeObject(entity);

                string json = DN.Framework.Utility.Serializer.SerializeObject(log);
                DN.Framework.Utility.LogHelper.Write(json, "errorcache");
            }
            catch (Exception logex)
            {
                Console.WriteLine(logex);
            }
        }
        static log4net.ILog logHelper = log4net.LogManager.GetLogger("testApp.Logging");

        public static void Add<T>(T entity)
        {
            try
            {
                ExceptionLog log = new ExceptionLog();
                log.Message = "";
                log.Type = entity.GetType().ToString();
                log.ObjJson = DN.Framework.Utility.Serializer.SerializeObject(entity);

                string json = DN.Framework.Utility.Serializer.SerializeObject(log);
                //DN.Framework.Utility.LogHelper.Write(json, "errorcache");                
                LogWriter.Default.WriteWarning(json);
            }
            catch (Exception logex)
            {
                Console.WriteLine(logex);
            }
        }
    }

    class ExceptionLog
    {
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 实体类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 实体对象
        /// </summary>
        public string ObjJson { get; set; }
    }
}
