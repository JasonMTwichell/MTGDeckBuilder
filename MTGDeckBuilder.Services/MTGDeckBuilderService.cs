using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.DTO;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Services
{
    public class MTGDeckBuilderService : IMTGDeckBuilderService
    {
        public IMTGDeckBuilderRepository _repo;
        public MTGDeckBuilderService(IMTGDeckBuilderRepository repo)
        {
            _repo = repo;
        }

        public Task<CardSearchCriteria> GetSearchCriteria()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Card>> PerformCardSearch(CardSearchParameters searchParams)
        {
            throw new NotImplementedException();
        }
    }
}
