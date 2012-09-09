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
        public void CollectData(string Name,WebBrowser wb)
        {
            Thread thr = Thread.CurrentThread;
            System.Diagnostics.Debug.WriteLine(thr.Name + " is working!");

            string result = wb.DocumentText;
            int startIndex = result.IndexOf("help: click on placing to see event results in the competition.") + 64;
            int endIndex = result.IndexOf("</td></table></td></tr>", startIndex);

            string end = result.Substring(startIndex, endIndex - startIndex);

            StreamWriter sw = new StreamWriter(Name + "Athlete.txt");
            sw.Write(end);
            sw.Close();

            System.Diagnostics.Debug.WriteLine(thr.Name + " FINISHED!");
        }
    }
}
