using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class KeywordData
    {
        public string Keyword { get; set; } //pk

        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardKeywordData> CardKeywords { get; set; }
    }
}
