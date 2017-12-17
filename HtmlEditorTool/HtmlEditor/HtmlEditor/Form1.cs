using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = UrlTextBox.Text.ToString();
            string filename = url.Substring(url.LastIndexOf('/') + 1, url.Length - url.LastIndexOf('/') - 1);
            FileInfo file = new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + "/Files/" + filename);
            if (!file.Exists)
            {
                MessageBox.Show("文件不存在!");
            }
            ProgressBar progressBar = new ProgressBar();
            Upload_Request2("http://api.bbphz.cn/service/generate.ashx",
                System.AppDomain.CurrentDomain.BaseDirectory + "/Files/" + filename, filename, progressBar);

            MessageBox.Show("文件上传成功！");
        }


        /// <summary>   
        /// 将本地文件上传到指定的服务器(HttpWebRequest方法)   
        /// </summary>   
        /// <param name="address">文件上传到的服务器</param>   
        /// <param name="fileNamePath">要上传的本地文件（全路径）</param>   
        /// <param name="saveName">文件上传后的名称</param>   
        /// <param name="progressBar">上传进度条</param>   
        /// <returns>成功返回1，失败返回0</returns>   
        private int Upload_Request2(string address, string fileNamePath, string saveName, ProgressBar progressBar)
        {
            int returnValue = 0;     // 要上传的文件   
            FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);     //时间戳   
            string strBoundary = "----------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + strBoundary + "\r\n");     //请求头部信息   
            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(strBoundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"");
            sb.Append("file");
            sb.Append("\"; filename=\"");
            sb.Append(saveName);
            sb.Append("\";");
            sb.Append("\r\n");
            sb.Append("Content-Type: ");
            sb.Append("application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");
            string strPostHeader = sb.ToString();
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(strPostHeader);     // 根据uri创建HttpWebRequest对象   
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(address));
            httpReq.Method = "POST";     //对发送的数据不使用缓存   
            httpReq.AllowWriteStreamBuffering = false;     //设置获得响应的超时时间（300秒）   
            httpReq.Timeout = 300000;
            httpReq.ContentType = "multipart/form-data; boundary=" + strBoundary;
            long length = fs.Length + postHeaderBytes.Length + boundaryBytes.Length;
            long fileLength = fs.Length;
            httpReq.ContentLength = length;
            try
            {
                progressBar.Maximum = int.MaxValue;
                progressBar.Minimum = 0;
                progressBar.Value = 0;
                //每次上传4k  
                int bufferLength = 4096;
                byte[] buffer = new byte[bufferLength]; //已上传的字节数   
                long offset = 0;         //开始上传时间   
                DateTime startTime = DateTime.Now;
                int size = r.Read(buffer, 0, bufferLength);
                Stream postStream = httpReq.GetRequestStream();         //发送请求头部消息   
                postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                while (size > 0)
                {
                    postStream.Write(buffer, 0, size);
                    offset += size;
                    progressBar.Value = (int)(offset * (int.MaxValue / length));
                    TimeSpan span = DateTime.Now - startTime;
                    double second = span.TotalSeconds;
                    lblTime.Text = "已用时：" + second.ToString("F2") + "秒";
                    //MessageBox.Show("已用时：" + second.ToString("F2") + "秒");
                    if (second > 0.001)
                    {
                        lblSpeed.Text = "平均速度：" + (offset / 1024 / second).ToString("0.00") + "KB/秒";
                       // MessageBox.Show("平均速度：" + (offset / 1024 / second).ToString("0.00") + "KB/秒");
                    }
                    else
                    {
                        lblSpeed.Text = " 正在连接…";
                    }
                     lblState.Text = "已上传：" + (offset * 100.0 / length).ToString("F2") + "%";
                     lblSize.Text = (offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M";
                    //MessageBox.Show("已上传：" + (offset * 100.0 / length).ToString("F2") + "%");
                    //MessageBox.Show((offset / 1048576.0).ToString("F2") + "M/" + (fileLength / 1048576.0).ToString("F2") + "M");

                    Application.DoEvents();
                    size = r.Read(buffer, 0, bufferLength);
                }
                //添加尾部的时间戳   
                postStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                postStream.Close();         //获取服务器端的响应   
                WebResponse webRespon = httpReq.GetResponse();
                Stream s = webRespon.GetResponseStream();
                //读取服务器端返回的消息  
                StreamReader sr = new StreamReader(s);
                String sReturnString = sr.ReadLine();
                s.Close();
                sr.Close();
                if (sReturnString == "Success")
                {
                    returnValue = 1;
                }
                else if (sReturnString == "Error")
                {
                    returnValue = 0;
                }
            }
            catch
            {
                returnValue = 0;
            }
            finally
            {
                fs.Close();
                r.Close();
            }
            return returnValue;
        }



        public void Log(string content,string filename)
        {
            try
            {
                //string filename = DateTime.Now.ToString("yyyyMMdd") + ".txt";
                if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "/Files/")) {
                    Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "/Files/");
                }
                FileInfo file = new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory +"/Files/"+ filename);
                if (file.Exists) {
                    file.Delete();
                 };
                StreamWriter sw = null;
                if (!file.Exists)
                {
                    sw = file.CreateText();
                    sw.WriteLine(content.ToString());
                }
                else
                {
                    sw = file.AppendText();
                    sw.WriteLine(content.ToString());
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

        // 分析
        private void button3_Click(object sender, EventArgs e)
        {
            string url = UrlTextBox.Text.ToString();
            if (url == "")
            {
                MessageBox.Show("请输入URL地址!");
            }
            string htmlcontent = Web.WebHandler.GetHtmlStr(url, "utf-8");
            Regex r = new Regex("(?<=var wx = \").*?(?=\";)", RegexOptions.IgnoreCase);
            Regex rtel = new Regex("(?<=var tel = \").*?(?=\";)", RegexOptions.IgnoreCase);
            weichatID.Text = r.Match(htmlcontent).Value;
            TelTextBOX.Text = rtel.Match(htmlcontent).Value;
            MessageBox.Show("分析结束!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string url = UrlTextBox.Text.ToString();
            if (url == "")
            {
                MessageBox.Show("请输入URL地址!");
            }
           string filename = url.Substring(url.LastIndexOf('/') + 1, url.Length - url.LastIndexOf('/') - 1);

            string wechatid = NewWechatID.Text.ToString();
            if (wechatid == "")
            {
                MessageBox.Show("请输入要替换的微信ID!");
            }
            string telid = NewTelID.Text.ToString();
            //if (telid == "")
            //{
            //    MessageBox.Show("请输入要替换的手机ID!");
            //}
            string htmlcontent = Web.WebHandler.GetHtmlStr(url,Encoding.Default.ToString());

            Regex r = new Regex("(?<=var wx = \").*?(?=\";)", RegexOptions.IgnoreCase);
            string result = r.Replace(htmlcontent, wechatid);
            Regex rtel = new Regex("(?<=var tel = \").*?(?=\";)", RegexOptions.IgnoreCase);
            result = rtel.Replace(result, telid);
            // 生成文件
            Log(result, filename);
            MessageBox.Show("生成文件成功!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string url = UrlTextBox.Text.ToString();
            if (url == "")
            {
                MessageBox.Show("请输入URL地址!");
            }
            string filename = url.Substring(url.LastIndexOf('/') + 1, url.Length - url.LastIndexOf('/') - 1);
            FileInfo file = new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + "/Files/" + filename);
            if (!file.Exists) {
                MessageBox.Show("文件不存在!");
            }
            else
            {
                string generateFile = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "/Files/" + filename);
                Regex r = new Regex("(?<=var wx = \").*?(?=\";)", RegexOptions.IgnoreCase);
                Regex rtel = new Regex("(?<=var tel = \").*?(?=\";)", RegexOptions.IgnoreCase);
                ResultWeChat.Text = r.Match(generateFile).Value;
                ResultTel.Text = rtel.Match(generateFile).Value;
                MessageBox.Show("检测完成!");
            }
        }

    
    }
}
