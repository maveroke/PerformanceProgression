using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WebScrapper
{
    class YearCollection
    {
        string athleteLocal = "";
        int ageOfCollection;
        int nameChange;
        WebBrowser webBrowser;
        public Uri athletePage; 
        public int position;
        public void begin()
        {
            webBrowser = new WebBrowser();
            webBrowser.Navigate(athletePage);
            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);


            foreach (HtmlElement asd in webBrowser.Document.All)
            {
                if (asd.GetAttribute("name").Equals("menupi9"))
                {
                    NavigateToAgePage(position, asd);
                    break;
                }
            }

        }
        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            CollectData();
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
