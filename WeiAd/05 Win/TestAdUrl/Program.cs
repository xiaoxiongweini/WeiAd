using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAdUrl
{
    class Program
    {
        static void Main(string[] args)
        {
            //暴力跑数据

            Start();

            Console.WriteLine("运行结束。");
        }

        static void Start()
        {
            string url = "http://tiao.iqnrs.cn/index/myad/id/{0}/pass/{1}";
            int adid = 400;
            int passid = 999999999;
            for (int i = 200; i < adid; i++)
            {
                for (int j = 100000; j < passid; j++)
                {
                    string nurl = string.Format(url, i, j);
                    try
                    {
                        string html = DN.Framework.Utility.WebClientHelper.GetSend(nurl);
                        if (!string.IsNullOrEmpty(html))
                        {
                            DN.Framework.Utility.LogHelper.Write(nurl);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine(string.Format("i={0},j={1}", i, j));
                }
            }
        }
    }
}
