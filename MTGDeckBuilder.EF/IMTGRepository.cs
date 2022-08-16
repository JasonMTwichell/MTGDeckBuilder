using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF
{
    public interface IMTGDeckBuilderRepository
    {
        Task AddColors(IEnumerable<ColorData> colors);
        Task AddTypes(IEnumerable<TypeData> types);
        Task AddSuperTypes(IEnumerable<SuperTypeData> superTypes);
        Task AddSubTypes(IEnumerable<SubTypeData> subTypes);
        Task AddKeywords(IEnumerable<KeywordData> keywords);
    }
}
