using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Attempt1MathCalculation
{
    class fPoint
    {
        protected float X_valAge;
        protected float Y_Val;
        protected bool Time = false;

        public fPoint()
        {
            X_valAge = 11111f;
            Y_Val = 11111f;
        }
        public fPoint(bool time)
        {
            Time = true;
            X_valAge = 11111f;
            convertTofloatTimeValue(1.1f);
        }
        /// <summary>
        /// Stores a Performance for Track Events
        /// </summary>
        public fPoint(float x, float y, bool time)
        {
            Time = time;
            X_valAge = x;
            Y_Val = y;
        }

        public bool getTrackField()
        {
            return Time;
        }
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
        public float getX_Date()
        {
            return X_valAge;
        }

        public void setX_Date(float date)
        {

            X_valAge = date;
            
        }

        public float getY_Value_AsFloat()
        {
            if (Time) return convertTofloatTimeNumber();
            else return Y_Val;
            
        }
        public DateTime getY_Value_AsDate()
        {
            double sec = Y_Val % 60;

            int mins = Convert.ToInt32((Y_Val - sec) / 60);
            int secs = (int)sec;
            string[] temp = sec.ToString().Split('.');

            int split = Convert.ToInt32(temp[1].Substring(0, 2));
            DateTime dt = new DateTime(2000, 1, 1, 0, mins, secs, split);
            DateTime dtt = new DateTime();
            dtt.AddHours(0);
            dtt.AddMinutes(mins);
            dtt.AddSeconds(secs);
            dtt.AddMilliseconds(secs);
            return dtt;
        }
        public void setY_Value(float performance)
        {
            Y_Val = performance;
            if (Time) convertTofloatTimeValue(performance);
        }
        public string ToString(bool time)
        {
            if (time)
            {
                double ipet = ((24 * Y_Val)*60)*60;
                double seconds = ipet % 60;
                
                int mins = Convert.ToInt32((ipet - seconds) / 60);
                string newtime = mins + ":" + string.Format("{0:0.00}", seconds);

                return X_valAge + " " + newtime;
            }
            else
                return X_valAge + " " + Y_Val;
        }

    }
}
