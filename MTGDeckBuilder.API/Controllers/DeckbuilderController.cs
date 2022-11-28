using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTGDeckBuilder.API.ViewModels;
using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;

namespace MTGDeckBuilder.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DeckbuilderController : ControllerBase
    {
        private readonly IMTGDeckBuilderService _svc;
        public DeckbuilderController(IMTGDeckBuilderService svc)
        {
            _svc = svc;
        }

        [HttpPost]
        public async Task CreateList([FromBody] CardListViewModel vm)
        {
            CardList cardList = new CardList()
            {
                CardListName = vm.CardListName,
                CardListDescription = vm.CardListDescription,
            };

            await _svc.CreateCardList(cardList);
        }

        [HttpPost]
        public async Task AddCardToList([FromBody] AddListCardViewModel vm)
        {
            await _svc.AddCardToList(vm.CardListID, vm.CardUUID);
        }

        [HttpGet]
        public IEnumerable<CardListViewModel> GetLists()
        {
            CardList[] lists = _svc.GetCardLists().ToArray();
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
        public IEnumerable<ListItemViewModel<int>> GetListReferences()
        {
            CardList[] lists = _svc.GetCardLists().ToArray();
            return lists.Select(l => new ListItemViewModel<int>()
            {
                Name = l.CardListName,
                Value = l.CardListID.Value,
            }).ToArray();
        }

        [HttpGet]
        public CardListViewModel GetList(int cardListID)
        {
            CardList list = _svc.GetCardList(cardListID);
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
    }

}
