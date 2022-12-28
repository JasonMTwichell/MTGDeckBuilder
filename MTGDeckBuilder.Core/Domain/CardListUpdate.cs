using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public class CardListUpdate
    {
        public int CardListID { get; set; }
        public string CardListName { get; set; }
        public string? CardListDescription { get; set; }
    }
}
