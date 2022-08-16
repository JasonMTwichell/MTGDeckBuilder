using System;
using System.Collections.Generic;
using System.Text;

namespace MTGDeckBuilder.EF
{
    public class CardSuperTypeData
    {
        public int fkCard { get; set; }
        public int fkSuperType { get; set; }
    }
}
