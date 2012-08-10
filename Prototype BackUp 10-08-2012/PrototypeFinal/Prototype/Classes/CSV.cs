using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace FileReader_Writer
{
    class CSV
    {
        public bool fileAlreadyExists = false;
        private string oldLocal = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PerformanceProgression\\Saved\\"+"CSV.txt");
        
        /// <summary>
        /// reads the file and adds it to the array
        /// </summary>
        /// <param name="txtLine">the information writen to the CSV file</param>
        public void Write(string txtLine)
        {
            //SaveToFile

            ArrayList temp = new ArrayList();

            ///reads the file 
            ///adds it to the array
            StreamReader inputStream = File.OpenText(oldLocal);
            string line;
            line = inputStream.ReadLine();
            for (int i = 0; line != null; i++)
            {
                temp.Insert(i, line);
                line = inputStream.ReadLine();
            }
            inputStream.Close();


            StreamWriter outputStream = File.CreateText(oldLocal);
            for (int g = 0; g < temp.Count; g++)
            {
                if (temp[g] != null && txtLine.CompareTo(temp[g]) != 0)
                {
                    outputStream.WriteLine(temp[g]);
                }
                if (txtLine.CompareTo(temp[g]) == 0)
                {
                    fileAlreadyExists = true;
                    MessageBox.Show("Athlete for this event already exists. Either create a new athlete or Open the original");
                }
            }
            outputStream.WriteLine(txtLine);
            outputStream.Close();
        }
        public void CreateNewFile(string fileName)
        {
            //CreateNewCSV
            StreamWriter outputStream = File.CreateText(oldLocal);
            outputStream.Close();
        }
        /// <summary>
        ///Only reads the txt file
        ///does nothing else
        ///returns the array
        /// </summary>
        /// <returns></returns>
        public ArrayList Read(){

            ArrayList arTemp = new ArrayList();
            StreamReader inputStream = File.OpenText(oldLocal);
            string line;
            line = inputStream.ReadLine();
            for (int i = 0; line != null;i++)
            {
                arTemp.Insert(i, line);
                line = inputStream.ReadLine();
            }
            inputStream.Close();
            return arTemp;
    }
        /// <summary>
        /// Deletes a List of Strings from the CSV File
        /// </summary>
        /// <param name="DeleteItems"></param>
        public void Delete(List<string> DeleteItems)
        {
            //SaveToFile
            try
            {
                ArrayList temp = new ArrayList();
                ///reads the file 
                ///adds it to the array
                StreamReader inputStream = File.OpenText(oldLocal);
                string line;
                line = inputStream.ReadLine();
                for (int i = 0; line != null; i++)
                {
                    bool ignore = false;
                    foreach (string deleteItem in DeleteItems)
                    {
                        string[] breakUp = line.Split(',');
                        string itemName = breakUp[0] + "/" + breakUp[3];
                        if (itemName.CompareTo(deleteItem) == 0)
                        {
                            try
                            {
                                File.Delete(breakUp[4]);
                                temp.Insert(i, "");
                                ignore = true;
                                break;
                            }
                            catch
                            {
                                MessageBox.Show("File :" + breakUp[0] + " " + breakUp[3] + " is in use. Close file before deleting");
                            }


                        }
                    }
                    if (!ignore)
                    {
                        temp.Insert(i, line);
                    }
                    line = inputStream.ReadLine();
                }
                inputStream.Close();


                StreamWriter outputStream = File.CreateText(oldLocal);
                for (int g = 0; g < temp.Count; g++)
                {
                    if (temp[g] != null && temp[g] != "")
                    {
                        outputStream.WriteLine(temp[g]);
                    }
                }
                outputStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("CSV ERROR: " + e);
            }
            }

    }
}
