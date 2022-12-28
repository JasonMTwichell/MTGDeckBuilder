using Microsoft.AspNetCore.Mvc;
using MTGDeckBuilder.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MTGDeckBuilder.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DeckController : ControllerBase
    {
        private readonly IMTGDeckBuilderService _deckBuilderSvc;
        public DeckController(IMTGDeckBuilderService deckBuilderService) 
        {
            _deckBuilderSvc = deckBuilderService;
        }

        // GET: api/<DeckController>
        [HttpGet]
        public IEnumerable<UserDeckViewModel> Get()
        {
                   
        }

        // GET api/<DeckController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DeckController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
