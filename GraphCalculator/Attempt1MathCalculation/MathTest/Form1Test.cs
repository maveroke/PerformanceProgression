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
    public class Form1Test
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
            Form1 target = new Form1(); // TODO: Initialize to an appropriate value
            float[] iper = { 1,2,3,4};
            float[] SumOf = {3376};
            float test = target.SecondOrderPolynomial(iper,iper);

                Assert.AreEqual(test,10);
        }

        /// <summary>
        ///A test for Matrix1x3
        ///</summary>
        [TestMethod()]
        public void Matrix1x3Test()
        {
            Form1_Accessor target = new Form1_Accessor(); // TODO: Initialize to an appropriate value
            float[] x = { 1, 2, 3, 4}; // TODO: Initialize to an appropriate value
            float[] y = { 1, 2, 3, 4}; // TODO: Initialize to an appropriate value
            float[] temp = target.Matrix1x3(x, y);
            float[] check = { 10,100,300};
            int p = 0;
            foreach (float i in temp)
            {
                Assert.AreEqual(i, check[p]);
                p++;
            }
        }

        /// <summary>
        ///A test for Matrix3x3
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Attempt1MathCalculation.exe")]
        public void Matrix3x3Test()
        {
            Form1_Accessor target = new Form1_Accessor(); // TODO: Initialize to an appropriate value
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
    }
}
