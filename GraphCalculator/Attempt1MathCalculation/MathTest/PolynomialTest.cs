using Attempt1MathCalculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace MathTest
{
    
    
    /// <summary>
    ///This is a test class for Form1Test and is intended
    ///to contain all Form1Test Unit Tests
    ///</summary>
    [TestClass()]
    public class PolynomialTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for SecondOrderPolynomial
        ///</summary>
        [TestMethod()]
        public void SecondOrderPolynomialTest()
        {
            PolynomialGraph_Accessor target = new PolynomialGraph_Accessor();
            float[] x = { 1, 2, 3, 4 };
            float[] y = { 1, 2, 3, 4 };

            float[] actual = target.SecondOrderPolynomial(x,y);
            float[] expected = new float[] { -222.5f, 202.500030517578f, -37.5f };
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        ///A test for Matrix1x3
        ///</summary>
        [TestMethod()]
        public void Matrix1x3Test()
        {
            PolynomialGraph_Accessor target = new PolynomialGraph_Accessor(); // TODO: Initialize to an appropriate value
            float[] x = { 1, 2, 3, 4}; // TODO: Initialize to an appropriate value
            float[] y = { 1, 2, 3, 4}; // TODO: Initialize to an appropriate value
            float[] actual = target.Matrix1x3(x, y);
            float[] expected = { 10,100,300};
            
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }
        }

        /// <summary>
        ///A test for Matrix3x3
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Attempt1MathCalculation.exe")]
        public void Matrix3x3Test()
        {
            PolynomialGraph_Accessor target = new PolynomialGraph_Accessor(); // TODO: Initialize to an appropriate value
            float[] x = { 1, 2, 3, 4 }; // TODO: Initialize to an appropriate value

            float[,] expected = new float[,]{
                {4,  10, 30},
	            {10, 30, 100},
	            {30, 100, 354},
            };

            float[,] actual = target.Matrix3x3(x);


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }

        /// <summary>
        ///A test for Matrix3x3Inverse
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Attempt1MathCalculation.exe")]
        public void Matrix3x3InverseTest()
        {
            PolynomialGraph_Accessor target = new PolynomialGraph_Accessor(); // TODO: Initialize to an appropriate value
            float[,] matrix3x3 = new float[,]{
            {1,2,3},
            {2,3,1},
            {3,1,2}
            }; // TODO: Initialize to an appropriate value
            float[,] expected = new float[,]{
            {-0.277777778f,0.055555556f,0.388888889f},
            {0.055555556f,0.388888889f,-0.277777778f},
            {0.388888889f,-0.277777778f,0.055555556f}
            }; // TODO: Initialize to an appropriate value
            float[,] actual = target.Matrix3x3Inverse(matrix3x3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual((expected[i, j]), (actual[i, j]));
                }
            }
            //test
        }
    }
}
