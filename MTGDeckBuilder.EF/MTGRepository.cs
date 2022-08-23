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

        public IEnumerable<FormatData> GetFormats()
        {
            return _ctx.Formats.ToArray();
        }

        public async Task BootstrapDB(BootstrapDBData fileData)
        {
            List<CardColorData> cardColors = new List<CardColorData>();
            List<CardColorIdentityData> cardColorIdentities = new List<CardColorIdentityData>();
            List<CardTypeData> cardTypes = new List<CardTypeData>();
            List<CardSuperTypeData> cardSuperTypes = new List<CardSuperTypeData>();
            List<CardSubTypeData> cardSubTypes = new List<CardSubTypeData>();
            List<CardKeywordData> cardKeywords = new List<CardKeywordData>();
            

            using (var transaction = _ctx.Database.BeginTransaction())
            {
                await _ctx.BulkInsertAsync(fileData.Colors.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.ColorIdentities.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.Types.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.SuperTypes.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.SubTypes.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.Keywords.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.Sets.ToList(), new BulkConfig { SetOutputIdentity = true });

                foreach (CardData cd in fileData.Cards) cd.fkSet = cd.Set.pkSet;
                
                await _ctx.BulkInsertAsync(fileData.Cards.ToList(), new BulkConfig { SetOutputIdentity = true });

                foreach (var card in fileData.Cards)
                {
                    card.fkSet = card.Set.pkSet;

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
                }

                _ctx.BulkInsert(cardColors);
                _ctx.BulkInsert(cardColorIdentities);
                _ctx.BulkInsert(cardTypes);
                _ctx.BulkInsert(cardSuperTypes);
                _ctx.BulkInsert(cardSubTypes);
                _ctx.BulkInsert(cardKeywords);
                transaction.Commit();
            }

            await _ctx.BulkSaveChangesAsync();
        }

        //public async Task BootstrapDB(BootstrapDBData fileData)
        //{
        //    // while I dont love using strings for primary keys, it provides one huge benefit
        //    // in allowing us to just blow the db away and rewrite it en masse
        //    // rather than trying to synchronize updates, inserts and deletes
        //    // is it correct? no. Is it plenty fast and plenty easy? by my standards.
        //    await _ctx.TruncateAsync<ColorData>();
        //    await _ctx.TruncateAsync<ColorIdentityData>();
        //    await _ctx.TruncateAsync<TypeData>();
        //    await _ctx.TruncateAsync<SuperTypeData>();
        //    await _ctx.TruncateAsync<SubTypeData>();
        //    await _ctx.TruncateAsync<KeywordData>();
        //    await _ctx.TruncateAsync<FormatData>();
        //    await _ctx.TruncateAsync<SetData>();
        //    await _ctx.TruncateAsync<CardData>();

        //    await _ctx.BulkInsertAsync(fileData.Colors.ToList());
        //    await _ctx.BulkInsertAsync(fileData.ColorIdentities.ToList());
        //    await _ctx.BulkInsertAsync(fileData.Types.ToList());
        //    await _ctx.BulkInsertAsync(fileData.SuperTypes.ToList());
        //    await _ctx.BulkInsertAsync(fileData.SubTypes.ToList());
        //    await _ctx.BulkInsertAsync(fileData.Keywords.ToList());
        //    await _ctx.BulkInsertAsync(fileData.Formats.ToList());
        //    await _ctx.BulkInsertAsync(fileData.Sets.ToList());
        //    await _ctx.BulkInsertAsync(fileData.Cards.ToList());

        //    await _ctx.BulkSaveChangesAsync();
        //}
    }
}
