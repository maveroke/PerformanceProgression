using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype
{
    public partial class DataUsed : Form
    {
        public DataUsed()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser_Data.Url = new Uri(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data_Volume.html"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser_Data.Url = new Uri(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data_Comparison.html"));

        }
    }
}
