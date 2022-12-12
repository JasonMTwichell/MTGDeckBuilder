using Microsoft.AspNetCore.Mvc;
using MTGDeckBuilder.API.ViewModels;
using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTGDeckBuilder.API.Controllers
{
    [Route("api/cardList/{cardListID}/[controller]")]
    [ApiController]
    public class CardListCardsController : ControllerBase
    {
        IMTGDeckBuilderService _deckBuilderSvc;
        public CardListCardsController(IMTGDeckBuilderService deckBuilderSvc)
        {
            _deckBuilderSvc = deckBuilderSvc;
        }

        // GET: api/cardList/{cardListID}/<CardListCardsController>
        [HttpGet]
        public IEnumerable<CardListCardViewModel> Get(int cardListID)
        {
            CardList cardList = _deckBuilderSvc.GetCardList(cardListID); // TODO: consider making this just retrieve cards
            CardListCardViewModel[] cardListCardViewModels = cardList.Cards.Select(c => new CardListCardViewModel()
            {
                CardListID = cardList.CardListID.Value,
                CardID = c.CardID.Value,
                CardUUID = c.UUID,
                ManaCost = c.ManaCost,
                ConvertedManaCost = c.ManaValue ?? 0,
                Name = c.Name,
                Text = c.Text,
                Type = c.Type,
                Power = c.Power,
                Toughness = c.Toughness,
                Loyalty = c.Loyalty,
                HasLoyalty = c.Loyalty.HasValue,
                HasPowerToughness = (!string.IsNullOrEmpty(c.Power) || !string.IsNullOrEmpty(c.Toughness))
            }).ToArray();

            return cardListCardViewModels;
        }

        // POST api/{cardListID}/<CardListCardsController>
        [HttpPost()]
        public void Post([FromBody] AddCardListCardViewModel viewModel)
        {
            _deckBuilderSvc.AddCardListCard(viewModel.CardListID, viewModel.CardUUID);
        }

        // DELETE api/<CardListCardsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        [HttpDelete()]
        public async Task Delete([FromBody] DeleteCardListCardsViewModel viewModel)
        {
            DeleteCardListCards deleteListCardCmd = new DeleteCardListCards
            {
                CardListID = viewModel.CardListID,
                CardUUIDsToDelete = viewModel.CardUUIDsToDelete,
            };

            await _deckBuilderSvc.DeleteCardListCards(deleteListCardCmd);
        }
    }
}
