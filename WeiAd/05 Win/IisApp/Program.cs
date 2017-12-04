using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace IisApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if(AppConfig.IsRunType == "0")
            {
                AddDomains();
            }
            else
            {
            }

            Console.Write("运行结束。");
            Console.ReadKey();
        }

        static void DelDomains()
        {
            IISHelper helper = new IISHelper();
            string maindomain = AppConfig.MainDomain;
            var list = ReaderDomains();

            foreach (var item in list)
            {
                string domain = item;
                if (domain.IndexOf("www.") == -1)
                {
                    domain = "www." + domain;
                }
                helper.Del(domain);
            }
        }

        //自动添加域名
        static void AddDomains()
        {
            IISHelper helper = new IISHelper();
            string maindomain = AppConfig.MainDomain;
            var list = ReaderDomains();

            helper.CreateWebSite(maindomain, list, AppConfig.WebPath);
        }

        static List<string> ReaderDomains()
        {
            List<string> list = new List<string>();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "domains.txt");
            Console.WriteLine(path);

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string domain = reader.ReadLine();
                    if (domain.IndexOf("www.") == -1)
                    {
                        domain = "www." + domain;
                    }

                    list.Add(domain);
                    while (!reader.EndOfStream)
                    {
                        domain = reader.ReadLine();
                        if (domain.IndexOf("www.") == -1)
                        {
                            domain = "www." + domain;
                        }
                        list.Add(domain);
                        Console.WriteLine(domain);
                    }
                }
            }


            return list;
        }

        //自动运行模式
        static void AutoRun()
        {
            IISHelper helper = new IISHelper();
            if (AppConfig.IsRunType == "0")
            {
                helper.Start();
            }
            else if (AppConfig.IsRunType == "1")
            {
                helper.Del();
            }
            else if (AppConfig.IsRunType == "2")
            {
                while (true)
                {
                    helper.RestartIIS();
                    Thread.Sleep(2000);
                }
            }
            else
            {

                Console.WriteLine(string.Format("未识别运行方式：{0}", AppConfig.IsRunType));
            }
        }
    }
}
