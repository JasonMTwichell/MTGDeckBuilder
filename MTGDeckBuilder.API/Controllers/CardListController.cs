using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTGDeckBuilder.API.ViewModels;
using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;
using System.Security.Cryptography.X509Certificates;

namespace MTGDeckBuilder.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CardListController : ControllerBase
    {
        public IMTGDeckBuilderService _deckBuilderSvc;
        public CardListController(IMTGDeckBuilderService deckBuilderSvc)
        {
            _deckBuilderSvc = deckBuilderSvc;
        }

        [HttpPost]
        public async Task CreateCardList([FromBody] CardListViewModel vm)
        {
            CardList cardList = new CardList()
            {
                CardListName = vm.CardListName,
                CardListDescription = vm.CardListDescription,
            };

            await _deckBuilderSvc.CreateCardList(cardList);
        }

        [HttpGet]
        public IEnumerable<CardListViewModel> GetAllCardLists()
        {
            CardList[] lists = _deckBuilderSvc.GetCardLists().ToArray();
            return lists.Select(cl => new CardListViewModel()
            {
                CardListID = cl.CardListID,
                CardListName = cl.CardListName,
                CardListDescription = cl.CardListDescription,
                Cards = cl.Cards.Select(c => new CardViewModel()
                {
                    CardID = c.CardID.Value,
                    CardUUID = c.UUID,
                    ConvertedManaCost = c.ManaValue ?? 0,
                    ManaCost = c.ManaCost,
                    Name = c.Name,
                    Text = c.Text,
                    Type = c.Type,
                    Power = c.Power,
                    Toughness = c.Toughness,
                    Loyalty = c.Loyalty,
                    HasLoyalty = c.Loyalty.HasValue,
                    HasPowerToughness = (!string.IsNullOrEmpty(c.Power) || !string.IsNullOrEmpty(c.Toughness))
                })
            }).ToArray();
        }

        [HttpGet]
        public IEnumerable<ListItemViewModel<int>> GetAllCardListReferences()
        {
            CardList[] lists = _deckBuilderSvc.GetCardLists().ToArray();
            return lists.Select(l => new ListItemViewModel<int>()
            {
                Name = l.CardListName,
                Value = l.CardListID.Value,
            }).ToArray();
        }

        [HttpGet("{cardListID}")]
        public CardListViewModel Get(int cardListID)
        {
            CardList list = _deckBuilderSvc.GetCardList(cardListID);
            return new CardListViewModel()
            {
                CardListID = list.CardListID,
                CardListName = list.CardListName,
                CardListDescription = list.CardListDescription,
                Cards = list.Cards.Select(c => new CardViewModel()
                {
                    CardID = c.CardID.Value,
                    CardUUID = c.UUID,
                    ConvertedManaCost = c.ManaValue ?? 0,
                    ManaCost = c.ManaCost,
                    Name = c.Name,
                    Text = c.Text,
                    Type = c.Type,
                    Power = c.Power,
                    Toughness = c.Toughness,
                    Loyalty = c.Loyalty,
                    HasLoyalty = c.Loyalty.HasValue,
                    HasPowerToughness = (!string.IsNullOrEmpty(c.Power) || !string.IsNullOrEmpty(c.Toughness))
                })
            };
        }

        [HttpPost]
        public async Task UpdateCardList([FromBody] CardListViewModel vm)
        {
            CardList cardList = new CardList()
            {
                CardListID = vm.CardListID,
                CardListName = vm.CardListName,
                CardListDescription = vm.CardListDescription,
            };

            await _deckBuilderSvc.UpdateCardList(cardList);
        }

        [HttpPost]
        public async Task AddCardToList([FromBody] AddListCardViewModel vm)
        {
            await _deckBuilderSvc.AddCardToList(vm.CardListID, vm.CardUUID);
        }

        
    }
}
