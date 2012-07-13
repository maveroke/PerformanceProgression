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
        private string PerformanceEG = "e.g. 7000";
        private bool setUP;

        private List<Athletes> ListOfAthletes;
        //total dataset of user data
        private List<fPoint> ListOfUserDataPoints = new List<fPoint>(150);
        //dataset of user points X & Y
        private List<fPoint> UserDataPoints = new List<fPoint>(150);
        private List<fPoint> ListOfUserDataCurve = new List<fPoint>(150);

        GraphPane myPane;

        //used to initialise the form
        private string fileloc;
        private bool newopen;
        private string chartName;
        private bool Male_Female;
        private string eventName;
        private string DoB = "1/1/1990";

        public void initialiseForm(string fileLocation,string theChartName,string theEventName,string theDateOfBirth,bool newOpen,bool MaleFemale){
         fileloc = fileLocation;
         newopen = newOpen;
         chartName = theChartName;
         Male_Female = MaleFemale;
         eventName = theEventName;
         DoB = theDateOfBirth;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setUP = true;
            for (int i = 0; i < 150; i++)
            {
                ListOfUserDataPoints.Add(new fPoint());
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
            
  ////          //myPane.YAxis.Scale.Max = new XDate(2000, 1, 1, 0, 0, 15, 0);
  ////          //myPane.YAxis.Scale.Min = new XDate(2000, 1, 1, 0, 0, 8, 0);
            myPane.YAxis.Scale.Max = 9000;
            myPane.YAxis.Scale.Min = 5000;

            // Enable the X and Y axis grids
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;


  ////         //myPane.YAxis.Scale.MajorUnit = DateUnit.Second;
  ////         //myPane.YAxis.Scale.MajorStep = 0.40;  

  ////          //myPane.YAxis.Scale.Format = "mm':'ss'.'ff"; // 24 hour clock for HH

            



            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            // Calculate the Axis Scale Ranges
            zg1.AxisChange();

            zg1.Invalidate();

        }
        private void SetSize()
        {
            zg1.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            zg1.Size = new Size(panel1.Width - 20, panel1.Height - 20);
            //myPane.YAxis.Scale.Format = "mm':'ss'.'ff"; // 24 hour clock for HH
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

                                    //age of the athlete
                                    ListOfUserDataPoints[locationXY.Y].setX_Age(dateFromNow(valueToAddToExcel));
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

        private float dateFromNow(string value)
        {
            // 1.
            // Parse the date and put in DateTime object.
            DateTime startDate = DateTime.Parse(DoB);

            DateTime now = Convert.ToDateTime(value);

            // 3.
            // Get the TimeSpan of the difference.
            TimeSpan elapsed = now.Subtract(startDate);

            float daysAgo = (float)(elapsed.TotalDays / 365);
            daysAgo = (float)(Math.Truncate(daysAgo * 100) / 100);
            return daysAgo;
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




            // Make up some data points from the Sine function

            PolynomialGraph pg = new PolynomialGraph();
            float[] abc = pg.Polynomial(UserDataPoints);

            PointPairList list = new PointPairList();
            for (int i = 0; i < UserDataPoints.Count; i++)
            {
                
 ////               //list.Add(UserDataPoints[i].getX_Age(), new XDate(UserDataPoints[i].getY_Value_AsDate()));
                list.Add(UserDataPoints[i].getX_Age(), UserDataPoints[i].getY_Value_AsFloat());
            }
            

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve = myPane.AddCurve("My Curve", list, Color.Blue, SymbolType.Circle);
            myCurve.Line.IsVisible = false;

            CreateTrendline ct = new CreateTrendline(ListOfUserDataPoints);

            LineItem myCurve2 = myPane.AddCurve("My Curve", ct.getTrendList(), Color.Red, SymbolType.None);
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
            zg1.IsEnableHPan = true;
            zg1.Invalidate();
            
        }
        private void createNewList()
        {
            foreach (fPoint f in ListOfUserDataPoints)
            {
                if (f.getX_Age().CompareTo(11111f) != 0 && f.getY_Value_AsFloat().CompareTo(1.1f) != 0)
                {
                    UserDataPoints.Add(f);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1[0, 0].Value = "1";
            dataGridView1[0, 1].Value = "2";
            dataGridView1[0, 2].Value = "3";
            dataGridView1[0, 3].Value = "4";

            dataGridView1[1, 0].Value = "1";
            dataGridView1[1, 1].Value = "2";
            dataGridView1[1, 2].Value = "3";
            dataGridView1[1, 3].Value = "4";

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                float a = (float)Convert.ToDouble(dataGridView1[0,i].Value.ToString());
                float b = (float)Convert.ToDouble(dataGridView1[1, i].Value.ToString());
                ListOfUserDataPoints[i] = new fPoint(a,b);
            }
            dataGridView1[0, 0].Value = "1/1/1991";
            dataGridView1[0, 1].Value = "1/1/1992";
            dataGridView1[0, 2].Value = "1/1/1993";
            dataGridView1[0, 3].Value = "1/1/1994";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1[0, 0].Value = "15";
            dataGridView1[0, 1].Value = "16";
            dataGridView1[0, 2].Value = "17";
            dataGridView1[0, 3].Value = "18";
            dataGridView1[0, 4].Value = "19";
            dataGridView1[0, 5].Value = "20";
            dataGridView1[0, 6].Value = "21";
            dataGridView1[0, 7].Value = "22";
            dataGridView1[0, 8].Value = "23";
            dataGridView1[0, 9].Value = "24";

            dataGridView1[1, 0].Value = "1873";
            dataGridView1[1, 1].Value = "1546";
            dataGridView1[1, 2].Value = "1359";
            dataGridView1[1, 3].Value = "1200";
            dataGridView1[1, 4].Value = "547";
            dataGridView1[1, 5].Value = "468";
            dataGridView1[1, 6].Value = "512";
            dataGridView1[1, 7].Value = "983";
            dataGridView1[1, 8].Value = "1569";
            dataGridView1[1, 9].Value = "1804";

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                float a = (float)Convert.ToDouble(dataGridView1[0, i].Value.ToString());
                float b = (float)Convert.ToDouble(dataGridView1[1, i].Value.ToString());
                ListOfUserDataPoints[i] = new fPoint(a, b);
            }
            dataGridView1[0, 0].Value = "1/1/2005";
            dataGridView1[0, 1].Value = "1/1/2006";
            dataGridView1[0, 2].Value = "1/1/2007";
            dataGridView1[0, 3].Value = "1/1/2008";
            dataGridView1[0, 4].Value = "1/1/2009";
            dataGridView1[0, 5].Value = "1/1/2010";
            dataGridView1[0, 6].Value = "1/1/2011";
            dataGridView1[0, 7].Value = "1/1/2012";
            dataGridView1[0, 8].Value = "1/1/2013";
            dataGridView1[0, 9].Value = "1/1/2014";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for(int i = 0;i<44;i++){dataGridView1.Rows.Add();}
dataGridView1[0, 0].Value = "19.79";
dataGridView1[0, 1].Value = "17.88";
dataGridView1[0, 2].Value = "18.76";
dataGridView1[0, 3].Value = "18.68";
dataGridView1[0, 4].Value = "19.72";
dataGridView1[0, 5].Value = "18.53";
dataGridView1[0, 6].Value = "18.78";
dataGridView1[0, 7].Value = "19.68";
dataGridView1[0, 8].Value = "19.83";
dataGridView1[0, 9].Value = "19.85";
dataGridView1[0, 10].Value = "17.89";
dataGridView1[0, 11].Value = "18.7";
dataGridView1[0, 12].Value = "19.2";
dataGridView1[0, 13].Value = "19.78";
dataGridView1[0, 14].Value = "19.87";
dataGridView1[0, 15].Value = "17.77";
dataGridView1[0, 16].Value = "18.57";
dataGridView1[0, 17].Value = "18.7";
dataGridView1[0, 18].Value = "19.16";
dataGridView1[0, 19].Value = "19.16";
dataGridView1[0, 20].Value = "19.37";
dataGridView1[0, 21].Value = "19.37";
dataGridView1[0, 22].Value = "18.43";
dataGridView1[0, 23].Value = "18.87";
dataGridView1[0, 24].Value = "18.84";
dataGridView1[0, 25].Value = "19.2";
dataGridView1[0, 26].Value = "19.41";
dataGridView1[0, 27].Value = "19.87";
dataGridView1[0, 28].Value = "18.87";
dataGridView1[0, 29].Value = "19.71";
dataGridView1[0, 30].Value = "17.48";
dataGridView1[0, 31].Value = "17.59";
dataGridView1[0, 32].Value = "17.88";
dataGridView1[0, 33].Value = "18.8";
dataGridView1[0, 34].Value = "17.86";
dataGridView1[0, 35].Value = "17.4";
dataGridView1[0, 36].Value = "17.41";
dataGridView1[0, 37].Value = "17.57";
dataGridView1[0, 38].Value = "17.82";
dataGridView1[0, 39].Value = "17.72";
dataGridView1[0, 40].Value = "18.85";
dataGridView1[0, 41].Value = "16.9";
dataGridView1[0, 42].Value = "17.55";
dataGridView1[0, 43].Value = "17.74";
dataGridView1[0, 44].Value = "17.78";

dataGridView1[1, 0].Value = "1.86";
dataGridView1[1, 1].Value = "1.85";
dataGridView1[1, 2].Value = "1.85";
dataGridView1[1, 3].Value = "1.84";
dataGridView1[1, 4].Value = "1.84";
dataGridView1[1, 5].Value = "1.83";
dataGridView1[1, 6].Value = "1.82";
dataGridView1[1, 7].Value = "1.82";
dataGridView1[1, 8].Value = "1.82";
dataGridView1[1, 9].Value = "1.82";
dataGridView1[1, 10].Value = "1.81";
dataGridView1[1, 11].Value = "1.81";
dataGridView1[1, 12].Value = "1.81";
dataGridView1[1, 13].Value = "1.81";
dataGridView1[1, 14].Value = "1.81";
dataGridView1[1, 15].Value = "1.8";
dataGridView1[1, 16].Value = "1.8";
dataGridView1[1, 17].Value = "1.8";
dataGridView1[1, 18].Value = "1.8";
dataGridView1[1, 19].Value = "1.8";
dataGridView1[1, 20].Value = "1.8";
dataGridView1[1, 21].Value = "1.8";
dataGridView1[1, 22].Value = "1.79";
dataGridView1[1, 23].Value = "1.79";
dataGridView1[1, 24].Value = "1.78";
dataGridView1[1, 25].Value = "1.78";
dataGridView1[1, 26].Value = "1.78";
dataGridView1[1, 27].Value = "1.77";
dataGridView1[1, 28].Value = "1.76";
dataGridView1[1, 29].Value = "1.76";
dataGridView1[1, 30].Value = "1.75";
dataGridView1[1, 31].Value = "1.75";
dataGridView1[1, 32].Value = "1.75";
dataGridView1[1, 33].Value = "1.75";
dataGridView1[1, 34].Value = "1.74";
dataGridView1[1, 35].Value = "1.73";
dataGridView1[1, 36].Value = "1.73";
dataGridView1[1, 37].Value = "1.73";
dataGridView1[1, 38].Value = "1.73";
dataGridView1[1, 39].Value = "1.71";
dataGridView1[1, 40].Value = "1.71";
dataGridView1[1, 41].Value = "1.7";
dataGridView1[1, 42].Value = "1.7";
dataGridView1[1, 43].Value = "1.7";
dataGridView1[1, 44].Value = "1.69";

for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
{
    float a = (float)Convert.ToDouble(dataGridView1[0, i].Value.ToString());
    float b = (float)Convert.ToDouble(dataGridView1[1, i].Value.ToString());
    ListOfUserDataPoints[i] = new fPoint(a, b);
}
dataGridView1[0, 0].Value = "2/26/2011 ";
dataGridView1[0, 1].Value = "3/28/2009 ";
dataGridView1[0, 2].Value = "2/13/2010 ";
dataGridView1[0, 3].Value = "1/16/2010 ";
dataGridView1[0, 4].Value = "1/28/2011 ";
dataGridView1[0, 5].Value = "11/21/2009";
dataGridView1[0, 6].Value = "2/20/2010 ";
dataGridView1[0, 7].Value = "1/15/2011 ";
dataGridView1[0, 8].Value = "3/12/2011 ";
dataGridView1[0, 9].Value = "3/19/2011 ";
dataGridView1[0, 10].Value = "4/3/2009  ";
dataGridView1[0, 11].Value = "1/23/2010 ";
dataGridView1[0, 12].Value = "7/23/2010 ";
dataGridView1[0, 13].Value = "2/19/2011 ";
dataGridView1[0, 14].Value = "3/26/2011 ";
dataGridView1[0, 15].Value = "2/15/2009 ";
dataGridView1[0, 16].Value = "12/5/2009 ";
dataGridView1[0, 17].Value = "1/22/2010 ";
dataGridView1[0, 18].Value = "7/9/2010  ";
dataGridView1[0, 19].Value = "7/10/2010 ";
dataGridView1[0, 20].Value = "9/23/2010 ";
dataGridView1[0, 21].Value = "9/25/2010 ";
dataGridView1[0, 22].Value = "10/15/2009";
dataGridView1[0, 23].Value = "3/27/2010 ";
dataGridView1[0, 24].Value = "3/14/2010 ";
dataGridView1[0, 25].Value = "7/25/2010 ";
dataGridView1[0, 26].Value = "10/10/2010";
dataGridView1[0, 27].Value = "3/25/2011 ";
dataGridView1[0, 28].Value = "3/26/2010 ";
dataGridView1[0, 29].Value = "1/25/2011 ";
dataGridView1[0, 30].Value = "11/1/2008 ";
dataGridView1[0, 31].Value = "12/13/2008";
dataGridView1[0, 32].Value = "3/28/2009 ";
dataGridView1[0, 33].Value = "2/27/2010 ";
dataGridView1[0, 34].Value = "3/21/2009 ";
dataGridView1[0, 35].Value = "10/4/2008 ";
dataGridView1[0, 36].Value = "10/7/2008 ";
dataGridView1[0, 37].Value = "12/6/2008 ";
dataGridView1[0, 38].Value = "3/7/2009  ";
dataGridView1[0, 39].Value = "1/31/2009 ";
dataGridView1[0, 40].Value = "3/18/2010 ";
dataGridView1[0, 41].Value = "4/4/2008  ";
dataGridView1[0, 42].Value = "11/29/2008";
dataGridView1[0, 43].Value = "2/7/2009  ";
dataGridView1[0, 44].Value = "2/20/2009 ";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1[0, 0].Value = "16.59";
            dataGridView1[0, 1].Value = "21.22";
            dataGridView1[0, 2].Value = "25.84";

            dataGridView1[1, 0].Value = "1.89";
            dataGridView1[1, 1].Value = "1.98";
            dataGridView1[1, 2].Value = "2.01";

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                float a = (float)Convert.ToDouble(dataGridView1[0, i].Value.ToString());
                float b = (float)Convert.ToDouble(dataGridView1[1, i].Value.ToString());
                ListOfUserDataPoints[i] = new fPoint(a, b);
            }
            dataGridView1[0, 0].Value = "1/1/2006";
            dataGridView1[0, 1].Value = "1/1/2011";
            dataGridView1[0, 2].Value = "1/1/2015";
        }
    }
}
