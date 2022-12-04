using MTGDeckBuilder.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF
{
    public interface IMTGDeckBuilderRepository
    {
        Task BootstrapDB(BootstrapDBData fileData);
        IEnumerable<SetData> GetSets();
        IEnumerable<CardData> GetCards();
        IEnumerable<ColorData> GetColors();
        IEnumerable<ColorIdentityData> GetColorIdentities();
        IEnumerable<TypeData> GetTypes();
        IEnumerable<SuperTypeData> GetSuperTypes();
        IEnumerable<SubTypeData> GetSubTypes();
        IEnumerable<KeywordData> GetKeywords();
        IEnumerable<FormatData> GetFormats();

        Task CreateCardList(CardListData cardListData);
        Task UpdateCardList(CardListData cardListData);
        IEnumerable<CardListData> GetCardLists();
        CardListData GetCardList(int cardListID);
        Task AddListCard(CardListCardData listCard);
    }
}
