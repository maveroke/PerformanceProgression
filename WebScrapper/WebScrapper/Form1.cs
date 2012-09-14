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
        int positionYear;
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



        private void button5_Click(object sender, EventArgs e)
        {
            nameOfAthlete = textBox1.Text;
            progressBar1.Value = 0;
            foreach (HtmlElement asd in webBrowser1.Document.All.GetElementsByName("Name"))
            {
                asd.InnerText = textBox1.Text;
            }

            accept();
            treset = true;
            ///I have a solution
            ///The URL of each page looks like this...
            ///
            ///http://www.tilastopaja.org/db/atm.php?ID=96815&Odd=33
            ///http://www.tilastopaja.org/db/atm.php?ID=96815&Season=2000&Odd=33
            ///http://www.tilastopaja.org/db/atm.php?ID=96815&Season=2001&Odd=33
            ///http://www.tilastopaja.org/db/atm.php?ID=96815&Season=2002&Odd=33
            ///focussing on this section here                ^^^^^^^^^^^^
            ///so the solution is to get the URL, cut it up, add the &Season=XXXX
            ///and doneskis for Threading!!!
                //for (; positionYear > 0; positionYear--)
                //{
                //    foreach (HtmlElement asd in webBrowser1.Document.All)
                //    {
                //        if (asd.GetAttribute("name").Equals("menupi9"))
                //        {
                //            NavigateToAgePage(positionYear, asd);
                //            break;
                //        }
                //    }
                //    list[positionYear - 1] = Convert.ToString(webBrowser1.Url);
                //}
            //http://www.tilastopaja.org/db/atm.php?ID=96815&Odd=33
            //http://www.tilastopaja.org/db/atm.php?ID=96815&Season=2000&Odd=33

            //list = 
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
                if (webBrowser1.Url.ToString().Contains("ID="))
                {
                    positionYear = AgeStartingPoint();
                    //MessageBox.Show(position + "");

                    string urlString = webBrowser1.Url.ToString();
                    int posSeasonData = urlString.IndexOf("&") + 1;
                    int year = ageOfCollection;
                    int yearName = year;
                    int i = 0;
                    for (; positionYear > 0; positionYear--)
                    {
                        urlString = urlString.Substring(0, posSeasonData) + "Season=" + year + "&Odd=33";
                        CollectData(urlString, year);
                        year++;
                        progressBar1.Value = 100 / positionYear;
                        i++;
                    }
                    MessageBox.Show("Athlete collection complete");
                }
                else
                {
                    MessageBox.Show("More than one athlete avaliable!");
                }
            }
        }
        public void CollectData(string value,int yearName)
        {
            // Open the requested URL
            WebRequest req = WebRequest.Create(value);

            // Get the stream from the returned web response
            StreamReader stream = new StreamReader(req.GetResponse().GetResponseStream());

            // Get the stream from the returned web response
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string strLine;
            // Read the stream a line at a time and place each one
            // into the stringbuilder
            while ((strLine = stream.ReadLine()) != null)
            {
                // Ignore blank lines
                if (strLine.Length > 0)
                    sb.Append(strLine);
            }
            // Finished with the stream so close it now
            stream.Close();

            string result = sb.ToString();
            if(!result.Contains("No results during")){
            int startIndex = result.IndexOf("help: click on placing to see event results in the competition.") + 64;
            int endIndex = result.IndexOf("</td></table></td></tr>", startIndex);

            string end = result.Substring(startIndex, endIndex - startIndex);

            StreamWriter sw = new StreamWriter(nameOfAthlete+"_"+yearName + ".txt");
            sw.Write(end);
            sw.Close();
            }
        }
        private void NavigateToAgePage(int position, HtmlElement asd)
        {
            asd.Children[position].SetAttribute("selected", "x");
            asd.RaiseEvent("onchange");
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }        

//    class YearCollection
//    {
//        int nameChange;
//        WebBrowser webBrowser = new WebBrowser();
//        public Uri athletePage;
//        public int position;
//        private bool treset = false;
//        public void begin()
//        {
//            Thread thr = Thread.CurrentThread;
//            webBrowser.Navigate(athletePage);
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////WebClient
//            //google C# using threads how do i open multiple webbrowsers
//            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
//            System.Diagnostics.Debug.WriteLine(thr.Name + " has begun threading");

//            System.Diagnostics.Debug.WriteLine(thr.Name + " is navigating to its page");
//            treset = true;
//        }
//        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
//        {
//            Thread thr = Thread.CurrentThread;
//            if (treset)
//            {
//                System.Diagnostics.Debug.WriteLine(thr.Name + " has navigated");
//                CollectData();
//            }
//        }



//        public void CollectData()
//        {
//            Thread thr = Thread.CurrentThread;
//            System.Diagnostics.Debug.WriteLine(thr.Name + " is working!");

//            string result = webBrowser.DocumentText;
//            int startIndex = result.IndexOf("help: click on placing to see event results in the competition.") + 64;
//            int endIndex = result.IndexOf("</td></table></td></tr>", startIndex);

//            string end = result.Substring(startIndex, endIndex - startIndex);

//            StreamWriter sw = new StreamWriter(thr.Name + ".txt");
//            sw.Write(end);
//            sw.Close();

//            System.Diagnostics.Debug.WriteLine(thr.Name + " FINISHED!");
//        }
//    }
}
