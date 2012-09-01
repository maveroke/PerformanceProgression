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
            string sourceCode = WebWorkerClass.getSourceCode(ur);
            int startIndex = sourceCode.IndexOf("help: click on placing to see event results in the competition.")+64;
            int endIndex = sourceCode.IndexOf("</tr></tbody></table>");
            sourceCode = sourceCode.Substring(startIndex, sourceCode.Length - startIndex);
        }
        
    //private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    //{
    //WebBrowser browser = sender as WebBrowser;
    //HtmlElementCollection imgCollection = browser.Document.GetElementsByTagName("img");
    //WebClient webClient = new WebClient();

    //foreach (HtmlElement img in imgCollection)
    //{

    //        string url = img.GetAttribute("src");
    //        webClient.DownloadFile(url, url.Substring(url.LastIndexOf('/')));

    //}
    //}
    //    private void button2_Click(object sender, EventArgs e)
    //    {
    //        foreach (string s in listBox1.Items)
    //        {
                
    //            WebClient client = new WebClient();
    //            string downloadString = client.DownloadString(ur);
    //            MessageBox.Show(downloadString);
    //        }
    //    }


    }
}
