﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LASI.Algorithm
{
    public class Document
    {
        #region Constructors

        public Document(IEnumerable<Word> allWords) {
            Words = new WordList(allWords);

            EstablishLexicalLinks();
            foreach (var w in allWords)
                w.ParentDoc = this;
        }
        public Document(IEnumerable<Sentence> allSentences) {
            _sentences = allSentences;
            Words = (WordList)from S in _sentences
                              from W in S.Words
                              select W;
            foreach (var w in Words)
                w.ParentDoc = this;
        }
        public Document(IEnumerable<Paragraph> allParagrpahs) {
            _paragraphs = allParagrpahs;
            _sentences = from P in _paragraphs
                         from S in P.Sentences
                         select S;
            Words = (WordList)from S in _sentences
                              from W in S.Words
                              select W;
            foreach (var w in Words)
                w.ParentDoc = this;
        }

        #endregion

        #region Methods
        private void EstablishLexicalLinks() {
            for (int i = 1; i < Words.Count - 1; ++i) {
                Words[i].PreviousWord = Words[i - 1];
                Words[i - 1].NextWord = Words[i];
            }

            var previousWord = Words[Words.Count - 1];
            if (Words.IndexOf(previousWord) > 0)
                previousWord.PreviousWord = Words[Words.Count - 2];
            else
                previousWord.PreviousWord = null;
            previousWord.NextWord = null;
        }

        public void PrintByLinkage() {
            var W = Words.First();
            while (W != null) {
                Console.Write(W.Text + " ");
                W = W.NextWord;
            }

        }

        public void AppendElement(Word word) {

            word.NextWord = null;
            if (Words.Count > 0) {
                var previousWord = Words[Words.Count - 1];
                word.PreviousWord = previousWord;
                previousWord.NextWord = word;
            }
            Words.Add(word);
        }

        #endregion

        #region Properties

        public WordList Words {
            get;
            private set;
        }
        public IReadOnlyCollection<Sentence> Sentences {
            get {
                return (from P in _paragraphs
                        select P.Sentences) as IReadOnlyCollection<Sentence>;
            }

        }
        public IReadOnlyCollection<Paragraph> Praragraphs {
            get {
                return _paragraphs.ToList().AsReadOnly();
            }
        }

        #endregion

        #region Fields

        private IEnumerable<Paragraph> _paragraphs = new List<Paragraph>();
        private IEnumerable<Sentence> _sentences = new List<Sentence>();
        #endregion
    }
}