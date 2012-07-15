﻿using Attempt1MathCalculation;
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
        ///A test for fPoint Constructor
        ///</summary>
        [TestMethod()]
        public void fPointConstructorTest()
        {
            fPoint target = new fPoint();
            Assert.AreEqual(target.getX_Age(), 1111f);
            Assert.AreEqual(target.getY_Value_AsFloat(), 1111f);

        }

        /// <summary>
        ///A test for fPoint Constructor
        ///</summary>
        [TestMethod()]
        public void fPointConstructorTest1()
        {
            float x = 10F; // TODO: Initialize to an appropriate value
            float y = 10F; // TODO: Initialize to an appropriate value
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 10, 0);
            fPoint target = new fPoint(x, y);

            Assert.AreEqual(target.getX_Age(), 10);
            Assert.AreEqual(target.getY_Value_AsDate(), dt);
        }

        /// <summary>
        ///A test for fPoint Constructor
        ///</summary>
        [TestMethod()]
        public void fPointConstructorTest2()
        {
            fPoint target = new fPoint();

            DateTime dt = new DateTime(2000, 1, 1, 0, 18, 31, 0);

            Assert.AreEqual(target.getX_Age(), 1111f);
            Assert.AreEqual(target.getY_Value_AsDate(), dt);
        }

        /// <summary>
        ///A test for getX_Age
        ///</summary>
        [TestMethod()]
        public void getX_AgeTest()
        {
            fPoint target = new fPoint(); // TODO: Initialize to an appropriate value
            float expected = 1111f; // TODO: Initialize to an appropriate value
            float actual;
            actual = target.getX_Age();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getY_Value_AsDate
        ///</summary>
        [TestMethod()]
        public void getY_Value_AsDateTest()
        {
            fPoint target = new fPoint(13, 71.5f); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(2000, 1, 1, 0, 1, 11, 50); // TODO: Initialize to an appropriate value
            DateTime actual = target.getY_Value_AsDate();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getY_Value_AsFloat
        ///</summary>
        [TestMethod()]
        public void getY_Value_AsFloatTest()
        {
            fPoint target = new fPoint(); // TODO: Initialize to an appropriate value
            float expected = 1111F; // TODO: Initialize to an appropriate value
            float actual;
            actual = target.getY_Value_AsFloat();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for setX_Age
        ///</summary>
        [TestMethod()]
        public void setX_AgeTest()
        {
            fPoint target = new fPoint(); // TODO: Initialize to an appropriate value
            float date = 120F; // TODO: Initialize to an appropriate value
            target.setX_Age(date);
            Assert.AreEqual(target.getX_Age(), date);
        }

        /// <summary>
        ///A test for setY_Value
        ///</summary>
        [TestMethod()]
        public void setY_ValueTest()
        {
            fPoint target = new fPoint(); // TODO: Initialize to an appropriate value
            float performance = 1230F; // TODO: Initialize to an appropriate value
            target.setY_Value(performance);
            Assert.AreEqual(target.getY_Value_AsFloat(), performance);
        }
    }
}
