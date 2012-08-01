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
        ///The original one that I thought it was
        ///</summary>
        [TestMethod()]
        public void SecondOrderPolynomialTest1()
        {
            PolynomialGraph_Accessor target = new PolynomialGraph_Accessor();
            double[] x = { 1, 2, 3, 4 };
            double[] y = { 1, 2, 3, 4 };

            double[] actual = target.SecondOrderPolynomial(x, y);
            double[] expected = new double[] { 0.0, 1.0, 0.0 };
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
        /// <summary>
        ///A test for SecondOrderPolynomial
        ///The original one that I thought it was
        ///</summary>
        [TestMethod()]
        public void SecondOrderPolynomialTest2()
        {
            PolynomialGraph_Accessor target = new PolynomialGraph_Accessor();
            double[] x = { 19.8f,20.8f,21.8f};
            double[] y = { 7917f,8142f,8327f};

            double[] actual = target.SecondOrderPolynomial(x, y);
            double[] expected = new double[] { -19.999997738748789,1036.9999220371246,-4774.7983207702637 };
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
                
            }
        }
        /// <summary>
        ///A test for SecondOrderPolynomial
        ///One on the internet that I think it should be.
        ///http://books.google.co.nz/books?id=afrRQCo_sHUC&pg=SA5-PA12&lpg=SA5-PA12&dq=how+excel+plots+2nd+order+polynomial+trend+lines&source=bl&ots=hB2MUeU_a9&sig=Xd9CNut6Px3z4UuQQmYxxup_GMY&hl=en&sa=X&ei=hK_2T62IDOSfiAf99JnjBg&ved=0CF8Q6AEwAw#v=onepage&q&f=false
        ///</summary>
        [TestMethod()]
        public void SecondOrderPolynomialTest3()
        {
            PolynomialGraph_Accessor target = new PolynomialGraph_Accessor();
            double[] x = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double[] y = { 1873, 1546, 1359, 1200, 547, 468, 512, 983, 1569, 1804 };

            double[] actual = target.SecondOrderPolynomial(x, y);
            double[] expected = new double[] { 63.462121212121019,-725.25303030303257,2731.7000000000044 };
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
            double[] x = { 1, 2, 3, 4 }; // TODO: Initialize to an appropriate value
            double[] y = { 1, 2, 3, 4 }; // TODO: Initialize to an appropriate value
            double[] actual = target.Matrix1x3(x, y);
            double[] expected = { 10, 30, 100 };

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
            double[] x = { 1, 2, 3, 4 }; // TODO: Initialize to an appropriate value

            double[,] expected = new double[,]{
                {4,  10, 30},
	            {10, 30, 100},
	            {30, 100, 354},
            };

            double[,] actual = target.Matrix3x3(x);


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
            double[,] matrix3x3 = new double[,]{
            {4,10,30},
            {10,30,100},
            {30,100,354}
            }; // TODO: Initialize to an appropriate value
            double[,] expected = new double[,]{
            {7.75,-6.75,1.25},
            {-6.75,6.45,-1.25},
            {1.25,-1.25,0.25}
            }; // TODO: Initialize to an appropriate value

            double[,] actual = target.Matrix3x3Inverse(matrix3x3);

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
