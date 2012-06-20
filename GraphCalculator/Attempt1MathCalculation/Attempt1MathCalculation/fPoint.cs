using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Attempt1MathCalculation
{
    class fPoint
    {
        protected DateTime X_valDate;
        protected float Y_Val;
        protected bool Time = false;

        public fPoint()
        {
            X_valDate = new DateTime(1111, 11, 11);
            Y_Val = 11111f;
        }
        public fPoint(bool time)
        {
            Time = true;
            X_valDate = new DateTime(1111, 11, 11);
            convertTofloatTimeValue(1.1f);
        }
        /// <summary>
        /// Stores a Performance for Track Events
        /// </summary>
        public fPoint(DateTime x, float y,bool time)
        {
            Time = time;
            X_valDate = x;
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
        public DateTime getX_Date()
        {
            return X_valDate;
        }

        public void setX_Date(DateTime date)
        {

            X_valDate = date;
            
        }

        public float getY_Value()
        {
            if (Time) return convertTofloatTimeNumber();
            else return Y_Val;
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

                return X_valDate.Date.ToString("dd'/'MM'/'yyyy") + " " + newtime;
            }
            else
                return X_valDate.Date.ToString("dd'/'MM'/'yyyy") + " " + Y_Val;
        }

    }
}
