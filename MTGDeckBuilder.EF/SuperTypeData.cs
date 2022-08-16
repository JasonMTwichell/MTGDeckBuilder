using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF
{
    public class SuperTypeData
    {
        public int pkSuperType { get; set; }
        public string SuperTypeName { get; set; }

        public virtual ICollection<CardData> Cards { get; set; }
    }
}
