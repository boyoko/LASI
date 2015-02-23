﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LASI.Core.Analysis.Relationships.Tests
{
    [TestClass]
    public class ExpressionExtensionsTest
    {
        /// <summary>
        ///A test for SetRelationshipLookup
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException), AllowDerivedTypes = true)]
        public void SetRelationshipLookupTest1()
        {
            IEntity entity1 = new ProperSingularNoun("John");
            IVerbal verb = new PastTenseVerb("walked");
            IEntity entity2 = new NounPhrase(new Determiner("the"), new CommonSingularNoun("store"));
            Bind(entity1, verb, entity2);
            IEnumerable<IVerbal> domain = new[] { verb };
            IRelationshipLookup<IEntity, IVerbal> relationshipLookup = CreateRelationshipLookup(domain);
            ActionsRelatedOn? expected = null;
            ActionsRelatedOn? actual;
            actual = entity1.IsRelatedTo(entity2);
            Assert.AreNotEqual(expected, actual); // Without calling ExpressionExtensions.SetRelationshipLookup(entity1, relationshipLookup);

        }

        private static void Bind(IEntity entity1, IVerbal verb, IEntity entity2)
        {
            verb.BindSubject(entity1);
            verb.BindDirectObject(entity2);
        }

        private static RelationshipLookup<IEntity, IVerbal> CreateRelationshipLookup(IEnumerable<IVerbal> domain)
        {
            return new RelationshipLookup<IEntity, IVerbal>(domain, Equals, Equals, Equals);
        }

        /// <summary>
        ///A test for SetRelationshipLookup
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException), AllowDerivedTypes = true)]
        public void SetRelationshipLookupTest2()
        {
            IEntity entity1 = new ProperSingularNoun("John");
            IVerbal verb = new PastTenseVerb("walked");
            IEntity entity2 = new NounPhrase(new Determiner("the"), new CommonSingularNoun("store"));
            Bind(entity1, verb, entity2);
            IEnumerable<IVerbal> domain = new[] { verb };
            IRelationshipLookup<IEntity, IVerbal> relationshipLookup = CreateRelationshipLookup(domain);
            ActionsRelatedOn? expected = null;
            ActionsRelatedOn? actual;
            actual = entity1.IsRelatedTo(new NounPhrase(new Determiner("the"), new CommonSingularNoun("store")));
            Assert.AreEqual(expected, actual); // Without calling ExpressionExtensions.SetRelationshipLookup(entity1, relationshipLookup);

        }
        /// <summary>
        ///A test for SetRelationshipLookup
        /// </summary>
        [TestMethod()]
        public void SetRelationshipLookupTest3()
        {
            IEntity entity1 = new ProperSingularNoun("John");
            IVerbal verb = new PastTenseVerb("walked");
            IEntity entity2 = new NounPhrase(new Determiner("the"), new CommonSingularNoun("store"));
            Bind(entity1, verb, entity2);
            IEnumerable<IVerbal> domain = new[] { verb };
            IRelationshipLookup<IEntity, IVerbal> relationshipLookup = CreateRelationshipLookup(domain);
            ExpressionExtensions.SetRelationshipLookup(entity1, relationshipLookup);
            ActionsRelatedOn? expected = null;
            ActionsRelatedOn? actual;
            actual = entity1.IsRelatedTo(entity2);
            Assert.AreNotEqual(expected, actual);// After calling ExpressionExtensions.SetRelationshipLookup(entity1, relationshipLookup);
        }
        /// <summary>
        ///A test for SetRelationshipLookup
        /// </summary>
        [TestMethod()]
        public void SetRelationshipLookupTest4()
        {
            IEntity entity1 = new ProperSingularNoun("John");
            IVerbal verb = new PastTenseVerb("walked");
            IEntity entity2 = new NounPhrase(new Determiner("the"), new CommonSingularNoun("store"));
            Bind(entity1, verb, entity2);
            IEnumerable<IVerbal> domain = new[] { verb };
            IRelationshipLookup<IEntity, IVerbal> relationshipLookup = CreateRelationshipLookup(domain);
            ExpressionExtensions.SetRelationshipLookup(entity1, relationshipLookup);
            ActionsRelatedOn? expected = null;
            ActionsRelatedOn? actual;
            actual = entity1.IsRelatedTo(new NounPhrase(new Determiner("the"), new CommonSingularNoun("store")));
            Assert.AreEqual(expected, actual);// After calling ExpressionExtensions.SetRelationshipLookup(entity1, relationshipLookup);
        }

        /// <summary>
        ///A test for On
        /// </summary>
        [TestMethod()]
        public void OnTest1()
        {
            ActionsRelatedOn? relatorSet = null;
            IVerbal relator = new PastTenseVerb("walked");
            bool expected = false;
            bool actual;
            actual = ExpressionExtensions.On(relatorSet, relator);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for On
        /// </summary>
        [TestMethod()]
        public void OnTest2()
        {
            IVerbal relator = new PastTenseVerb("walked");
            ActionsRelatedOn? relatorSet = new ActionsRelatedOn(new[] { relator });
            bool expected = true;
            bool actual;
            actual = ExpressionExtensions.On(relatorSet, relator);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsRelatedTo
        /// </summary>
        [TestMethod()]
        public void IsRelatedToTest()
        {
            IEntity performer = new CommonPluralNoun("dogs");
            IEntity receiver = new CommonPluralNoun("cats");
            IVerbal relator = new BaseVerb("chase");
            Bind(performer, relator, receiver);
            performer.SetRelationshipLookup(new RelationshipLookup<IEntity, IVerbal>(new[] { relator }, Equals, Equals, Equals));
            ActionsRelatedOn? expected = new ActionsRelatedOn(new[] { relator });
            ActionsRelatedOn? actual;
            actual = ExpressionExtensions.IsRelatedTo(performer, receiver);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for IsRelatedTo
        /// </summary>
        [TestMethod]
        public void IsRelatedToOnTest1()
        {
            IEntity performer = new CommonPluralNoun("dogs");
            IEntity receiver = new CommonPluralNoun("cats");
            IVerbal relator = new BaseVerb("chase");
            Bind(performer, relator, receiver);
            performer.SetRelationshipLookup(new RelationshipLookup<IEntity, IVerbal>(new[] { relator }, Equals, Equals, Equals));
            bool expected = true;
            bool actual;
            actual = ExpressionExtensions.IsRelatedTo(performer, receiver).On(relator);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for IsRelatedTo
        /// </summary>
        [TestMethod]
        public void IsRelatedToOnTest2()
        {
            IEntity performer = new CommonPluralNoun("dogs");
            IEntity receiver = new CommonPluralNoun("cats");
            IVerbal relator = new BaseVerb("chase");
            Bind(performer, relator, receiver);
            performer.SetRelationshipLookup(new RelationshipLookup<IEntity, IVerbal>(new[] { relator }, Equals, Equals, Equals));
            bool expected = true;
            bool actual;
            actual = ExpressionExtensions.IsRelatedTo(receiver, performer).On(relator);
            Assert.AreEqual(expected, actual);
        }
    }
}