﻿using LASI.Content;
using LASI.Content.Tagging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NFluent;
using Fact = Xunit.FactAttribute;

namespace LASI.Content.Tests
{


    /// <summary>
    ///This is a test class for TaggedTextFragmentTest and is intended
    ///to contain all TaggedTextFragmentTest Unit Tests
    /// </summary>
    public class TaggedTextFragmentTest
    {

        private Tagger Tagger => new Tagger();

        /// <summary>
        ///A test for TaggedTextFragment Constructor
        /// </summary>
        [Fact]
        public void TaggedTextFragmentConstructorTest()
        {
            var lines = Tagger.TaggedFromRaw(new[] {
                "This is a test which i will not regret.",
                "While it may yield me, in the context of the system at large, only ",
                "a little confidence, each test makes everything else that much better."
            });
            string name = "Test Fragment";
            TaggedTextFragment target = new TaggedTextFragment(lines, name);
            Check.That(target.Name).IsEqualTo(name);
        }

        /// <summary>
        ///A test for LoadText
        /// </summary>
        [Fact]
        public void LoadTextTest()
        {
            var lines = Tagger.TaggedFromRaw(new[] {
                "This is a test which i will not regret.",
                "While it may yield me, in the context of the system at large, only ",
                "a little confidence, each test makes everything else that much better."
            });
            string name = "Test Fragment";
            TaggedTextFragment target = new TaggedTextFragment(lines, name);
            string expected = string.Join("\n", lines);
            string actual;
            actual = target.LoadText();
            Check.That(actual).IsEqualTo(expected);
        }

        /// <summary>
        ///A test for LoadTextAsync
        /// </summary>
        [Fact]
        public void LoadTextAsyncTest()
        {
            var lines = Tagger.TaggedFromRaw(new[] {
                "This is a test which i will not regret.",
                "While it may yield me, in the context of the system at large, only ",
                "a little confidence, each test makes everything else that much better."
            });
            string name = "Test Fragment";
            TaggedTextFragment target = new TaggedTextFragment(lines, name);
            string expected = string.Join("\n", lines);
            string actual = null;
            Task.WaitAll(Task.Run(async () => actual = await target.LoadTextAsync()));
            Check.That(actual).IsEqualTo(expected);
        }
    }
}
