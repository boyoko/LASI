﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LASI.Algorithm
{
    public class SimpleDeclarativePhrase : Phrase
    {
        public SimpleDeclarativePhrase(IEnumerable<Word> composedWords)
            : base(composedWords) {
        }
    }
}