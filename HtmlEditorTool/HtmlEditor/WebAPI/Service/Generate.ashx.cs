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
                    //string filePath = "C:\\Documents and Settings\\Administrator\\桌面\\2\\" + file.FileName;//this.MapPath("UploadDocument")  
                    string filePath = "c:\\test\\" + file.FileName;
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

            //string filename1 = context.Request.QueryString["Title"];
            //string filecontent1 = context.Request.QueryString["Desc"];
            //Log("spark3");
            //string filename2 = context.Request["Title"];
            //string filecontent2 = context.Request["Desc"];
            //Log("spark4");
            //Log(context.Request.Form["Title"]);
            //Log(context.Request.Form["Desc"]);
            //Log("spark5");

            //if (context.Request.ServerVariables["Request_Method"].ToString() == "POST")
            //{
            //    string strTitle = context.Request.Form["Title"];
            //    string strContent = context.Request.Form["Desc"];
            //    if (File.Exists(context.Server.MapPath(".") + "\\MyPostFile.txt") == false)
            //    {
            //        File.CreateText(context.Server.MapPath(".") + "\\MyPostFile.txt");
            //    }
            //    StreamWriter SW;
            //    SW = File.AppendText(context.Server.MapPath(". ") + "\\MyPostFile.txt ");
            //    SW.WriteLine(strTitle);
            //    SW.WriteLine(strContent);
            //    SW.Close();
            //    SW = null;
            //}
            //else
            //{
            //    StreamReader SR;
            //    string S;
            //    SR = File.OpenText(context.Server.MapPath(". ") + "\\MyPostFile.txt ");
            //    S = SR.ReadLine();
            //    while (S != null)
            //    {
            //        context.Response.Write(S + "\r\n ");
            //        S = SR.ReadLine();
            //    }
            //    SR.Close();
            //    SR = null;
            //}


            //try
            //{

            //    string filename1 = context.Request.Form["filename"];
            //    string filecontent1 = context.Request.Form["filecontent"];



            //    Log(filename1);
            //    Log(filecontent1);


            //    string fileName = htmlpath + filename1;
            //    FileInfo fi = new FileInfo(fileName);

            //    using (FileStream fs = fi.Create())
            //    {
            //        Byte[] txt = new UTF8Encoding(true).GetBytes(filecontent1);
            //        fs.Write(txt, 0, txt.Length);
            //    }

            //    context.Response.Write(filename1);
            //    context.Response.Write(filecontent1);


            //}
            //catch (Exception ex)
            //{
            //    WriteLog.WriteData.WriteLine(ex.Message);
            //    throw;
            //}


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