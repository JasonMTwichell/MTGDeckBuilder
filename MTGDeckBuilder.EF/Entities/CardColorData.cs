using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF.Entities
{
    public class CardColorData
    {
        public int fkCard { get; set; }
        public int fkColor { get; set; }

        public virtual CardData Card { get; set; }
        public virtual ColorData Color { get; set; }
    }
}
