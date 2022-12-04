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

        public async Task AddCardToList(int cardListID, string cardUUID)
        {
            CardListCardData cardListCardData = new CardListCardData()
            {
                CardUUID = cardUUID,
                fkCardList = cardListID,
            };

            await _repo.AddListCard(cardListCardData);
        }

        public async Task CreateCardList(CardList cardList)
        {
            CardListData cardListData = new CardListData()
            {
                CardListName = cardList.CardListName,
                CardListDescription = cardList.CardListDescription,
            };

            await _repo.CreateCardList(cardListData);
        }

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

        public async Task UpdateCardList(CardList cardList)
        {
            CardListData existing = _repo.GetCardList(cardList.CardListID.Value);
            existing.CardListName = cardList.CardListName;
            existing.CardListDescription = cardList.CardListDescription;
            await _repo.UpdateCardList(existing);
        }
    }
}
