using Microsoft.AspNetCore.Mvc;
using MTGDeckBuilder.API.ViewModels;
using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.DTO;
using MTGDeckBuilder.Core.Service;

namespace MTGDeckBuilder.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MTGSearchController: ControllerBase
    {
        private readonly IMTGDeckBuilderService _mtgSvc;
        public MTGSearchController(IMTGDeckBuilderService mtgSvc)
        {
            _mtgSvc = mtgSvc;
        }

        [HttpGet]
        public async Task<SearchCriteriaViewModel> GetSearchCriteria()
        {
            CardSearchCriteria cardSearchCriteria = await _mtgSvc.GetSearchCriteria();
            return new SearchCriteriaViewModel()
            {
                Colors = cardSearchCriteria.Colors.Select(c => new ListItemViewModel<int>()
                {
                    Value = c.ColorID.Value,
                    Name = c.ColorName
                }).ToArray(),
                Formats = cardSearchCriteria.Formats.Select(f => new ListItemViewModel<int>()
                {
                    Value = f.FormatID.Value,
                    Name = f.FormatName
                }).ToArray(),
                Sets = cardSearchCriteria.Sets.Select(s => new ListItemViewModel<int>()
                {
                    Value = s.SetID.Value,
                    Name = s.SetName,
                }).ToArray(),
                Types = cardSearchCriteria.Types.Select(t => new ListItemViewModel<int>()
                {
                    Value = t.CardTypeID.Value,
                    Name = t.TypeName
                }).ToArray(),
                SuperTypes = cardSearchCriteria.SuperTypes.Select(t => new ListItemViewModel<int>()
                {
                    Value = t.SuperTypeID.Value,
                    Name = t.SuperTypeName
                }).ToArray(),
                SubTypes = cardSearchCriteria.SubTypes.Select(t => new ListItemViewModel<int>()
                {
                    Value = t.SubTypeID.Value,
                    Name = t.SubTypeName
                }).ToArray()
            };
        }

        [HttpGet]
        public async Task<IEnumerable<CardViewModel>> Search(CardSearchViewModel searchVM)
        {
            CardSearchParameters searchParams = new CardSearchParameters()
            {
                SearchTerm = searchVM.SearchTerm,
                FormatID = searchVM.FormatID,
                SetID = searchVM.SetID,
                KeywordID = searchVM.KeywordID,
                TypeID = searchVM.TypeID,
                SuperTypeID = searchVM.SuperTypeID,
                SubTypeID = searchVM.SubTypeID,
                SelectedColorFilters = searchVM.Colors,
                MatchColorIdentity = searchVM.MatchColorIdentity ?? false,
                MatchColorsExactly = searchVM.MatchColorsExactly ?? false,
            };

            IEnumerable<Card> searchResults = await _mtgSvc.PerformCardSearch(searchParams);
            CardViewModel[] mappedSearchResults = searchResults.Select(c => new CardViewModel()
            {
                CardID = c.CardID.Value,
                ManaCost = c.ManaCost,
                Name = c.Name,
                Text = c.Text,
            }).ToArray();

            return mappedSearchResults;
        }
    }
}
