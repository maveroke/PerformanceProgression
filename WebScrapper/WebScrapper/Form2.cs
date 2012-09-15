using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebScrapper
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string athlete = textBox1.Text;
            listView1.Items.Add(athlete);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                item.Remove();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> temp = new List<string>(listView1.Items.Count);
            foreach (ListViewItem item in listView1.Items)
            {
                temp.Add(item.Text);
            }
            this.Hide();
            Form1 f = new Form1(temp);
            f.Show();
        }
    }
}
