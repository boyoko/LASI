﻿using LASI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Test.Assertions;
using NFluent;
using Xunit;

namespace LASI.Core.Tests
{
    /// <summary>
    ///This is A test class for VerbTest and is intended
    ///to contain all VerbTest Unit Tests
    /// </summary>
    public class VerbTest
    {
        /// <summary>
        ///A test for Verb Constructor
        /// </summary>
        [Fact]
        public void VerbConstructorTest()
        {
            string text = "insulate";
            Verb target = new BaseVerb(text);

            Check.That(target.Text).Equals(text);
            Check.That(target.Subjects).IsEmpty();
            Check.That(target.DirectObjects).IsEmpty();
            Check.That(target.IndirectObjects).IsEmpty();
            Check.That(target.Modality).IsNull();
            Check.That(target.IsPossessive).IsFalse();
        }

        /// <summary>
        ///A test for AttachObjectViaPreposition
        /// </summary>
        [Fact]
        public void AttachObjectViaPrepositionTest()
        {
            string text = "insulate";
            Verb target = new BaseVerb(text);
            NounPhrase prepositionObject = new NounPhrase(new[] { new PersonalPronoun("them") });
            IPrepositional prep = new Preposition("for");
            prep.BindObject(prepositionObject);
            target.AttachObjectViaPreposition(prep);
            Check.That(target.ObjectOfThePreposition).Equals(prepositionObject);
        }

        /// <summary>
        ///A test for BindDirectObject
        /// </summary>
        [Fact]
        public void BindDirectObjectTest()
        {
            string text = "gave";
            Verb target = new PastTenseVerb(text);
            IEntity directObject = new NounPhrase(new Word[] { new Determiner("a"), new CommonSingularNoun("cake") });
            target.BindDirectObject(directObject);

            Check.That(target.DirectObjects).Contains(directObject).And.HasSize(1);
        }

        /// <summary>
        ///A test for BindIndirectObject
        /// </summary>
        [Fact]
        public void BindIndirectObjectTest()
        {
            string text = "gave";
            Verb target = new PastTenseVerb(text);
            IEntity indirectObject = new PersonalPronoun("him");
            target.BindIndirectObject(indirectObject);

            Check.That(target.IndirectObjects).Contains(indirectObject).And.HasSize(1);
        }
        /// <summary>
        ///A test for BindSubject
        /// </summary>
        [Fact]
        public void BindSubjectTest()
        {
            string text = "gave";
            Verb target = new BaseVerb(text);
            IEntity subject = new PersonalPronoun("he");
            target.BindSubject(subject);

            Check.That(target.Subjects).Contains(subject).And.HasSize(1);
        }



        /// <summary>
        ///A test for ModifyWith
        /// </summary>
        [Fact]
        public void ModifyWithTest()
        {
            string text = "insulate";
            Verb target = new BaseVerb(text);
            IAdverbial adv = new Adverb("sufficiently");
            target.ModifyWith(adv);

            Check.That(target.AdverbialModifiers).Contains(adv).And.HasSize(1);
        }



        /// <summary>
        ///A test for Modality
        /// </summary>
        [Fact]
        public void ModalityTest()
        {
            string text = "insulate";
            Verb target = new BaseVerb(text);
            ModalAuxilary expected = new ModalAuxilary("can");
            ModalAuxilary actual;
            target.Modality = expected;
            actual = target.Modality;
            Check.That(expected).Equals(actual);

        }



        /// <summary>
        ///A test for Subjects
        /// </summary>
        [Fact]
        public void SubjectsTest()
        {
            string text = "attack";
            Verb target = new BaseVerb(text);
            IEnumerable<IEntity> actual;
            actual = target.Subjects;
            Check.That(actual).IsEmpty();
            IEntity subject = new CommonPluralNoun("chimpanzees");
            target.BindSubject(subject);
            actual = target.Subjects;
            Check.That(actual).Contains(subject);
            Check.That(target.AggregateSubject).Contains(subject);
        }

        /// <summary>
        ///A test for Modifiers
        /// </summary>
        [Fact]
        public void ModifiersTest()
        {
            string text = "attacked";
            Verb target = new PastTenseVerb(text);
            IEnumerable<IAdverbial> actual;
            actual = target.AdverbialModifiers;
            Check.That(actual).IsEmpty();
            IAdverbial modifier = new Adverb("swiftly");
            target.ModifyWith(modifier);
            actual = target.AdverbialModifiers;
            Check.That(actual).Contains(modifier);
            Check.That(modifier.Modifies).Equals(target);
        }



        /// <summary>
        ///A test for IsPossessive
        /// </summary>
        [Fact]
        public void IsPossessiveTest()
        {
            string text = "has";
            Verb target = new BaseVerb(text);
            bool isClassifier;
            isClassifier = target.IsPossessive;
            Check.That(isClassifier).IsTrue();
        }

        /// <summary>
        ///A test for IsClassifier
        /// </summary>
        [Fact]
        public void IsClassifierTest()
        {
            string text = "is";
            Verb target = new BaseVerb(text);
            bool isClassifier;
            isClassifier = target.IsClassifier;
            Check.That(isClassifier).IsTrue();
        }

        /// <summary>
        ///A test for IndirectObjects
        /// </summary>
        [Fact]
        public void IndirectObjectsTest()
        {
            string text = "attack";
            Verb target = new BaseVerb(text);
            IEnumerable<IEntity> actual;
            actual = target.IndirectObjects;
            Check.That(actual).IsEmpty();
            IEntity indirectObject = new CommonPluralNoun("allies");
            target.BindIndirectObject(indirectObject);
            actual = target.IndirectObjects;
            Check.That(actual).Contains(indirectObject);
            Check.That(target.AggregateIndirectObject).Contains(indirectObject);

        }

        /// <summary>
        ///A test for DirectObjects
        /// </summary>
        [Fact]
        public void DirectObjectsTest()
        {
            string text = "attack";
            Verb target = new BaseVerb(text);
            IEnumerable<IEntity> actual;
            actual = target.IndirectObjects;
            Check.That(actual).IsEmpty();
            IEntity directObject = new CommonPluralNoun("monkeys");
            target.BindDirectObject(directObject);
            actual = target.DirectObjects;
            Check.That(actual).Contains(directObject);
            Check.That(target.AggregateDirectObject).Contains(directObject);
        }

        /// <summary>
        ///A test for AggregateSubject
        /// </summary>
        [Fact]
        public void AggregateSubjectTest()
        {
            string text = "attack";
            Verb target = new BaseVerb(text);
            IAggregateEntity actual;
            actual = target.AggregateSubject;
            Check.That(actual).IsEmpty();
            IEntity subject = new CommonPluralNoun("monkeys");
            target.BindSubject(subject);
            actual = target.AggregateSubject;
            EnumerableAssert.AreSetEqual(new[] { subject }, actual);
        }

        /// <summary>
        ///A test for AggregateIndirectObject
        /// </summary>
        [Fact]
        public void AggregateIndirectObjectTest()
        {
            string text = "attack";
            Verb target = new BaseVerb(text);
            IAggregateEntity actual;
            actual = target.AggregateIndirectObject;
            Check.That(actual).IsEmpty();
            IEntity indirectObject = new CommonPluralNoun("monkeys");
            target.BindIndirectObject(indirectObject);
            actual = target.AggregateIndirectObject;
            EnumerableAssert.AreSetEqual(new[] { indirectObject }, actual);
        }

        /// <summary>
        ///A test for AggregateDirectObject
        /// </summary>
        [Fact]
        public void AggregateDirectObjectTest()
        {
            string text = "attack";
            Verb target = new BaseVerb(text);
            IAggregateEntity actual;
            actual = target.AggregateDirectObject;
            Check.That(actual).IsEmpty();
            IEntity directObject = new CommonPluralNoun("monkeys");
            target.BindDirectObject(directObject);
            actual = target.AggregateDirectObject;
            EnumerableAssert.AreSetEqual(new[] { directObject }, actual);
        }




        /// <summary>
        ///A test for HasSubjectOrObject
        /// </summary>
        [Fact]
        public void HasSubjectOrObjectTest()
        {
            string text = "attack";
            Verb target = new BaseVerb(text);
            IEntity entity = new CommonPluralNoun("monkeys");
            int rand = new Random().Next(-1, 2);
            switch (rand)
            {
            case -1:
            target.BindSubject(entity);
            break;
            case 0:
            target.BindDirectObject(entity);
            break;
            case 1:
            target.BindDirectObject(entity);
            break;
            default:
            Check.That(false).IsTrue();
            break;
            }
            Func<IEntity, bool> predicate = e => e.Text == "monkeys";
            bool expected = true;
            bool actual;
            actual = target.HasSubjectOrObject(predicate);
            Check.That(expected).Equals(actual);
        }



        /// <summary>
        ///A test for HasSubject
        /// </summary>
        [Fact]
        public void HasSubjectTest()
        {
            string text = "hired";
            Verb target = new PastTenseVerb(text);
            Check.That(target.HasSubject()).IsFalse();
            target.BindSubject(new PersonalPronoun("him"));
            Func<IEntity, bool> predicate = s => s.Text == "her";
            bool expected = false;
            bool actual;
            actual = target.HasSubject(predicate);
            Check.That(expected).Equals(actual);
            target.BindSubject(new PersonalPronoun("her"));
            expected = true;
            actual = target.HasSubject(predicate);
            Check.That(expected).Equals(actual);
        }


    }
}
