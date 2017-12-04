using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinIIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReaderSite_Click(object sender, EventArgs e)
        {
            IISHelper helper = new IISHelper();
            var alist = helper.GetAppliction();

            foreach (var item in alist)
            {
                listBox1.Items.Add("alist-" + item);
            }

            var wlist = helper.GetWebSites();

            foreach (var item in wlist)
            {
                listBox1.Items.Add("wlist-" + item);
            }


        }
    }
}
