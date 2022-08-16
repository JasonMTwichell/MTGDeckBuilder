using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF
{
    public class CardColorData
    {
        public int fkCard { get; set; }
        public int fkColor { get; set; }
    }
}
