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
    public partial class MoreDetail : Form
    {

        public MoreDetail()
        {
            InitializeComponent();
        }

        public MoreDetail(string p)
        {
            InitializeComponent();
            
            switch(p){
                case "Stephen (Steve) Hollings.":
                    this.Text = p.TrimEnd('.');
                    panelBG.BackgroundImage = global::Prototype.Properties.Resources.Person_1;
                    ReadData(p);
                    break;
                case "Professor Patria Hume.":
                    this.Text = p.TrimEnd('.');
                    panelBG.BackgroundImage = global::Prototype.Properties.Resources.Person_2;
                    ReadData(p);
                    break;
                case "Professor Will Hopkins.":
                    this.Text = p.TrimEnd('.');
                    panelBG.BackgroundImage = global::Prototype.Properties.Resources.Person_3;
                    ReadData(p);
                    break;
                case "Michael Whitehead.":
                    this.Text = p.TrimEnd('.');
                    panelBG.BackgroundImage = global::Prototype.Properties.Resources.Person_4;
                    panelBG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    ReadData(p);
                    break;
            }
        }

        private void MoreDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            Authors aut = new Authors();
            aut.Show();
        }
        private void ReadData(string nameOfPerson)
        {
            int countBlanks = 0;
            bool checkExists = false;
            bool firstIgnore = true;

            // Read the file and display it line by line.
            string oldLocal = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "AuthorsInfo.txt");

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
                        else if (line.Contains(nameOfPerson))//name is found
                        {
                            checkExists = true;
                            string[] temp = line.Split('#');
                            textBoxTitle.Text = temp[0].TrimEnd('.');
                            textBoxTitle.Text = textBoxTitle.Text + "\r\n\r\n";
                            textBoxTitle.AppendText(temp[1]);
                           
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

        private void panelBG_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
