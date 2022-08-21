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
        IEnumerable<CardData> GetCards();
        IEnumerable<ColorData> GetColors();
        IEnumerable<TypeData> GetTypes();
        IEnumerable<SuperTypeData> GetSuperTypes();
        IEnumerable<SubTypeData> GetSubTypes();
        IEnumerable<KeywordData> GetKeywords();
        IEnumerable<LegalityData> GetLegalities();
    }
}
