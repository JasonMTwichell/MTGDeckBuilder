using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public record UserDeckStub
    {
        public int UserDeckID { get; init; }
        public string UserDeckName { get; init; }
        public string UserDeckDescription { get; init; }
    }
}
