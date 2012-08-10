using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using mdisample;
using Prototype.Forms.Authors;
using System.IO;

namespace Prototype
{
    public partial class IntroForm : Form
    {
        int count = 0;
        public IntroForm()
        {
            InitializeComponent();            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            MainFormSample msp = new MainFormSample();
            msp.Show();
            timer1.Stop();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count > 80)
            {
                this.Opacity -= 0.01;
            }
            if (this.Opacity <= 0)
            {
                this.Hide();
                MainFormSample msp = new MainFormSample();
                msp.Show();
                timer1.Stop();
            }
        }
    }
}
