using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoolPrintPreview
{
    public partial class Key : Form
    {
        private bool HShow = true;
        public Point locate,size;
        public Key()
        {
            InitializeComponent();
        }

        private void Key_Load(object sender, EventArgs e)
        {
            //Label lab = new Label();
            //lab.AutoSize = true;
            //lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 70F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //lab.Location = new System.Drawing.Point(0, 0);
            //lab.Name = "label3";
            //lab.Size = new System.Drawing.Size(200, 50);
            //lab.TabIndex = 2;
            //lab.Text = "9th - 16th at OG or WC";
            //// 
            //// Key
            //// 
            //this.Controls.Add(lab);
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HShow) 
            {
                //Hide

                this.Width = 100;
                this.Height = 50;
                this.Location = new Point(locate.X + 50, locate.Y + size.Y - 60);
                hideToolStripMenuItem.Text = "Show";
                HShow = !HShow;
            }
            else 
            {
                //Show
                this.Width = 306;
                this.Height = 224;
                if (this.locate.Y < 200) 
                {
                    this.Location = new Point(locate.X + size.X / 2 - this.Width / 2, locate.Y + size.Y / 2);
                }
                else 
                {
                    this.Location = new Point(locate.X + size.X / 2 - this.Width / 2, locate.Y + size.Y / 2 - this.Height / 2);

                }
                hideToolStripMenuItem.Text = "Hide";
                HShow = !HShow;
            }
            //Do the Hide thing
            //If hidden do the Show thing
        }
        public void HideThis() 
        {
            this.Width = 100;
            this.Height = 50;
            this.Location = new Point(locate.X + 50, locate.Y + size.Y - 60);
            hideToolStripMenuItem.Text = "Show";
            HShow = !HShow;
        }
        public void PositionChanged()
        {
            if (!HShow)
            {
                //Hide

                this.Width = 100;
                this.Height = 50;
                this.Location = new Point(locate.X + 50, locate.Y + size.Y - 60);
            }
            else
            {
                //Show

                this.Width = 306;
                this.Height = 224;
                this.Location = new Point(locate.X + size.X / 2 - this.Width / 2, locate.Y + size.Y / 2 - this.Height / 2);
            }
        }
    }
}
