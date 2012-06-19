﻿using Attempt1MathCalculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Collections.Generic;

namespace MathTest
{
    
    
    /// <summary>
    ///This is a test class for AthletesTest and is intended
    ///to contain all AthletesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AthletesTest
    {


        private TestContext testContextInstance;
        private static Athletes target;

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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            List<fPoint> pt = new List<fPoint>() { new fPoint(new DateTime(1111, 11, 11), 2, false), new fPoint(new DateTime(4321, 11, 11), 3, false), new fPoint(new DateTime(1112, 11, 11), 3, false), new fPoint(new DateTime(1123, 11, 11), 4, false), new fPoint(new DateTime(1234, 11, 11), 5, false) };
            target = new Athletes("Name","Medal",pt); // TODO: Initialize to an appropriate value
        }
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
        ///A test for getName
        ///</summary>
        [TestMethod()]
        public void getNameTest()
        {
            
            string expected = "Name"; // TODO: Initialize to an appropriate value
            string actual = target.getName();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getStatus
        ///</summary>
        [TestMethod()]
        public void getStatusTest()
        {
            string expected = "Medal"; // TODO: Initialize to an appropriate value
            string actual = target.getStatus();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for getData
        ///</summary>
        [TestMethod()]
        public void getDataTest()
        {
            List<fPoint> expected = new List<fPoint>() { new fPoint(new DateTime(1111, 11, 11), 2, false), new fPoint(new DateTime(4321, 11, 11), 3, false), new fPoint(new DateTime(1112, 11, 11), 3, false), new fPoint(new DateTime(1123, 11, 11), 4, false), new fPoint(new DateTime(1234, 11, 11), 5, false) };
            List<fPoint> actual = target.getData();
            
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].ToString(), actual[i].ToString());
            }
        }
    }
}
