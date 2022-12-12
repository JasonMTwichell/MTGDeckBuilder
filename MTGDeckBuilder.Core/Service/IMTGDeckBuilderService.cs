using MTGDeckBuilder.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Core.Service
{
    public interface IMTGDeckBuilderService
    {
        Task CreateCardList(CardList cardList);
        Task UpdateCardList(CardList cardList);
        IEnumerable<CardList> GetCardLists();
        CardList GetCardList(int cardListID);
        Task DeleteCardList(int cardListID);
        Task AddCardListCard(int cardListID, string cardUUID);
        Task DeleteCardListCards(DeleteCardListCards deleteCmd);
    }
}
