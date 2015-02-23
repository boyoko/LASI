﻿using System;
using System.Collections.Generic;
using System.Linq;
using LASI.Utilities.Validation;

namespace LASI.Utilities
{
    /// <summary>
    /// Provides static methods for the creation of <see cref="IEqualityComparer{T}" /> instances.
    /// </summary>
    public static class ComparerFactory
    {
        /// <summary>
        /// Creates a new instance of the CustomComparer class which will use the provided function
        /// to define element equality.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="equals">A function which determines if two objects of type T are equal.</param>
        /// <exception cref="ArgumentNullException">
        /// The provided <paramref name="equals" /> function is null.
        /// </exception>
        /// <remarks>
        /// A custom hashing function is automatically provided, ensuring that equality comparisons
        /// take place except when reference is null. While this provides clean, customizable
        /// semantics for set operations, more expensive to use having a complexity of N^2
        /// </remarks>
        public static IEqualityComparer<T> CreateEquality<T>(Func<T, T, bool> equals)
        {
            Validate.NotNull(equals, nameof(equals));
            return new ComparerWithCutomEqualsAndNullityBasedHashing<T>(equals);
        }

        /// <summary>
        /// Creates a new <see cref="IEqualityComparer{T}" /> which will use the provided equality
        /// and hashing functions.
        /// </summary>
        /// <param name="equals">A function which determines if two objects of type T are equal.</param>
        /// <param name="getHashCode">
        /// A function which generates a hash code from an element of type T.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The provided <paramref name="equals" /> or <paramref name="getHashCode" /> function is null.
        /// </exception>
        /// <remarks>
        /// Proper usage requires that elements which will compare equal under the specified equals
        /// function will also produce identical hashcodes. Elements may yield identical hash codes,
        /// without being considered equal.
        /// </remarks>
        /// <returns>
        /// A new <see cref="IEqualityComparer{T}" /> which will use the provided equality and
        /// hashing functions.
        /// </returns>
        public static IEqualityComparer<T> CreateEquality<T>(Func<T, T, bool> equals, Func<T, int> getHashCode)
        {
            Validate.NotNull(equals, nameof(equals));
            Validate.NotNull(getHashCode, nameof(getHashCode));
            return new ComparerWithCutomEqualsAndHashing<T>(equals, getHashCode);
        }

        private sealed class ComparerWithCutomEqualsAndNullityBasedHashing<T> : IEqualityComparer<T>
        {
            /// <summary>
            /// Initializes a new instance of the
            /// <see cref="ComparerWithCutomEqualsAndNullityBasedHashing{T}" /> class which
            /// will use the provided function to define element equality.
            /// </summary>
            /// <param name="equals">
            /// A function which determines if two objects of type T are equal.
            /// </param>
            /// <exception cref="ArgumentNullException">
            /// The provided <paramref name="equals" /> function is null.
            /// </exception>
            /// <remarks>
            /// A custom hashing function is automatically provided, ensuring that equality
            /// comparisons take place except when reference is null. While this provides clean,
            /// customizable semantics for set operations, more expensive to use having a complexity
            /// of N^2
            /// </remarks>
            public ComparerWithCutomEqualsAndNullityBasedHashing(Func<T, T, bool> equals)
            {
                this.equals = equals;
            }
            /// <summary>Determines whether two objects of type T are equal.</summary>
            /// <param name="x">The first object to compare.</param>
            /// <param name="y">The second object to compare.</param>
            /// <returns><c>true</c> if the specified objects are equal; otherwise, <c>false</c>.</returns>
            public bool Equals(T x, T y) => equals(x, y);
            public int GetHashCode(T obj) => obj == null ? 0 : 1;

            private readonly Func<T, T, bool> equals;
        }

        /// <summary>
        /// An EqualityComparer&lt;T&gt; whose Equals and GetHashCode implementations are specified
        /// upon construction.
        /// </summary>
        /// <typeparam name="T">The type of objects to compare.</typeparam>
        /// <remarks>
        /// <para>
        /// The primary purpose of this class is to allow for the ad hoc, inline creation of an
        /// IEqualityComparer&lt;T&gt; from arbitrary functions. This allows for the easy use of
        /// Query Operators taking an IEqualityComparer&lt;T&gt; as an argument.
        /// </para>
        /// <para>
        /// Proper usage requires that elements which will compare equal under the specified equals
        /// function will also produce identical hashcodes. Elements may yield identical hash codes,
        /// without being considered equal.
        /// </para>
        /// </remarks>
        /// <example>
        /// <code>
        /// An equality comparer which makes determinations based on the specified comparison function.
        /// var fuzzilyDistinctNps = nps.Distinct(new CustomComparer&lt;Phrase&gt;((x, y) =&gt; x.IsSimilarTo(y));
        /// </code>
        /// <code>
        /// // An equality comparer which makes determinations based on the specified comparison and hashing functions.
        /// var fuzzilyDistinctNps = nps.Distinct(new CustomComparer&lt;Phrase&gt;((x, y) =&gt; x.IsSimilarTo(y), x =&gt; x == null? 0 : 1);
        /// </code>
        /// </example>
        private sealed class ComparerWithCutomEqualsAndHashing<T> : IEqualityComparer<T>
        {
            /// <summary>
            /// Initializes a new instance of the CustomComparer class which will use the provided
            /// equality and hashing functions.
            /// </summary>
            /// <param name="equals">
            /// A function which determines if two objects of type T are equal.
            /// </param>
            /// <param name="getHashCode">
            /// A function which generates a hash code from an element of type T.
            /// </param>
            /// <exception cref="ArgumentNullException">
            /// The provided <paramref name="equals" /> or <paramref name="getHashCode" /> function
            /// is null.
            /// </exception>
            /// <remarks>
            /// Proper usage requires that elements which will compare equal under the specified
            /// equals function will also produce identical hashcodes. Elements may yield identical
            /// hash codes, without being considered equal.
            /// </remarks>
            public ComparerWithCutomEqualsAndHashing(Func<T, T, bool> equals, Func<T, int> getHashCode)
            {
                this.equals = equals;
                this.getHashCode = getHashCode;
            }

            /// <summary>Determines whether two objects of type T are equal.</summary>
            /// <param name="x">The first object to compare.</param>
            /// <param name="y">The second object to compare.</param>
            /// <returns><c>true</c> if the specified objects are equal; otherwise, <c>false</c>.</returns>
            public bool Equals(T x, T y) => y == null ? y == null : y == null ? x == null : equals(x, y);

            /// <summary>
            /// Serves as a hash function for the specified object for hashing algorithms and data
            /// structures, such as a hash table.
            /// </summary>
            /// <param name="obj">The object for which to get a hash code.</param>
            /// <returns>A hash code for the specified object.</returns>
            public int GetHashCode(T obj) => getHashCode(obj);

            private readonly Func<T, T, bool> equals;
            private readonly Func<T, int> getHashCode;
        }
    }
}