using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class TypeData
    {
        public int pkType { get; set; } // pk
        public string Type { get; set; } // unique index

        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardTypeData> CardTypes { get; set; }
    }
}
