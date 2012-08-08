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

namespace Prototype.Forms
{
    public partial class DeleteDisplay : Form
    {
        private string itemName, itemDoB, itemSex, itemEvent, itemLocation;
        private int sortColumn = -1;
        private bool okButtonB = false;
        private List<string> selectedItemsR = new List<string>();

        public DeleteDisplay()
        {
            InitializeComponent();

            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            displayUpdate();

        }

        private void displayUpdate()
        {
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

        private void listView1_ColumnClick(object sender,
                                   System.Windows.Forms.ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                listView1.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listView1.Sorting == SortOrder.Ascending)
                    listView1.Sorting = SortOrder.Descending;
                else
                    listView1.Sorting = SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            listView1.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            listView1.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              listView1.Sorting);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?","", MessageBoxButtons.YesNoCancel);

            if (result.ToString().CompareTo("Yes") == 0)
            {
                //gets the index's of all the selected files in the ListView1
                List<string> w = new List<string>();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    w.Add(item.SubItems[0].Text + "/" + item.SubItems[2].Text);
                }


                //writes the CSV string to a new List using the index's of the selected items
                CSV csv = new CSV();
                csv.Delete(w);
            }
            okButtonB = true;
            foreach (ListViewItem item in listView1.Items)
            {
                item.Remove();
            }
            displayUpdate();
        }

        public bool okButton()
        {
            return okButtonB;
        }
    }
}
