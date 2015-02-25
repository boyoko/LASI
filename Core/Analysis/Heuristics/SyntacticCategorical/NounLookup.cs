﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using LASI.Core.InteropBindings;
using LASI.Utilities;

namespace LASI.Core.Heuristics.WordNet
{
    using LASI.Core.Analysis.Heuristics.WordMorphing;
    using static Enumerable;
    using EventArgs = ResourceLoadEventArgs;
    using Link = NounLink;
    using SetReference = KeyValuePair<NounLink, int>;

    internal sealed class NounLookup : WordNetLookup<Noun>
    {
        /// <summary>
        /// Initializes a new instance of the NounProvider class.
        /// </summary>
        /// <param name="path">
        /// The path of the WordNet database file containing the synonym data for nouns.
        /// </param>
        public NounLookup(string path) { filePath = path; }

        /// <summary>
        /// Parses the contents of the underlying WordNet database file.
        /// </summary>
        internal override void Load()
        {
            var setsEnumerated = 0;
            var setsSampled = 0;
            var indexedSynsets = LoadData()
                .Zip(Range(1, TotalLines), (line, i) => new { Set = CreateSet(line), LineNumber = i });
            try
            {
                indexedSynsets.ToObservable()
                    .Do(set =>
                    {
                        ++setsEnumerated;
                        setsById[set.Set.Id] = set.Set;
                    })
                    .Sample(TimeSpan.FromMilliseconds(20))
                    //.Where(e => e.LineNumber % 821 == 0)
                    .Subscribe(
                        onNext: e =>
                        {
                            ++setsSampled;
                            OnReport(new EventArgs($"Loaded Noun Data - Set: {e.LineNumber} / {TotalLines}", ProgressAmount));
                        },
                        onCompleted: () => OnReport(new EventArgs("Noun Data Loaded", 1)),
                        onError: e =>
                        {
                            e.Log();
                        });
            }
            catch (Exception e)
            {
                e.Log();
                throw;
            }
        }

        private static NounSynSet CreateSet(string fileLine)
        {
            var line = fileLine.Substring(0, fileLine.IndexOf('|')).Replace('_', '-');

            var referencedSets = from Match match in POINTER_REGEX.Matches(line)
                                 let split = match.Value.SplitRemoveEmpty(' ')
                                 where split.Length > 1 && consideredSetLinks.Contains(linkMap[split[0]])
                                 select new SetReference(
                                    key: linkMap[split[0]],
                                    value: int.Parse(split[1])
                                 );
            return new NounSynSet(
                id: int.Parse(line.Substring(0, 8)),
                words: from Match m in WORD_REGEX.Matches(line) select m.Value,
                category: (NounCategory)int.Parse(line.Substring(9, 2)),
                pointerRelationships: referencedSets
            );
        }

        private IEnumerable<string> LoadData()
        {
            using (var reader = new StreamReader(File.Open(path: filePath, mode: FileMode.Open, access: FileAccess.Read)))
            {
                for (int i = 0; i < FILE_HEADER_LINE_COUNT; ++i)
                {
                    reader.ReadLine();
                }
                for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    yield return line;
                }
            }
        }

        private IImmutableSet<string> SearchFor(string word)
        {
            var containingSet = setsById.Values.FirstOrDefault(set => set.ContainsWord(word));
            if (containingSet != null)
            {
                try
                {
                    var results = new List<string>();
                    SearchSubsets(containingSet, results, new HashSet<NounSynSet>());
                    return results.ToImmutableHashSet(IgnoreCase);
                }
                catch (InvalidOperationException e)
                {
                    Output.WriteLine(string.Format("{0} was thrown when attempting to get synonyms for word {1}: , containing set: {2}", e.Message, word, containingSet));
                }
            }
            return ImmutableHashSet<string>.Empty;
        }

        private void SearchSubsets(NounSynSet containingSet, List<string> results, HashSet<NounSynSet> setsSearched)
        {
            results.AddRange(containingSet.Words);
            results.AddRange(containingSet[Link.HypERnym].Where(set => setsById.ContainsKey(set)).SelectMany(set => setsById[set].Words));
            setsSearched.Add(containingSet);
            foreach (var set in containingSet.ReferencedSet
                .Except(containingSet[Link.HypERnym])
                .Select(setsById.GetValueOrDefault)
                .Where(set => set != null))
            {
                if (set != null && set.Category == containingSet.Category && !setsSearched.Contains(set))
                {
                    SearchSubsets(set, results, setsSearched);
                }
            }
        }

        internal override IImmutableSet<string> this[string search]
        {
            get
            {
                var morpher = new NounMorpher();
                try
                {
                    return SearchFor(morpher.FindRoot(search))
                        .SelectMany(morpher.GetLexicalForms)
                        .DefaultIfEmpty(search)
                        .ToImmutableHashSet();
                }
                catch (Exception e) when (e is AggregateException || e is InvalidOperationException)
                {
                    e.Log();
                }
                return this[search];
            }
        }

        internal override IImmutableSet<string> this[Noun search]
        {
            get { return this[search.Text]; }
        }

        private const int TotalLines = 82114;
        private const double ProgressAmount = 100 / (821 * 100d);
        private static readonly IImmutableSet<Link> consideredSetLinks = ImmutableHashSet.Create(
             Link.MemberOfThisDomain_REGION,
             Link.MemberOfThisDomain_TOPIC,
             Link.MemberOfThisDomain_USAGE,
             Link.DomainOfSynset_REGION,
             Link.DomainOfSynset_TOPIC,
             Link.DomainOfSynset_USAGE,
             Link.HypOnym,
             Link.InstanceHypOnym,
             Link.InstanceHypERnym,
             Link.HypERnym
        );

        // Provides an indexed lookup between the values of the Noun enum and their corresponding
        // string representation in WordNet data.noun files.
        private static readonly IReadOnlyDictionary<string, Link> linkMap = new Dictionary<string, Link>
        {
            ["!"] = Link.Antonym,
            ["@"] = Link.HypERnym,
            ["@i"] = Link.InstanceHypERnym,
            ["~"] = Link.HypOnym,
            ["~i"] = Link.InstanceHypOnym,
            ["#m"] = Link.MemberHolonym,
            ["#s"] = Link.SubstanceHolonym,
            ["#p"] = Link.PartHolonym,
            ["%m"] = Link.MemberMeronym,
            ["%s"] = Link.SubstanceMeronym,
            ["%p"] = Link.PartMeronym,
            ["="] = Link.Attribute,
            ["+"] = Link.DerivationallyRelatedForm,
            [";c"] = Link.DomainOfSynset_TOPIC,
            ["-c"] = Link.MemberOfThisDomain_TOPIC,
            [";r"] = Link.DomainOfSynset_REGION,
            ["-r"] = Link.MemberOfThisDomain_REGION,
            [";u"] = Link.DomainOfSynset_USAGE,
            ["-u"] = Link.MemberOfThisDomain_USAGE
        };

        private static readonly Regex POINTER_REGEX = new Regex(@"\D{1,2}\s*\d{8}", RegexOptions.Compiled);
        private static readonly Regex WORD_REGEX = new Regex(@"(?<word>[A-Za-z_\-\']{3,})", RegexOptions.Compiled);
        private string filePath;
        private ConcurrentDictionary<NounCategory, List<NounSynSet>> lexicalGoups = new ConcurrentDictionary<NounCategory, List<NounSynSet>>();
        private ConcurrentDictionary<int, NounSynSet> setsById = new ConcurrentDictionary<int, NounSynSet>(Concurrency.Max, TotalLines);

    }
}