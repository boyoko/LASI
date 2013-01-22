﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LASI.Algorithm
{
    /// <summary>
    /// Represents a verb phrase.
    /// </summary>
    public class VerbPhrase : Phrase, ISubjectTaker, IModifiable, IModalityModifiable
    {
        /// <summary>
        /// Initializes a new instance of the VerbPhrase class.
        /// </summary>
        /// <param name="composedWords">The words which compose to form the VerbPhrase.</param>
        public VerbPhrase(IEnumerable<Word> composedWords)
            : base(composedWords) {
            Tense = VerbTense.Base;
        }
        /// <summary>
        /// Binds the given subject to the VerbPhrase.
        /// </summary>
        /// <param name="verbSubject">The IActionSubject to bind to the VerbPhrase.</param>
        public void BindToSubject(IActionSubject verbSubject) {
            BoundSubject = verbSubject;
        }
        /// <summary>
        /// Gets or sets the subject of the VerbPhrase.
        /// </summary>
        public IActionSubject BoundSubject {
            get;
            set;
        }
        /// <summary>
        /// Attaches an Adverbial construct, such as an Adverb or AdverbPhrase, as a modifier of the Verb.
        /// </summary>
        /// <param name="adv">The Adverbial construct by which to modify the AdjectivePhrase.</param>
        public void ModifyWith(IAdverbial adv) {
            Modifiers.Add(adv);
        }
        /// <summary>
        /// Gets or sets the List of IAdverbial modifiers which modify the VerbPhrase.
        /// </summary>
        public List<IAdverbial> Modifiers {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the tense of the VerbPhrase.
        /// </summary>
        public VerbTense Tense {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the Modal word which modifies the VerbPhrase.
        /// </summary>
        public Modal Modality {
            get;
            set;
        }
    }
}
