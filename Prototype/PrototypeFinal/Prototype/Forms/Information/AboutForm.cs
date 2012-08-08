using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Prototype.Forms.Authors
{
    public partial class AboutForm : Form
    {
        // Read the file and display it line by line.
        private string oldLocal = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "AuthorsInfo.txt");

        
        public AboutForm()
        {
            
            InitializeComponent();
            
            int countBlanks = 0;
            bool checkExists = false;
            bool firstIgnore = true;

            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(oldLocal))
                {
                    String line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (checkExists)
                        {
                            textBoxInfo.AppendText(line);
                        }
                        else if (line.Contains("Introduction"))//name is found
                        {
                            checkExists = true;
                            string[] temp = line.Split('#');
                            textBoxInfo.Text = temp[0].TrimEnd('.');
                            textBoxInfo.Text = textBoxInfo.Text + "\r\n\r\n";
                            //textBoxTitle.AppendText(temp[1]);
                        }
                        if (!checkExists) { 
                        }
                        else
                        {
                            if (line.CompareTo("") == 0)//two spaces found
                            {
                                countBlanks++;
                                if (countBlanks == 2) { break; }
                                //end writing to screen and exit loop
                            }
                            else
                            {
                                if (!firstIgnore)
                                {
                                    countBlanks = 0;
                                    textBoxInfo.Text = textBoxInfo.Text + "\r\n\r\n";
                                }
                                firstIgnore = false;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            textBoxInfo.Select(0, 0);
        }
    }
}
