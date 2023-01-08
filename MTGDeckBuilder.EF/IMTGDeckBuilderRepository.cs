using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF
{
    public interface IMTGDeckBuilderRepository
    {
        Task BootstrapDB(BootstrapDBData fileData);
        IEnumerable<SetData> GetSets();
        IEnumerable<CardData> GetCards();
        IEnumerable<ColorData> GetColors();
        IEnumerable<ColorIdentityData> GetColorIdentities();
        IEnumerable<TypeData> GetTypes();
        IEnumerable<SuperTypeData> GetSuperTypes();
        IEnumerable<SubTypeData> GetSubTypes();
        IEnumerable<KeywordData> GetKeywords();
        IEnumerable<FormatData> GetFormats();

        #region Card List
        Task CreateCardList(CardListData cardListData);
        Task UpdateCardList(CardListData cardListData);
        IEnumerable<CardListData> GetCardLists();
        CardListData GetCardList(int cardListID);
        Task DeleteCardList(int cardListID);
        Task AddListCard(CardListCardData listCard);
        Task DeleteCardListCards(CardListCardsDelete deleteCmd);
        #endregion

        #region User Deck
        IEnumerable<UserDeckData> GetUserDecks();
        IEnumerable<UserDeckData> GetUserDeckStubs();
        UserDeckData GetUserDeck(int userDeckID);
        Task CreateUserDeck(UserDeckData deckData);
        Task UpdateUserDeck(UserDeckData deckData);
        Task DeleteUserDeck(int userDeckID);
        Task AddDeckCard(UserDeckCardData deckCard);
        Task DeleteUserDeckCards(UserDeckCardsDelete deleteCmd);
        Task AddSideboardCard(UserDeckSideboardCardsCreate userDeckSideboardCardsCreate);
        Task DeleteSideboardCard(UserDeckSideboardCardDelete userDeckSideboardCardDelete);
        #endregion
    }
}
