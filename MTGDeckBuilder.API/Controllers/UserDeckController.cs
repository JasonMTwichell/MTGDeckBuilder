using Microsoft.AspNetCore.Mvc;
using MTGDeckBuilder.API.ViewModels;
using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTGDeckBuilder.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserDeckController : ControllerBase
    {
        private readonly IMTGDeckBuilderService _deckBuilderSvc;
        public UserDeckController(IMTGDeckBuilderService deckBuilderService) 
        {
            _deckBuilderSvc = deckBuilderService;
        }

        // GET: api/<DeckController>
        [HttpGet]
        public IEnumerable<UserDeckViewModel> Get()
        {
            return _deckBuilderSvc.GetUserDeckStubs().Select(uds => new UserDeckViewModel
            {
                UserDeckID = uds.UserDeckID,
                UserDeckName = uds.UserDeckName,
                UserDeckDescription = uds.UserDeckDescription,
            }).ToArray();
        }

        // GET api/<DeckController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DeckController>
        [HttpPost]
        public async Task Post([FromBody] CreateUserDeckViewModel vm)
        {
            UserDeckCreate createCmd = new UserDeckCreate()
            {
                DeckName = vm.UserDeckName,
                DeckDescription = vm.UserDeckDescription,
                DateCreated = DateTime.Now,
            };

            await _deckBuilderSvc.CreateUserDeck(createCmd);
        }

        // PUT api/<DeckController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeckController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
