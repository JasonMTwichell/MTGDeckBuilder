using Microsoft.AspNetCore.Mvc;
using MTGDeckBuilder.API.ViewModels;
using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.EF.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTGDeckBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardListController : ControllerBase
    {
        private IMTGDeckBuilderService _deckBuilderSvc;
        public CardListController(IMTGDeckBuilderService deckBuilderSvc)
        {
            _deckBuilderSvc = deckBuilderSvc;
        }
        // GET: api/<CardListController>
        [HttpGet]
        public IEnumerable<CardListViewModel> Get()
        {
            CardList[] cardLists = _deckBuilderSvc.GetCardLists().ToArray();
            CardListViewModel[] viewModels = cardLists.Select(cardList => new CardListViewModel()
            {
                CardListID = cardList.CardListID.Value,
                Name = cardList.CardListName,
                Description = cardList.CardListDescription,
            }).ToArray();
            return viewModels;
        }

        // GET api/<CardListController>/5
        [HttpGet("{id}")]
        public CardListViewModel Get(int id)
        {
            CardList cardList = _deckBuilderSvc.GetCardList(id);
            CardListViewModel viewModel = new CardListViewModel()
            {
                CardListID = cardList.CardListID.Value,
                Name = cardList.CardListName,
                Description = cardList.CardListDescription,
            };
            return viewModel;
        }

        // POST api/<CardListController>
        [HttpPost]
        public async Task Post([FromBody] CreateCardListViewModel viewModel)
        {
            CardList cardList = new CardList
            {
                CardListName = viewModel.Name,
                CardListDescription = viewModel.Description,
            };

            await _deckBuilderSvc.CreateCardList(cardList);
        }

        // PUT api/<CardListController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UpdateCardListViewModel viewModel)
        {
            CardList cardList = new CardList()
            {
                CardListID = viewModel.CardListID,
                CardListName = viewModel.Name,
                CardListDescription = viewModel.Description,
            };

            await _deckBuilderSvc.UpdateCardList(cardList);
        }

        // DELETE api/<CardListController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _deckBuilderSvc.DeleteCardList(id);
        }
    }
}
