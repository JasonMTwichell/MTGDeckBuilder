using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class TypeData
    {
        public int pkType { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardTypeData> CardTypes { get; set; }
    }
}
