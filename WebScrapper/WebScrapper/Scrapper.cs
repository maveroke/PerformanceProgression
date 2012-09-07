using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WebScrapper
{
    class Scrapper
    {
        string athleteBirthDate = "";
        int ageOfCollection;
        int nameChange;
        WebBrowser webBrowser;

        public void AthleteToCollect(string AthleteName,WebBrowser browser)
        {
            webBrowser = browser;
            foreach (HtmlElement asd in webBrowser.Document.All.GetElementsByName("Name"))
            {
                asd.InnerText = AthleteName;
            }
            accept();
            comboBox();
        }
        private void accept()
        {
            foreach (HtmlElement asd in webBrowser.Document.All)
            {
                if (asd.GetAttribute("type").Equals("submit"))
                {
                    asd.InvokeMember("click");
                    break;
                }
            }
        }

        private void comboBox()
        {
            int position = AgeStartingPoint();

            foreach (HtmlElement asd in webBrowser.Document.All)
            {
                if (asd.GetAttribute("name").Equals("menupi9"))
                {
                    for (; position > 0; position--)
                    {
                        nameChange = position;
                        asd.Children[position].SetAttribute("selected", "x");
                        asd.RaiseEvent("onchange");
                        
                        MessageBox.Show("><>");
                    }
                    break;
                }
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
            string result = webBrowser.DocumentText;
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

    }
}
