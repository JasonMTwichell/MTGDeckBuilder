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
            ColorData[] existingColors = GetColors().ToArray();
            ColorIdentityData[] existingColorIdentities = GetColorIdentities().ToArray();
            TypeData[] existingTypes = GetTypes().ToArray();
            SuperTypeData[] existingSuperTypes = GetSuperTypes().ToArray();
            SubTypeData[] existingSubTypes = GetSubTypes().ToArray();
            KeywordData[] existingKeywords = GetKeywords().ToArray();
            LegalityData[] existingLegalities = GetLegalities().ToArray();
            CardData[] existingCards = GetCards().ToArray();

            // inserts
            BootstrapDBData inserts = fileData with
            {
                Colors = fileData.Colors.GroupJoin(existingColors, o => o.ColorName, i => i.ColorName, (o, i) => new { Incoming = o, Existing = i }).SelectMany(oi => oi.Existing.DefaultIfEmpty(), (o, i) => new { Incoming = o.Incoming, Existing = i }).Where(group => group.Existing == null).Select(group => group.Incoming).ToArray(),
                ColorIdentities = fileData.ColorIdentities.GroupJoin(existingColorIdentities, o => o.ColorIdentityName, i => i.ColorIdentityName, (o, i) => new { Incoming = o, Existing = i }).SelectMany(oi => oi.Existing.DefaultIfEmpty(), (o, i) => new { Incoming = o.Incoming, Existing = i }).Where(group => group.Existing == null).Select(group => group.Incoming).ToArray(),
                Types = fileData.Types.GroupJoin(existingTypes, o => o.TypeName, i => i.TypeName, (o, i) => new { Incoming = o, Existing = i }).SelectMany(oi => oi.Existing.DefaultIfEmpty(), (o, i) => new { Incoming = o.Incoming, Existing = i }).Where(group => group.Existing == null).Select(group => group.Incoming).ToArray(),
                SuperTypes = fileData.SuperTypes.GroupJoin(existingSuperTypes, o => o.SuperTypeName, i => i.SuperTypeName, (o, i) => new { Incoming = o, Existing = i }).SelectMany(oi => oi.Existing.DefaultIfEmpty(), (o, i) => new { Incoming = o.Incoming, Existing = i }).Where(group => group.Existing == null).Select(group => group.Incoming).ToArray(),
                SubTypes = fileData.SubTypes.GroupJoin(existingSubTypes, o => o.SubTypeName, i => i.SubTypeName, (o, i) => new { Incoming = o, Existing = i }).SelectMany(oi => oi.Existing.DefaultIfEmpty(), (o, i) => new { Incoming = o.Incoming, Existing = i }).Where(group => group.Existing == null).Select(group => group.Incoming).ToArray(),
                Keywords = fileData.Keywords.GroupJoin(existingKeywords, o => o.Keyword, i => i.Keyword, (o, i) => new { Incoming = o, Existing = i }).SelectMany(oi => oi.Existing.DefaultIfEmpty(), (o, i) => new { Incoming = o.Incoming, Existing = i }).Where(group => group.Existing == null).Select(group => group.Incoming).ToArray(),
                Legalities = fileData.Legalities.GroupJoin(existingLegalities, o => o.Format, i => i.Format, (o, i) => new { Incoming = o, Existing = i }).SelectMany(oi => oi.Existing.DefaultIfEmpty(), (o, i) => new { Incoming = o.Incoming, Existing = i }).Where(group => group.Existing == null).Select(group => group.Incoming).ToArray(),
                Cards = fileData.Cards.GroupJoin(existingCards, o => o.Name, i => i.Name, (o, i) => new { Incoming = o, Existing = i }).SelectMany(oi => oi.Existing.DefaultIfEmpty(), (o, i) => new { Incoming = o.Incoming, Existing = i }).Where(group => group.Existing == null).Select(group => group.Incoming).ToArray(),                
            };

            await PerformBootstrapInserts(inserts);


            // update card legalities as theyre the only thing that should reasonably change, unless old data is sured up
            // join to existing cards to see whats eligible for update
            // get the legalities from the incoming joined cards
            // update the existing legalities to match incoming legalities

            
        }

        private async Task PerformBootstrapInserts(BootstrapDBData fileData)
        {
            List<CardColorData> cardColors = new List<CardColorData>();
            List<CardColorIdentityData> cardColorIdentities = new List<CardColorIdentityData>();
            List<CardTypeData> cardTypes = new List<CardTypeData>();
            List<CardSuperTypeData> cardSuperTypes = new List<CardSuperTypeData>();
            List<CardSubTypeData> cardSubTypes = new List<CardSubTypeData>();
            List<CardKeywordData> cardKeywords = new List<CardKeywordData>();
            List<CardLegalityData> cardLegalities = new List<CardLegalityData>();

            using (var transaction = _ctx.Database.BeginTransaction())
            {
                await _ctx.AddAsync(new FileVersionData()
                {
                    Version = fileData.VersionNumber,
                    VersionDate = fileData.VersionDate
                });

                await _ctx.BulkInsertAsync(fileData.Colors.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.ColorIdentities.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.Types.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.SuperTypes.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.SubTypes.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.Keywords.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.Legalities.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.Cards.ToList(), new BulkConfig { SetOutputIdentity = true });
                foreach (var card in fileData.Cards)
                {
                    foreach (var color in card.CardColors)
                    {
                        color.fkCard = card.pkCard;
                        color.fkColor = color.Color.pkColor;
                    }
                    cardColors.AddRange(card.CardColors);

                    foreach (var colorIdentity in card.CardColorIdentities)
                    {
                        colorIdentity.fkCard = card.pkCard;
                        colorIdentity.fkColorIdentity = colorIdentity.ColorIdentity.pkColorIdentity;
                    }
                    cardColorIdentities.AddRange(card.CardColorIdentities);

                    foreach (var type in card.CardTypes)
                    {
                        type.fkCard = card.pkCard;
                        type.fkType = type.Type.pkType;
                    }
                    cardTypes.AddRange(card.CardTypes);

                    foreach (var superType in card.CardSuperTypes)
                    {
                        superType.fkCard = card.pkCard;
                        superType.fkSuperType = superType.SuperType.pkSuperType;
                    }
                    cardSuperTypes.AddRange(card.CardSuperTypes);

                    foreach (var subType in card.CardSubTypes)
                    {
                        subType.fkCard = card.pkCard;
                        subType.fkSubType = subType.SubType.pkSubType;
                    }
                    cardSubTypes.AddRange(card.CardSubTypes);

                    foreach (var keyword in card.CardKeywords)
                    {
                        keyword.fkCard = card.pkCard;
                        keyword.fkKeyword = keyword.Keyword.pkKeyword;
                    }
                    cardKeywords.AddRange(card.CardKeywords);

                    foreach (var legality in card.CardLegalities)
                    {
                        legality.fkCard = card.pkCard;
                        legality.fkLegality = legality.Legality.pkLegality;
                    }
                    cardLegalities.AddRange(card.CardLegalities);
                }

                await _ctx.BulkInsertAsync(cardColors);
                await _ctx.BulkInsertAsync(cardColorIdentities);
                await _ctx.BulkInsertAsync(cardTypes);
                await _ctx.BulkInsertAsync(cardSuperTypes);
                await _ctx.BulkInsertAsync(cardSubTypes);
                await _ctx.BulkInsertAsync(cardKeywords);
                await _ctx.BulkInsertAsync(cardLegalities);
                transaction.Commit();
            }

            await _ctx.BulkSaveChangesAsync();
        }
    }
}
