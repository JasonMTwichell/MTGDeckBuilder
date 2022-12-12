using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public struct DeleteCardListCards
    {
        public int CardListID { get; init; }
        public string[] CardUUIDsToDelete { get; init; }
    }
}
