using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebAPI.Service
{
    /// <summary>
    /// Summary description for Generate
    /// </summary>
    public class Generate : IHttpHandler
    {
        string htmlpath= System.Configuration.ConfigurationManager.AppSettings["htmlpath"];
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                try
                {
                    HttpPostedFile file = context.Request.Files[0];

                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    // 替换文件名
                    string filePath = htmlpath + file.FileName; //旧文件
                    string newfilePath = htmlpath + file.FileName.Split('.')[0] + "_" +
                                                    Convert.ToInt64(ts.TotalSeconds).ToString() +"."+
                                                    file.FileName.Split('.')[1];

                    // 如果文件存在，重新命名文件 文件名_日期戳
                    FileInfo f = new FileInfo(filePath);
                    if (f.Exists) {
                        System.IO.File.Move(filePath, newfilePath);
                    }
                    file.SaveAs(filePath);
                    context.Response.Write("Success");
                }
                catch
                {
                    context.Response.Write("Error");
                }
            }
            else
            {
                context.Response.Write("Error1");
            }
        }

        public void Log(string ex)
        {
            try
            {
                string filename = DateTime.Now.ToString("yyyyMMdd") + ".txt";
                FileInfo file = new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + filename); //如果是web程序，这个的变成Http什么的
                StreamWriter sw = null;
                if (!file.Exists)
                {
                    sw = file.CreateText();
                    sw.WriteLine(ex.ToString());
                }
                else
                {
                    sw = file.AppendText();
                    sw.WriteLine(ex.ToString());
                }
                sw.Close();
                sw.Flush();
                sw.Dispose();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}