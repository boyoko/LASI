﻿using LASI.Utilities.SupportTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using LASI.UnitTests;

namespace LASI.Utilities.Tests
{
    [TestClass]
    public class OptionTest
    {
        [TestMethod]
        public void ValueTest1() {
            Option<string> target = "str".ToOption();
            Assert.IsInstanceOfType(target, typeof(Option<string>));
        }
        [TestMethod]
        public void CoalescenseTest1() {
            Option<string> target = "str".ToOption().ToOption();
            Assert.AreEqual(target, "str".ToOption());
            Assert.AreEqual("str".ToOption(), target);
        }
        [TestMethod]
        public void CoalescenseTest2() {
            Option<string> target = "str".ToOption();
            for (var i = 0; i < new Random().Next(0, 100); ++i) {
                target = target.ToOption();
            }
            Assert.AreEqual(target, "str".ToOption());
            Assert.AreEqual("str".ToOption(), target);
        }
        [TestMethod]
        public void OptionFromNullTest1() {
            Option<object> target = FromNullFactory<object>();
            Assert.IsFalse(target.HasValue);
        }

        [TestMethod]
        [ExpectedInvalidOperationException]
        public void OptionFromNullTest2() {
            Option<object> target = FromNullFactory<object>();
            object value = target.Value;// Must fail
        }
        [TestMethod]
        public void OptionFromValueTest1() {
            const string source = "str";
            Option<string> target = source.ToOption();
            string value = target.Value;
            Assert.AreEqual(value, source);
        }
        [TestMethod]
        public void OptionFromValueTest2() {
            const string source = "str";
            Option<string> target = source.ToOption();
            Assert.IsTrue(target.HasValue);
        }
        [TestMethod]
        public void OptionFromValueSelectTest1() {
            const string source = "str";
            Option<string> target = source.ToOption();
            Option<string> projected = target.Select(x => x.ToUpper());
            Assert.IsTrue(projected.HasValue);
            string value = projected.Value;
            Assert.AreEqual(value, source.ToUpper());
        }
        [TestMethod]
        public void OptionFromValueSelectTest2() {
            const string source = "str";
            Option<string> target = source.ToOption();
            Option<string> projected = from vx in target
                                       select vx.ToUpper();
            Assert.IsTrue(projected.HasValue);
            string value = projected.Value;
            Assert.AreEqual(value, source.ToUpper());
        }
        [TestMethod]
        public void OptionFromNullTestWhereTest1() {
            Option<object> filtered = OptionFromNullWhereTestHelper<object>(x => true);     // Should always return None, never applying the predicate.
            Assert.IsFalse(filtered.HasValue);
        }

        [TestMethod]
        public void OptionFromNullTestWhereTest2() {
            Option<object> filtered = OptionFromNullWhereTestHelper<object>(x => false);
            Assert.IsFalse(filtered.HasValue);
        }

        [TestMethod]
        [ExpectedInvalidOperationException]
        public void OptionFromNullTestWhereTest3() {
            Option<object> filtered = OptionFromNullWhereTestHelper<object>(x => true);
            object value = filtered.Value; // Must fail
        }

        [TestMethod]
        public void OptionFromNullSelectTest1() {
            Option<object> target = FromNullFactory<object>();
            Option<int> projected = target.Select(x => 1);
            Assert.IsFalse(projected.HasValue);
        }

        [TestMethod]
        [ExpectedInvalidOperationException]
        public void OptionFromNullSelectTest2() {
            Option<object> target = FromNullFactory<object>();
            Option<int> projected = target.Select(x => 1);
            int result = projected.Value; // Must fail
        }

        [TestMethod]
        public void OptionFromNullSelectTest3() {
            Option<object> target = FromNullFactory<object>();
            Option<int> result = from value in target
                                 select 1;
            Assert.IsFalse(result.HasValue);
        }

        [TestMethod]
        [ExpectedInvalidOperationException]
        public void OptionFromNullSelectTest4() {
            Option<object> target = FromNullFactory<object>();
            Option<int> projected = from value in target
                                    select 1;
            int result = projected.Value;// Must fail
        }

        [TestMethod]
        public void OptionFromNullSelectManyTest1() {
            Option<int> projected = OptionFromNullSelectManyTestHelper<object, int>(x => 1.ToOption());
            Assert.IsFalse(projected.HasValue);
        }

        [TestMethod]
        public void OptionFromNullSelectManyTest2() {
            Option<object> target = FromNullFactory<object>();
            Option<int> projected = from value in target
                                    from x in target
                                    select 1;
            Assert.IsFalse(projected.HasValue);
        }
        [TestMethod]
        [ExpectedInvalidOperationException]
        public void OptionFromNullSelectManyTest3() {
            Option<object> target = FromNullFactory<object>();
            Option<int> projected = from value in target
                                    from x in target
                                    select 1;
            int result = projected.Value; // must fail
        }
        [TestMethod]
        [ExpectedInvalidOperationException]
        public void OptionFromNullSelectManyTest4() {
            Option<int> projected = OptionFromNullSelectManyTestHelper<object, int>(x => 1.ToOption());
            int result = projected.Value;// must fail
        }

        private static Option<T> OptionFromNullWhereTestHelper<T>(Func<T, bool> predicate) where T : class {
            Option<T> target = FromNullFactory<T>();
            Option<T> filtered = target.Where(predicate);
            return filtered;
        }

        private static Option<TResult> OptionFromNullSelectManyTestHelper<T, TResult>(Func<T, Option<TResult>> selector) where T : class {
            Option<T> target = FromNullFactory<T>();
            Option<TResult> projected = target.SelectMany(selector);
            return projected;
        }

        static Option<T> FromNullFactory<T>() where T : class {
            T target = null;
            return target.ToOption();
        }
    }
}