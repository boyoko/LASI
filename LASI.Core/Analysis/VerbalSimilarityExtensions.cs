﻿using System;
using System.Collections.Generic;
using System.Linq;
using LASI.Utilities;

namespace LASI.Core.Heuristics
{
    public static class VerbalSimilarityExtensions
    {
        /// <summary>e
        /// Determines if two <see cref="IVerbal"/>s are similar.
        /// </summary>
        /// <param name="first">The first IVerbal</param>
        /// <param name="second">The second IVerbal</param>
        /// <returns> <c>true</c> if the given IVerbal instances are similar; otherwise, <c>false</c>.</returns>
        public static Similarity IsSimilarTo(this IVerbal first, IVerbal second) =>
            first.Match()
                .When(first.Text.EqualsIgnoreCase(second.Text))
                .Then(Similarity.Similar)
                .Case((Verb v1) =>
                    second.Match()
                        .Case((Verb v2) => v1.IsSimilarTo(v2))
                        .Case((VerbPhrase vp2) => v1.IsSimilarTo(vp2))
                    .Result())
                .Case((VerbPhrase vp1) =>
                    second.Match()
                        .Case((VerbPhrase vp2) => vp1.IsSimilarTo(vp2))
                        .Case((Verb v2) => vp1.IsSimilarTo(v2))
                .Result())
            .Result();
        /// <summary>
        /// Determines if two <see cref="Verb"/>s are similar.
        /// </summary>
        /// <param name="first">The first Verb.</param>
        /// <param name="second">The second Verb.</param>
        /// <returns> <c>true</c> if the first Verb is similar to the second; otherwise, <c>false</c>.</returns>
        public static Similarity IsSimilarTo(this Verb first, Verb second) =>
            Similarity.FromBoolean(Equals(first, second) || (first?.GetSynonyms().Contains(second?.Text) ?? false));

        /// <summary>
        /// Determines if two <see cref="VerbPhrase"/>s are similar.
        /// </summary>
        /// <param name="first">The first VerbPhrase</param>
        /// <param name="second">The second VerbPhrase</param>
        /// <returns> <c>true</c> if the given VerbPhrases are similar; otherwise, <c>false</c>.</returns>
        public static Similarity IsSimilarTo(this VerbPhrase first, VerbPhrase second)
        {
            //Look into refining this

            var results = from v1 in first.Words.OfVerb()
                          from v2 in second.Words.OfVerb()
                          select (bool)v1.IsSimilarTo(v2);

            var ratio = results.PercentTrue() / 100;
            return Similarity.FromRatio(ratio);

            // TODO: make this fuzzier.

            //return new Similarity(leftHandVerbs.Count == rightHandVerbs.Count &&
            //    leftHandVerbs.Zip(rightHandVerbs, (x, y) => x.IsSynonymFor(y)).All(areSyonyms => areSyonyms)
            //);
        }

        /// <summary>
        /// Determines if the provided VerbPhrase is similar to the provided Verb.
        /// </summary>
        /// <param name="first">The VerbPhrase.</param>
        /// <param name="second">The Verb.</param>
        /// <returns> <c>true</c> if the provided VerbPhrase is similar to the provided Verb; otherwise, <c>false</c>.</returns>
        private static Similarity IsSimilarTo(this VerbPhrase first, Verb second) => second.IsSimilarTo(first);

        /// <summary>
        /// Determines if the provided <see cref="Verb"/> is similar to the provided VerbPhrase.
        /// </summary>
        /// <param name="first">The Verb.</param>
        /// <param name="second">The VerbPhrase.</param>
        /// <returns> <c>true</c> if the provided Verb is similar to the provided VerbPhrase; otherwise, <c>false</c>.</returns>
        private static Similarity IsSimilarTo(this Verb first, VerbPhrase second)
        {
            // TODO: This is rough and needs to be enhanced.
            return Similarity.FromBoolean(second.Words
                .TakeWhile(w => !(w is ToLinker)) // Collect all words in the phrase cutting short when and if an infinitive precedent is found.
                .OfVerb().Any(v => v.IsSimilarTo(first))); // If an infinitive is found, it will be the local direct object of the verb phrase.
        }
    }
}
