using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Attempt1MathCalculation
{
    class PolynomialGraph
    {
        public float[] Polynomial(List<fPoint> list)
        {
            List<fPoint> temp = new List<fPoint>();
            foreach (fPoint t in list)
            {
                if (t.getX_Age().CompareTo(1111) != 0)
                {
                    temp.Add(t);
                }

            }
            float[] listX = Enumerable.Repeat(-1f, temp.Count).ToArray();
            float[] listY = Enumerable.Repeat(-1f, temp.Count).ToArray();

            int i = 0;
            foreach (fPoint f in temp)
            {
                listX[i] = f.getX_Age();
                listY[i] = f.getY_Value_AsFloat();
                i++;
            }
            return SecondOrderPolynomial(listX, listY);
        }
        /// <summary>
        /// takes 2 float arrays of all x,y values
        /// </summary>
        /// <returns>
        /// returns a float array of the values a,b,c for the equation
        /// y = ax^2+bx+c
        /// </returns>
        public float[] SecondOrderPolynomial(float[] x, float[] y)
        {

            //initialise the matrix
            float[,] MatrixA = Matrix3x3(x);
            float[] MatrixB = Matrix1x3(x, y);
            float[,] MatrixA_1 = Matrix3x3Inverse(MatrixA);
            float[] MatrixABC = new float[] { 0, 0, 0 };

            MatrixABC[0] = MatrixA_1[0, 0] * MatrixB[0] + MatrixA_1[1, 0] * MatrixB[1] + MatrixA_1[2, 0] * MatrixB[2];
            MatrixABC[1] = MatrixA_1[0, 1] * MatrixB[0] + MatrixA_1[1, 1] * MatrixB[1] + MatrixA_1[2, 1] * MatrixB[2];
            MatrixABC[2] = MatrixA_1[0, 2] * MatrixB[0] + MatrixA_1[1, 2] * MatrixB[1] + MatrixA_1[2, 2] * MatrixB[2];

            //returns a b c in a array
            return MatrixABC;
        }

        protected float[,] Matrix3x3(float[] x)
        {
            float[,] MatrixA = new float[,]{
                {0, 0, 0},
	            {0, 0, 0},
	            {0, 0, 0},
            };


            float temp_xx = 0;
            float temp_xxx = 0;
            float temp_xxxx = 0;

            foreach (float value in x)
            {
                temp_xx += value * value;
                temp_xxx += value * value * value;
                temp_xxxx += value * value * value * value;
            }
            MatrixA[0, 0] = x.Count();
            MatrixA[1, 0] = x.Sum();
            MatrixA[2, 0] = temp_xx;
            MatrixA[0, 1] = x.Sum();
            MatrixA[1, 1] = temp_xx;
            MatrixA[2, 1] = temp_xxx;
            MatrixA[0, 2] = temp_xx;
            MatrixA[1, 2] = temp_xxx;
            MatrixA[2, 2] = temp_xxxx;

            return MatrixA;
        }

        protected float[] Matrix1x3(float[] x, float[] y)
        {
            float[] MatrixB = new float[] { 0, 0, 0 };
            float temp = 0;
            foreach (float x_val in x)
            {
                temp += x_val * x_val;
            }
            MatrixB[0] = y.Sum();
            MatrixB[1] = y.Sum() * x.Sum();
            MatrixB[2] = temp * y.Sum();
            return MatrixB;
        }
        protected float[,] Matrix3x3Inverse(float[,] matrix3x3)
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

            float a11 = matrix3x3[0, 0];
            float a12 = matrix3x3[1, 0];
            float a13 = matrix3x3[2, 0];
            float a21 = matrix3x3[0, 1];
            float a22 = matrix3x3[1, 1];
            float a23 = matrix3x3[2, 1];
            float a31 = matrix3x3[0, 2];
            float a32 = matrix3x3[1, 2];
            float a33 = matrix3x3[2, 2];

            float DET = 1 / (a11 * (a33 * a22 - a32 * a23) - a21 * (a33 * a12 - a32 * a13) + a31 * (a23 * a12 - a22 * a13));

            float[,] MatrixA_1 = new float[,]{
            {DET*(a33*a22-a32*a23),     DET*(-(a33*a12-a32*a13)),   DET*(a23*a12-a22*a13)},
            {DET*(-(a33*a21-a31*a23)),  DET*(a33*a11-a31*a13),      DET*(-(a23*a11-a21*a13))},
            {DET*(a32*a21-a31*a22),     DET*(-(a32*a11-a31*a12)),   DET*(a22*a11-a21*a12)}
            };


            return MatrixA_1;
        }
    }
}
