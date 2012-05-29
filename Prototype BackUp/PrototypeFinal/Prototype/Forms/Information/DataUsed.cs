using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype
{
    public partial class DataUsed : Form
    {
        public DataUsed()
        {
            InitializeComponent();
            PopulateTables("DataGridData_Genders.txt", dataGridView1);
            PopulateTables("DataGridData_Volume.txt", dataGridView2);
        }
        private void PopulateTables(string name,DataGridView table)
        {
            string fileName = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, name);
            var rows = System.IO.File.ReadAllLines(fileName);
            Char[] separator = new Char[] { '|' };
            DataTable tbl = new DataTable(fileName);
            if (rows.Length != 0)
            {
                foreach (string headerCol in rows[0].Split(separator))
                {
                    DataGridViewTextBoxColumn temp = new DataGridViewTextBoxColumn();
                    temp.HeaderText = headerCol;
                    table.Columns.Add(temp);
                    //tbl.Columns.Add(new DataColumn(headerCol));
                }
                if (rows.Length > 1)
                {
                    for (int rowIndex = 1; rowIndex < rows.Length; rowIndex++)
                    {
                        table.Rows.Add();
                        //var newRow = tbl.NewRow();
                        var cols = rows[rowIndex].Split(separator);
                        for (int colIndex = 0; colIndex < cols.Length; colIndex++)
                        {
                            table[colIndex, (rowIndex - 1)].Value = cols[colIndex];
                            if (cols[colIndex].CompareTo("") == 0) table.Rows[rowIndex - 1].Height = 4;
                            if (cols[colIndex].Contains("Total")) table.Rows[rowIndex - 1].DefaultCellStyle.BackColor = Color.LemonChiffon;
                            //newRow[colIndex] = cols[colIndex];
                        }
                        //dataGridView1.Rows.Add();
                        //tbl.Rows.Add(newRow);
                    }
                }
            }
            for (int i = 0; i < table.Columns.Count; i++)
            {
                table.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i != 0) table.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
