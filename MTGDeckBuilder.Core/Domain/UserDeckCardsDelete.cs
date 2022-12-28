using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public record struct UserDeckCardsDelete
    {
        public int UserDeckID { get; init; }
        public string[] CardUUIDsToDelete { get; init; }
    }
}
