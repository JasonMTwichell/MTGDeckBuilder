using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class KeywordData
    {
        public int pkKeyword { get; set; }
        public string Keyword { get; set; } // unique index

        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardKeywordData> CardKeywords { get; set; }
    }
}
