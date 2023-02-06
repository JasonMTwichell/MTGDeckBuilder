using MTGDeckBuilder.MTGJson.AllPrintings;
using MTGDeckBuilder.MTGJson.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson.Mapping
{
    internal static class AllPrintingsMapper
    {
        public static ParsedAllPrintingsSet MapToParsedAllPrintingsSet(MTGJsonAllPrintingsSet deserializedSet)
        {
            return new ParsedAllPrintingsSet
            {
                BaseSetSize = deserializedSet.BaseSetSize,
                Block = deserializedSet.Block,
                Cards = deserializedSet.Cards?.Select(deserializedSetCard => new ParsedAllPrintingsSetCard
                {
                    Artist = deserializedSetCard.Artist,
                    Availability = deserializedSetCard.Availability,
                    BoosterTypes = deserializedSetCard.BoosterTypes,
                    BorderColor = deserializedSetCard.BorderColor,
                    ColorIdentity = deserializedSetCard.ColorIdentity,
                    Colors = deserializedSetCard.Colors,
                    ConvertedManaCost = deserializedSetCard.ConvertedManaCost,
                    EdhrecRank = deserializedSetCard.EdhrecRank,
                    Finishes = deserializedSetCard.Finishes,
                    ForeignData = deserializedSetCard.ForeignData?.Select(deserializedSetCardForeignDatum => new ParsedAllPrintingsForeignData
                    {
                        Language = deserializedSetCardForeignDatum.Language,
                        Name = deserializedSetCardForeignDatum.Name,
                        Type = deserializedSetCardForeignDatum.Type,
                        MultiverseID = deserializedSetCardForeignDatum.MultiverseId,
                        Text = deserializedSetCardForeignDatum.Text
                    }).ToArray(),
                    FrameVersion = deserializedSetCard.FrameVersion,
                    HasFoil = deserializedSetCard.HasFoil,
                    HasNonFoil = deserializedSetCard.HasNonFoil,
                    Identifiers = deserializedSetCard.Identifiers != null ? new ParsedAllPrintingsIdentifiers
                    {
                        CardKingdomId = deserializedSetCard.Identifiers.CardKingdomId,
                        CardsphereId = deserializedSetCard.Identifiers.CardsphereId,
                        McmId = deserializedSetCard.Identifiers.McmId,
                        MtgjsonV4Id = deserializedSetCard.Identifiers.MtgjsonV4Id,
                        MultiverseId = deserializedSetCard.Identifiers.MultiverseId,
                        ScryfallId = deserializedSetCard.Identifiers.ScryfallId,
                        ScryfallIllustrationId = deserializedSetCard.Identifiers.ScryfallIllustrationId,
                        ScryfallOracleId = deserializedSetCard.Identifiers.ScryfallOracleId,
                        TcgplayerProductId = deserializedSetCard.Identifiers.TcgplayerProductId
                    } : null,
                    IsReprint = deserializedSetCard.IsReprint,
                    Keywords = deserializedSetCard.Keywords,
                    Language = deserializedSetCard.Language,
                    Layout = deserializedSetCard.Layout,
                    Legalities = deserializedSetCard.Legalities != null ? new ParsedAllPrintingsLegalities
                    {
                        Commander = deserializedSetCard.Legalities.Commander,
                        Duel = deserializedSetCard.Legalities.Duel,
                        Legacy = deserializedSetCard.Legalities.Legacy,
                        Oldschool = deserializedSetCard.Legalities.Oldschool,
                        Penny = deserializedSetCard.Legalities.Penny,
                        Premodern = deserializedSetCard.Legalities.Premodern,
                        Vintage = deserializedSetCard.Legalities.Vintage
                    } : null,
                    ManaCost = deserializedSetCard.ManaCost,
                    ManaValue = deserializedSetCard.ManaValue,
                    Name = deserializedSetCard.Name,
                    Number = deserializedSetCard.Number,
                    OriginalText = deserializedSetCard.OriginalText,
                    OriginalType = deserializedSetCard.OriginalType,
                    Printings = deserializedSetCard.Printings,
                    PurchaseUrls = deserializedSetCard.PurchaseUrls != null ? new ParsedAllPrintingsPurchaseUrls
                    {
                        CardKingdom = deserializedSetCard.PurchaseUrls.CardKingdom,
                        Tcgplayer = deserializedSetCard.PurchaseUrls.Tcgplayer
                    } : null,
                    Rarity = deserializedSetCard.Rarity,
                    Rulings = deserializedSetCard.Rulings != null ? new ParsedAllPrintingsRuling() : null,
                    SetCode = deserializedSetCard.SetCode,
                    Subtypes = deserializedSetCard.Subtypes,
                    Supertypes = deserializedSetCard.Supertypes,
                    Text = deserializedSetCard.Text,
                    Type = deserializedSetCard.Type,
                    Types = deserializedSetCard.Types,
                    UUID = deserializedSetCard.UUID
                }).ToArray(),
                CardsphereSetId = deserializedSet.CardsphereSetId,
                Code = deserializedSet.Code,
                IsFoilOnly = deserializedSet.IsFoilOnly,
                IsNonFoilOnly = deserializedSet.IsNonFoilOnly,
                IsOnlineOnly = deserializedSet.IsOnlineOnly,
                KeyruneCode = deserializedSet.KeyruneCode,
                Languages = deserializedSet.Languages,
                Name = deserializedSet.Name,
                ReleaseDate = deserializedSet.ReleaseDate,
                TcgplayerGroupId = deserializedSet.TcgplayerGroupId,
                TotalSetSize = deserializedSet.TotalSetSize,
                Type = deserializedSet.Type
            };
        }
    }
}
