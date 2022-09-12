using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.DTO;
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
        public IMTGDeckBuilderRepository _repo;
        public MTGDeckBuilderService(IMTGDeckBuilderRepository repo)
        {
            _repo = repo;
        }

        public async Task<CardSearchCriteria> GetSearchCriteria()
        {
            return new CardSearchCriteria()
            {
                Colors = _repo.GetColors().Select(c => new Color()
                {
                    ColorID = c.pkColor,
                    ColorName = c.Color,
                }).ToArray(),
                Formats = _repo.GetFormats().Select(f => new Format()
                {
                    FormatID = f.pkFormat,
                    FormatName = f.Format,
                }).ToArray(),
                Keywords = _repo.GetKeywords().Select(k => new Keyword()
                {
                    KeywordID = k.pkKeyword,
                    KeywordName = k.Keyword,
                }).ToArray(),
                Sets = _repo.GetSets().Select(s => new Set()
                {
                    SetID = s.pkSet,
                    SetName = s.SetName,
                }).ToArray(),
                SubTypes = _repo.GetSubTypes().Select(s => new SubType()
                {
                    SubTypeID = s.pkSubType,
                    SubTypeName = s.SubType
                }).ToArray(),
                SuperTypes = _repo.GetSuperTypes().Select(s => new SuperType()
                {
                    SuperTypeID = s.pkSuperType,
                    SuperTypeName = s.SuperType,
                }).ToArray(),
                Types = _repo.GetTypes().Select(t => new CardType()
                {
                    CardTypeID = t.pkType,
                    TypeName = t.Type,
                }).ToArray()
            };
        }

        public async Task<IEnumerable<Card>> PerformCardSearch(CardSearchParameters searchParams)
        {
            IQueryable<CardData> cards = Array.Empty<CardData>().AsQueryable();
            
            if(searchParams.SetID != null)
            {
                cards = cards.Where(c => c.fkSet == searchParams.SetID);
            }

            if(searchParams.FormatID != null)
            {
                cards = cards.Where(c => c.Formats.Any(f => f.pkFormat == searchParams.FormatID.Value));
            }
            
            if(searchParams.TypeID != null)
            {
                cards = cards.Where(c => c.Types.Any(t => t.pkType == searchParams.TypeID.Value));
            }

            if(searchParams.SuperTypeID != null)
            {
                cards = cards.Where(c => c.SuperTypes.Any(st => st.pkSuperType == searchParams.SuperTypeID.Value));
            }

            if(searchParams.SubTypeID != null)
            {
                cards = cards.Where(c => c.SubTypes.Any(st => st.pkSubType == searchParams.SubTypeID.Value));
            }

            if (searchParams.KeywordID != null)
            {
                cards = cards.Where(c => c.Keywords.Any(k => k.pkKeyword == searchParams.KeywordID.Value));
            }

            if(searchParams.SelectedColorFilters.Length > 0)
            {
                if(searchParams.MatchColorsExactly)
                {
                    if(searchParams.MatchColorIdentity)
                    {
                        cards = cards.Where(c => c.ColorIdentities.All(color => searchParams.SelectedColorFilters.Contains(color.pkColorIdentity)));
                    }
                    else
                    {
                        cards = cards.Where(c => c.Colors.All(color => searchParams.SelectedColorFilters.Contains(color.pkColor)));
                    }
                }
                else
                {
                    if (searchParams.MatchColorIdentity)
                    {
                        cards = cards.Where(c => c.ColorIdentities.Any(color => searchParams.SelectedColorFilters.Contains(color.pkColorIdentity)));
                    }
                    else
                    {
                        cards = cards.Where(c => c.Colors.Any(color => searchParams.SelectedColorFilters.Contains(color.pkColor)));
                    }
                }
            }
            
            if(!string.IsNullOrEmpty(searchParams.SearchTerm))
            {
                cards = _repo.GetCards().Where(c => c.Name.Contains(searchParams.SearchTerm) || c.Text.Contains(searchParams.SearchTerm)).AsQueryable();
            }

            Card[] matchingCards = cards.Select(c => new Card()
            {
                CardID = c.pkCard,
                AsciiName = c.AsciiName,
                FaceName = c.FaceName,
                FlavorText = c.FlavorText,
                ManaCost = c.ManaCost,
                ManaValue = c.ManaValue ?? 0,
                Text = c.Text,
            }).ToArray();

            return matchingCards;
        }
    }
}
