using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class TypeData
    {
        public string Type { get; set; } //pk

        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardTypeData> CardTypes { get; set; }
    }
}
