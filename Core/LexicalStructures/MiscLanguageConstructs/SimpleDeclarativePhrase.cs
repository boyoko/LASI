﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LASI.Core
{
    /// <summary>
    /// A phrase which indicates the possible start of a Simple Declarative Clause.
    /// </summary>
    public class SimpleDeclarativeClauseBeginPhrase : Phrase
    {
        /// <summary>
        /// Initializes a new instance of the SimpleDeclarativeClauseBeginPhrase class.
        /// </summary>
        /// <param name="composed">The words which comprise the SimpleDeclarativeClauseBeginPhrase.</param>
        public SimpleDeclarativeClauseBeginPhrase(IEnumerable<Word> composed)
            : base(composed) {
        }
    }

}
