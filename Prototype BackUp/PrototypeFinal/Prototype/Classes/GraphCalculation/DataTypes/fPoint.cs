using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Attempt1MathCalculation
{
    struct fPoint
    {
        private double X_valAge;
        private double Y_Val;

        public static fPoint ConstructDefault()
        {
            return new fPoint(1111f, 1111f);
        }

        /// <summary>
        /// Stores a Performance for Track Events
        /// </summary>
        public fPoint(double x, double y)
        {
            X_valAge = x;
            Y_Val = y;
        }

        public double getX_Age()
        {
            return X_valAge;
        }

        public void setX_Age(double date)
        {
            X_valAge = date;
        }
        
        public double getY_Value_Asdouble()
        {
            return Y_Val;
        }

        public DateTime getY_Value_AsDate()
        {
            //Note: Currently only working for mins secs and splits. You want to do more than 59 mins for a race its gonna cause you issues
            double Maximum = ((24 * Y_Val) * 60) * 60;
            double Maxseconds = Maximum % 60;//secs
            double milli = Math.Round(Maxseconds, 3);
            int Maxmins = Convert.ToInt32((Maximum - milli) / 60);//mins
            string Maxtemp = milli.ToString();
            if (!milli.ToString().Contains('.')) { Maxtemp += ".0"; }
            string[] MaxSplits = Maxtemp.Split('.');



            DateTime dt = new DateTime(2000, 1, 1, 0, Maxmins, Convert.ToInt32(MaxSplits[0]), Convert.ToInt32(MaxSplits[1]));

            return dt;
        }

        public void setY_Value(double performance)
        {
            Y_Val = performance;
        }

        //public string ToString(bool time)
        //{
        //    if (time)
        //    {
        //        double ipet = ((24 * Y_Val)*60)*60;
        //        double seconds = ipet % 60;

        //        int mins = Convert.ToInt32((ipet - seconds) / 60);
        //        string newtime = mins + ":" + string.Format("{0:0.00}", seconds);

        //        return X_valAge + " " + newtime;
        //    }
        //    else
        //        return X_valAge + " " + Y_Val;
        //}


        /// <summary>
        /// converts a combination number to a value of 24 hours
        /// eg time = 3mins 40 secs 1 split :: number = 220.1 :: value = 0.00254745...
        /// </summary>
        /// <param name="value"></param>
        private void convertTodoubleTimeValue(double value)
        {
            double tempval = ((value / 60) / 60) / 24;
            Y_Val = tempval;
        }
        /// <summary>
        /// converts a value of 24 hours to a combination number
        /// eg value = 0.00254745... :: number = 220.1 :: time = 3mins 40 secs 1 split
        /// </summary>
        private double convertTodoubleTimeNumber()
        {
            double tempval = ((24 * Y_Val) * 60) * 60;
            return tempval;
        }
    }
}