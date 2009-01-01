using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using NUnit.Framework;

namespace FluentGenerator.Tests
{
    public static class TestExtension
    {
        public static void ShouldBeTrue(this bool condition)
        {
            Assert.IsTrue(condition);
        }

        public static void ShouldBeTrue(this bool condition, string message)
        {
            Assert.IsTrue(condition, message);
        }

        public static void ShouldBeFalse(this bool condition)
        {
            Assert.IsFalse(condition);
        }

        public static void ShouldBeFalse(this bool condition, string message)
        {
            Assert.IsFalse(condition, message);
        }

        public static void ShouldBe<T>(this T actual, T expected)
        {
            Assert.AreEqual(expected, actual);
        }

        public static void ShouldBe<T>(this T actual, T expected, string message)
        {
            Assert.AreEqual(expected, actual, message);
        }

        public static void ShouldNotBe<T>(this T actual, T notExpected)
        {
            Assert.AreNotEqual(notExpected, actual);
        }

        public static void ShouldNotBe<T>(this T actual, T notExpected, string message)
        {
            Assert.AreNotEqual(notExpected, actual, message);
        }

        public static void ShouldBe<T>(this T actual, Type type)
        {
            Assert.IsInstanceOfType(type, actual);
        }

        public static void ShouldBe<T>(this T actual, Type type, string message)
        {
            Assert.IsInstanceOfType(type, actual, message);
        }

        public static void ShouldBeEmpty<T>(this IEnumerable<T> collection)
        {
            collection.ShouldNotBeNull();
            collection.Count().ShouldBe(0);
        }

        public static void ShouldBeEmpty<T>(this IEnumerable<T> collection, string message)
        {
            collection.ShouldNotBeNull(message);
            collection.Count().ShouldBe(0, message);
        }

        public static void ShouldNotBeEmpty<T>(this IEnumerable<T> collection)
        {
            collection.ShouldNotBeNull();
            collection.Count().ShouldNotBe(0);
        }

        public static void ShouldNotBeEmpty<T>(this IEnumerable<T> collection, string message)
        {
            collection.ShouldNotBeNull(message);
            collection.Count().ShouldNotBe(0, message);
        }

        public static void ShouldNotBe<T>(this T actual, Type type, string message)
        {
            Assert.IsNotInstanceOfType(type, actual, message);
        }

        public static void ShouldNotBe<T>(this T actual, Type type)
        {
            Assert.IsNotInstanceOfType(type, actual);
        }

        public static void ShouldBeNull(this object actual)
        {
            Assert.IsNull(actual);
        }

        public static void ShouldBeGreaterThan<T>(this T actual, T expected) where T : IComparable
        {
            (actual.CompareTo(expected) > 0).ShouldBeTrue(string.Format("{0} was not greater than {1}", actual, expected));
        }

        public static void ShouldBeLessThan<T>(this T actual, T expected) where T : IComparable
        {
            (actual.CompareTo(expected) < 0).ShouldBeTrue(string.Format("{0} was not less than {1}", actual, expected));
        }

        public static void ShouldBeBetween<T>(this T actual, T lowerBound, T upperBound) where T : IComparable
        {
            ((actual.CompareTo(lowerBound) >= 0) && (actual.CompareTo(upperBound) <= 0)).ShouldBeTrue(string.Format("{0} was not between {1} and {2}", actual, lowerBound, upperBound));
        }

        public static void ShouldBeNull(this object actual, string message)
        {
            Assert.IsNull(actual, message);
        }

        public static void ShouldNotBeNull(this object actual)
        {
            Assert.IsNotNull(actual);
        }

        public static void ShouldNotBeNull(this object actual, string message)
        {
            Assert.IsNotNull(actual, message);
        }

        public static void ShouldBeEqualIgnoringCase(this string actual, string expected)
        {
            if (actual.ToLower() != expected.ToLower())
                Assert.AreEqual(expected, actual);
        }

        public static void ShouldBeEqualIgnoringCase(this string actual, string expected, string message)
        {
            if (actual.ToLower() != expected.ToLower())
                Assert.AreEqual(expected, actual, message);
        }

        public static void ShouldContain(this IEnumerable list, object expected)
        {
            list.ShouldContain(expected, null);
        }

        public static void ShouldContain(this IEnumerable list, object expected, string message)
        {
            bool found = false;

            if (list != null)
                foreach (object o in list)
                    if (o == expected)
                        found = true;

            found.ShouldBeTrue("The <" + (list ?? "NULL") + "> should have contained: <" + (expected ?? "NULL") + ">. " + (message ?? string.Empty));
        }

        public static void ShouldContain<T>(this IEnumerable<T> list, T expected)
        {
            ShouldContain(list, expected, null);
        }

        public static void ShouldContain<T>(this IEnumerable<T> list, T expected, string message)
        {

            list.Contains(expected).ShouldBeTrue("The <" + (list.ToString() ?? "NULL") + "> should have contained: <" + (expected.ToString() ?? "NULL") + ">. " + (message ?? string.Empty));
        }

        public static void ShouldNotContain(this IEnumerable list, object expected)
        {
            list.ShouldNotContain(expected, null);
        }

        public static void ShouldNotContain(this IEnumerable list, object expected, string message)
        {
            bool found = false;

            if (list != null)
                foreach (var o in list)
                    if (o == expected)
                        found = true;

            found.ShouldBeFalse("The <" + (list ?? "NULL") + "> should not have contained: <" + (expected ?? "NULL") + ">. " + (message ?? string.Empty));
        }

        public static void ShouldNotContain<T>(this IEnumerable<T> list, T expected)
        {
            list.Contains(expected).ShouldBeFalse();
        }

        public static void ShouldNotContain<T>(this IEnumerable<T> list, T expected, string message)
        {

            list.Contains(expected).ShouldBeFalse("The <" + (list.ToString() ?? "NULL") + "> should not have contained: <" + (expected.ToString() ?? "NULL") + ">. " + (message ?? string.Empty));
        }

        public static void ShouldStartWith(this string actual, string expected)
        {
            actual.ShouldStartWith(expected, null);
        }

        public static void ShouldStartWith(this string actual, string expected, string message)
        {
            if (actual == null || !actual.StartsWith(expected))
            {
                Assert.Fail("Actual: <" + (actual ?? "NULL") + "> did not start with the Expected: <" + (expected ?? "NULL") + ">. " + (message ?? string.Empty));
            }
        }

        public static void ShouldEndWith(this string actual, string expected)
        {
            actual.ShouldEndWith(expected, null);
        }

        public static void ShouldEndWith(this string actual, string expected, string message)
        {
            if (actual == null || !actual.EndsWith(expected))
            {
                Assert.Fail("Actual: <" + (actual ?? "NULL") + "> did not end with the Expected: <" + (expected ?? "NULL") + ">. " + (message ?? string.Empty));
            }
        }

        /// <summary>
        /// Compares two objects by reference.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        public static void ShouldBeTheSameAs<T>(this T actual, T expected)
        {
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Compares two objects by reference with a message for failures.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="message"></param>
        public static void ShouldBeTheSameAs<T>(this T actual, T expected, string message)
        {
            Assert.AreSame(expected, actual, message);
        }

        /// <summary>
        /// Makes sure two objects are not the same reference.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        public static void ShouldBeDifferentFrom<T>(this T actual, T expected)
        {
            Assert.AreNotSame(expected, actual);
        }

        /// <summary>
        /// Makes sure two objects are not the same reference with a message for failures.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="message"></param>
        public static void ShouldBeDifferentFrom<T>(this T actual, T expected, string message)
        {
            Assert.AreNotSame(expected, actual, message);
        }

        public static void ShouldBeOrderedBy<T, TKey>(this IEnumerable<T> list, Func<T, TKey> property)
            where TKey : IComparable
        {
            list.ShouldBeOrdered(l => l.OrderBy(property));
        }

        public static void ShouldBeOrderedByDescending<T, TKey>(this IEnumerable<T> list, Func<T, TKey> property)
            where TKey : IComparable
        {
            list.ShouldBeOrdered(l => l.OrderByDescending(property));
        }

        public static void ShouldBeOrdered<T>(this IEnumerable<T> list, Func<IEnumerable<T>, IOrderedEnumerable<T>> func)
        {
            if (list == null || list.Count() <= 1)
                return;

            var orderedList = func.Invoke(list);
            var orderedEnumerator = orderedList.GetEnumerator();
            var enumerator = list.GetEnumerator();

            while (orderedEnumerator.MoveNext() && enumerator.MoveNext())
            {
                orderedEnumerator.Current.ShouldBeTheSameAs(enumerator.Current, "The list was not in the correct order.");
            }
        }

        public static void ShouldBeOfType<T>(this object actual)
        {
            Assert.IsInstanceOfType(typeof(T), actual);
        }
    }
}
