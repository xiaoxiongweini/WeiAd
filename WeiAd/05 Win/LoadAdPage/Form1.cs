using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadAdPage
{
    public partial class Form1 : Form
    {
        class IpProxyResult
        {
            public string code { get; set; }

            public bool success { get; set; }

            public string msg { get; set; }

            public List<IpInfo> data { get; set; }
        }

        class IpInfo
        {
            public string port { get; set; }

            public string ip { get; set; }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private List<IpInfo> GetIps()
        {
            List<IpInfo> list = new List<IpInfo>();

            string url = "http://api.zdaye.com/?api=201710131331268754&pw=111111&gb=2&rtype=1";

            string html = DN.Framework.Utility.WebClientHelper.GetSend(url);

            var tlist = html.Split(System.Environment.NewLine.ToArray());
            foreach (var ips in tlist)
            {
                try
                {

                    if (!string.IsNullOrEmpty(ips))
                    {
                        IpInfo item = new IpInfo();

                        item.ip = ips.Split(':')[0];
                        item.port = ips.Split(':')[1];
                        list.Add(item);

                    }
                }
                catch 
                {
                     
                }
            }

            return list;
        }

        private void LoadIp()
        {
            if (ltIp.Items.Count == 0)
            {
                var list = GetIps();

                foreach (var item in list)
                {
                    ltIp.Items.Add(string.Format("{0}:{1}", item.ip, item.port));
                }
            }
        }

        private List<string> GetUserAgents()
        {
            List<string> list = new List<string>();

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\data\\sj.txt";
            if (!System.IO.File.Exists(path))
            {
                path = path.Replace("\\bin\\Debug\\", "");
            }
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                string str = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    str = reader.ReadLine();
                    if (!string.IsNullOrEmpty(str))
                    {
                        list.Add(str);
                    }
                }

            }
            return list;
        }

        List<string> m_UserAgent = new List<string>();
        Random m_rd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            m_UserAgent = GetUserAgents();

            Start();
        }

        void Start()
        {
            LoadIp();
            if (ltIp.Items.Count != 0)
            {
                txtIp.Text = ltIp.Items[0].ToString();
                ltIp.Items.Remove(txtIp.Text);

                string proxy = this.txtIp.Text;
                //RefreshIESettings(proxy);

                IEProxy ie = new IEProxy(proxy);
                label1.Text = txtIp.Text + "=" + ie.RefreshIESettings().ToString();

                string useragent = m_UserAgent[m_rd.Next(m_UserAgent.Count)];
                webKitBrowser1.Url = new Uri(txtUrl.Text);
                webKitBrowser1.UserAgent = useragent;
                webKitBrowser1.DocumentCompleted += WebKitBrowser1_DocumentCompleted;

                //WebBrowse.Url = null;
                //WebBrowse.Navigate(txtUrl.Text, null, null, "User-Agent:" + useragent);
                //WebBrowse.ScriptErrorsSuppressed = true;

                WebFrm web = new WebFrm(txtUrl.Text + "&webkit=1", useragent, proxy);
                web.Show();
            }
        }

        private void WebKitBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            System.Threading.Thread.Sleep(2 * 1000);
            Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //设置代理
            string proxy = this.txtIp.Text;
            //RefreshIESettings(proxy);
            IEProxy ie = new IEProxy(proxy);
            MessageBox.Show(ie.RefreshIESettings().ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IEProxy ie = new IEProxy(null);
            ie.DisableIEProxy();
        }

        private void WebBrowse_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //加载完成
            //System.Threading.Thread.Sleep(5 * 1000);
            Start();
        }


        private void WebBrowserDocumentCompletedEventHandler(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //加载完成
            System.Threading.Thread.Sleep(2 * 1000);
            Start();
        }
    }
}
