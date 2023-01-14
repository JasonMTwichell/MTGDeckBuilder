using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedMeta
    {
        public DateTime? Date { get; set; }
        public string? Version { get; set; }
    }
}
