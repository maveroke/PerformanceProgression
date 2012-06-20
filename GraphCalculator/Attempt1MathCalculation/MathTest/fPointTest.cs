using Attempt1MathCalculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathTest
{
    
    
    /// <summary>
    ///This is a test class for fPointTest and is intended
    ///to contain all fPointTest Unit Tests
    ///</summary>
    [TestClass()]
    public class fPointTest
    {


        private TestContext testContextInstance;
        private static fPoint target;
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
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
                    DateTime x = new DateTime(2000,12,25); // TODO: Initialize to an appropriate value
            float y = 11.5f; // TODO: Initialize to an appropriate value
            target = new fPoint(x, y, false); // TODO: Initialize to an appropriate value
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            string expected = "25/12/2000 11.5"; // TODO: Initialize to an appropriate value
            string actual = target.ToString(false);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for X_Date
        ///</summary>
        [TestMethod()]
        public void X_DateTest()
        {
            DateTime expected = new DateTime(2000,12,25); // TODO: Initialize to an appropriate value
            DateTime actual;
            actual = target.getX_Date();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Y_Distance
        ///</summary>
        [TestMethod()]
        public void Y_DistanceTest()
        {
            DateTime x = new DateTime(); // TODO: Initialize to an appropriate value
            float y = 12.21f; // TODO: Initialize to an appropriate value
            fPoint target = new fPoint(x, y, false); // TODO: Initialize to an appropriate value
            float expected = 12.21F; // TODO: Initialize to an appropriate value
            float actual = target.getY_Value_AsFloat();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Y_ValDistance
        ///</summary>
        [TestMethod()]
        public void Y_TimeTest()
        {
            float expected = 11.5f; // TODO: Initialize to an appropriate value
            float actual = target.getY_Value_AsFloat();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for Y_ValDistance ToString
        ///</summary>
        [TestMethod()]
        public void Y_TimeTests()
        {
            DateTime x = new DateTime(2000, 12, 25);
            float y = 1978.66f; // TODO: Initialize to an appropriate value
            target = new fPoint(x, y, false); // TODO: Initialize to an appropriate value
            string expected = "25/12/2000 1978.66"; // TODO: Initialize to an appropriate value
            string actual = target.ToString(false);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for setX_Date
        ///</summary>
        [TestMethod()]
        public void setX_DateTest()
        {
            target.setX_Date(new DateTime(4444, 4, 4));
            String expected = "04/04/4444 11.5";
            String actual = target.ToString(false);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for setY_Value
        ///</summary>
        [TestMethod()]
        public void setY_ValueTestDouble()
        {
            target.setY_Value(5555);
            String expected = "25/12/2000 5555";
            String actual = target.ToString(false);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for setY_Value
        ///</summary>
        [TestMethod()]
        public void setY_ValueTestTime()
        {
            float time = 12.5f;
            float value = ((time / 60) / 60) / 24;
            target.setY_Value(value);
            String expected = "25/12/2000 0:12.50";
            String actual = target.ToString(true);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for getY_ValueTime
        ///</summary>
        [TestMethod()]
        public void getY_ValueTestTime()
        {
            fPoint target = new fPoint(new DateTime(1111, 11, 11), 11.5f,true);
            float time = 12.5f;
            target.setY_Value(time);
            float expected = 12.5f;
            float actual = target.getY_Value_AsFloat();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getY_Value_AsDate
        ///</summary>
        [TestMethod()]
        public void getY_Value_AsDateTest()
        {
            fPoint target = new fPoint(new DateTime(1111, 11, 11), 71.54f, true);
            DateTime expected = new DateTime(2000,1,1,0,1,11,54); // TODO: Initialize to an appropriate value
            DateTime actual = target.getY_Value_AsDate();
            Assert.AreEqual(expected, actual);
        }
    }
}
