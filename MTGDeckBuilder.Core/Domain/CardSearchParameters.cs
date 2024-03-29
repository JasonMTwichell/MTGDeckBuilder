﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public class CardSearchParameters
    {
        public string? SearchTerm { get; set; }
        public int? SetID { get; set; }
        public int? FormatID { get; set; }
        public int? TypeID { get; set; }
        public int? SuperTypeID { get; set; }
        public int? SubTypeID { get; set; }
        public int? KeywordID { get; set; }

        // color
        public int[] SelectedColorFilters { get; set; }
        public bool SearchNameText { get; set; }
        public bool SearchRulesText { get; set; }
        public bool MatchColorsExactly { get; set; }
        public bool MatchColorIdentity { get; set; }
        public bool MatchMulticolorCardsOnly { get; set; }
        public bool ExcludeUnselectedColors { get; set; }
    }
}
