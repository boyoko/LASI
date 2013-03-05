﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LASI.Algorithm
{
    /// <summary>
    /// Represents a Phrase Which does not correspond to a known catregory.
    /// This may be the result of a Tagging error or a Tag-Parsing error.
    /// </summary>
    public class UndeterminedPhrase : Phrase
    {
        /// <summary>
        /// Initializes a new instance of the UndeterminedPhrase class.
        /// </summary>
        /// <param name="composedWords">The words which compose to form the UndeterminedPhrase.</param>
        public UndeterminedPhrase(IEnumerable<Word> composedWords)
            : base(composedWords) {
        }




        public override XElement Serialize() {
            throw new NotImplementedException();
        }
    }
}