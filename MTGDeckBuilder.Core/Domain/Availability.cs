using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public record Availability
    {
        public int? AvailabilityID { get; init; }
        public string AvailabilityDescription { get; init; }
    }
}
