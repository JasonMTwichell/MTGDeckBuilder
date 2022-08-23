using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class CardSuperTypeData
    {
        public int fkCard { get; set; }
        public int fkSuperType { get; set; }

        public virtual CardData Card { get; set; }
        public virtual SuperTypeData SuperType { get; set; }
    }
}
