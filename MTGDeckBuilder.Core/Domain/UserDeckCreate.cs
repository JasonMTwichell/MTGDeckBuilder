using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public class UserDeckCreate
    {
        public string DeckName { get; set; }
        public string DeckDescription { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
