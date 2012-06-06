using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FileReader_Writer;

namespace Prototype
{
    public partial class Contents : Form
    {
        private Color panelListColor = Color.AliceBlue;


        public Contents()
        {
            InitializeComponent();
            HandleAboutForm();
            webBrowserHowToUse.Url = new Uri(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath,"HowToUse.html"));
            webBrowserAbout.Url = new Uri(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath,"Introduction.html"));
            OP_setUpOpen();
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2, 0);

        }

        private void label12_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        #region ContentsButtons

        /// <summary>
        /// Create New
        /// </summary>
        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (panelList1.BackColor != panelListColor)
            {
                returnToNormal();
                panelList1.BackColor = panelListColor;
                tabControlMVersion1.SelectTab("CreateNew");
            }
        }

        /// <summary>
        /// How To Use
        /// </summary>
        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            if (panelList3.BackColor != panelListColor)
            {
                returnToNormal();
                panelList3.BackColor = panelListColor;
                tabControlMVersion1.SelectTab("HowToUse");
            }
        }
        /// <summary>
        /// Data
        /// </summary>
        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            if (panelList4.BackColor != panelListColor)
            {
                returnToNormal();
                panelList4.BackColor = panelListColor;
                tabControlMVersion1.SelectTab("Data");
            }
        }
        /// <summary>
        /// About
        /// </summary>
        private void label6_MouseClick(object sender, MouseEventArgs e)
        {
            if (panelList5.BackColor != panelListColor)
            {
                HandleAboutForm();
                returnToNormal();
                panelList5.BackColor = panelListColor;
                tabControlMVersion1.SelectTab("About");

            }
        }
        /// <summary>
        /// Authors
        /// </summary>
        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            if (panelList6.BackColor != panelListColor)
            {
                upDateInfo("Stephen (Steve) Hollings.");
                returnToNormal();
                panelList6.BackColor = panelListColor;
                tabControlMVersion1.SelectTab("Authors");
            }
        }
        private void returnToNormal()
        {
            panelList1.BackColor = Color.FromName("Control");
            panelList3.BackColor = Color.FromName("Control");
            panelList4.BackColor = Color.FromName("Control");
            panelList5.BackColor = Color.FromName("Control");
            panelList6.BackColor = Color.FromName("Control");
        }
        #endregion

        #region CreateNew

        public bool CN_fileAlreadyExists = false;

        private string CN_formName, CN_DoB, CN_eventName, CN_locationChosen, CN_chartName;
        public string CN_getLocation()
        {
            return CN_locationChosen;
        }
        public string CN_getName()
        {
            return CN_formName;
        }
        public string CN_getChartName()
        {
            return CN_chartName;
        }
        public bool CN_getmale_Female()
        {
            return CNradioButtonM.Checked;
        }
        public string CN_getDoB()
        {
            return CN_DoB;
        }
        public string CN_getEventName()
        {
            return CN_eventName;
        }
        private bool correctValuesInName()
        {
            return CNtextBoxName.Text.All(c => Char.IsLetterOrDigit(c) || c == '_' || c == ' ');
        }
        private void CNbutton1_Click(object sender, EventArgs e)
        {
            if (correctValuesInName())
            {
                string CN_myName, CN_myDate, CN_mySex, CN_myEvent, CN_track_Field;
                //string myName, myDate, mySex, myEvent, track_Field;
                getDataOffForm(out CN_myName, out CN_myDate, out CN_mySex, out CN_myEvent, out CN_track_Field);

                CN_formName = CN_myName + "_" + CN_myEvent;
                CN_eventName = CN_myEvent;
                CN_chartName = CN_myEvent.Substring(1) + " Performance Progression for  " + CN_myName;
                //newName = locationOfFile
                string oldName = CN_myEvent + ".xlsx";
                string newName = CN_myName + "_" + CN_myEvent + ".xlsx";
                //[LocalAppDataFolder]\[ProductName]\Saved
                //string newLocal = "C:\\Users\\Joris\\Documents\\Visual Studio 2010\\Projects\\PrototypeFinal\\Prototype\\bin\\Release\\Saved\\M\\Track\\" + newName;
                string newLocal = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PerformanceProgression\\Saved\\" + CN_mySex + "\\" + CN_track_Field + "\\" + newName);

                string oldLocal = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Made\\" + CN_mySex + "\\" + CN_track_Field + "\\" + oldName);
                //string newLocal = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Saved\\" + mySex + "\\" + track_Field + "\\"+newName);
                CN_DoB = CN_myDate;
                try
                {
                    File.Copy(oldLocal, newLocal, true);
                    CN_locationChosen = newLocal;
                    CSVWriter(CN_myName, CN_myDate, CN_mySex, CN_myEvent, newLocal);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("" + ee);
                }
                CNNotifyButtonClicked(e);
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
            CN_fileAlreadyExists = csv.fileAlreadyExists;
        }

        private void getDataOffForm(out String myName, out String myDate, out String mySex, out String myEvent, out String track_Field)
        {
            //CNdateTimePicker.Value.ToShortDateString();
            myName = CNtextBoxName.Text;

            myDate = CNmonthCalendar.SelectionStart.ToShortDateString();

            if (CNradioButtonM.Checked)
                mySex = "M";
            else
                mySex = "W";

            myEvent = mySex + CNcomboBoxEvent.SelectedItem;
            string cerh = CNcomboBoxEvent.SelectedItem + "";
            switch (cerh)
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
        private void CNradioButtonM_CheckedChanged(object sender, EventArgs e)
        {
            int localON = 0;
            if (CNcomboBoxEvent.Items.Contains("Decathlon"))
            {
                localON = CNcomboBoxEvent.Items.IndexOf("Decathlon");
                CNcomboBoxEvent.Items.RemoveAt(localON);
            }
            if (CNcomboBoxEvent.Items.Contains("Heptathlon"))
            {
                localON = CNcomboBoxEvent.Items.IndexOf("Heptathlon");
                CNcomboBoxEvent.Items.RemoveAt(localON);
            }

            if (CNradioButtonF.Checked)
                CNcomboBoxEvent.Items.Insert(localON, "Heptathlon");
            else
                CNcomboBoxEvent.Items.Insert(localON, "Decathlon");




            int localES = 0;
            if (CNcomboBoxEvent.Items.Contains("110m Hurdles"))
            {
                localES = CNcomboBoxEvent.Items.IndexOf("110m Hurdles");
                CNcomboBoxEvent.Items.RemoveAt(localES);
            }
            if (CNcomboBoxEvent.Items.Contains("100m Hurdles"))
            {
                localES = CNcomboBoxEvent.Items.IndexOf("100m Hurdles");
                CNcomboBoxEvent.Items.RemoveAt(localES);
            }

            if (CNradioButtonF.Checked)
                CNcomboBoxEvent.Items.Insert(localES, "100m Hurdles");
            else
                CNcomboBoxEvent.Items.Insert(localES, "110m Hurdles");

            if (CNcomboBoxEvent.Text.CompareTo("") == 0)
                CNcomboBoxEvent.Text = "100m";

        }


        #region hideShow_CN_OP
        private void listView1_Enter(object sender, EventArgs e)
        {
            OPbutton3.Enabled = true;
            CNbutton1.Enabled = false;
        }

        private void CNtextBoxName_Enter(object sender, EventArgs e)
        {
            CNbutton1.Enabled = true;
            OPbutton3.Enabled = false;
        }
        #endregion

        #endregion

        #region Open

        private List<string> OP_selectedItemsR = new List<string>();

        private void OPbutton3_Click(object sender, EventArgs e)
        {
            OP_GetDataOffList();
            OPNotifyButtonClicked(e);
        }
        private void OP_GetDataOffList()
        {
            string itemName;
            //gets the index's of all the selected files in the ListView1
            List<string> w = new List<string>();
            foreach (ListViewItem item in OPlistView1.SelectedItems)
            {
                w.Add(item.SubItems[0].Text + "/" + item.SubItems[2].Text);
            }


            //writes the CSV string to a new List using the index's of the selected items
            CSV csv = new CSV();
            string[] stringArray = (string[])csv.Read().ToArray(typeof(string));

            foreach (string itemSelectedinLV in w)
            {
                foreach (string s in stringArray)
                {
                    string[] individ = s.Split(',');
                    itemName = individ[0] + "/" + individ[3];

                    if (itemName.CompareTo(itemSelectedinLV) == 0)
                    {
                        OP_selectedItemsR.Add(s);
                        break;
                    }
                }
            }
        }

        public List<string> OP_sItemsR()
        {
            return OP_selectedItemsR;
        }

        private void OP_setUpOpen()
        {
            string OP_itemName, OP_itemDoB, OP_itemSex, OP_itemEvent, OP_itemLocation;

            CSV csv = new CSV();
            string[] stringArray = (string[])csv.Read().ToArray(typeof(string));

            // Get current date.
            DateTime thisDay = DateTime.Today;
            // Display the date in a variety of formats.
            int i = 0;
            foreach (string s in stringArray)
            {
                string[] individ = s.Split(',');
                OP_itemName = individ[0];
                string[] temp = individ[1].Split('/');

                DateTime now = DateTime.Today;
                int age = now.Year;
                OP_itemDoB = Convert.ToString(age - Convert.ToInt32(temp[2]));
                OP_itemSex = individ[2];
                OP_itemEvent = individ[3];
                OP_itemLocation = individ[4];

                OPlistView1.Items.Add(new ListViewItem(new string[] { OP_itemName, OP_itemDoB, OP_itemEvent }));
                if (OP_itemSex.CompareTo("M") == 0)
                {
                    OPlistView1.Items[i].SubItems[0].BackColor = Color.LightSteelBlue;
                }
                else
                {
                    OPlistView1.Items[i].SubItems[0].BackColor = Color.Thistle;
                }
                i++;
            }

            //show DATETIMEPICKER to show the years view first
            //dateTimePicker1.Value = DateTime.Now;
        }

        #endregion

        #region About
        private void HandleAboutForm()
        {
            //string oldLocal = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "AuthorsInfo.txt");
            //int countBlanks = 0;
            //bool checkExists = false;
            //bool firstIgnore = true;

            //try
            //{
            //    // Create an instance of StreamReader to read from a file.
            //    // The using statement also closes the StreamReader.
            //    using (StreamReader sr = new StreamReader(oldLocal))
            //    {
            //        String line;
            //        // Read and display lines from the file until the end of
            //        // the file is reached.
            //        while ((line = sr.ReadLine()) != null)
            //        {
            //            if (checkExists)
            //            {
            //                AbtextBoxInfo.AppendText(line);
            //            }
            //            else if (line.Contains("Introduction"))//name is found
            //            {
            //                checkExists = true;
            //                string[] temp = line.Split('#');
            //                AbtextBoxInfo.Text = temp[0].TrimEnd('.');
            //                AbtextBoxInfo.Text = AbtextBoxInfo.Text + "\r\n\r\n";
            //                //textBoxTitle.AppendText(temp[1]);
            //            }
            //            if (!checkExists)
            //            {
            //            }
            //            else
            //            {
            //                if (line.CompareTo("") == 0)//two spaces found
            //                {
            //                    countBlanks++;
            //                    if (countBlanks == 2) { break; }
            //                    //end writing to screen and exit loop
            //                }
            //                else
            //                {
            //                    if (!firstIgnore)
            //                    {
            //                        countBlanks = 0;
            //                        AbtextBoxInfo.Text = AbtextBoxInfo.Text + "\r\n\r\n";
            //                    }
            //                    firstIgnore = false;
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    // Let the user know what went wrong.
            //    Console.WriteLine("The file could not be read:");
            //    Console.WriteLine(e.Message);
            //}
            //AbtextBoxInfo.Select(0, 0);
        }

        #endregion

        #region Authors

        private bool sect1 = true, sect2 = false, sect3 = false;
        private void panel8_MouseClick(object sender, MouseEventArgs e)
        {
            if (!sect1)
            {
                resetBlurredImages();
                ApanelAuthor1.BackgroundImage = global::Prototype.Properties.Resources.Person_1;
                upDateInfo("Stephen (Steve) Hollings.");
                sect1 = true;
            }
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            if (!sect2)
            {
                resetBlurredImages();
                ApanelAuthor2.BackgroundImage = global::Prototype.Properties.Resources.Person_2;
                upDateInfo("Professor Patria Hume.");
                sect2 = true;
            }
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            if (!sect3)
            {
                resetBlurredImages();
                ApanelAuthor3.BackgroundImage = global::Prototype.Properties.Resources.Person_3;
                upDateInfo("Professor Will Hopkins.");
                sect3 = true;
            }
        }
        private void resetBlurredImages()
        {
            ApanelAuthor1.BackgroundImage = global::Prototype.Properties.Resources.Author1Grey;
            ApanelAuthor2.BackgroundImage = global::Prototype.Properties.Resources.Author2Grey;
            ApanelAuthor3.BackgroundImage = global::Prototype.Properties.Resources.Author3Grey;
            sect1 = false;
            sect2 = false;
            sect3 = false;
        }
        private void upDateInfo(string p)
        {
            switch (p)
            {
                case "Stephen (Steve) Hollings.":
                    this.Text = p.TrimEnd('.');
                    ReadData(p);
                    break;
                case "Professor Patria Hume.":
                    this.Text = p.TrimEnd('.');
                    ReadData(p);
                    break;
                case "Professor Will Hopkins.":
                    this.Text = p.TrimEnd('.');
                    ReadData(p);
                    break;
            }
        }
        private void ReadData(string nameOfPerson)
        {
            int countBlanks = 0;
            bool checkExists = false;
            bool firstIgnore = true;
            AutextBoxInfo.Clear();
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
                            AutextBoxInfo.AppendText(line);
                        }
                        else if (line.Contains(nameOfPerson))//name is found
                        {
                            checkExists = true;
                            string[] temp = line.Split('#');
                            AutextBoxTitle.Text = temp[0].TrimEnd('.');
                            AutextBoxTitle.Text = AutextBoxTitle.Text + "\r\n\r\n";
                            AutextBoxTitle.AppendText(temp[1]);
                        }
                        if (!checkExists)
                        {
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
                                    AutextBoxInfo.Text = AutextBoxInfo.Text + "\r\n\r\n";
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
            AutextBoxInfo.Select(0, 0);
        }
        #endregion

        #region Help

        #endregion

        public event EventHandler CNButtonClicked;
        public event EventHandler OPButtonClicked;

        public void CNNotifyButtonClicked(EventArgs e)
        {
            if (CNButtonClicked != null)
                CNButtonClicked(this, e);

        }
        public void OPNotifyButtonClicked(EventArgs e)
        {
            if (OPButtonClicked != null)
                OPButtonClicked(this, e);

        }

        private void Data_button_DataUsed_Click(object sender, EventArgs e)
        {
            webBrowser_Data.Url = new Uri(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data_Volume.html"));

        }

        private void Data_button_Comparison_Click(object sender, EventArgs e)
        {
            webBrowser_Data.Url = new Uri(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data_Comparison.html"));

        }



        ///// <summary>
        ///// DataGridData_Genders.txt
        ///// DataGridData_Volume.txt
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="table"></param>
        //private void Data_PopulateTables(string name, DataGridView table)
        //{
        //    string fileName = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, name);
        //    var rows = System.IO.File.ReadAllLines(fileName);
        //    Char[] separator = new Char[] { '|' };
        //    DataTable tbl = new DataTable(fileName);
        //    if (rows.Length != 0)
        //    {
        //        foreach (string headerCol in rows[0].Split(separator))
        //        {
        //            DataGridViewTextBoxColumn temp = new DataGridViewTextBoxColumn();
        //            temp.HeaderText = headerCol;
        //            table.Columns.Add(temp);
        //            //tbl.Columns.Add(new DataColumn(headerCol));
        //        }
        //        if (rows.Length > 1)
        //        {
        //            for (int rowIndex = 1; rowIndex < rows.Length; rowIndex++)
        //            {
        //                table.Rows.Add();
        //                //var newRow = tbl.NewRow();
        //                var cols = rows[rowIndex].Split(separator);
        //                for (int colIndex = 0; colIndex < cols.Length; colIndex++)
        //                {
        //                    table[colIndex, (rowIndex - 1)].Value = cols[colIndex];
        //                    if (cols[colIndex].CompareTo("") == 0) table.Rows[rowIndex - 1].Height = 4;
        //                    if (cols[colIndex].Contains("Total")) table.Rows[rowIndex - 1].DefaultCellStyle.BackColor = Color.LemonChiffon;
        //                    //newRow[colIndex] = cols[colIndex];
        //                }
        //                //dataGridView1.Rows.Add();
        //                //tbl.Rows.Add(newRow);
        //            }
        //        }
        //    }
        //    for (int i = 0; i < table.Columns.Count; i++)
        //    {
        //        table.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        //        if(i != 0)table.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    }
        //}
    }
}