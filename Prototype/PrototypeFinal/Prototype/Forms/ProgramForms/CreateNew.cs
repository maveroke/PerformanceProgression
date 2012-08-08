using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using EmbeddedExcel;
using System.IO;
using FileReader_Writer;

namespace Prototype
{
    public partial class CreateNew : Form
    {
        private bool okButtonB = false;
        private string locationChosen;
        private string formName,chartName,DoB,eventName;
        public bool fileAlreadyExists = false;

        public CreateNew()
        {
            InitializeComponent();
            SetMyCustomFormat();
        }

        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = " dd, MMMM, yyyy";
        }

        private bool correctValuesInName()
        {
            return textBoxName.Text.All(c => Char.IsLetterOrDigit(c) || c == '_' || c == ' ');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (correctValuesInName())
            {
                this.Hide();
                
                String myName, myDate, mySex, myEvent, track_Field;
                getDataOffForm(out myName, out myDate, out mySex, out myEvent, out track_Field);

                formName = myName + "_" + myEvent;
                eventName = myEvent;
                chartName = myEvent.Substring(1) + " Performance Progression for  " + myName;
                //newName = locationOfFile
                string oldName = myEvent + ".xlsx";
                string newName = myName + "_" + myEvent + ".xlsx";
                //[LocalAppDataFolder]\[ProductName]\Saved
                //string newLocal = "C:\\Users\\Joris\\Documents\\Visual Studio 2010\\Projects\\PrototypeFinal\\Prototype\\bin\\Release\\Saved\\M\\Track\\" + newName;
                string newLocal = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PerformanceProgression\\Saved\\" + mySex + "\\" + track_Field + "\\" + newName);

                string oldLocal = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Made\\" + mySex + "\\" + track_Field + "\\" + oldName);
                //string newLocal = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Saved\\" + mySex + "\\" + track_Field + "\\"+newName);
                DoB = myDate;
                try
                {
                    File.Copy(oldLocal, newLocal, true);
                    locationChosen = newLocal;
                    CSVWriter(myName, myDate, mySex, myEvent, newLocal);
                    okButtonB = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("File is already open");
                }
            }
            else
            {
                MessageBox.Show("Athlete Name error:" + "\r\n" + "Only \"A-Z\", \"0-9\" and \"_\" allowed.");
            }
        }
        /// <summary>
        /// writes the details to a CSV file to be read later
        /// </summary>
        /// <param name="myName">Athlete Name</param>
        /// <param name="myDate">Athlete DoB</param>
        /// <param name="mySex">Athlete sex</param>
        /// <param name="myEvent">Athlete event</param>
        /// <param name="newLocal">File Location</param>
        private void CSVWriter(String myName, String myDate, String mySex, String myEvent, string newLocal)
        {
            string tempEvent = myEvent.Substring(1);
            string CSVtext = myName + "," + myDate + "," + mySex + "," + tempEvent + "," + newLocal;
            CSV csv = new CSV();
            csv.Write(CSVtext);
            fileAlreadyExists = csv.fileAlreadyExists;
        }
        public bool okButton()
        {
            return okButtonB;
        }
        public string getLocation()
        {
            return locationChosen;
        }
        public string getName()
        {
            return formName;
        }
        public string getChartName()
        {
            return chartName;
        }
        public bool getmale_Female()
        {
            return radioButtonM.Checked;
        }
        public string getDoB()
        {
            return DoB;
        }
        public string getEventName()
        {
            return eventName;
        }

        private void getDataOffForm(out String myName, out String myDate, out String mySex, out String myEvent, out String track_Field)
        {

            myName = textBoxName.Text;
            myDate = dateTimePicker.Value.ToShortDateString();
            if (radioButtonM.Checked)
                mySex = "M";
            else
                mySex = "W";

            myEvent = mySex + comboBoxEvent.Text;
            switch (comboBoxEvent.Text)
            {
                case "100m": 
                case "100m Hurdles":
                case "110m Hurdles":
                case "200m":
                case "400m": 
                case "400m Hurdles": 
                case "800m": 
                case "1500m": 
                case "3000m Steeple":
                case "5000m":
                case "10000m":
                    track_Field = "Track";
                break;
                default:
                    track_Field = "Field";
                    break;
            }
        }

        //Sorts out the combobox Heptathlon, Decathlon
        private void radioButtonM_CheckedChanged(object sender, EventArgs e)
        {
            int localON = 0;
            if (comboBoxEvent.Items.Contains("Decathlon"))
            {
                localON = comboBoxEvent.Items.IndexOf("Decathlon");
                comboBoxEvent.Items.RemoveAt(localON);
            }
            if (comboBoxEvent.Items.Contains("Heptathlon"))
            {
                localON = comboBoxEvent.Items.IndexOf("Heptathlon");
                comboBoxEvent.Items.RemoveAt(localON);
            }

            if (radioButtonF.Checked)
                comboBoxEvent.Items.Insert(localON,"Heptathlon");
            else
                comboBoxEvent.Items.Insert(localON,"Decathlon");




            int localES = 0;
            if (comboBoxEvent.Items.Contains("110m Hurdles"))
            {
                localES = comboBoxEvent.Items.IndexOf("110m Hurdles");
                comboBoxEvent.Items.RemoveAt(localES);
            }
            if (comboBoxEvent.Items.Contains("100m Hurdles"))
            {
                localES = comboBoxEvent.Items.IndexOf("100m Hurdles");
                comboBoxEvent.Items.RemoveAt(localES);
            }

            if (radioButtonF.Checked)
                comboBoxEvent.Items.Insert(localES, "100m Hurdles");
            else
                comboBoxEvent.Items.Insert(localES, "110m Hurdles");

            if(comboBoxEvent.Text.CompareTo("") == 0)
                comboBoxEvent.Text = "100m";

        }
    }
}
