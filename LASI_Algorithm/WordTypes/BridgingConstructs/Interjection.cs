﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LASI.Algorithm
{
    /// <summary>
    /// Represents interjection words, such as "by-jove!"
    /// Not common in strategic documents, but they are necessary to properly map to the Tagset.
    /// And its nice to write "by-jove!" in documentation.
    /// </summary>
    public class Interjection : Word
    {
        /// <summary>
        /// Initializes a new instance of the Interjection class.
        /// </summary>
        /// <param name="text">The literal text content of the word.</param>
        public Interjection(string text)
            : base(text) {
        }

        public override System.Xml.Linq.XElement Serialize() {
            throw new NotImplementedException();
        }
    }
}
