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
        #region Card List
        Task CreateCardList(CardListCreate cardList); 
        Task UpdateCardList(CardListUpdate cardList);
        IEnumerable<CardList> GetCardLists();
        CardList GetCardList(int cardListID);
        Task DeleteCardList(int cardListID);
        Task AddCardListCard(CardListCardCreate create);
        Task DeleteCardListCards(CardListCardsDelete deleteCmd);
        #endregion

        #region User Decks
        IEnumerable<UserDeck> GetUserDecks();
        UserDeck GetUserDeck(int userDeckID);
        Task CreateUserDeck(UserDeckCreate createUserDeck);
        Task UpdateUserDeck(UserDeckUpdate createUserDeck);
        Task DeleteUserDeck(int userDeckID);
        Task AddUserDeckCard(UserDeckCardCreate createCmd);
        Task UpdateUserDeckCard(UserDeckCardUpdate updateCmd);
        Task DeleteUserDeckCards(UserDeckCardsDelete deleteCmd);
        Task AddUserSideboardCard(UserDeckSideboardCardsCreate createCmd);
        Task UpdateUserSideboardCard(UserDeckSideboardCardsCreate createCmd);
        Task DeleteUserSideboardCards(UserDeckSideboardCardDelete createCmd);
        #endregion
    }
}
