using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public record UserDeckCreate
    {
        public string DeckName { get; init; }
        public string? DeckDescription { get; init; }
        public DateTime DateCreated { get; init; }
    }
}
