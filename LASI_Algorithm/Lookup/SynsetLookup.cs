﻿using LASI.Algorithm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LASI.Algorithm.Lookup
{
    internal abstract class SynonymLookup
    {
        /// <summary>
        /// Constructor accessible only to derrived classes.
        /// Provides common initialization logic.
        /// </summary>
        /// <param name="filePath">The path of WordNet database file which provides the synonym data (form should be data.pos, e.g. data.adverb)</param>
        protected SynonymLookup(string filePath) {
            FilePath = filePath;
        }
        /// <summary>
        /// gets or sets the path of the WordNet database file which this thesaurus is built on
        /// </summary>
        protected string FilePath {
            get;
            set;
        }
        /// <summary>
        /// When overriden in a derrived class, this method
        /// Loads the database file and performs additional initialization
        /// </summary>
        public abstract void Load();

        public virtual async Task LoadAsync() {
            await Task.Run(() => Load());
        }

        public abstract ISet<string> this[string search] {
            get;
        }

        public abstract ISet<string> this[Word search] {
            get;
        }
        protected const int HEADER_LENGTH = 29;
    }
}
