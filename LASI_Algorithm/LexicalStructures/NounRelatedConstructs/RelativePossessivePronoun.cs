﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LASI.Algorithm
{
    /// <summary>
    /// Represents a Possessive Relative Pronoun such as "whose". Possessive Relative Pronouns provide contextual ownership semantics.
    /// </summary>
    public class RelativePossessivePronoun : PossessivePronoun
    {
        /// <summary>
        /// Initialiazes a new instance of the RelativePossessivePronoun class.
        /// </summary>
        /// <param name="text">The literal text content of the RelativePossessivePronoun.</param>
        public RelativePossessivePronoun(string text)
            : base(text)
        {
        }


    }
}