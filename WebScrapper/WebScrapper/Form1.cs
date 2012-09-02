using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WebScrapper
{
    public partial class Form1 : Form
    {
        protected Uri ur = new Uri("http://www.tilastopaja.org/");
        //protected Uri ur = new Uri("http://www.ThisIsWhyImBroke.com/");

        public Form1()
        {
            InitializeComponent();
            
            //WebBrowser browser = new WebBrowser();
            //browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Navigate(ur);
            textBox1.Text = "Glen Ballam";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Add(textBox1.Text);
            foreach (HtmlElement asd in webBrowser1.Document.All.GetElementsByName("Name"))
            {
                asd.InnerText = textBox1.Text;
            }

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            //http://stackoverflow.com/questions/3640236/converting-htmldocument-domdocument-to-string
            string result = webBrowser1.DocumentText;

            StreamWriter sw = new StreamWriter("website.txt");
            sw.Write(result);
            sw.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = webBrowser1.DocumentText;
            int startIndex = result.IndexOf("help: click on placing to see event results in the competition.") + 64;
            int endIndex = result.IndexOf("</td></table></td></tr>",startIndex);
           
            string end = result.Substring(startIndex,endIndex-startIndex);
            
            StreamWriter sw = new StreamWriter("website.txt");
            sw.Write(end);
            sw.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (HtmlElement asd in webBrowser1.Document.All)
            {
                if (asd.GetAttribute("name").Equals("menupi9"))
                {
                    asd.Children[3].SetAttribute("selected", "x");
                    asd.RaiseEvent("onchange");
                    break;
                }
            }
        }
    }
}
