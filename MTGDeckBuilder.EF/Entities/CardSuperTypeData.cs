using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class CardSuperTypeData
    {
        public string fkCard { get; set; }
        public string fkSuperType { get; set; }

        public virtual CardData Card { get; set; }
        public virtual SuperTypeData SuperType { get; set; }
    }
}
