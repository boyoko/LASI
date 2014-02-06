﻿using LASI.Core.Heuristics.Morphemization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using LASI.Core;

namespace L_CoreTests
{
    
    
    /// <summary>
    ///This is a test class for AdverbMorpherTest and is intended
    ///to contain all AdverbMorpherTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AdverbMorpherTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
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
        ///A test for GetLexicalForms
        ///</summary>
        [TestMethod()]
        public void GetLexicalFormsTest() {
            string search = string.Empty; // TODO: Initialize to an appropriate value
            IEnumerable<string> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<string> actual;
            actual = AdverbMorpher.GetLexicalForms(search);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindRoot
        ///</summary>
        [TestMethod()]
        public void FindRootTest() {
            Adverb adverb = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = AdverbMorpher.FindRoot(adverb);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FindRoot
        ///</summary>
        [TestMethod()]
        public void FindRootTest1() {
            string adverbText = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = AdverbMorpher.FindRoot(adverbText);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
