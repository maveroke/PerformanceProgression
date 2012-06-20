using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using WindowsFormsApplicationValueInput;
using System.Globalization;

namespace Attempt1MathCalculation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Boolean FormSaved = true;
        private string tempValueInCell;
        private string PerformanceEG = "e.g. mm:ss.ss";
        private bool setUP;

        private List<Athletes> ListOfAthletes;
        //total dataset of user data
        private List<fPoint> ListOfUserDataPoints = new List<fPoint>(150);
        //dataset of user points X & Y
        private List<fPoint> UserDataPoints = new List<fPoint>(150);
        private List<fPoint> ListOfUserDataCurve = new List<fPoint>(150);

        GraphPane myPane;

        //used to initialise the form
        public string fileloc;
        public bool newopen;
        public string chartName;
        public bool Male_Female;
        public string eventName;
        public string DoB;



        private void Form1_Load(object sender, EventArgs e)
        {
            setUP = true;
            for (int i = 0; i < 150; i++)
            {
                ListOfUserDataPoints.Add(new fPoint(true));
            }
            CreateGraph(zg1);
            SetSize();
            setUP = false;

        }
        #region Graph
        private void CreateGraph(ZedGraphControl zgc)
        {
            myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "My Test Graph";
            myPane.XAxis.Title.Text = "X Value";
            myPane.YAxis.Title.Text = "My Y Axis";
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Scale.Format = "dd'/'MM'/'yyyy";
            myPane.YAxis.Type = AxisType.Date;
            myPane.YAxis.Scale.Format = "mm':'ss'.'ff"; // 24 hour clock for HH
            myPane.Y2Axis.Scale.MajorUnit = DateUnit.Minute;
            myPane.Y2Axis.Scale.MinorUnit = DateUnit.Second;
            zgc.IsEnableHPan = false;

        }
        private void SetSize()
        {
            zg1.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            zg1.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20);
            myPane.YAxis.Scale.Format = "mm':'ss'.'ff"; // 24 hour clock for HH
            myPane.Y2Axis.Scale.MajorUnit = DateUnit.Minute;
            myPane.Y2Axis.Scale.MinorUnit = DateUnit.Second;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            SetSize();
        }
        #endregion
        #region DataGrid
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //MessageBox.Show(dataGridView1.CurrentCellAddress.X + " " + dataGridView1.CurrentCellAddress.Y);
            FormSaved = false;
            //next two lines do a Ctrl+Z type save
            if (dataGridView1.CurrentCell.Value != null)
                tempValueInCell = dataGridView1.CurrentCell.Value.ToString();
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
                        Point locationXY = dataGridView1.CurrentCellAddress;

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
                                if (locationXY.X == 0)
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
                                if (locationXY.X == 1 && PerformanceEG.Contains("e.g. mm:ss.ss"))
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
                                    string[] resplit = valueToAddToExcel.Split(':');
                                    valueToAddToExcel = Convert.ToString(Convert.ToInt32(resplit[0]) * 60 + Convert.ToDouble(resplit[1]));
                                }
                                dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[dataGridView1.CurrentCellAddress.X].Style.ForeColor = Color.Black;
                                //excelWrapper1.Workbook.ActiveSheet.Range(locationColumn).Value = valueToAddToExcel;//adds the Date/Time to the list
                                //if x_val needs changing
                                if (locationXY.X == 0)
                                {
                                    //string[] t = valueToAddToExcel.Split('/');
                                    //string value = t[1] + "/" + t[0] + "/" + t[2] + " 12:00:00 AM";
                                    ListOfUserDataPoints[locationXY.Y].setX_Date(Convert.ToDateTime(valueToAddToExcel));
                                }
                                //if y_val needs changing
                                if (locationXY.X == 1)
                                    ListOfUserDataPoints[locationXY.Y].setY_Value((float)Convert.ToDouble(valueToAddToExcel));
                            }
                        }
                        else
                        {
                            //excelWrapper1.Workbook.ActiveSheet.Range(locationColumn).Value = dataGridView1.CurrentCell.Value;//adds a value !time
                        }
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



        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            createNewList();

            string temp = "";

            for (int i = 0; i < 150; i++)
            {
                temp = temp + "\r\n" + ListOfUserDataPoints[i].ToString(true);
            }
            MessageBox.Show(temp);

            // Make up some data points from the Sine function
            float[] iper_x = { 11.5f, 2, 3 };
            float[] iper_y = { 11.5f, 2, 3 };
            PolynomialGraph pg = new PolynomialGraph();
            float[] abc = pg.SecondOrderPolynomial(iper_x, iper_y);

            PointPairList list = new PointPairList();
            for (int i = 0; i < UserDataPoints.Count; i++)
            {
                
                list.Add(new XDate(UserDataPoints[i].getX_Date()), new XDate(UserDataPoints[i].getY_Value_AsDate()));
            }
            

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve = myPane.AddCurve("My Curve", list, Color.Blue, SymbolType.Circle);
            myCurve.Line.IsVisible = false;
            //CurveItem myCurve = myPane.AddCurve("My Curve", list, Color.Blue, SymbolType.None);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            //myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);





            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            // Calculate the Axis Scale Ranges
            zg1.AxisChange();

            zg1.Invalidate();
        }
        private void sortList()
        {

        }
        private void createNewList()
        {
            foreach (fPoint f in ListOfUserDataPoints)
            {
                if (f.getX_Date().CompareTo(new DateTime(1111, 11, 11)) != 0 && f.getY_Value_AsFloat().CompareTo(1.1f) != 0)
                {
                    UserDataPoints.Add(f);
                }
            }
        }
    }
}
