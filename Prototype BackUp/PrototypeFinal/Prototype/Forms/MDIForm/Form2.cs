using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using EmbeddedExcel;
using WindowsFormsApplicationValueInput;
using CoolPrintPreview;
using Prototype;

namespace mdisample
{
    /// <summary>
    /// Summary description for Form2.
    /// </summary>
    public class Form2 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItemCFile;
        private System.Windows.Forms.OpenFileDialog oFileDlg;
        private System.Windows.Forms.SaveFileDialog sFileDlg;

        public string fileloc;
        public bool newopen;
        public string chartName;
        public bool Male_Female;
        public string eventName;
        public string DoB;

        private Timer timer;
        private SplitContainer splitContainer1;
        private ExcelWrapper excelWrapper1;
        private DataGridView dataGridView1;
        private IContainer components;
        private double maxDistancePercent = 0.7;
        private string dateEG = "e.g.  " + DateTime.Now.AddYears(-15).ToString("d/M/yyyy");
        private string PerformanceEG;
        private bool setUP;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemMagnification;
        private System.Windows.Forms.MenuItem menuItemZoomIn;
        private System.Windows.Forms.MenuItem menuItemZoomOut;
        private System.Windows.Forms.MenuItem menuItemPrint;
        private DataGridViewTextBoxColumn DateofEvent;
        private DataGridViewTextBoxColumn Performance;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private string tempValueInCell;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private Panel panelLoad;
        private System.Windows.Forms.MenuItem menuItem1;
        private string LocationImage = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PerformanceProgression\\Saved\\" + "ImageToPrint.tif");
        private Key key = new Key();
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItemSave;
        private bool keyVisible = false;

        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemCFile = new System.Windows.Forms.MenuItem();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemMagnification = new System.Windows.Forms.MenuItem();
            this.menuItemZoomIn = new System.Windows.Forms.MenuItem();
            this.menuItemZoomOut = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemPrint = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.oFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.sFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DateofEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Performance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLoad = new System.Windows.Forms.Panel();
            this.excelWrapper1 = new EmbeddedExcel.ExcelWrapper();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCFile,
            this.menuItem2});
            // 
            // menuItemCFile
            // 
            this.menuItemCFile.Index = 0;
            this.menuItemCFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSave});
            this.menuItemCFile.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.menuItemCFile.Text = "&File";
            // 
            // menuItemSave
            // 
            this.menuItemSave.Index = 0;
            this.menuItemSave.MergeOrder = 2;
            this.menuItemSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItemSave.Text = "&Save";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemMagnification,
            this.menuItemPrint,
            this.menuItem1});
            this.menuItem2.Text = "Excel";
            // 
            // menuItemMagnification
            // 
            this.menuItemMagnification.Index = 0;
            this.menuItemMagnification.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemZoomIn,
            this.menuItemZoomOut,
            this.menuItem3});
            this.menuItemMagnification.Text = "Magnification";
            this.menuItemMagnification.Visible = false;
            // 
            // menuItemZoomIn
            // 
            this.menuItemZoomIn.Index = 0;
            this.menuItemZoomIn.Text = "";
            // 
            // menuItemZoomOut
            // 
            this.menuItemZoomOut.Index = 1;
            this.menuItemZoomOut.Text = "";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "";
            // 
            // menuItemPrint
            // 
            this.menuItemPrint.Index = 1;
            this.menuItemPrint.Text = "Print";
            this.menuItemPrint.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "Key / Legend";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click_1);
            // 
            // oFileDlg
            // 
            this.oFileDlg.AddExtension = false;
            this.oFileDlg.Title = "MDI Sample";
            // 
            // sFileDlg
            // 
            this.sFileDlg.FileName = "doc1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.excelWrapper1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(636, 206);
            this.splitContainer1.SplitterDistance = 454;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateofEvent,
            this.Performance});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 4;
            this.dataGridView1.Size = new System.Drawing.Size(178, 227);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // DateofEvent
            // 
            this.DateofEvent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DateofEvent.DefaultCellStyle = dataGridViewCellStyle1;
            this.DateofEvent.HeaderText = "DateofEvent";
            this.DateofEvent.Name = "DateofEvent";
            // 
            // Performance
            // 
            this.Performance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "12:21.13";
            dataGridViewCellStyle2.NullValue = null;
            this.Performance.DefaultCellStyle = dataGridViewCellStyle2;
            this.Performance.HeaderText = "Performance";
            this.Performance.Name = "Performance";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(71, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 17);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loading...";
            // 
            // panelLoad
            // 
            this.panelLoad.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelLoad.Controls.Add(this.label1);
            this.panelLoad.Controls.Add(this.progressBar1);
            this.panelLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoad.Location = new System.Drawing.Point(0, 0);
            this.panelLoad.Name = "panelLoad";
            this.panelLoad.Size = new System.Drawing.Size(636, 206);
            this.panelLoad.TabIndex = 2;
            // 
            // excelWrapper1
            // 
            this.excelWrapper1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.excelWrapper1.Location = new System.Drawing.Point(0, 0);
            this.excelWrapper1.Name = "excelWrapper1";
            this.excelWrapper1.Size = new System.Drawing.Size(719, 227);
            this.excelWrapper1.TabIndex = 1;
            this.excelWrapper1.ToolBarVisible = false;
            // 
            // Form2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(636, 206);
            this.Controls.Add(this.panelLoad);
            this.Controls.Add(this.splitContainer1);
            this.Menu = this.mainMenu1;
            this.Name = "Form2";
            this.Text = "Child";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form2_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelLoad.ResumeLayout(false);
            this.panelLoad.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void Form2_Load(object sender, System.EventArgs e)
        {
            progressBar1.Value = 5;
            setUP = true;
            switch (eventName.Substring(1))
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

                    PerformanceEG = "e.g. mm:ss.ss";
                    break;
                case "Decathlon":
                case "Heptathlon":
                    PerformanceEG = "e.g. 7000";
                    break;
                default:
                    PerformanceEG = "e.g. mm.cc";
                    break;
            }
            progressBar1.Value = 15;
            for (int i = 0; i < 150; i++)
            {
                if (i < 5)
                {
                    dataGridView1.Rows.Add(dateEG, PerformanceEG);
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
                }
                else
                {
                    dataGridView1.Rows.Add();
                }
            }
            progressBar1.Value = 45;
            try
            {
                //load image to picturebox
                this.excelWrapper1.OpenFile(fileloc);

            }
            catch
            {
                MessageBox.Show("Error opening image", "MDI Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = 50;
            if (this.excelWrapper1.m_XlApplication != null)
            {
                timer.Stop();
                if (newopen)//if new then add initial values once
                {
                    addValuesToExcel();
                }
                else//get values from the excel sheet and display then in the dataGridView
                { addValuesToDataGridView(); }
                dataGridView1.Focus();
            }
        }

        private void addValuesToExcel()
        {
            progressBar1.Value = 60;
            //ChartName
            excelWrapper1.Workbook.ActiveSheet.Unprotect("1500kosmin");
            excelWrapper1.Workbook.ActiveSheet.ChartObjects("Chart 2").Activate();
            this.excelWrapper1.m_XlApplication.ActiveChart.ChartTitle.Text = chartName;
            //DoB
            progressBar1.Value = 70;
            excelWrapper1.Workbook.ActiveSheet.Range("AJ1").NumberFormatLocal = "mm/dd/yyyy";
            excelWrapper1.Workbook.ActiveSheet.Range("AJ1").Value = DoB;
            progressBar1.Value = 80;
            excelWrapper1.Workbook.ActiveSheet.Protect("1500kosmin", false);
            progressBar1.Value = 100;
            progressBar1.Hide();
            panelLoad.Hide();
            setUP = false;
        }
        /// <summary>
        /// gets the values from the excel Document and adds it to the dataGridView
        /// </summary>
        private void addValuesToDataGridView()
        {
            progressBar1.Value = 80;
            for (int i = 3; i <= 150; i++)
            {
                string AIName = "AI" + i;
                string AKName = "AK" + i;
                if (excelWrapper1.Workbook.ActiveSheet.Range[AIName].Value != null)
                {//Left hand Column
                    DataGridViewCell cell = dataGridView1.Rows[(i - 3)].Cells[0];
                    dataGridView1.CurrentCell = cell;
                   //gets the date out of Excel 
                    string DateOfEventTemp = excelWrapper1.Workbook.ActiveSheet.Range[AIName].Value.ToString();
                   //splits the date off from time
                    string[] Temp = DateOfEventTemp.Split(' ');

                    //splits the date up into 3
                    string[] dateOut = Temp[0].Split('/') ;
                    //changes mm/dd/yyyy to dd/mm/yyyy
                    string disp = dateOut[1] + "/" + dateOut[0] + "/" + dateOut[2];

                    dataGridView1.CurrentCell.Value = disp;
                    dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[dataGridView1.CurrentCellAddress.X].Style.ForeColor = Color.Black;
                }
                if (excelWrapper1.Workbook.ActiveSheet.Range[AKName].Value != null)
                {//Right hand Column
                    DataGridViewCell cell = dataGridView1.Rows[(i - 3)].Cells[1];
                    dataGridView1.CurrentCell = cell;
                    if (PerformanceEG.CompareTo("e.g. mm:ss.ss") == 0)
                    {
                        double ipet = ((24 * excelWrapper1.Workbook.ActiveSheet.Range[AKName].Value) * 60) * 60;
                        double seconds = ipet % 60;
                        int mins = Convert.ToInt32((ipet - seconds) / 60);
                        dataGridView1.CurrentCell.Value = mins + ":" + seconds;
                    }
                    else
                    {
                        dataGridView1.CurrentCell.Value = ""+excelWrapper1.Workbook.ActiveSheet.Range[AKName].Value;
                    }
                    //dataGridView1.Columns[1].DefaultCellStyle.Format = "HH:mm:ss";
                    dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[dataGridView1.CurrentCellAddress.X].Style.ForeColor = Color.Black;
                }

                if(progressBar1.Value<=99)
                progressBar1.Value = progressBar1.Value + (i / 100);
            }
            DataGridViewCell cellwe = dataGridView1.Rows[0].Cells[0];
            dataGridView1.CurrentCell = cellwe;
            progressBar1.Value = 100;
            progressBar1.Hide();
            panelLoad.Hide();
            setUP = false;
        }
        /// <summary>
        /// resize the forms to appropriate sizes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            int size = Convert.ToInt32(splitContainer1.Width * maxDistancePercent);
            if (splitContainer1.SplitterDistance < size)
            {
                splitContainer1.SplitterDistance = size;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            FormSaved = false;
            try
            {
                if (!setUP)
                {

                    if (checkFormat().CompareTo("working") == 0)
                    {

                        string locationColumn = LocateLocation();


                        excelWrapper1.Workbook.ActiveSheet.Unprotect("1500kosmin");


                        if (dataGridView1.CurrentCell.Value != null)
                        {
                            if (dataGridView1.CurrentCell.Value.ToString().Contains("e.g."))
                            {
                                //value in this field is an e.g.
                            }
                            else
                            {
                                //this cell has a value but it is not an e.g.

                                ///need to find out the location, if date then do the date thing
                                ///so that means...
                                ///if(dd/mm/yyyy where mm < 12) split the date and export it to excel as mm/dd/yyyy //turns it into mm/dd/yyyy format
                                ///if(dd/mm/yyyy where mm > 12) export it to excel as dd/mm/yyyy <-so leave it how it is. //its already in mm/dd/yyyy format

                                string valueToAddToExcel = dataGridView1.CurrentCell.Value.ToString();

                                //working in the DateOfPerformanceColumn
                                if (locationColumn.Contains("AI")) {
                                    string[] tempDate = valueToAddToExcel.Split('/');
                                    if (Convert.ToInt32(tempDate[1]) <= 12)
                                    {
                                        valueToAddToExcel = tempDate[1] + "/" + tempDate[0] + "/" + tempDate[2];
                                    }
                                    else
                                    {

                                        dataGridView1.CurrentCell.Value = tempDate[1] + "/" + tempDate[0] + "/" + tempDate[2];
                                    }
                                }
                                //working in the Performance
                                if (locationColumn.Contains("AK") && PerformanceEG.Contains("e.g. mm:ss.ss"))
                                {
                                    //if its not in the form MM:SS.ss then{
                                    if (valueToAddToExcel.Contains(":") && valueToAddToExcel.Contains(".")) { }
                                    else
                                    {
                                        
                                        string[] tempDate = valueToAddToExcel.Split(':', '.');
                                        
                                        switch (eventName)
                                        {
                                            case "W100m":
                                            case "M100m":
                                            case "W100m Hurdles":
                                            case "M110m Hurdles":
                                            case "W200m":
                                            case "M200m":
                                            case "M400m":
                                                //if its in the form aa:bb then { assume 00:aa.bb }
                                                //if its in the form aa.bb then { assume 00:aa.bb }

                                                valueToAddToExcel = "00:" + tempDate[0] + "." + tempDate[1];
                                                break;
                                            default:
                                                //if its in the form aa:bb then { assume aa:bb.00 }
                                                //if its in the form aa.bb then { assume 00:aa.bb }
                                                if (valueToAddToExcel.Contains(":"))
                                                    valueToAddToExcel = tempDate[0] + ":" + tempDate[1] + ".00";
                                                else
                                                    valueToAddToExcel = "00:" + tempDate[0] + "." + tempDate[1];

                                                break;
                                        }
                                    }
                                    dataGridView1.CurrentCell.Value = valueToAddToExcel;
                                }
                                dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[dataGridView1.CurrentCellAddress.X].Style.ForeColor = Color.Black;
                                excelWrapper1.Workbook.ActiveSheet.Range(locationColumn).Value = valueToAddToExcel;
                            }
                        }
                        else
                        {
                            //MessageBox.Show("this cell is Null");
                            excelWrapper1.Workbook.ActiveSheet.Range(locationColumn).Value = dataGridView1.CurrentCell.Value;
                        }
                        excelWrapper1.Workbook.ActiveSheet.Protect("1500kosmin", false);

                    }
                    else { MessageBox.Show(checkFormat()); dataGridView1.CurrentCell.Value = tempValueInCell; }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
            }
        }

        private string checkFormat()
        {
            if (dataGridView1.CurrentCell.Value != null)
            {
                FormatString fs = new FormatString(dataGridView1.CurrentCell.Value.ToString());
                if (dataGridView1.CurrentCellAddress.X == 0)
                {
                    return fs.Date();
                }
                else
                {
                    switch (PerformanceEG)
                    {
                        case "e.g. mm:ss.ss":
                            return fs.Time();
                        case "e.g. 7000":
                            return fs.Points();
                        default:
                            return fs.Distance();
                    }
                }
            }
            return "working";
        }

        private string LocateLocation()
        {
            string locationColumn;
            if (dataGridView1.CurrentCellAddress.X == 0)
            {
                locationColumn = "AI" + (dataGridView1.CurrentCellAddress.Y + 3);
            }
            else
            {
                locationColumn = "AK" + (dataGridView1.CurrentCellAddress.Y + 3);
            }
            return locationColumn;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            FormSaved = false;
            if (dataGridView1.CurrentCell.Value != null)
                tempValueInCell = dataGridView1.CurrentCell.Value.ToString();
        }

        /// <summary>
        /// Print
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Chart chart1 = excelWrapper1.Workbook.ActiveSheet.ChartObjects("Chart 2").Chart;
            //chart1.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlXYScatterLines;

            chart1.Export(LocationImage, "BMP", misValue);

            using (var dlg = new CoolPrintPreviewDialog())
            {
                dlg.Document = this.printDocument1;
                dlg.ShowDialog(this);
            }
        }

        void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image photo = Image.FromFile(LocationImage);
            System.Drawing.Point ulCorner = new System.Drawing.Point(100, 100);
            e.Graphics.DrawImage(photo, ulCorner);
        }

        private void menuItem1_Click_1(object sender, EventArgs e)
        {
            key = null;
            if ((key = (Key)IsFormAlreadyOpen(typeof(Key))) == null)
            {
                key = new Key();
                key.locate = new System.Drawing.Point(this.Location.X, this.Location.Y);
                key.size = new System.Drawing.Point(this.Width, this.Height);
                key.Show(this);
            }
            else
            {
                key.Select(); // may be UForm.Select();
            }
            keyVisible = true;
        }
        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in System.Windows.Forms.Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            if (keyVisible)
            {
                key.Hide();
                key.locate = new System.Drawing.Point(this.Location.X, this.Location.Y);
                key.size = new System.Drawing.Point(this.Width, this.Height);
                key.PositionChanged();
                key.HideThis();
                key.Show(this);

            }
        }



        private void Form2_Activated(object sender, EventArgs e)
        {
            excelWrapper1.Focus();
            dataGridView1.Focus();
        }

        public int closeCount = 1;
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("C: 2");
            if (key.Visible)
            {
                key.Close();
            }
            
            //if (MdiChildren.Length == 0)
            //{
            //    Contents ct = new Contents();
            //    ct.MdiParent = this.MdiParent;
            //    //ct.Show();
            //}
        }
        private Boolean FormSaved = true;
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("C: 1");
            //closeCount++;
            //if (closeCount == 2)
            //{
            if (!FormSaved)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes you made to the" + chartName.Substring(3) + "?", "Save",
                    MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    //Save
                    //excelWrapper1.Close(true);
                    FormSaved = true;
                }
                else if (result == DialogResult.No)
                {
                    //Dont Save
                    //excelWrapper1.Close(false);
                    //MessageBox.Show(this.Text+".xlsx");
                    
                    //excelWrapper1.m_XlApplication.Workbooks[this.Text + ".xlsx"].Activate();
                    //excelWrapper1.namesTest(this.Text+".xlsx");
                    excelWrapper1.Workbook.Saved = true;
                    FormSaved = true;
                }
                else
                {
                    //closeCount = 0;
                    e.Cancel = true;
                }
            }
           // }
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            excelWrapper1.Workbook.Save();
            FormSaved = true;
        }
    }
}
