using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedAllPrintingsFile
    {        
        public string VersionNumber { get; set; }
        public DateTime VersionDate { get; set; }
        public IEnumerable<ParsedSet> Sets { get; set; }
    }
}
