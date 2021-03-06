﻿using System;
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


        public PointPairList getTrendList()
        {
            PointPairList list = new PointPairList();
            for (int i = 0; i < Range.Count; i++)
            {

                ////               //list.Add(UserDataPoints[i].getX_Age(), new XDate(UserDataPoints[i].getY_Value_AsDate()));
                list.Add(Range[i].getX_Age(), Range[i].getY_Value_AsFloat());
            }
            return list;
        }
        public CreateTrendline(List<fPoint> searchMaxMin)
        {
            MaxMin = searchMaxMin;

            if (MaxMin.Count >= 2)
            {
                //method to find the largest and smallest values
                fPoint smallest = MaxMin[0], largest = MaxMin[0];
                foreach (fPoint f in MaxMin)
                {
                    if (largest.getX_Age().CompareTo(f.getX_Age()) < 0 && f.getX_Age().CompareTo(1111)!=0) { largest = f; }
                    if (smallest.getX_Age().CompareTo(f.getX_Age()) > 0) { smallest = f; }
                }
                
                
                //method to set hundreds of values in a list between the Min and Max values
                double rangeMM = largest.getX_Age() - smallest.getX_Age();
                
                double maxRange = rangeMM * 50;
                rangeMM = 0.02;
                
                Range = new List<fPoint>((int)maxRange);
                for (int i = 0; i < maxRange; i++)
                {
                    Range.Add(new fPoint());
                }

                double percentValue = smallest.getX_Age()+rangeMM;

                Range[0] = smallest;
                Range[(int)(maxRange - 1)] = largest; 
                for (int i = 1; i < maxRange; i++)
                {
                    Range[i] = new fPoint((float)percentValue, 1111f);
                    percentValue += rangeMM;
                }

                //get ABC off the x,y user data.
                PolynomialGraph pg = new PolynomialGraph();
                float[] tempABC = pg.Polynomial(searchMaxMin);
                //MessageBox.Show(searchMaxMin[2].getX_Age()+"");

                //MessageBox.Show("A: "+tempABC[0] + " B: " + tempABC[1] + " C: " + tempABC[2]);

                //use ABC + equation on range to get Y
                string temp = "";
                foreach (fPoint p in Range)
                {
                    p.setY_Value(tempABC[0] * (p.getX_Age() * p.getX_Age()) + tempABC[1] * p.getX_Age() + tempABC[2]);
                    temp += "\r\n" + p.getX_Age()+ " " + p.getY_Value_AsFloat();
                }
                //MessageBox.Show(temp);
                //MessageBox.Show(Range.Count()+" "+ Range[Range.Count - 1].getX_Age());
            }
        }
    }
}
