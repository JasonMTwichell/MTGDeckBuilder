using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class SubTypeData
    {
        public int pkSubType { get; set; }
        public string SubTypeName { get; set; }

        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardSubTypeData> CardSubTypes { get; set; }
    }
}
