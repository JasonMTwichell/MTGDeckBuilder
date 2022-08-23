using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF.Entities
{
    public record BootstrapDBData
    {
        public string VersionNumber { get; init; }
        public DateTime VersionDate { get; init; }
        public IEnumerable<ColorData> Colors { get; init; }
        public IEnumerable<ColorIdentityData> ColorIdentities { get; init; }
        public IEnumerable<TypeData> Types { get; init; }
        public IEnumerable<SuperTypeData> SuperTypes { get; init; }
        public IEnumerable<SubTypeData> SubTypes { get; init; }
        public IEnumerable<KeywordData> Keywords { get; init; }
        public IEnumerable<FormatData> Formats { get; init; }
        public IEnumerable<SetData> Sets { get; set; }
        public IEnumerable<CardData> Cards { get; set; }
    }
}
