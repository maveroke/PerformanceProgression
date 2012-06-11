using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Attempt1MathCalculation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            float[] iper_x = { 1,2,3,4};
            float[] iper_y = { 1,2,3,4};
            SecondOrderPolynomial(iper_x, iper_y);
        }
        /// <summary>
        /// takes 2 float arrays of all x,y values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public float SecondOrderPolynomial(float[] x, float[] y)
        {

            //initialise the matrix
            Matrix3x3(x);


            float[] MatrixB = Matrix1x3(x, y);

            //returns a b c in a array
            float iper = y.Sum();
            return iper;
        }

        private float[,] Matrix3x3(float[] x)
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

        private float[] Matrix1x3(float[] x, float[] y)
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
    }
}
