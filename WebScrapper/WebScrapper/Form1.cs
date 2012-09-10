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
using System.Threading;

namespace WebScrapper
{
    public partial class Form1 : Form
    {
        protected Uri ur = new Uri("http://www.tilastopaja.org/");
        //protected Uri ur = new Uri("http://www.ThisIsWhyImBroke.com/");
        string athleteBirthDate = "";
        int ageOfCollection;
        bool treset = false;
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

            foreach (HtmlElement asd in webBrowser1.Document.All.GetElementsByName("Name"))
            {
                asd.InnerText = textBox1.Text;
            }

            accept();
            treset = true;
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

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (treset)
            {
                MessageBox.Show("");
                Uri theAthletePage = webBrowser1.Url;
                int position = AgeStartingPoint();
                for (; position > 0; position--)
                {
                    YearCollection yc = new YearCollection();
                    yc.athletePage = theAthletePage;
                    yc.position = position;
                    Thread thrd = new Thread(new ThreadStart(yc.begin));
                    thrd.Name = nameOfAthlete + " " + position;
                    thrd.Start();
                }
            }
        }
    }
    class YearCollection
    {
        int nameChange;
        WebBrowser webBrowser = new WebBrowser();
        public Uri athletePage;
        public int position;
        private bool treset = false;
        public void begin()
        {
            Thread thr = Thread.CurrentThread;
            webBrowser.Navigate(athletePage);
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////WebClient
            //google C# using threads how do i open multiple webbrowsers
            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
            System.Diagnostics.Debug.WriteLine(thr.Name + " has begun threading");

            foreach (HtmlElement asd in webBrowser.Document.All)
            {
                if (asd.GetAttribute("name").Equals("menupi9"))
                {
                    NavigateToAgePage(position, asd);
                    break;
                }
            }
            System.Diagnostics.Debug.WriteLine(thr.Name + " is navigating to its page");
            treset = true;
        }
        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Thread thr = Thread.CurrentThread;
            if (treset)
            {
                System.Diagnostics.Debug.WriteLine(thr.Name + " has navigated");
                CollectData();
            }
        }
        private void NavigateToAgePage(int position, HtmlElement asd)
        {
            nameChange = position;
            asd.Children[position].SetAttribute("selected", "x");
            asd.RaiseEvent("onchange");
        }


        public void CollectData()
        {
            Thread thr = Thread.CurrentThread;
            System.Diagnostics.Debug.WriteLine(thr.Name + " is working!");

            string result = webBrowser.DocumentText;
            int startIndex = result.IndexOf("help: click on placing to see event results in the competition.") + 64;
            int endIndex = result.IndexOf("</td></table></td></tr>", startIndex);

            string end = result.Substring(startIndex, endIndex - startIndex);

            StreamWriter sw = new StreamWriter(thr.Name + ".txt");
            sw.Write(end);
            sw.Close();

            System.Diagnostics.Debug.WriteLine(thr.Name + " FINISHED!");
        }
    }
}
