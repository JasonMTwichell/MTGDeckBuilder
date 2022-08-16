using MTGDeckBuilder.Core.Domain;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.EF;
using MTGDeckBuilder.Services;
using MTGDeckBuilder.Services.JSONParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IHost host = Host.CreateDefaultBuilder(args).Build()

namespace MTGDeckBuilder
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IMTGParser parser = new MTGJsonParser(new ConsoleLoggingService());
            IEnumerable<Card> cards = await parser.ParseMTGFile(@"C:\Users\jason\Downloads\MTG JSON\AtomicCards\AtomicCards.json");
            Console.WriteLine(cards.Count());

            // get all reference data
            ColorData[] distinctColors = cards.SelectMany(c => c.Colors).Distinct().Select(c => new ColorData()
            {
                ColorName = c
            }).ToArray();

            TypeData[] distinctTypes = cards.SelectMany(c => c.Types).Distinct().Select(t => new TypeData()
            {
                TypeName = t
            }).ToArray();

            SuperTypeData[] distinctSuperTypes = cards.SelectMany(c => c.SuperTypes).Distinct().Select(t => new SuperTypeData()
            {
                SuperTypeName = t
            }).ToArray();

            SubTypeData[] distinctSubTypes = cards.SelectMany(c => c.Types).Distinct().Select(t => new SubTypeData()
            {
                SubTypeName = t
            }).ToArray();

            KeywordData[] distinctKeywords= cards.SelectMany(c => c.Keywords).Distinct().Select(k => new KeywordData()
            {
                Keyword = k
            }).ToArray();

            CardData[] cardData = cards.Select(c => new CardData()
            {
                Name = c.Name,
                AsciiName = c.AsciiName,
                Text = c.Text,
                Type = c.Type,
                Layout = c.Layout,
                Side = c.Side,
                ManaCost = c.ManaCost,
                ManaValue = c.ManaValue,
                Loyalty = c.Loyalty,
                HandModifier = c.HandModifier,
                LifeModifier = c.LifeModifier,
                Power = c.Power,
                Toughness = c.Toughness,
                IsFunny = c.IsFunny,
                IsReserved = c.IsReserved,
                HasAlternateDeckLimit = c.HasAlternateDeckLimit,                
            }).ToArray();

            using(MTGDeckBuilderContext ctx = new MTGDeckBuilderContext())
            {
                IMTGDeckBuilderRepository repo = new MTGDeckBuilderRepository(ctx);
                
                await repo.AddColors(distinctColors);
                await repo.AddTypes(distinctTypes); 
                await repo.AddSuperTypes(distinctSuperTypes);
                await repo.AddSubTypes(distinctSubTypes);
                await repo.AddKeywords(distinctKeywords);
            }            
        }
    }
}
