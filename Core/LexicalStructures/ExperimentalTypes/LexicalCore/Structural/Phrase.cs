﻿using LASI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LASI.Core
{
    /// <summary>
    /// Provides the base class, properties, and behaviors for all Phrase level grammatical constructs.
    /// </summary>
    public abstract class Phrase : ILexical
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Phrase class.
        /// </summary>
        /// <param name="words">The one or more instances of the Word class which are composed to form the Phrase.</param>
        protected Phrase(IEnumerable<Word> words) {
            Words = words;
            Weight = 1;
            MetaWeight = 1;
        }

        /// <summary>
        /// Initializes a new instance of the Phrase class.
        /// </summary>
        /// <param name="first">The first Word of the Phrase.</param>
        /// <param name="rest">The rest of the Words comprise the Phrase.</param>
        /// <remarks>This constructor overload reduces the syntactic overhead associated with the manual construction of Phrases. 
        /// Thus, its purpose is to simplify test code.</remarks>
        protected Phrase(Word first, params Word[] rest) : this(rest.Prepend(first)) { }

        #endregion

        #region Methods

        /// <summary>
        /// Overrides the ToString method to augment the string representation of Phrase to include the text of the words it is composed of.
        /// </summary>
        /// <returns>A string containing the Type information of the instance as well as the textual representations of the words it is composed of.</returns>
        public override string ToString() => string.Format("{0} \"{1}\"", GetType()
                                                                                          .Name, Text);

        /// <summary>
        /// Establish the nested links between the Phrase, its parent Clause, and the Words comprising it.
        /// </summary>
        /// <param name="parent">The Clause to which the Phrase belongs.</param>
        internal void EstablishParent(Clause parent) {
            Clause = parent;
            Sentence = parent.Sentence;
            Document = Sentence.Document;
            foreach (var word in Words) {
                word.EstablishParent(this);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Prepositional construct which is lexically to the right of the word.
        /// </summary>
        public IPrepositional PrepositionOnRight { get; set; }

        /// <summary>
        /// Gets or sets the Prepositional construct which is lexically to the left of the Phrase.
        /// </summary>
        public IPrepositional PrepositionOnLeft { get; set; }

        /// <summary>
        /// Gets, lexically speaking, the next Phrase in the Document to which the instance belongs.
        /// </summary>
        public Phrase NextPhrase { get; internal set; }

        /// <summary>
        /// Gets, lexically speaking, the previous Phrase in the Document to which the instance belongs.
        /// </summary>
        public Phrase PreviousPhrase { get; internal set; }

        /// <summary>
        /// Gets or sets the Clause to which the Phrase belongs.
        /// </summary>
        public Clause Clause { get; private set; }

        /// <summary>
        /// Gets or sets the Sentence to which the Phrase belongs.
        /// </summary>
        public Sentence Sentence { get; private set; }

        /// <summary>
        /// Gets or the Paragraph to which the Phrase belongs.
        /// </summary>
        public Paragraph Paragraph => Sentence?.Paragraph;

        /// <summary>
        /// Gets or set the Document instance to which the Phrase belongs.
        /// </summary>
        public Document Document { get; private set; }

        /// <summary>
        /// Gets the concatenated text content of all of the words which comprise the Phrase.
        /// </summary>
        public string Text => text = text ?? string.Join(" ", Words.Select(w => w.Text));

        /// <summary>
        /// Gets the collection of words which comprise the Phrase.
        /// </summary>
        public IEnumerable<Word> Words { get; }

        /// <summary>
        /// Gets or sets the numeric Weight of the Phrase within the context of its document.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Gets or sets the numeric Weight of the Phrase over the context of all extant documents.
        /// </summary>
        public double MetaWeight { get; set; }

        #region Fields

        private string text;

        #endregion

        #endregion

        #region Static Members

        #region Static Properties

        /// <summary>
        /// Controls the level detail of the information provided by the ToString method of all instances of the Phrase class.
        /// </summary>
        public static bool VerboseOutput { get; set; }

        #endregion

        #endregion
    }
}