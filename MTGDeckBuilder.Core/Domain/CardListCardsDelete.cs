﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Domain
{
    public record struct CardListCardsDelete
    {
        public int CardListID { get; init; }
        public string[] CardUUIDsToDelete { get; init; }
    }
}
