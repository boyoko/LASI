﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LASI.Algorithm
{
    public class PastTenseVerbPhrase : VerbPhrase
    {
        public PastTenseVerbPhrase(IEnumerable<Word> composedWords)
            : base(composedWords) {
        }
    }
}