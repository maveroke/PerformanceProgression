using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileReader_Writer;
using System.Collections;
using mdisample;

namespace Prototype.Forms
{
    public partial class OpenDisplay : Form
    {
        private string itemName, itemDoB, itemSex, itemEvent, itemLocation;
        private bool oButtonB = false;
        private bool cnButtonB = false;
        private List<string> selectedItemsR = new List<string>();

        public OpenDisplay()
        {
            InitializeComponent();

            CSV csv = new CSV();
            string[] stringArray = (string[])csv.Read().ToArray(typeof(string));

            // Get current date.
            DateTime thisDay = DateTime.Today;
            // Display the date in a variety of formats.
            int i = 0;
            foreach (string s in stringArray)
            {
                string[] individ = s.Split(',');
                itemName = individ[0];
                string[] temp = individ[1].Split('/');
               
                DateTime now = DateTime.Today;
                int age = now.Year;
                itemDoB = Convert.ToString(age - Convert.ToInt32(temp[2]));
                itemSex = individ[2];
                itemEvent = individ[3];
                itemLocation = individ[4];

                listView1.Items.Add(new ListViewItem(new string[] { itemName, itemDoB, itemEvent }));
                if (itemSex.CompareTo("M") == 0)
                {
                    listView1.Items[i].SubItems[0].BackColor = Color.LightSteelBlue;
                }
                else
                {
                    listView1.Items[i].SubItems[0].BackColor = Color.Thistle;
                }
                i++;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            //gets the index's of all the selected files in the ListView1
             List<string> w = new List<string>();
             foreach (ListViewItem item in listView1.SelectedItems) {
                 w.Add(item.SubItems[0].Text+"/"+item.SubItems[2].Text);
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
                        selectedItemsR.Add(s);
                        break;
                    }
                }
            }

            oButtonB = true;

        }

        public bool openButton()
        {
            return oButtonB;
        }
        public bool createNewButton()
        {
            return cnButtonB;
        }
        public List<string> sItemsR()
        {
            return selectedItemsR;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnButtonB = true;
            this.Close();
        }
    }
}
