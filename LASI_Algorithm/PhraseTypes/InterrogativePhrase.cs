﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LASI.Algorithm
{
    /// <summary>
    /// Represents an interrogative phrase or clause.
    /// </summary>
    public class InterrogativePhrase : Phrase
    {
        /// <summary>
        /// Initializes a new instance of the ConjunctionPhrase class.
        /// </summary>
        /// <param name="composedWords">The words which compose to form the ConjunctionPhrase.</param>
        public InterrogativePhrase(IEnumerable<Word> composedWords)
            : base(composedWords) {
        }
    }
}