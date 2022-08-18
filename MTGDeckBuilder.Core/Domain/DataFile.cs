using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public class DataFile
    {
        public string VersionNumber { get; set; }
        public DateTime VersionDate { get; set; }
        public IEnumerable<Card> Cards { get; set; }
    }
}
