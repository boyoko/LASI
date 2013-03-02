﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LASI.Algorithm
{
    /// <summary>
    /// Represents a foriegn word embedded in an english written work.
    /// </summary>
    public class ForeignWord : Word
    {
        /// <summary>
        /// Initializes an instance of the ForeignWord class.
        /// </summary>
        /// <param name="text">The literal text content of the ForeignWord.</param>
        public ForeignWord(string text)
            : base(text) {
        }
        /// <summary>
        /// Gets or sets the equivalent English word type if it can be inferred from the ForeignWord's usage.
        /// </summary>
        public virtual Type UsedAsType {
            get;
            set;
        }

        public override System.Xml.Linq.XElement Serialize() {
            throw new NotImplementedException();
        }
    }

}