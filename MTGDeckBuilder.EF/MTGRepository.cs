using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF
{
    public class MTGDeckBuilderRepository: IMTGDeckBuilderRepository
    {
        private MTGDeckBuilderContext _ctx;
        public MTGDeckBuilderRepository(MTGDeckBuilderContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddColors(IEnumerable<ColorData> colors)
        {
            await _ctx.Colors.AddRangeAsync(colors);
            await _ctx.SaveChangesAsync();
        }

        public async Task AddKeywords(IEnumerable<KeywordData> keywords)
        {
            await _ctx.Keywords.AddRangeAsync(keywords);
            await _ctx.SaveChangesAsync();
        }

        public async Task AddSubTypes(IEnumerable<SubTypeData> subTypes)
        {
            await _ctx.SubTypes.AddRangeAsync(subTypes);
            await _ctx.SaveChangesAsync();
        }

        public async Task AddSuperTypes(IEnumerable<SuperTypeData> superTypes)
        {
            await _ctx.SuperTypes.AddRangeAsync(superTypes);
            await _ctx.SaveChangesAsync();
        }

        public async Task AddTypes(IEnumerable<TypeData> types)
        {
            await _ctx.Types.AddRangeAsync(types);
            await _ctx.SaveChangesAsync();
        }
    }
}
