using Microsoft.AspNetCore.Mvc;
using MTGDeckBuilder.API.ViewModels;
using MTGDeckBuilder.Core.Domain;
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
        public async Task<CardSearchCriteriaViewModel> GetSearchCriteria()
        {
            CardSearchCriteria cardSearchCriteria = await _mtgSvc.GetSearchCriteria();
            return new CardSearchCriteriaViewModel()
            {
                Colors = cardSearchCriteria.Colors.Select(f => new ListItemViewModel<int>()
                {
                    Value = f.ColorID.Value,
                    Name = f.ColorName
                }).OrderBy(f => f.Name).ToArray(),
                Formats = cardSearchCriteria.Formats.Select(f => new ListItemViewModel<int>()
                {
                    Value = f.FormatID.Value,
                    Name = f.FormatName
                }).OrderBy(f => f.Name).ToArray(),
                Sets = cardSearchCriteria.Sets.Select(s => new ListItemViewModel<int>()
                {
                    Value = s.SetID.Value,
                    Name = s.SetName,
                }).OrderBy(f => f.Name).ToArray(),
                Types = cardSearchCriteria.Types.Select(t => new ListItemViewModel<int>()
                {
                    Value = t.CardTypeID.Value,
                    Name = t.TypeName
                }).OrderBy(f => f.Name).ToArray(),
                SuperTypes = cardSearchCriteria.SuperTypes.Select(t => new ListItemViewModel<int>()
                {
                    Value = t.SuperTypeID.Value,
                    Name = t.SuperTypeName
                }).OrderBy(f => f.Name).ToArray(),
                SubTypes = cardSearchCriteria.SubTypes.Select(t => new ListItemViewModel<int>()
                {
                    Value = t.SubTypeID.Value,
                    Name = t.SubTypeName
                }).OrderBy(f => f.Name).ToArray(),
                Keywords = cardSearchCriteria.Keywords.Select(k => new ListItemViewModel<int>()
                {
                    Value = k.KeywordID.Value,
                    Name = k.KeywordName
                }).OrderBy(f => f.Name)
            };
        }

        [HttpPost]
        public async Task<IEnumerable<CardViewModel>> Search([FromBody] CardSearchParametersViewModel searchVM)
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
                SelectedColorFilters = searchVM.SearchColors ?? Array.Empty<int>(),
                SearchNameText = searchVM.SearchNameText ?? false,
                SearchRulesText = searchVM.SearchRulesText ?? false,
                MatchMulticolorCardsOnly = searchVM.MatchMulticolorOnly ?? false,
                MatchColorIdentity = searchVM.MatchColorIdentity ?? false,
                MatchColorsExactly = searchVM.MatchColorsExactly ?? false,
                ExcludeUnselectedColors = searchVM.ExcludeUnselectedColors ?? false,
            };

            IEnumerable<Card> searchResults = await _mtgSvc.PerformCardSearch(searchParams);
            CardViewModel[] mappedSearchResults = searchResults.DistinctBy(c => c.Name).Select(c => new CardViewModel()
            {
                CardID = c.CardID.Value,
                ConvertedManaCost = c.ManaValue ?? 0,
                ManaCost = c.ManaCost,
                Name = c.Name,
                Text = c.Text,
            }).OrderBy(c => c.ConvertedManaCost).ToArray();

            return mappedSearchResults;
        }
    }
}
