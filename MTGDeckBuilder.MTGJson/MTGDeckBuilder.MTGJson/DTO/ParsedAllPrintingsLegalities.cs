﻿using Newtonsoft.Json;

namespace MTGDeckBuilder.MTGJson.DTO
{
    public record ParsedAllPrintingsLegalities
    {
        public string? Commander { get; set; }
        public string? Duel { get; set; }
        public string? Legacy { get; set; }
        public string? Oldschool { get; set; }
        public string? Penny { get; set; }
        public string? Premodern { get; set; }
        public string? Vintage { get; set; }
        public string? Pauper { get; set; }
        public string? Paupercommander { get; set; }
        public string? Modern { get; set; }
        public string? Pioneer { get; set; }
        public string? Alchemy { get; set; }
        public string? Brawl { get; set; }
        public string? Explorer { get; set; }
        public string? Future { get; set; }
        public string? Gladiator { get; set; }
        public string? Historic { get; set; }
        public string? Historicbrawl { get; set; }
        public string? Standard { get; set; }
    }
}
