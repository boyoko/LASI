﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LASI.Core
{
    /// <summary>
    /// Represents a punctuation character at the Word level.
    /// </summary>
    public class Punctuator : Symbol
    {
        /// <summary>
        /// Initializes a new instance of the Punctuator class.
        /// </summary>
        /// <param name="punctuation">The literal character representation of the punctuator.</param>
        public Punctuator(char punctuation) : this(punctuation.ToString()) { }

        /// <summary>
        /// Initializes a new instance of the Punctuator class.
        /// </summary>
        /// <param name="punctuation">The single character string which comprises the Punctuator"</param>
        public Punctuator(string punctuation) : base(punctuation)
        {
            AliasString = PunctuationAliasMap.GetAliasStringForChar(LiteralCharacter);
        }

        /// <summary>
        /// Gets the alias string corresponding to the Punctuator.
        /// </summary>
        public string AliasString { get; }

        /// <summary>
        /// Maps between certain punctuation characters and alias text.
        /// </summary>
        private static class PunctuationAliasMap
        {
            private static readonly IDictionary<string, char> aliasMap = new Dictionary<string, char>
            {
                ["COMMA"] = ',',
                ["LEFT_SQUARE_BRACKET"] = '[',
                ["RIGHT_SQUARE_BRACKET"] = ']',
                ["PERIOD_CHARACTER_SYMBOL"] = '.',
                ["END_OF_PARAGRAPH"] = '\n'
            };

            public static char GetCharForAliasString(string alias) => aliasMap[alias];

            public static string GetAliasStringForChar(char actual) => aliasMap.FirstOrDefault(kvp => kvp.Value == actual).Key ?? actual.ToString();

        }

    }
}
