﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LASI.Core.Heuristics
{
    using ActionReceiverPair = ActionReceiverPair<IVerbal, IEntity>;
    using EntityPair = PerformerReceiverPair<IEntity, IEntity>;
    using ActionReceiverPairSeq = IEnumerable<ActionReceiverPair<IVerbal, IEntity>>;
    using EntityPairSeq = IEnumerable<PerformerReceiverPair<IEntity, IEntity>>;
    using VerbalSeq = IEnumerable<IVerbal>;
    using EntitySeq = IEnumerable<IEntity>;
    /// <summary>
    /// A sample (or test) implementation of the IRelationshipLookup interface.
    /// </summary>
    public class SampleRelationshipLookup : IRelationshipLookup<IEntity, IVerbal>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the SampleRelationshipLookup class over the given domain.
        /// </summary>
        /// <param name="domain">The sequence of IVerbal instances which provide the relevant relationships.</param>
        public SampleRelationshipLookup(IEnumerable<IVerbal> domain)
        {
            verbalRelationshipDomain = domain.WithSubject().WithObject();
        }
        /// <summary>
        /// Initializes a new instance of the SampleRelationshipLookup class over the given domain.
        /// </summary>
        /// <param name="domain">The sequence of Sentence instances which contain the relevant lexical data set.</param>
        public SampleRelationshipLookup(IEnumerable<Sentence> domain)
            : this(from verbphrase in domain.Phrases().OfVerbPhrase()
                   select verbphrase)
        {
        }
        /// <summary>
        /// Initializes a new instance of the SampleRelationshipLookup class over the given domain.
        /// </summary>
        /// <param name="domain">The sequence of Paragraph instances which contain the relevant lexical data set.</param>
        public SampleRelationshipLookup(IEnumerable<Paragraph> domain)
            : this(domain.SelectMany(paragraph => paragraph.Sentences))
        {
        }
        /// <summary>
        /// Initializes a new instance of the SampleRelationshipLookup class over the given domain.
        /// </summary>
        /// <param name="domain">The Document instance which contains the relevant lexical data set.</param>
        public SampleRelationshipLookup(Document domain)
            : this(domain.Paragraphs)
        {
        }


        #endregion

        #region Indexers
        /// <summary>
        /// Gets the Verbals which are known to link the given action Performing Entity and action Receiving Entity.
        /// </summary>
        /// <param name="actionPerformer">The action Performing Entity.</param>
        /// <param name="actionReceiver">The action Receiving Entity</param>
        /// <returns>The Verbals which are known to link the given action Performing Entity and action Receiving Entity.</returns>
        public VerbalSeq this[IEntity actionPerformer, IEntity actionReceiver] => verbalRelationshipDomain.WithSubject(p => p == actionPerformer).WithObject(r => r == actionReceiver);

        /// <summary>
        /// Gets the Verbals which are known to link the given action Performing Entity and action Receiving Entity.
        /// The extant performers and receivers within the data set are matched based on the logic of the supplied predicate functions.
        /// </summary>
        /// <param name="actionPerformer">The action Performing Entity.</param>
        /// <param name="performerComparer">A predicate function which determines how to find matches for action Performer.</param>
        /// <param name="actionReceiver">The action Receiving Entity</param>
        /// <param name="receiverComparer">A predicate function which determines how to find matches for action Receiver.</param>
        /// <returns>The Verbals which are known to link the given action Performing Entity and action Receiving Entity.</returns>
        public VerbalSeq this[IEntity actionPerformer, Func<IEntity, IEntity, bool> performerComparer, IEntity actionReceiver, Func<IEntity, IEntity, bool> receiverComparer]
        {
            get
            {
                return verbalRelationshipDomain
                    .WithSubject(s => performerComparer(actionPerformer, s))
                    .WithObject(o => receiverComparer(actionReceiver, o));
            }
        }
        /// <summary>
        /// Gets the collection of Performer - Receiver EntityPairs which consists of all pairing of Entities which are related by the given Verbal.
        /// </summary>
        /// <param name="relator">The verbal for which to find relationships over.</param>
        /// <returns>The collection of Performer - Receiver EntityPairs which consists of all pairing of Entities which are related by the given Verbal.</returns>
        public EntityPairSeq this[IVerbal relator]
        {
            get
            {
                return from action in verbalRelationshipDomain
                       where action == relator
                       from performer in relator.Subjects
                       from receiver in relator.DirectObjects.Concat(relator.IndirectObjects)
                       select new EntityPair(performer, receiver);
            }
        }
        /// <summary>
        /// Gets the collection of Action - Receiver ActionReceiverPairs which consists of all pairings of Actions and Receivers for all received Actions the given Entity performs.
        /// </summary>
        /// <param name="performer">The verbal for which to find relationships over.</param>
        /// <returns>The collection of Action - Receiver ActionReceiverPairs which consists of all pairings of Actions and Receivers for all received Actions the given Entity performs.</returns>
        public ActionReceiverPairSeq this[IEntity performer]
        {
            get
            {
                return from action in verbalRelationshipDomain
                       from doer in action.Subjects
                       where doer == performer
                       from receiver in action.DirectObjects.Concat(action.IndirectObjects)
                       select new ActionReceiverPair(action, receiver);
            }
        }
        /// <summary>
        /// Gets the collection of Action - Receiver ActionReceiverPairs which consists of all pairings of Actions and Receivers which for all received Actions the given Entity performs.
        /// The extant performers within the data set are matched based on the logic of the supplied predicate function.
        /// </summary>
        /// <param name="performer">The verbal for which to find relationships over.</param>
        /// <param name="performerComparer">A predicate function which determines how to find matches for action Performer.</param>
        /// <returns>The collection of Action - Receiver ActionReceiverPairs which consists of all pairings of Actions and Receivers which for all received Actions the given Entity performs.</returns>
        public ActionReceiverPairSeq this[IEntity performer, Func<IEntity, IEntity, bool> performerComparer]
        {
            get
            {
                return from action in verbalRelationshipDomain
                       from doer in action.Subjects
                       where performerComparer(doer, performer)
                       from receiver in action.DirectObjects.Concat(action.IndirectObjects)
                       select new ActionReceiverPair(action, receiver);
            }
        }
        /// <summary>
        /// Gets the collection of Performer - Receiver EntityPairs which consists of all pairing of Entities which are related by the given Verbal.
        /// The extant verbals within the data set are matched based on the logic of the supplied predicate function.
        /// </summary>
        /// <param name="action">The verbal for which to find relationships over.</param>
        /// <param name="actionComparer">A predicate function which determines how to find matches for the given Verbal.</param>
        /// <returns>The collection of Performer - Receiver EntityPairs which consists of all pairing of Entities which are related by the given Verbal.</returns>
        public EntityPairSeq this[IVerbal action, Func<IVerbal, IVerbal, bool> actionComparer]
        {
            get
            {
                return from act in verbalRelationshipDomain
                       where actionComparer(act, action)
                       from performer in action.Subjects
                       from receiver in action.DirectObjects.Concat(action.IndirectObjects)
                       select new EntityPair(performer, receiver);
            }
        }
        /// <summary>
        /// Gets the collection of entities which are the recipients of the given action when performed by the given action Performer.
        /// </summary>
        /// <param name="actionPerformer">The action Performing Entity.</param>
        /// <param name="action">The Action which the Performing Entity performs.</param>
        /// <returns>The collection of entities which are the recipients of the given action when performed by the given action Performer.</returns>
        public IEnumerable<IEntity> this[IEntity actionPerformer, IVerbal action]
        {
            get
            {
                return from act in verbalRelationshipDomain
                       where act == action
                       where act.HasSubject(s => s == actionPerformer)
                       from receiver in act.DirectObjects.Concat(act.IndirectObjects)
                       select receiver;
            }
        }
        /// <summary>
        /// Gets the collection of entities which are the recipients of the given action when performed by the given action Performer.
        /// The extant Actions and Action performers within the data set are matched based on the logic of the supplied predicate functions.
        /// </summary>
        /// <param name="actionPerformer">The action Performing Entity.</param>
        /// <param name="performerComparer">A predicate function which determines how to find matches for action Performer.</param>
        /// <param name="action">The Action which the Performing Entity performs.</param>
        /// <param name="actionComparer">A predicate function which determines how to find matches for the given Verbal.</param>
        /// <returns>The collection of entities which are the recipients of the given action when performed by the given action Performer.</returns>
        public EntitySeq this[
            IEntity actionPerformer,
            Func<IEntity, IEntity, bool> performerComparer,
            IVerbal action,
            Func<IVerbal, IVerbal, bool> actionComparer] => from verbal in verbalRelationshipDomain
                                                            where actionComparer(verbal, action)
                                                            where verbal.HasSubject(s => performerComparer(s, actionPerformer))
                                                            from receiver in verbal.DirectObjects.Concat(verbal.IndirectObjects)
                                                            select receiver;

        #endregion

        #region Fields

        private VerbalSeq verbalRelationshipDomain;

        #endregion

    }
}
