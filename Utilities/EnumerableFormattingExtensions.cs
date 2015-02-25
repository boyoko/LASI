﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LASI.Utilities.Validation;

namespace LASI.Utilities
{
    public  static  class EnumerableFormattingExtensions
    {
        #region Formatting Methods

        /// <summary>
        /// Returns a formated string representation of the IEnumerable sequence with the pattern: [
        /// element0, element1, ..., elementN ] such that the string representation of each element
        /// is produced by calling its ToString method.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the generic IEnumerable sequence.</typeparam>
        /// <param name="source">
        /// An IEnumerable sequence containing 0 or more Elements of type T.
        /// </param>
        /// <returns>
        /// A formated string representation of the IEnumerable sequence with the pattern: [
        /// element0, element1, ..., elementN ].
        /// </returns>
        public static string Format<T>(this IEnumerable<T> source)
        {
            return source.Format(Tuple.Create('[', ',', ']'));
        }

        /// <summary>
        /// Returns a formated string representation of the IEnumerable sequence with the pattern: [
        /// element0, element1, ..., elementN ] such that the string representation of each element
        /// is produced by calling its ToString method. The resultant string is line broken based on
        /// the provided line length.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the generic IEnumerable sequence.</typeparam>
        /// <param name="source">
        /// An IEnumerable sequence containing 0 or more Elements of type T.
        /// </param>
        /// <param name="lineLength">
        /// Indicates the number of characters after which a line break is to be inserted.
        /// </param>
        /// <returns>
        /// A formated string representation of the IEnumerable sequence with the pattern: [
        /// element0, element1, ..., elementN ].
        /// </returns>
        public static string Format<T>(this IEnumerable<T> source, long lineLength)
        {
            return source.Format(Tuple.Create('[', ',', ']'), lineLength);
        }

        /// <summary>
        /// Returns a formated string representation of the IEnumerable sequence with the pattern: [
        /// element0, element1, ..., elementN ] such that the string representation of each element
        /// is produced by calling its ToString method.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the generic IEnumerable sequence.</typeparam>
        /// <param name="source">
        /// An IEnumerable sequence containing 0 or more Elements of type T.
        /// </param>
        /// <param name="delimiters">
        /// The triple of delimiters specifying the beginning, separating, and ending characters.
        /// </param>
        /// <returns>
        /// A formated string representation of the IEnumerable sequence with the pattern: [
        /// element0, element1, ..., elementN ].
        /// </returns>
        public static string Format<T>(this IEnumerable<T> source, Tuple<char, char, char> delimiters)
        {
            Validate.NotNull(source, "source", delimiters, "delimiters");
            return source.Aggregate(
                    new StringBuilder(delimiters.Item1 + " "),
                    (builder, e) => builder.Append(e.ToString() + delimiters.Item2 + ' '),
                    result => result.ToString().TrimEnd(' ', '\n', delimiters.Item2) + ' ' + delimiters.Item3);
        }

        /// <summary>
        /// Returns a formated string representation of the IEnumerable sequence with the pattern: [
        /// selector(element0), selector(element1), ..., selector(elementN) ] such that the string
        /// representation of each element is produced by calling the provided selector function.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the generic IEnumerable sequence.</typeparam>
        /// <param name="source">
        /// An IEnumerable sequence containing 0 or more Elements of type T.
        /// </param>
        /// <param name="selector">
        /// The function used to produce a string representation for each element.
        /// </param>
        /// <returns>
        /// A a formated string representation of the IEnumerable sequence with the pattern: [
        /// selector(element0), selector(element1), ..., selector(elementN) ].
        /// </returns>
        public static string Format<T>(this IEnumerable<T> source, Func<T, string> selector)
        {
            return source.Format(Tuple.Create('[', ',', ']'), selector);
        }

        /// <summary>
        /// Returns a formated string representation of the IEnumerable sequence with the pattern: [
        /// selector(element0), selector(element1), ..., selector(elementN) ] such that the string
        /// representation of each element is produced by calling the provided elementToString function.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the generic IEnumerable sequence.</typeparam>
        /// <param name="source">
        /// An IEnumerable sequence containing 0 or more Elements of type T.
        /// </param>
        /// <param name="delimiters">
        /// The triple of delimiters specifying the beginning, separating, and ending characters.
        /// </param>
        /// <param name="selector">
        /// The function used to produce a string representation for each element.
        /// </param>
        /// <returns>
        /// formated string representation of the IEnumerable sequence with the pattern: [
        /// selector(element0), selector(element1), ..., selector(elementN) ].
        /// </returns>
        public static string Format<T>(this IEnumerable<T> source, Tuple<char, char, char> delimiters, Func<T, string> selector)
        {
            Validate.NotNull(source, "source", selector, "selector", delimiters, "delimiters");
            return source.Select(selector).Format(delimiters);
        }

        /// <summary>
        /// Returns a formated string representation of the IEnumerable sequence with the pattern: [
        /// element0, element1, ..., elementN ] such that the string representation of each element
        /// is produced by calling its ToString method. The resultant string is line broken based on
        /// the provided line length.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the generic IEnumerable sequence.</typeparam>
        /// <param name="source">
        /// An IEnumerable sequence containing 0 or more Elements of type T.
        /// </param>
        /// <param name="delimiters">
        /// The triple of delimiters specifying the beginning, separating, and ending characters.
        /// </param>
        /// <param name="lineLength">
        /// Indicates the number of characters after which a line break is to be inserted.
        /// </param>
        /// <returns>
        /// A formated string representation of the IEnumerable sequence with the pattern: [
        /// element0, element1, ..., elementN ].
        /// </returns>
        public static string Format<T>(this IEnumerable<T> source, Tuple<char, char, char> delimiters, long lineLength)
        {
            return source.Format(delimiters, lineLength, x => x.ToString());
        }

        /// <summary>
        /// Returns a formated string representation of the IEnumerable sequence with the pattern: [
        /// selector(element0), selector(element1), ..., selector(elementN) ] such that the string
        /// representation of each element is produced by calling the provided selector function.
        /// The resultant string is line broken based on the provided line length.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the generic IEnumerable sequence.</typeparam>
        /// <param name="source">
        /// An IEnumerable sequence containing 0 or more Elements of type T.
        /// </param>
        /// <param name="lineLength">
        /// Indicates the number of characters after which a line break is to be inserted.
        /// </param>
        /// <param name="selector">
        /// The function used to produce a string representation for each element.
        /// </param>
        /// <returns>
        /// A formated string representation of the IEnumerable sequence with the pattern: [
        /// selector(element0), selector(element1), ..., selector(elementN) ].
        /// </returns>
        public static string Format<T>(this IEnumerable<T> source, long lineLength, Func<T, string> selector)
        {
            return source.Format(Tuple.Create('[', ',', ']'), lineLength, selector);
        }

        /// <summary>
        /// Returns a formated string representation of the IEnumerable sequence with the pattern:
        /// delimiters.Item1 selector(element0)delimiters.Item2 selector(element1)delimiter
        /// ...delimiters.Item2 selector(elementN) delimiters.Item3 such that the string
        /// representation of each element is produced by calling the provided selector function on
        /// each element of the sequence and separating their each resulting string with the second
        /// element of the provided tupple of delimiters. The resultant string is line broken based
        /// on the provided line length.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the generic IEnumerable sequence.</typeparam>
        /// <param name="source">
        /// An IEnumerable sequence containing 0 or more Elements of type T.
        /// </param>
        /// <param name="lineLength">
        /// Indicates the number of characters after which a line break is to be inserted.
        /// </param>
        /// <param name="delimiters">
        /// A three item tuple delimiters which will be used to format the result.
        /// </param>
        /// <param name="selector">
        /// The function used to produce a string representation for each element.
        /// </param>
        /// <returns>
        /// delimiters.Item1 selector(element0)delimiters.Item2 selector(element1)delimiter
        /// ...delimiters.Item2 selector(elementN) delimiters.Item3.
        /// </returns>
        public static string Format<T>(this IEnumerable<T> source, Tuple<char, char, char> delimiters, long lineLength, Func<T, string> selector)
        {
            Validate.NotNull(source, "source", delimiters, "delimiters", selector, "selector");
            Validate.NotLessThan(lineLength, 1, "lineLength", "Line length must be greater than 0.");
            return source.Select(e => selector(e) + delimiters.Item2)
                .Aggregate(new { ModLength = 1L, Text = delimiters.Item1.ToString() },
                (z, element) =>
                {
                    var rem = 1L;
                    var quotient = Math.DivRem(z.ModLength + element.Length + 1, lineLength, out rem);
                    var sep = z.ModLength + element.Length + 1 > lineLength ? '\n' : ' ';
                    return new { ModLength = z.ModLength + element.Length + 1, Text = z.Text + sep + element };
                }).Text.TrimEnd(' ', delimiters.Item2) + ' ' + delimiters.Item3;
        }

        #endregion Formatting Methods

    }
}