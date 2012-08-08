using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Attempt1MathCalculation
{
    class CreateTrendline
    {
        protected List<fPoint> MaxMin;
        protected List<fPoint> Range;
        protected string EventType;


        public PointPairList getTrendList()
        {
            PointPairList list = new PointPairList();
            for (int i = 0; i < Range.Count; i++)
            {

                ////               //list.Add(UserDataPoints[i].getX_Age(), new XDate(UserDataPoints[i].getY_Value_AsDate()));
                if (EventType.CompareTo("Track") == 0) { 
                    list.Add(Convert.ToDouble(Range[i].getX_Age()),new XDate(Range[i].getY_Value_AsDate())); 
                }
                else { 
                    list.Add(Convert.ToDouble(Range[i].getX_Age()), Convert.ToDouble(Range[i].getY_Value_Asdouble())); 
                }
                
            }
            return list;
        }
        public CreateTrendline(List<fPoint> searchMaxMin,string eventType)
        {
            EventType = eventType;
            MaxMin = new List<fPoint>(searchMaxMin.Count);
            foreach (fPoint a in searchMaxMin)
            {
                MaxMin.Add(a);
            }
            //MaxMin = searchMaxMin;

            if (MaxMin.Count >= 2)
            {
                //method to find the largest and smallest values
                fPoint smallest = MaxMin[0], largest = MaxMin[0];
                foreach (fPoint f in MaxMin)
                {
                    if (largest.getX_Age().CompareTo(f.getX_Age()) < 0 && f.getX_Age().CompareTo(1111) != 0) { largest = f; }
                    if (smallest.getX_Age().CompareTo(f.getX_Age()) > 0) { smallest = f; }
                }

                decimal x = smallest.getX_Age();                              //starting x value

                decimal range = largest.getX_Age() - smallest.getX_Age();     //range

                decimal maxRange = range * 50;                               //the maximum amount of range points

                decimal delta = (decimal)0.02;                                        //the increment of age

                //method to set hundreds of values in a list between the Min and Max values
                //double rangeMM = largest.getX_Age() - smallest.getX_Age();

                //double maxRange = rangeMM * 50;
                //rangeMM = 0.02;

                Range = new List<fPoint>((int)maxRange);
                for (int i = 0; i < maxRange; i++)
                {
                    Range.Add(fPoint.ConstructDefault());
                }

                //double percentValue = smallest.getX_Age() + rangeMM;

                Range[0] = smallest;
                //Range[(int)(maxRange-1)] = largest;

                //get ABC off the x,y user data.
                PolynomialGraph pg = new PolynomialGraph();
                decimal[] tempABC = pg.Polynomial(MaxMin);

                for (int i = 1; i < maxRange; i++)
                {
                    decimal x_val = x;
                    Range[i] = new fPoint(x_val, tempABC[0] * (x_val * x_val) + tempABC[1] * x_val + tempABC[2]);
                    x = x_val + delta;
                }
                int p = 0;
                p++;

                //MessageBox.Show(searchMaxMin[2].getX_Age()+"");

                //MessageBox.Show("A: "+tempABC[0] + " B: " + tempABC[1] + " C: " + tempABC[2]);

                //use ABC + equation on range to get Y
                //string temp = "";
                //foreach (fPoint g in Range)
                //{
                //    temp += g.getX_Age() + " " + g.getY_Value_AsDate().Minute + ":" + g.getY_Value_AsDate().Second + "." + g.getY_Value_AsDate().Millisecond + "\r\n";
                //}
                //MessageBox.Show(temp);
            }
        }
    }
}
