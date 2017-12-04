using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeTest
{
    class Program
    {
        private static long _totalTimeCost = 0;
        private static int _endedConnenctionCount = 0;
        private static int _failedConnectionCount = 0;
        private static int _connectionCount = 0;


        static void Main(string[] args)
        {
            var connectionCount = 100000;
            //var requestThread = new Thread(() => StartRequest(connectionCount)) { IsBackground = true };
            //requestThread.Start();

            for (int i = 0; i < connectionCount; i++)
            {
                var thread = new Thread(() => StartRequest(200)) { IsBackground = true };
                thread.Start();
            }

            Console.WriteLine("恭喜，成功完成！");
            Console.ReadLine();
        }

        private static void StartRequest(int connectionCount)
        {
            Reset();
            for (var i = 0; i < connectionCount; i++)
            {
                ThreadPool.QueueUserWorkItem(u => SendRequest());
            }
        }


        static void SendRequest()
        {
            try
            {
                var url ="http://www.bbphz.cn/s/zg?d=436";
                var r = SendRequestByGet(url);
                url = "http://www.bbphz.cn/s/zg?d=436&ticket";
                r = SendRequestByGet(url);

                IncreaseSuccessConnection();
            }
            catch (Exception)
            {
                IncreaseFailedConnection();
            }
        }
        private static void Reset()
        {
            _failedConnectionCount = 0;
            _endedConnenctionCount = 0;
            _totalTimeCost = 0;
        }

        private static void IncreaseFailedConnection()
        {
            Interlocked.Increment(ref _failedConnectionCount);
            Console.WriteLine("失败个数：" + _failedConnectionCount);
        }

        private static void IncreaseSuccessConnection()
        {
            Interlocked.Increment(ref _endedConnenctionCount);
            Console.WriteLine("成功个数：" + _endedConnenctionCount);
        }


        public static string SendRequestByGet(string uri)
        {
            string fullhtml = null;
            while (true)
            {
                try
                {
                    var req = (HttpWebRequest)WebRequest.Create(uri);
                    req.Method = "GET";
                    req.ServicePoint.ConnectionLimit = int.MaxValue;
                    req.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:5.0) Gecko/20100101 Firefox/5.0";
                    req.KeepAlive = true;
                    req.Timeout = 1000 * 10;
                    var resp = (HttpWebResponse)req.GetResponse();
                    if (resp.StatusCode != HttpStatusCode.OK) //如果服务器未响应，那么继续等待相应
                        continue;
                    var sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                    fullhtml = sr.ReadToEnd().Trim();
                    resp.Close();
                    sr.Close();
                    break;
                }
                catch (WebException e)
                {
                    e.StackTrace.ToString();
                    Trace.WriteLine(e.Message);
                    if (true)
                        continue;
                }
            }
            return fullhtml;
        }
    }
}
