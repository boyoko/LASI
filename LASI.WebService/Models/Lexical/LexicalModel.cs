using LASI.Core;
using Newtonsoft.Json;

namespace LASI.WebService.Models.Lexical
{
    public abstract class LexicalModel<TLexical> : ILexicalModel<TLexical>, ILinkedViewModel<TLexical> where TLexical : class, ILexical
    {
        protected LexicalModel(TLexical element)
        {
            Element = element;
            Id = element.GetSerializationId();
            Text = element.Text;
            Style = SyntacticStyleMap[element];
        }
        public int Id { get; }
        public string Text { get; }
        //[JsonIgnore]
        public abstract string DetailText { get; }
        public Style Style { get; }
        [JsonIgnore]
        public TLexical Element { get; }
        [JsonIgnore]
        public TLexical ModelFor => Element;
        public abstract ILexicalContextmenu Contextmenu { get; }

        public string ContextmenuId { get; }

        static readonly SyntacticStyleMap SyntacticStyleMap = new SyntacticStyleMap();
    }
}