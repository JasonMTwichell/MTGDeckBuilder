using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class CardTypeData
    {
        public int fkCard { get; set; }
        public int fkType { get; set; }

        public virtual CardData Card { get; set; }
        public virtual TypeData Type { get; set; }
    }
}
