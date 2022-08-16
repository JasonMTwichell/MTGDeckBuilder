using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF
{
    public class CardTypeData
    {
        public int fkCard { get; set; }
        public int fkType { get; set; }
    }
}
