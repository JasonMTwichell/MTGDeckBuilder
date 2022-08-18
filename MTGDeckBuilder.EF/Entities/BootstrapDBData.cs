using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF.Entities
{
    public class BootstrapDBData
    {
        public string VersionNumber { get; set; }
        public DateTime VersionDate { get; set; }
        public IEnumerable<ColorData> Colors { get; set; }
        public IEnumerable<ColorIdentityData> ColorsIdentity { get; set; }
        public IEnumerable<TypeData> Types { get; set; }
        public IEnumerable<SuperTypeData> SuperTypes { get; set; }
        public IEnumerable<SubTypeData> SubTypes { get; set; }
        public IEnumerable<KeywordData> Keywords { get; set; }
        public IEnumerable<CardData> Cards { get; set; }
    }
}
