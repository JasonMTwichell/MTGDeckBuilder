using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.EF;
using MTGDeckBuilder.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.Services
{
    public class MTGDeckBuilderService : IMTGDeckBuilderService
    {
        private readonly IMTGDeckBuilderRepository _repo;
        public MTGDeckBuilderService(IMTGDeckBuilderRepository repo)
        {
            _repo = repo;
        }

        #region Card List
        public CardList GetCardList(int cardListID)
        {
            CardListData cardList = _repo.GetCardList(cardListID);
            return new CardList()
            {
                CardListID = cardList.pkCardList,
                CardListName = cardList.CardListName,
                CardListDescription = cardList.CardListDescription,
                Cards = cardList.ListCards.Select(lc => lc.Card).Select(c => new Card()
                {
                    CardID = c.pkCard,
                    UUID = c.UUID,
                    Name = c.Name,
                    AsciiName = c.AsciiName,
                    FaceName = c.FaceName,
                    FlavorText = c.FlavorText,
                    ManaCost = c.ManaCost,
                    ManaValue = c.ManaValue ?? 0,
                    Text = c.Text,
                    Type = c.Type,
                }).ToArray(),
            };
        }

        public IEnumerable<CardList> GetCardLists()
        {
            IEnumerable<CardListData> cardLists = _repo.GetCardLists();
            return cardLists.Select(cl => new CardList()
            {
                CardListID = cl.pkCardList,
                CardListName = cl.CardListName,
                CardListDescription = cl.CardListDescription,
                Cards = cl.ListCards?.Select(cl => cl.Card).Select(c => new Card()
                {
                    CardID = c.pkCard,
                    Name = c.Name,
                    AsciiName = c.AsciiName,
                    FaceName = c.FaceName,
                    FlavorText = c.FlavorText,
                    ManaCost = c.ManaCost,
                    ManaValue = c.ManaValue ?? 0,
                    Text = c.Text,
                    Type = c.Type,
                }).ToArray(),
            });
        }

        public async Task CreateCardList(CardListCreate cardList)
        {
            CardListData cardListData = new CardListData()
            {
                CardListName = cardList.CardListName,
                CardListDescription = cardList.CardListDescription,
            };

            await _repo.CreateCardList(cardListData);
        }

        public async Task DeleteCardList(int cardListID)
        {
            await _repo.DeleteCardList(cardListID);
        }

        public async Task UpdateCardList(CardListUpdate cardList)
        {
            CardListData existing = _repo.GetCardList(cardList.CardListID);
            existing.CardListName = cardList.CardListName;
            existing.CardListDescription = cardList.CardListDescription;
            await _repo.UpdateCardList(existing);
        }
        public async Task AddCardListCard(CardListCardCreate createCmd)
        {
            CardListCardData cardListCardData = new CardListCardData()
            {
                fkCardList = createCmd.CardListID,
                CardUUID = createCmd.CardUUID,
            };

            await _repo.AddListCard(cardListCardData);
        }

        public async Task DeleteCardListCards(CardListCardsDelete deleteCmd)
        {
            await _repo.DeleteCardListCards(deleteCmd with { });
        } 
        #endregion

        #region User Deck
        public IEnumerable<UserDeck> GetUserDecks()
        {
            UserDeckData[] decks = _repo.GetUserDecks().ToArray();
            UserDeck[] mappedDecks = decks.Select(d => new UserDeck()
            {
                UserDeckID = d.pkUserDeck,
                DeckName = d.DeckName,
                DeckDescription = d.DeckDescription,
                DateCreated = d.DateCreated,
                Cards = d.Cards.Select(dc => new UserDeckCard()
                {
                    UserDeckID = d.pkUserDeck,
                    NumCopiesInDeck = dc.NumCopies,
                    Card = new Card()
                    {
                        CardID = dc.CardData.pkCard,
                        UUID = dc.CardData.UUID,
                        Name = dc.CardData.Name,
                        AsciiName = dc.CardData.AsciiName,
                        FaceName = dc.CardData.FaceName,
                        FlavorText = dc.CardData.FlavorText,
                        ManaCost = dc.CardData.ManaCost,
                        ManaValue = dc.CardData.ManaValue ?? 0,
                        Text = dc.CardData.Text,
                        Type = dc.CardData.Type,
                    }
                }).ToArray(),
                SideBoard = d.SideBoard?.Cards?.Select(sc => new UserDeckCard()
                {
                    UserDeckID = d.pkUserDeck,
                    NumCopiesInDeck = sc.NumCopies,
                    Card = new Card()
                    {
                        CardID = sc.Card.pkCard,
                        UUID = sc.Card.UUID,
                        Name = sc.Card.Name,
                        AsciiName = sc.Card.AsciiName,
                        FaceName = sc.Card.FaceName,
                        FlavorText = sc.Card.FlavorText,
                        ManaCost = sc.Card.ManaCost,
                        ManaValue = sc.Card.ManaValue ?? 0,
                        Text = sc.Card.Text,
                        Type = sc.Card.Type,
                    }
                }).ToArray(),
            }).ToArray();

            return mappedDecks;
        }

        public UserDeck GetUserDeck(int userDeckID)
        {
            UserDeckData deck = _repo.GetUserDeck(userDeckID);
            UserDeck mappedDecks = new UserDeck()
            {
                UserDeckID = deck.pkUserDeck,
                DeckName = deck.DeckName,
                DeckDescription = deck.DeckDescription,
                DateCreated = deck.DateCreated,
                Cards = deck.Cards.Select(dc => new UserDeckCard()
                {
                    UserDeckID = deck.pkUserDeck,
                    NumCopiesInDeck = dc.NumCopies,
                    Card = new Card()
                    {
                        CardID = dc.CardData.pkCard,
                        UUID = dc.CardData.UUID,
                        Name = dc.CardData.Name,
                        AsciiName = dc.CardData.AsciiName,
                        FaceName = dc.CardData.FaceName,
                        FlavorText = dc.CardData.FlavorText,
                        ManaCost = dc.CardData.ManaCost,
                        ManaValue = dc.CardData.ManaValue ?? 0,
                        Text = dc.CardData.Text,
                        Type = dc.CardData.Type,
                    }
                }).ToArray(),
                SideBoard = deck.SideBoard?.Cards?.Select(sc => new UserDeckCard()
                {
                    UserDeckID = deck.pkUserDeck,
                    NumCopiesInDeck = sc.NumCopies,
                    Card = new Card()
                    {
                        CardID = sc.Card.pkCard,
                        UUID = sc.Card.UUID,
                        Name = sc.Card.Name,
                        AsciiName = sc.Card.AsciiName,
                        FaceName = sc.Card.FaceName,
                        FlavorText = sc.Card.FlavorText,
                        ManaCost = sc.Card.ManaCost,
                        ManaValue = sc.Card.ManaValue ?? 0,
                        Text = sc.Card.Text,
                        Type = sc.Card.Type,
                    }
                }).ToArray(),
            };

            return mappedDecks;
        }

        public async Task CreateUserDeck(UserDeckCreate createUserDeck)
        {
            UserDeckData deckData = new UserDeckData()
            {
                DeckName = createUserDeck.DeckName,
                DeckDescription = createUserDeck.DeckDescription,
                DateCreated = createUserDeck.DateCreated,
                SideBoard = new UserDeckSideboardData(),                
            };

            await _repo.CreateUserDeck(deckData);
        }

        public async Task UpdateUserDeck(UserDeckUpdate updateUserDeck)
        {
            UserDeckData deckData = _repo.GetUserDeck(updateUserDeck.UserDeckID);
            deckData.DeckName = updateUserDeck.DeckName;
            deckData.DeckDescription = updateUserDeck.DeckDescription ?? deckData.DeckDescription;
            await _repo.UpdateUserDeck(deckData);
        }

        public async Task DeleteUserDeck(int userDeckID)
        {
            await _repo.DeleteUserDeck(userDeckID);
        }

        public async Task AddUserDeckCard(UserDeckCardCreate createCmd)
        {
            UserDeckCardData deckCardData = new UserDeckCardData()
            {
                fkUserDeck = createCmd.UserDeckID,
                CardUUID = createCmd.CardUUID,
                NumCopies = createCmd.NumCopies,
            };

            await _repo.AddDeckCard(deckCardData);
        }

        public async Task DeleteUserDeckCards(UserDeckCardsDelete deleteCmd)
        {
            await _repo.DeleteUserDeckCards(deleteCmd with { }); 
        }

        public async Task AddUserSideboardCard(UserDeckSideboardCardsCreate createCmd)
        {
            await _repo.AddSideboardCard(createCmd with { });
        }

        public async Task DeleteUserSideboardCards(UserDeckSideboardCardDelete deleteCmd)
        {
            await _repo.DeleteSideboardCard(deleteCmd with { });
        }

        public Task UpdateUserDeckCard(UserDeckCardUpdate updateCmd)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserSideboardCard(UserDeckSideboardCardsCreate createCmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDeckStub> GetUserDeckStubs()
        {
            return _repo.GetUserDeckStubs().Select(ud => new UserDeckStub()
            {
                UserDeckID = ud.pkUserDeck,
                UserDeckName = ud.DeckName,
                UserDeckDescription = ud.DeckDescription
            }).ToArray();
        }
        #endregion
    }
}
