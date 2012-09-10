﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace WebScrapper
{
    public partial class Form1 : Form
    {
        protected Uri ur = new Uri("http://www.tilastopaja.org/");
        //protected Uri ur = new Uri("http://www.ThisIsWhyImBroke.com/");
        string athleteBirthDate = "";
        int ageOfCollection;
        int nameChange;
        string nameOfAthlete;

        public Form1()
        {
            InitializeComponent();
            
            //WebBrowser browser = new WebBrowser();
            //browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(ur);
            textBox1.Text = "Glen Ballam";
            nameOfAthlete = textBox1.Text;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int position = AgeStartingPoint();
            foreach (HtmlElement asd in webBrowser1.Document.All.GetElementsByName("Name"))
            {
                asd.InnerText = textBox1.Text;
            }
            accept();
            Uri theAthletePage = webBrowser1.Url;

            for (; position > 0; position--)
            {
                YearCollection yc = new YearCollection();
                yc.athletePage = theAthletePage;
                yc.position = position;
                Thread thrd = new Thread(new ThreadStart(yc.begin));
                thrd.Name = nameOfAthlete +" "+ position;

            }
        }
        /// <summary>
        /// Collects the age at the top of the page
        /// Adds 10 years as a start point of when the athlete started performing
        /// Figures out which year in the combobox is the start
        /// </summary>
        /// <returns>The position in the list where the year is stored</returns>
        private int AgeStartingPoint()
        {
            string result = webBrowser1.DocumentText;
            int startIndex = result.IndexOf("</a>&nbsp;&nbsp;") + 16;
            int endIndex = result.IndexOf("</font>", startIndex);

            athleteBirthDate = result.Substring(startIndex, endIndex - startIndex);
            result = athleteBirthDate.Substring(4);
            startIndex = result.IndexOf(" ") + 1;
            result = result.Substring(startIndex);
            int startAge = Convert.ToInt32(result);
            ageOfCollection = startAge + 1910;
            return DateTime.Today.Year - ageOfCollection + 1;
        }        

        private void accept()
        {
            foreach (HtmlElement asd in webBrowser1.Document.All)
            {
                if (asd.GetAttribute("type").Equals("submit"))
                {
                    asd.InvokeMember("click");
                    break;
                }
            }
        }
    }
}
