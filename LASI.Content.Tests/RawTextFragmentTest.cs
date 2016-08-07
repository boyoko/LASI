﻿using LASI.Content;
 using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;
namespace LASI.Content.Tests
{
    /// <summary>
    ///This is a test class for RawTextFragmentTest and is intended
    ///to contain all RawTextFragmentTest Unit Tests
    /// </summary>
    public class RawTextFragmentTest
    {

        /// <summary>
        ///A test for RawTextFragment Constructor
        /// </summary>
        [Fact]
        public void RawTextFragmentConstructorTest()
        {
            IEnumerable<string> text = new[] {
                "John enjoyed, with his usual lack of humility, consuming the object in question.",
                "Some may call him a heathen, but they are mistaken.",
                "Heathens are far less dangerous than he." };
            var name = "test fragment";
            var target = new RawTextFragment(text, name);
            Assert.Equal(target.Name, name);
            Assert.Equal(target.LoadText(), string.Join("\n", text));
        }

        /// <summary>
        ///A test for LoadText
        /// </summary>
        [Fact]
        public void LoadTextTest()
        {
            IEnumerable<string> text = new[] { "John enjoyed, with his usual lack of humility, consuming the object in question.",
                "Some may call him a heathen, but they are mistaken.",
                "Heathens are far less dangerous than he." };
            var name = "test fragment";
            var target = new RawTextFragment(text, name);
            var expected = string.Join("\n", text);
            var actual = target.LoadText();
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for LoadTextAsync
        /// </summary>
        [Fact]
        public void LoadTextAsyncTest()
        {
            IEnumerable<string> text = new[] {
                "John enjoyed, with his usual lack of humility, consuming the object in question.",
                "Some may call him a heathen, but they are mistaken.",
                "Heathens are far less dangerous than he." };
            var name = "test fragment";
            var target = new RawTextFragment(text, name);
            var expected = string.Join("\n", text);
            var actual = target.LoadTextAsync().Result;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///A test for op_Implicit
        /// </summary>
        [Fact]
        public void op_ImplicitTest()
        {
            IEnumerable<string> text = new[] {
                "John enjoyed, with his usual lack of humility, consuming the object in question.",
                "Some may call him a heathen, but they are mistaken.",
                "Heathens are far less dangerous than he." };
            var name = "test fragment";
            var fragment = new RawTextFragment(text, name);
            var expected = string.Join("\n", text);
            string actual;
            actual = fragment;
            Assert.Equal(expected, actual);
        }
    }
}
