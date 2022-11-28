using MTGDeckBuilder.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Service
{
    public interface IMTGCardService
    {
        Task<CardSearchCriteria> GetSearchCriteria();
        Task<IEnumerable<Card>> PerformCardSearch(CardSearchParameters searchParams);        
    }
}
