﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Text.RegularExpressions;

namespace LASI.Algorithm.Lookup
{
    using SetReference = System.Collections.Generic.KeyValuePair<AdverbSetRelationship, int>;
    internal class AdverbThesaurus : SynonymLookup
    {
        /// <summary>
        /// Initializes a new instance of the AdjectiveThesaurus class.
        /// </summary>
        /// <param name="filePath">The path of the WordNet database file containing the synonym data for adverbs.</param>
        public AdverbThesaurus(string filePath)
            : base(filePath) {
            FilePath = filePath;
        }

        List<AdverbSynSet> allSets = new List<AdverbSynSet>();

        /// <summary>
        /// Parses the contents of the underlying WordNet database file.
        /// </summary>
        public override void Load() {
            //throw new NotImplementedException();


            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader(FilePath)) {
                for (int i = 0; i < HEADER_LENGTH; ++i) {
                    reader.ReadLine();
                }
                while (!reader.EndOfStream) {

                    var set = CreateSet(reader.ReadLine());
                    allSets.Add(set);
                }
            }
        }

        AdverbSynSet CreateSet(string line) {


            var setLine = line.Substring(0, line.IndexOf('|'));

            var referencedSets = from match in Regex.Matches(setLine, @"\D{1,2}\s*\d{8}").Cast<Match>()
                                 let split = match.Value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 where split.Count() > 1
                                 select new SetReference(relationMap[split[0]], Int32.Parse(split[1]));

            IEnumerable<string> words = from match in Regex.Matches(setLine, @"(?<word>[A-Za-z_\-\']{3,})").Cast<Match>()
                                        select match.Value.Replace('_', '-');

            int id = Int32.Parse(setLine.Substring(0, 8));

            AdverbCategory lexCategory = ( AdverbCategory )Int32.Parse(setLine.Substring(9, 2));
            return new AdverbSynSet(id, words, referencedSets, lexCategory);




        }

        private ISet<string> SearchFor(string word) {

            //gets pointers of searched word
            //var tempResults = from sn in allSets
            //                  where sn.Words.Contains(word)
            //                  select sn.ReferencedIndexes;
            //var flatPointers = from R in tempResults
            //                   from r in R
            //                   select r;
            ////gets words of searched word
            //var tempWords = from sw in allSets
            //                where sw.Words.Contains(word)
            //                select sw.Words;
            HashSet<string> results = new HashSet<string>();
            //from Q in tempWords
            //from q in Q
            //select q);


            ////gets related words from above pointers
            //foreach (var t in flatPointers) {

            //    foreach (NounSynSet s in allSets) {

            //        if (t == s.ID) {
            //            results.Union(s.Words);
            //        }

            //    }

            //}

            return new HashSet<string>(results);


            //foreach (string tester in results)
            //{

            //    Console.WriteLine(tester);

            //}//console view
        }

        public override ISet<string> this[string search] {
            get {
                return SearchFor(search);
            }
        }


        public override ISet<string> this[Word search] {
            get {
                return this[search.Text];
            }
        }

        private static readonly LASI.Algorithm.Lookup.InterSetRelationshipManagement.AdverbPointerSymbolMap relationMap =
            new LASI.Algorithm.Lookup.InterSetRelationshipManagement.AdverbPointerSymbolMap();
    }
}
