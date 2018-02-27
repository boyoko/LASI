﻿using System;
using System.Collections.Generic;
using System.Linq;
using LASI.WebService.Models.Lexical;
using LASI.Core;
using Newtonsoft.Json;

namespace LASI.WebService.Models.DocumentStructures
{
    public class SentenceModel : TextualModel<Sentence, ParagraphModel>
    {
        public SentenceModel(Sentence sentence) : base(sentence)
        {
            Phrases = ModelFor.Phrases
               .Select(phrase => new PhraseModel(phrase))
               .Append(new PhraseModel(new SymbolPhrase(sentence.Ending)));
        }
        [JsonIgnore]
        public override string Text => ModelFor.Text;
        public override Style Style => new Style { CssClass = "sentence" };
        public IEnumerable<PhraseModel> Phrases { get; }
        [JsonIgnore]
        public override ParagraphModel Parent { get; }
    }
}