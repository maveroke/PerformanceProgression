using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WebScrapper
{
    class YearCollection
    {
        public void CollectData(string Name,WebBrowser wb)
        {
            string result = wb.DocumentText;
            int startIndex = result.IndexOf("help: click on placing to see event results in the competition.") + 64;
            int endIndex = result.IndexOf("</td></table></td></tr>", startIndex);

            string end = result.Substring(startIndex, endIndex - startIndex);

            StreamWriter sw = new StreamWriter(Name + "Athlete.txt");
            sw.Write(end);
            sw.Close();
        }
    }
}
