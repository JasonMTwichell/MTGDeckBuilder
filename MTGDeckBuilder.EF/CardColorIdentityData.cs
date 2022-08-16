using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF
{
    public class CardColorIdentityData
    {
        public int fkCard { get; set; }
        public int fkColor { get; set; }
    }
}
