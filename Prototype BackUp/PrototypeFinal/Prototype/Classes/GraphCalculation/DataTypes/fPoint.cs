using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Attempt1MathCalculation
{
    struct fPoint
    {
        private float X_valAge;
        private float Y_Val;

        public static fPoint ConstructDefault()
        {
            return new fPoint(1111f, 1111f);
        }

        /// <summary>
        /// Stores a Performance for Track Events
        /// </summary>
        public fPoint(float x, float y)
        {
            X_valAge = x;
            Y_Val = y;
        }

        public float getX_Age()
        {
            return X_valAge;
        }

        public void setX_Age(float date)
        {

            X_valAge = date;

        }


        public float getY_Value_AsFloat()
        {
            return Y_Val;
        }

        public DateTime getY_Value_AsDate()
        {
            //Note: Currently only working for mins secs and splits. You want to do more than 59 mins for a race its gonna cause you issues
            int mins = (int)Y_Val / 60;
            int secs = (int)Y_Val % 60;
            double splits = Convert.ToDouble((Y_Val - mins * 60 - secs)) * 100;
            DateTime dt = new DateTime(2000, 1, 1, 0, mins, secs, Convert.ToInt32(splits));

            return dt;
        }

        public void setY_Value(float performance)
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
        private void convertTofloatTimeValue(float value)
        {
            float tempval = ((value / 60) / 60) / 24;
            Y_Val = tempval;
        }
        /// <summary>
        /// converts a value of 24 hours to a combination number
        /// eg value = 0.00254745... :: number = 220.1 :: time = 3mins 40 secs 1 split
        /// </summary>
        private float convertTofloatTimeNumber()
        {
            float tempval = ((24 * Y_Val) * 60) * 60;
            return tempval;
        }
    }
}