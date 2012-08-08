using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Attempt1MathCalculation
{
    class PolynomialGraph
    {
        public decimal[] Polynomial(List<fPoint> list)
        {
            List<fPoint> temp = new List<fPoint>();
            foreach (fPoint t in list)
            {
                if (t.getX_Age().CompareTo(1111) != 0)
                {
                    temp.Add(t);
                }

            }
            decimal[] listX = Enumerable.Repeat((decimal)-1.0, temp.Count).ToArray();
            decimal[] listY = Enumerable.Repeat((decimal)-1.0, temp.Count).ToArray();

            int i = 0;
            foreach (fPoint f in temp)
            {
                listX[i] = f.getX_Age();
                listY[i] = f.getY_Value_Asdouble();
                i++;
            }
            return SecondOrderPolynomial(listX, listY);
        }
        /// <summary>
        /// takes 2 double arrays of all x,y values
        /// </summary>
        /// <returns>
        /// returns a double array of the values a,b,c for the equation
        /// y = ax^2+bx+c
        /// </returns>
        public decimal[] SecondOrderPolynomial(decimal[] x, decimal[] y)
        {

            //initialise the matrix
            decimal[,] MatrixA = Matrix3x3(x);
            decimal[] MatrixB = Matrix1x3(x, y);
            decimal[,] MatrixA_1 = Matrix3x3Inverse(MatrixA);
            decimal[] MatrixABC = new decimal[] { 0, 0, 0 };


            //MessageBox.Show(MatrixA_1[0, 0] + " " + MatrixA_1[1, 0] + " " + MatrixA_1[2, 0] + " \r\n" + MatrixA_1[0, 1] + " " + MatrixA_1[1, 1] + " " + MatrixA_1[2, 1] + " \r\n" + MatrixA_1[0, 2] + " " + MatrixA_1[1, 2] + " " + MatrixA_1[2, 2]);
            //MessageBox.Show(MatrixB[0] + " \r\n" + MatrixB[1] + " \r\n" + MatrixB[2]);

            MatrixABC[2] = MatrixA_1[0, 0] * MatrixB[0] + MatrixA_1[1, 0] * MatrixB[1] + MatrixA_1[2, 0] * MatrixB[2];
            MatrixABC[1] = MatrixA_1[0, 1] * MatrixB[0] + MatrixA_1[1, 1] * MatrixB[1] + MatrixA_1[2, 1] * MatrixB[2];
            MatrixABC[0] = MatrixA_1[0, 2] * MatrixB[0] + MatrixA_1[1, 2] * MatrixB[1] + MatrixA_1[2, 2] * MatrixB[2];

            //returns a b c in a array
            return MatrixABC;
        }

        protected decimal[,] Matrix3x3(decimal[] x)
        {
            decimal[,] MatrixA = new decimal[,]{
                {0, 0, 0},
	            {0, 0, 0},
	            {0, 0, 0},
            };


            decimal temp_xx = 0;
            decimal temp_xxx = 0;
            decimal temp_xxxx = 0;

            foreach (decimal value in x)
            {
                temp_xx += value * value;
                temp_xxx += value * value * value;
                temp_xxxx += value * value * value * value;
            }
            MatrixA[0, 0] = x.Count();
            MatrixA[0, 1] = x.Sum();
            MatrixA[0, 2] = temp_xx;
            MatrixA[1, 0] = x.Sum();
            MatrixA[1, 1] = temp_xx;
            MatrixA[1, 2] = temp_xxx;
            MatrixA[2, 0] = temp_xx;
            MatrixA[2, 1] = temp_xxx;
            MatrixA[2, 2] = temp_xxxx;

            return MatrixA;
        }

        protected decimal[] Matrix1x3(decimal[] x, decimal[] y)
        {
            decimal[] MatrixB = new decimal[] { 0, 0, 0 };
            decimal temp_sqrd = 0;
            decimal temp2 = 0;
            decimal temp3 = 0;
            for (int i = 0; i < x.LongLength; i++)
            {
                temp_sqrd = x[i] * x[i];
                temp2 += x[i] * y[i];
                temp3 += temp_sqrd * y[i];
            }
            MatrixB[0] = y.Sum();
            MatrixB[1] = temp2;
            MatrixB[2] = temp3;
            return MatrixB;
        }
        protected decimal[,] Matrix3x3Inverse(decimal[,] matrix3x3)
        {
            /* 0,0 = 11
             * 1,0 = 12
             * 2,0 = 13
             * 
             * 0,1 = 21
             * 1,1 = 22
             * 2,1 = 23
             * 
             * 0,2 = 31
             * 1,2 = 32
             * 2,2 = 33
             */

            decimal a11 = matrix3x3[0, 0];
            decimal a12 = matrix3x3[1, 0];
            decimal a13 = matrix3x3[2, 0];
            decimal a21 = matrix3x3[0, 1];
            decimal a22 = matrix3x3[1, 1];
            decimal a23 = matrix3x3[2, 1];
            decimal a31 = matrix3x3[0, 2];
            decimal a32 = matrix3x3[1, 2];
            decimal a33 = matrix3x3[2, 2];

            decimal DET = 1 / (a11 * (a33 * a22 - a32 * a23) - a21 * (a33 * a12 - a32 * a13) + a31 * (a23 * a12 - a22 * a13));

            decimal[,] MatrixA_1 = new decimal[,]{
            {DET*(a33*a22-a32*a23),     DET*(-(a33*a12-a32*a13)),   DET*(a23*a12-a22*a13)},
            {DET*(-(a33*a21-a31*a23)),  DET*(a33*a11-a31*a13),      DET*(-(a23*a11-a21*a13))},
            {DET*(a32*a21-a31*a22),     DET*(-(a32*a11-a31*a12)),   DET*(a22*a11-a21*a12)}
            };


            return MatrixA_1;
        }
    }
}
