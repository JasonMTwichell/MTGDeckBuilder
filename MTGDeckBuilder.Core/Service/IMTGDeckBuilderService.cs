﻿using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Service
{
    public interface IMTGDeckBuilderService
    {
        Task<CardSearchCriteria> GetSearchCriteria();
        Task<IEnumerable<Card>> PerformCardSearch(CardSearchParameters searchParams); 
    }
}
