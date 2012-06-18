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

        public fPoint()
        {
            X_valDate = new DateTime(1111, 11, 11);
            Y_Val = 11.11f;
        }
        /// <summary>
        /// Stores a Performance for Track Events
        /// </summary>
        public fPoint(DateTime x, float y)
        {
            X_valDate = x;
            Y_Val = y;
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
            return Y_Val;
        }

        public void setY_Value(float performance)
        {
            Y_Val = performance;
        }
        override public string ToString()
        {
            return X_valDate.Date.ToString("dd'/'MM'/'yyyy") + " " + Y_Val;
        }
    }
}
