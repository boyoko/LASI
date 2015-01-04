﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LASI.Core
{
    /// <summary>
    /// Represents an adverb which can be bound as a modifier to either a verb construct or an adjective construct.
    /// </summary>
    public class Adverb : Word, IAdverbial, IAdverbialModifiable
    {

        public IEnumerable<IAdverbial> AttributedBy => AdverbialModifiers;
        public IVerbal AttributedTo => ModifiedBy as IVerbal;
        IDescriptor IAttributive<IDescriptor>.AttributedTo => ModifiedBy as IDescriptor;
        /// <summary>
        /// Initializes a new instance of the Adverb class.
        /// </summary>
        /// <param name="text">The text content of the adverb.</param>
        public Adverb(string text)
            : base(text) {
        }
        /// <summary>
        /// Gets or sets the IAdverbialModifiable construct; such as an Adjective, AdjectivePhrase, Verb, or VerbPhrase; which the Adverb Modifies. 
        /// </summary>
        public virtual IAdverbialModifiable ModifiedBy {
            get;
            set;
        }

        /// <summary>
        /// Attaches an IAdverbial construct, such as an Adverb or AdverbPhrase, as a modifier of the current Adverb
        /// <param name="modifier">The IAdverbial construct by which to modify the current Adverb.</param>
        /// </summary>
        public void ModifyWith(IAdverbial modifier) {
            adverbialModifiers.Add(modifier);
            modifier.ModifiedBy = this;
        }
        /// <summary>
        /// Gets the List of IAdverbial modifiers which modify the Adverb.
        /// </summary>
        public IEnumerable<IAdverbial> AdverbialModifiers {
            get {
                return adverbialModifiers;
            }
        }
        private HashSet<IAdverbial> adverbialModifiers = new HashSet<IAdverbial>();
    }
}
