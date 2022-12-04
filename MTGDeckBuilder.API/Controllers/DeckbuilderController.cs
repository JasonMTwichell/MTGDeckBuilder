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

        
    }

}
