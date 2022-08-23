using EFCore.BulkExtensions;
using MTGDeckBuilder.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.EF
{
    public class MTGDeckBuilderRepository : IMTGDeckBuilderRepository
    {
        private MTGDeckBuilderContext _ctx;
        public MTGDeckBuilderRepository(MTGDeckBuilderContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<SetData> GetSets()
        {
            return _ctx.Sets.ToArray();
        }

        public IEnumerable<CardData> GetCards()
        {
            return _ctx.Cards.ToArray();
        }

        public IEnumerable<ColorData> GetColors()
        {
            return _ctx.Colors.ToArray();
        }

        public IEnumerable<ColorIdentityData> GetColorIdentities()
        {
            return _ctx.ColorIdentities.ToArray();
        }

        public IEnumerable<KeywordData> GetKeywords()
        {
            return _ctx.Keywords.ToArray();
        }

        public IEnumerable<SubTypeData> GetSubTypes()
        {
            return _ctx.SubTypes.ToArray();
        }

        public IEnumerable<SuperTypeData> GetSuperTypes()
        {
            return _ctx.SuperTypes.ToArray();
        }

        public IEnumerable<TypeData> GetTypes() 
        {
            return _ctx.Types.ToArray();
        }

        public IEnumerable<LegalityData> GetLegalities()
        {
            return _ctx.Legality.ToArray();
        }

        public async Task BootstrapDB(BootstrapDBData fileData)
        {
            // while I dont love using strings for primary keys, it provides one huge benefit
            // in allowing us to just blow the db away and rewrite it en masse
            // rather than trying to synchronize updates, inserts and deletes
            // is it correct? no. Is it plenty fast and plenty easy? by my standards.
            await _ctx.TruncateAsync<ColorData>();
            await _ctx.TruncateAsync<ColorIdentityData>();
            await _ctx.TruncateAsync<TypeData>();
            await _ctx.TruncateAsync<SuperTypeData>();
            await _ctx.TruncateAsync<SubTypeData>();
            await _ctx.TruncateAsync<KeywordData>();
            await _ctx.TruncateAsync<LegalityData>();
            await _ctx.TruncateAsync<SetData>();
            await _ctx.TruncateAsync<CardData>();

            await _ctx.BulkInsertAsync(fileData.Colors.ToList());
            await _ctx.BulkInsertAsync(fileData.ColorIdentities.ToList());
            await _ctx.BulkInsertAsync(fileData.Types.ToList());
            await _ctx.BulkInsertAsync(fileData.SuperTypes.ToList());
            await _ctx.BulkInsertAsync(fileData.SubTypes.ToList());
            await _ctx.BulkInsertAsync(fileData.Keywords.ToList());
            await _ctx.BulkInsertAsync(fileData.Legalities.ToList());
            await _ctx.BulkInsertAsync(fileData.Sets.ToList());
            await _ctx.BulkInsertAsync(fileData.Cards.ToList());

            await _ctx.BulkSaveChangesAsync();
        }
    }
}
