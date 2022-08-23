using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class SubTypeData
    {
        public string SubType { get; set; } //pk

        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardSubTypeData> CardSubTypes { get; set; }
    }
}
