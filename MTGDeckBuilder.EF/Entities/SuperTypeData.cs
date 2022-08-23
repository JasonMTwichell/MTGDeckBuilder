using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class SuperTypeData
    {
        public string SuperType { get; set; } //pk

        public virtual ICollection<CardData> Cards { get; set; }
        public virtual ICollection<CardSuperTypeData> CardSuperTypes { get; set; }
    }
}
