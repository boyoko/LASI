﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LASI.Algorithm
{
    public class Existential : Word
    {
        public Existential(string text)
            : base(text) {
        }

        public override System.Xml.Linq.XElement Serialize() {
            throw new NotImplementedException();
        }
    }
}
