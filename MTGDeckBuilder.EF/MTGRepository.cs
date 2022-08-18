using EFCore.BulkExtensions;
using MTGDeckBuilder.EF.Entities;
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

        public async Task AddCards(IEnumerable<CardData> cards)
        {
            await _ctx.AddRangeAsync(cards);
            await _ctx.SaveChangesAsync();
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
                await _ctx.BulkInsertAsync(fileData.ColorsIdentity.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.Types.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.SuperTypes.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.SubTypes.ToList(), new BulkConfig { SetOutputIdentity = true });
                await _ctx.BulkInsertAsync(fileData.Keywords.ToList(), new BulkConfig { SetOutputIdentity = true });
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
    }
}
