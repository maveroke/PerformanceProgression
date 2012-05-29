using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Prototype.Forms.Authors
{
    public partial class Authors : Form
    {
        public Authors()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoreDetail md = new MoreDetail("Stephen (Steve) Hollings.");
            md.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoreDetail md = new MoreDetail("Professor Patria Hume.");
            md.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MoreDetail md = new MoreDetail("Professor Will Hopkins.");
            md.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MoreDetail md = new MoreDetail("Michael Whitehead.");
            md.Show();
            this.Close();
        }
    }
}
