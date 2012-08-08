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
using System.Collections.Generic;
using Attempt1MathCalculation;
using System.Linq;
using ZedGraph;

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

        private List<Athletes> ListOfAthletes = new List<Athletes>(150);
        //total dataset of user data
        private List<fPoint> ListOfUserDataPoints = new List<fPoint>(150);
        //dataset of user points X & Y
        private List<fPoint> UserDataPoints = new List<fPoint>(150);
        private List<fPoint> ListOfUserDataCurve = new List<fPoint>(150);

        GraphPane myPane;

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
        private System.Windows.Forms.MenuItem menuItem4;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.MenuItem menuItem5;
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
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.oFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.sFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.excelWrapper1 = new EmbeddedExcel.ExcelWrapper();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DateofEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Performance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLoad = new System.Windows.Forms.Panel();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
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
            this.menuItem2,
            this.menuItem5});
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
            this.menuItem1,
            this.menuItem4});
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
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlW;
            this.menuItem4.Text = "Graph Image";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.zg1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.excelWrapper1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(868, 186);
            this.splitContainer1.SplitterDistance = 619;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // zg1
            // 
            this.zg1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zg1.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zg1.IsEnableSelection = true;
            this.zg1.IsShowPointValues = true;
            this.zg1.Location = new System.Drawing.Point(0, 0);
            this.zg1.Name = "zg1";
            this.zg1.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(617, 186);
            this.zg1.TabIndex = 3;
            this.zg1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zg1_PointValueEvent);
            // 
            // excelWrapper1
            // 
            this.excelWrapper1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.excelWrapper1.Location = new System.Drawing.Point(0, 0);
            this.excelWrapper1.Name = "excelWrapper1";
            this.excelWrapper1.Size = new System.Drawing.Size(132, 207);
            this.excelWrapper1.TabIndex = 1;
            this.excelWrapper1.ToolBarVisible = false;
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
            this.dataGridView1.Size = new System.Drawing.Size(245, 207);
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
            this.panelLoad.Location = new System.Drawing.Point(528, 0);
            this.panelLoad.Name = "panelLoad";
            this.panelLoad.Size = new System.Drawing.Size(108, 319);
            this.panelLoad.TabIndex = 2;
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "test";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // Form2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(868, 186);
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

        #region LOAD
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
                CreateGraph(zg1);
                addValuesToListofAthletes();
                addLinestoGraph();
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
        /// adds athletes from the excel sheet to a list within the C# program
        /// to be used to display lines in the graph
        /// </summary>
        private void addValuesToListofAthletes()
        {
            excelWrapper1.Workbook.ActiveSheet.Unprotect("1500kosmin");
            int rowCount = excelWrapper1.Workbook.ActiveSheet.UsedRange.Rows.Count - 1;
            Microsoft.Office.Interop.Excel.Range last1 = excelWrapper1.Workbook.ActiveSheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            Microsoft.Office.Interop.Excel.Range range1 = excelWrapper1.Workbook.ActiveSheet.Range("C1", "C" + rowCount);
            Microsoft.Office.Interop.Excel.Range last2 = excelWrapper1.Workbook.ActiveSheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            Microsoft.Office.Interop.Excel.Range range2 = excelWrapper1.Workbook.ActiveSheet.Range("G1", "G" + rowCount);
            Microsoft.Office.Interop.Excel.Range last3 = excelWrapper1.Workbook.ActiveSheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            Microsoft.Office.Interop.Excel.Range range3 = excelWrapper1.Workbook.ActiveSheet.Range("K1", "K" + rowCount);

            List<fPoint> temp = new List<fPoint> { fPoint.ConstructDefault(), fPoint.ConstructDefault(), fPoint.ConstructDefault() };
            Athletes at = new Athletes();
            for (int f = 0; f < 150; f++)
            {
                ListOfAthletes.Add(at);
            }
            
            int i = 0;//counter of 3
            int j = 2;//counter of rows
            int k = 0;//counter of Athletes
            foreach (Microsoft.Office.Interop.Excel.Range r in range1)
            {
                if (excelWrapper1.Workbook.ActiveSheet.Range["C" + j].Value.ToString().CompareTo(".") == 0) { j++; }
                if (excelWrapper1.Workbook.ActiveSheet.Range["C" + j].Value.ToString().CompareTo(".") == 0 || excelWrapper1.Workbook.ActiveSheet.Range["C" + j] == null) { break; }

                temp[i] = new fPoint(Convert.ToDecimal(excelWrapper1.Workbook.ActiveSheet.Range["C" + j].Value.ToString()), Convert.ToDecimal(excelWrapper1.Workbook.ActiveSheet.Range["D" + j].Value.ToString()));
                i++;

                if (i == 3)
                {
                    ListOfAthletes[k] = new Athletes(excelWrapper1.Workbook.ActiveSheet.Range["A" + j].Value.ToString(), excelWrapper1.Workbook.ActiveSheet.Range["B" + j].Value2.ToString(), temp,PerformanceEG);
                    k++;
                    i = 0;
                }
                j++;
            }

            i = 0;//counter of 3
            j = 2;//counter of rows
            foreach (Microsoft.Office.Interop.Excel.Range r in range2)
            {
                if (excelWrapper1.Workbook.ActiveSheet.Range["G" + j].Value.ToString().CompareTo(".") == 0) { j++; }
                if (excelWrapper1.Workbook.ActiveSheet.Range["G" + j].Value.ToString().CompareTo(".") == 0 || excelWrapper1.Workbook.ActiveSheet.Range["G" + j] == null) { break; }
                temp[i] = new fPoint(Convert.ToDecimal(excelWrapper1.Workbook.ActiveSheet.Range["G" + j].Value.ToString()), Convert.ToDecimal(excelWrapper1.Workbook.ActiveSheet.Range["H" + j].Value.ToString()));
                i++;
                if (i == 3)
                {
                    ListOfAthletes[k] = new Athletes(excelWrapper1.Workbook.ActiveSheet.Range["E" + j].Value.ToString(), excelWrapper1.Workbook.ActiveSheet.Range["F" + j].Value2.ToString(), temp, PerformanceEG);
                    k++;
                    i = 0;
                }
                j++;
            }
            i = 0;//counter of 3
            j = 2;//counter of rows
            foreach (Microsoft.Office.Interop.Excel.Range r in range3)
            {

                if (excelWrapper1.Workbook.ActiveSheet.Range["K" + j].Value.ToString().CompareTo(".") == 0) { j++; }
                if (excelWrapper1.Workbook.ActiveSheet.Range["K" + j].Value.ToString().CompareTo(".") == 0 || excelWrapper1.Workbook.ActiveSheet.Range["K" + j] == null) { break; }

                temp[i] = new fPoint(Convert.ToDecimal(excelWrapper1.Workbook.ActiveSheet.Range["K" + j].Value.ToString()), Convert.ToDecimal(excelWrapper1.Workbook.ActiveSheet.Range["L" + j].Value.ToString()));
                i++;

                if (i == 3)
                {
                    ListOfAthletes[k] = new Athletes(excelWrapper1.Workbook.ActiveSheet.Range["I" + j].Value.ToString(), excelWrapper1.Workbook.ActiveSheet.Range["J" + j].Value2.ToString(), temp, PerformanceEG);
                    k++;
                    i = 0;
                }
                j++;
            }

            excelWrapper1.Workbook.ActiveSheet.Protect("1500kosmin", false);
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
                    string[] dateOut = Temp[0].Split('/');
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
                        dataGridView1.CurrentCell.Value = "" + excelWrapper1.Workbook.ActiveSheet.Range[AKName].Value;
                    }
                    //dataGridView1.Columns[1].DefaultCellStyle.Format = "HH:mm:ss";
                    dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[dataGridView1.CurrentCellAddress.X].Style.ForeColor = Color.Black;
                }

                if (progressBar1.Value <= 99)
                    progressBar1.Value = progressBar1.Value + (i / 100);
            }
            DataGridViewCell cellwe = dataGridView1.Rows[0].Cells[0];
            dataGridView1.CurrentCell = cellwe;
            progressBar1.Value = 100;
            progressBar1.Hide();
            panelLoad.Hide();
            setUP = false;
        }
        #endregion

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
                                if (locationColumn.Contains("AI"))
                                {
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
                                        if (valueToAddToExcel.CompareTo("") != 0)
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
            SetSize();
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
            //excelWrapper1.Focus();
            dataGridView1.Focus();
        }

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

        private void menuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Chart chart1 = excelWrapper1.Workbook.ActiveSheet.ChartObjects("Chart 2").Chart;
                //chart1.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlXYScatterLines;

                chart1.Export(LocationImage, "BMP", misValue);
                Image imgToCopy = Image.FromFile(LocationImage);
                Clipboard.SetImage(imgToCopy);
                MessageBox.Show("The Graph has been copied to your Clip Board");
            }
            catch (Exception gg)
            {
                MessageBox.Show("Error occured while trying to copy the graph: " + gg);
            }
        }

        #region graph
        private void CreateGraph(ZedGraphControl zgc)
        {

            excelWrapper1.Workbook.ActiveSheet.Unprotect("1500kosmin");
            
            myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = chartName;
            myPane.XAxis.Title.Text = "Age of Athletes";
            myPane.YAxis.Title.Text = "Performance of Athletes";


                                            //sets the XY value types
            myPane.XAxis.Type = AxisType.Linear;
            ////          //myPane.YAxis.Type = AxisType.Date;
            myPane.YAxis.Type = AxisType.Linear;
                        //max and min for standard view
            myPane.XAxis.Scale.Max = 35;
            myPane.XAxis.Scale.Min = 10;
                        // Enable the X and Y axis grids
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;

            myPane.Legend.IsVisible = false;

            switch (PerformanceEG)
            {
                case "e.g. mm:ss.ss":
                                


                    //sets the XY value types
                    myPane.XAxis.Type = AxisType.Linear;
                    myPane.YAxis.Type = AxisType.Date;

                    string MaxDate = excelWrapper1.Workbook.ActiveSheet.Range["M6"].Value.ToString();
                    string MinimumDate = excelWrapper1.Workbook.ActiveSheet.Range["N6"].Value.ToString();

                    //Note: Currently only working for mins secs and splits. You want to do more than 59 mins for a race its gonna cause you issues

                        double Maximum = ((24 * excelWrapper1.Workbook.ActiveSheet.Range["M6"].Value) * 60) * 60;
                        double Maxseconds = Maximum % 60;//secs
                        int Maxmins = Convert.ToInt32((Maximum - Maxseconds) / 60);//mins
                        string Maxtemp = Maxseconds.ToString();
                        if (!Maxseconds.ToString().Contains('.')) { Maxtemp += ".0"; }
                        string[] MaxSplits = Maxtemp.Split('.');

                        double Minimum = ((24 * excelWrapper1.Workbook.ActiveSheet.Range["N6"].Value) * 60) * 60;
                        double Minseconds = Minimum % 60;
                        string Mintemp = Minseconds.ToString();
                        if (!Minseconds.ToString().Contains('.')) { Mintemp += ".0"; }
                        int Minmins = Convert.ToInt32((Minimum - Minseconds) / 60);
                        string[] MinSplits = Mintemp.Split('.');

                        myPane.YAxis.Scale.Min = new XDate(2000, 1, 1, 0, Maxmins, Convert.ToInt32(MaxSplits[0]), Convert.ToInt32(MaxSplits[1]));
                        myPane.YAxis.Scale.Max = new XDate(2000, 1, 1, 0, Minmins, Convert.ToInt32(MinSplits[0]), Convert.ToInt32(MinSplits[1]));

                        double MajorStep = ((24 * excelWrapper1.Workbook.ActiveSheet.Range["O6"].Value) * 60) * 60;
                        double MSseconds = MajorStep % 60;


                    myPane.YAxis.Scale.MajorUnit = DateUnit.Second;
                    myPane.YAxis.Scale.MajorStep = MSseconds;
                    myPane.YAxis.Scale.IsReverse = true;
                    myPane.YAxis.Scale.Format = "mm':'ss'.'ff"; // 24 hour clock for HH
                    break;
                ///////////////////////////////////////////////////////////////////////////////////////////////

                case "e.g. 7000":

                    myPane.YAxis.Scale.Max = 10000;
                    myPane.YAxis.Scale.Min = 4000;

                    break;
                ///////////////////////////////////////////////////////////////////////////////////////////////
                case "e.g. mm.cc":

                    myPane.YAxis.Scale.Max = 2;
                    myPane.YAxis.Scale.Min = 1;
                    break;
                ///////////////////////////////////////////////////////////////////////////////////////////////
            }
                                    
            excelWrapper1.Workbook.ActiveSheet.Protect("1500kosmin", false);
            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            // Calculate the Axis Scale Ranges
            zg1.AxisChange();
            zg1.RestoreScale(myPane);
            zg1.ZoomOut(myPane);

            //zg1.Invalidate();

        }
        private void SetSize()
        {
            zg1.Location = new System.Drawing.Point(10, 10);
            // Leave a small margin around the outside of the control
            zg1.Size = new Size(splitContainer1.Panel1.Width - 20, splitContainer1.Panel1.Height - 20);
            //myPane.YAxis.Scale.Format = "mm':'ss'.'ff"; // 24 hour clock for HH
        }

        private void addLinestoGraph()
        {
            //Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            //LineItem myCurve = myPane.AddCurve("My Curve", list, Color.Blue, SymbolType.Circle);
            //myCurve.Line.IsVisible = false;

            foreach (Athletes a in ListOfAthletes)
            {
                Color col = Color.Black;
                if (a.getName() != null)
                {
                    if (a.getStatus().CompareTo("Medal") == 0) { col = Color.Red; }
                    else if (a.getStatus().CompareTo("Final") == 0) { col = Color.Blue; }
                    else if (a.getStatus().CompareTo("Other") == 0) { col = Color.Purple; }
                    //if (a.getName().CompareTo("Asafa Powell") == 0)
                    //{

                    if (PerformanceEG.CompareTo("e.g. mm:ss.ss") == 0)
                    {

                        myPane.CurveList.Add(new LineItem(a.getName(), a.getCurveData(), col, SymbolType.None));
                    }
                    else
                    {
                        myPane.CurveList.Add(new LineItem(a.getName(), a.getCurveData(), col, SymbolType.None));
                    }
                    //}
                }

            }

            //CurveItem myCurve = myPane.AddCurve("My Curve", list, Color.Blue, SymbolType.None);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            //myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            //myCurve.Symbol.Fill = new Fill(Color.White);

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            // Calculate the Axis Scale Ranges
            //zg1.AxisChange();
            zg1.IsEnableHPan = true;
            zg1.Invalidate();
        }
        #endregion

        private string zg1_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair pt = curve[iPt];
            return (curve.Label.Text + pt.X.ToString()+" , "+pt.Y.ToString());
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            string temp = "";
            foreach (Athletes a in ListOfAthletes)
            {
                if (a.getName() != null)
                {
                    if (a.getName().CompareTo("Asafa Powell") == 0)
                    {
                        foreach (PointPair p in a.getCurveData())
                        {
                            double tt = ((((p.Y * 24) * 60) * 60) - 3155846410) * 100;
                            temp += "( " + p.X + "," + tt + " ) \r\n";
                        }
                    }
                }
            }
            MessageBox.Show(temp);
        }
    }
}
