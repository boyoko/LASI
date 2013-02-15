﻿using System;
namespace LASI.Algorithm
{
    /// <summary>
    /// Defines the roles of Conjunctive constructs which link two Clauses together.
    /// </summary>
    interface IConjunctive : ILexical
    {
        Clause OnLeft {
            get;
            set;
        }
        Clause OnRight {
            get;
            set;
        }
    }
}
