using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF
{
    public class KeywordData
    {
        public int pkKeyword { get; set; }
        public string Keyword { get; set; }
        
        public virtual ICollection<CardData> Cards { get; set; }
    }
}
