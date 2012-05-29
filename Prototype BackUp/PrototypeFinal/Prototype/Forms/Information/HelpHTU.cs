using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype.Forms.Information
{
    public partial class HelpHTU : Form
    {
        public HelpHTU()
        {
            InitializeComponent();
            webBrowser1.Url = new Uri(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PerformanceProgression\\Saved\\" + "Help.html"));
        }
    }
}
