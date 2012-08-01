using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Attempt1MathCalculation
{
    class PolynomialGraph
    {
        public double[] Polynomial(List<fPoint> list)
        {
            List<fPoint> temp = new List<fPoint>();
            foreach (fPoint t in list)
            {
                if (t.getX_Age().CompareTo(1111) != 0)
                {
                    temp.Add(t);
                }

            }
            double[] listX = Enumerable.Repeat(-1.0, temp.Count).ToArray();
            double[] listY = Enumerable.Repeat(-1.0, temp.Count).ToArray();

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
        public double[] SecondOrderPolynomial(double[] x, double[] y)
        {

            //initialise the matrix
            double[,] MatrixA = Matrix3x3(x);
            double[] MatrixB = Matrix1x3(x, y);
            double[,] MatrixA_1 = Matrix3x3Inverse(MatrixA);
            double[] MatrixABC = new double[] { 0, 0, 0 };


            //MessageBox.Show(MatrixA_1[0, 0] + " " + MatrixA_1[1, 0] + " " + MatrixA_1[2, 0] + " \r\n" + MatrixA_1[0, 1] + " " + MatrixA_1[1, 1] + " " + MatrixA_1[2, 1] + " \r\n" + MatrixA_1[0, 2] + " " + MatrixA_1[1, 2] + " " + MatrixA_1[2, 2]);
            //MessageBox.Show(MatrixB[0] + " \r\n" + MatrixB[1] + " \r\n" + MatrixB[2]);

            MatrixABC[2] = MatrixA_1[0, 0] * MatrixB[0] + MatrixA_1[1, 0] * MatrixB[1] + MatrixA_1[2, 0] * MatrixB[2];
            MatrixABC[1] = MatrixA_1[0, 1] * MatrixB[0] + MatrixA_1[1, 1] * MatrixB[1] + MatrixA_1[2, 1] * MatrixB[2];
            MatrixABC[0] = MatrixA_1[0, 2] * MatrixB[0] + MatrixA_1[1, 2] * MatrixB[1] + MatrixA_1[2, 2] * MatrixB[2];

            //returns a b c in a array
            return MatrixABC;
        }

        protected double[,] Matrix3x3(double[] x)
        {
            double[,] MatrixA = new double[,]{
                {0, 0, 0},
	            {0, 0, 0},
	            {0, 0, 0},
            };


            double temp_xx = 0;
            double temp_xxx = 0;
            double temp_xxxx = 0;

            foreach (double value in x)
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

        protected double[] Matrix1x3(double[] x, double[] y)
        {
            double[] MatrixB = new double[] { 0, 0, 0 };
            double temp_sqrd = 0;
            double temp2 = 0;
            double temp3 = 0;
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
        protected double[,] Matrix3x3Inverse(double[,] matrix3x3)
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

            double a11 = matrix3x3[0, 0];
            double a12 = matrix3x3[1, 0];
            double a13 = matrix3x3[2, 0];
            double a21 = matrix3x3[0, 1];
            double a22 = matrix3x3[1, 1];
            double a23 = matrix3x3[2, 1];
            double a31 = matrix3x3[0, 2];
            double a32 = matrix3x3[1, 2];
            double a33 = matrix3x3[2, 2];

            double DET = 1 / (a11 * (a33 * a22 - a32 * a23) - a21 * (a33 * a12 - a32 * a13) + a31 * (a23 * a12 - a22 * a13));

            double[,] MatrixA_1 = new double[,]{
            {DET*(a33*a22-a32*a23),     DET*(-(a33*a12-a32*a13)),   DET*(a23*a12-a22*a13)},
            {DET*(-(a33*a21-a31*a23)),  DET*(a33*a11-a31*a13),      DET*(-(a23*a11-a21*a13))},
            {DET*(a32*a21-a31*a22),     DET*(-(a32*a11-a31*a12)),   DET*(a22*a11-a21*a12)}
            };


            return MatrixA_1;
        }
    }
}
