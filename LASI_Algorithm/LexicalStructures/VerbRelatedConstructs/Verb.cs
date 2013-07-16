﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using LASI.Algorithm.ClauseTypes;

namespace LASI.Algorithm
{
    /// <summary>
    /// Provides the base class for all word level verb constructs. An instance of this class represents a verb in its base tense.
    /// </summary>
    public class Verb : Word, IVerbal, IAdverbialModifiable, IModalityModifiable
    {
        /// <summary>
        /// Initializes a new instance of the Verb class which represents the base tense form of a verb.
        /// </summary>
        /// <param name="text">The key text content of the verb.</param>
        /// <param name="tense">The tense of the verb</param>
        public Verb(string text, VerbTense tense)
            : base(text) {
            Tense = tense;
        }
        #region Methods


        /// <summary>
        /// Attaches an IAdverbial construct, such as an Adverb or AdverbPhrase, as a modifier of the Verb
        /// <param name="adv">The IAdverbial construct by which to modify the AdjectivePhrase.</param>
        /// </summary>
        public virtual void ModifyWith(IAdverbial adv) {
            _modifiers.Add(adv);
            adv.Modifies = this;
        }


        /// <summary>
        /// Binds the Verb to an object via a propisitional construct such as a Prepositon or or PrepositionalPhrase.
        /// Example: He "ran" to work. where "work" is the object of ran via the prepositional construct "to"
        /// </summary>
        /// <param name="prepositional"></param>
        public virtual void AttachObjectViaPreposition(IPrepositional prepositional) {
            ObjectOfThePreoposition = prepositional.BoundObject;
            PrepositionalToObject = prepositional;
        }

        /// <summary>
        /// Binds the given Entity as a subject of the Verb instance.
        /// </summary>
        /// <param name="subject">The Entity to attach to the Verb as a subject.</param>
        public virtual void BindSubject(IEntity subject) {
            _subjects.Add(subject);
            subject.SubjectOf = this;

        }

        /// <summary>
        /// Binds the given Entity as a direct object of the Verb instance.
        /// </summary>
        /// <param name="directObject">The Entity to attach to the Verb as a direct object.</param>
        public virtual void BindDirectObject(IEntity directObject) {
            _directObjects.Add(directObject);
            directObject.DirectObjectOf = this;
            if (IsPossessive) {
                foreach (var subject in this.Subjects) {
                    subject.AddPossession(directObject);
                }
            }
            else if (IsClassifier) {
                foreach (var subject in this.Subjects) {
                    AliasDictionary.DefineAlias(subject, directObject);
                }
            }

        }
        /// <summary>
        /// Binds the given Entity as an indirect object of the Verb instance.
        /// </summary>
        /// <param name="indirectObject">The Entity to attach to the Verb as an indirect object.</param>
        public virtual void BindIndirectObject(IEntity indirectObject) {
            _indirectObjects.Add(indirectObject);
            indirectObject.IndirectObjectOf = this;
        }

        /// <summary>
        /// Determines if the Verb implies a possession relationship. E.g. in the senetence 
        /// "They have a lot of ideas." the Verb "have" asserts a possessor possessee relationship between "They" and "a lot of ideas".
        /// </summary>
        /// <returns>True if the Verb is a possessive relationship specifier, false otherwise.</returns>
        protected virtual bool DetermineIsPossessive() {
            var syns = LASI.Algorithm.LexicalInformationProviders.LexicalLookup.Lookup(this);
            isPossessive = syns.Contains("have");
            return IsPossessive;
        }
        /// <summary>
        /// Determines if the Verb acts as a classifier. E.g. in the senetence "Rodents are prey animals." the Verb "are" acts as a classification tool because it states that rodents are a subset of prey animals.
        /// </summary>
        /// <returns>True if the Verb is a classifier, false otherwise.</returns>
        protected virtual bool DetermineIsClassifier() {
            var syns = LASI.Algorithm.LexicalInformationProviders.LexicalLookup.Lookup(this);
            isClassifier = syns.Contains("be");
            return IsClassifier;
        }


        /// <summary>
        /// Return a value indicating if the Verb has any subjects bound to it.
        /// </summary>
        /// <returns>True if the Verb has any Subjects bound to it, false otherwise.</returns>
        public bool HasSubject() {
            return _subjects.Any();
        }
        /// <summary>
        /// Return a value indicating if the Verb has any subjects bound to it which match the given predicate function.
        /// </summary>
        /// <returns>True if the Verb has any subjects bound to it which match the given predicate function, false otherwise.</returns>
        public bool HasSubject(Func<IEntity, bool> predicate) {
            return Subjects.Any(predicate) || Subjects.OfType<IPronoun>().Any(p => predicate(p.BoundEntity));
        }
        /// <summary>
        /// Return a value indicating if the Verb has any direct objects bound to it.
        /// </summary>
        /// <returns>True if the Verb has any direct objects bound to it, false otherwise.</returns>
        public bool HasDirectObject() {
            return DirectObjects.Any();
        }
        /// <summary>
        /// Return a value indicating if the Verb has any direct objects bound to it which match the given predicate function.
        /// </summary>
        /// <returns>True if the Verb has any direct objects bound to it which match the given predicate function, false otherwise.</returns>
        public bool HasDirectObject(Func<IEntity, bool> predicate) {
            return DirectObjects.Any(predicate) || DirectObjects.OfType<IPronoun>().Any(p => predicate(p.BoundEntity));
        }
        /// <summary>
        /// Return a value indicating if the Verb has any indirect objects bound to it.
        /// </summary>
        /// <returns>True if the Verb has any direct objects bound to it, false otherwise.</returns>
        public bool HasIndirectObject() {
            return IndirectObjects.Any();
        }
        /// <summary>
        /// Return a value indicating if the Verb has any indirect objects bound to it which match the given predicate function.
        /// </summary>
        /// <returns>True if the Verb has any indirect objects bound to it which match the given predicate function, false otherwise.</returns>
        public bool HasIndirectObject(Func<IEntity, bool> predicate) {
            return IndirectObjects.Any(predicate) || IndirectObjects.OfType<IPronoun>().Any(p => predicate(p.BoundEntity));
        }
        /// <summary>
        /// Return a value indicating if the Verb has any direct OR indirect objects bound to it.
        /// </summary>
        /// <returns>True if the Verb has any direct OR indirect objects bound to it, false otherwise.</returns>
        public bool HasObject() {
            return HasDirectObject() || HasIndirectObject();
        }
        /// <summary>
        /// Return a value indicating if the Verb has any direct OR indirect objects bound to it which match the given predicate function.
        /// </summary>
        /// <returns>True if the Verb has any direct OR indirect objects bound to it which match the given predicate function, false otherwise.</returns>
        public bool HasObject(Func<IEntity, bool> predicate) {
            return HasDirectObject(predicate) || HasIndirectObject(predicate);
        }



        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the List of IAdverbial modifiers which modify the Verb.
        /// </summary>
        public virtual IEnumerable<IAdverbial> Modifiers {
            get {
                return _modifiers;
            }
        }
        /// <summary>
        /// Gets or sets the ModalAuxilary word which modifies the Verb.
        /// </summary>
        public ModalAuxilary Modality {
            get;
            set;
        }
        /// <summary>
        /// Gets the VerbTense of the Verb.
        /// </summary>
        public VerbTense Tense {
            get;
            protected set;
        }
        /// <summary>
        /// Gets a value indicating wether or not the Verb has classifying semantics. E.g. "A (is) a B"
        /// </summary>
        public bool IsClassifier {
            get {
                return isClassifier ?? DetermineIsClassifier();
            }
        }
        /// <summary>
        /// Gets a value indicating wether or not the Verb has possessive semantics. E.g. "A (has) a B"
        /// </summary>
        public bool IsPossessive {
            get {
                return isPossessive ?? DetermineIsPossessive();
            }
        }

        /// <summary>
        /// Gets the subjects of the Verb.
        /// </summary>
        /// 
        public IEnumerable<IEntity> Subjects {
            get {
                return _subjects;
            }
        }
        /// <summary>
        /// Gets the indirect objects of the Verb.
        /// </summary>
        public virtual IEnumerable<IEntity> IndirectObjects {
            get {
                return _indirectObjects;
            }
        }
        /// <summary>
        /// Gets the direct objects of the Verb.
        /// </summary>
        public virtual IEnumerable<IEntity> DirectObjects {
            get {
                return _directObjects;
            }
        }
        /// <summary>
        /// Gets the object of the Verb's preposition. This can be any ILexical construct including a word, phrase, or clause.
        /// </summary>
        public ILexical ObjectOfThePreoposition {
            get;
            protected set;
        }
        /// <summary>
        /// Gets the IPrepositional object which links the Verb to the ObjectOfThePreoposition.
        /// </summary>
        public IPrepositional PrepositionalToObject {
            get;
            protected set;
        }



        #endregion


        #region Fields

        private IList<IAdverbial> _modifiers = new List<IAdverbial>();
        private HashSet<IEntity> _subjects = new HashSet<IEntity>();
        private HashSet<IEntity> _directObjects = new HashSet<IEntity>();
        private HashSet<IEntity> _indirectObjects = new HashSet<IEntity>();
        bool? isPossessive;
        bool? isClassifier;

        #endregion







    }
}
