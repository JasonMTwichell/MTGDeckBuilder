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
                    AsciiName = deserializedSetCard.AsciiName,
                    Availability = deserializedSetCard.Availability,
                    BoosterTypes = deserializedSetCard.BoosterTypes,
                    BorderColor = deserializedSetCard.BorderColor,
                    CardParts = deserializedSetCard.CardParts,
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
                        CardKingdomEtchedId = deserializedSetCard.Identifiers.CardKingdomEtchedId,
                        CardKingdomFoilId = deserializedSetCard.Identifiers.CardKingdomFoilId,
                        CardKingdomId = deserializedSetCard.Identifiers.CardKingdomId,
                        CardsphereId = deserializedSetCard.Identifiers.CardsphereId,
                        McmId = deserializedSetCard.Identifiers.McmId,
                        McmMetaId = deserializedSetCard.Identifiers.McmMetaId,
                        MtgArenaId = deserializedSetCard.Identifiers.MtgArenaId,
                        MtgoFoilId = deserializedSetCard.Identifiers.MtgoFoilId,
                        MtgoId = deserializedSetCard.Identifiers.MtgoId,
                        MtgjsonV4Id = deserializedSetCard.Identifiers.MtgjsonV4Id,
                        MultiverseId = deserializedSetCard.Identifiers.MultiverseId,
                        ScryfallId = deserializedSetCard.Identifiers.ScryfallId,
                        ScryfallOracleId = deserializedSetCard.Identifiers.ScryfallOracleId,
                        ScryfallIllustrationId = deserializedSetCard.Identifiers.ScryfallIllustrationId,
                        TcgplayerProductId = deserializedSetCard.Identifiers.TcgplayerProductId,
                        TcgPlayerEtchedProductId = deserializedSetCard.Identifiers.TcgplayerEtchedProductId
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
                        Vintage = deserializedSetCard.Legalities.Vintage,
                        Pauper = deserializedSetCard.Legalities.Pauper,
                        Paupercommander = deserializedSetCard.Legalities.Paupercommander,
                        Modern = deserializedSetCard.Legalities.Modern,
                        Pioneer = deserializedSetCard.Legalities.Pioneer,
                        Alchemy = deserializedSetCard.Legalities.Alchemy,
                        Brawl = deserializedSetCard.Legalities.Brawl,
                        Explorer = deserializedSetCard.Legalities.Explorer,
                        Future = deserializedSetCard.Legalities.Future,
                        Gladiator = deserializedSetCard.Legalities.Gladiator,
                        Historic = deserializedSetCard.Legalities.Historic,
                        Historicbrawl = deserializedSetCard.Legalities.Historicbrawl,
                        Standard = deserializedSetCard.Legalities.Standard
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
                        CardKingdomEtched = deserializedSetCard.PurchaseUrls.CardKingdomEtched,
                        CardKingdomFoil = deserializedSetCard.PurchaseUrls.CardKingdomFoil,
                        CardMarket = deserializedSetCard.PurchaseUrls.CardMarket,
                        Tcgplayer = deserializedSetCard.PurchaseUrls.Tcgplayer,
                        TcgplayerEtched = deserializedSetCard.PurchaseUrls.TcgplayerEtched
                    } : null,
                    Rarity = deserializedSetCard.Rarity,
                    Rulings = deserializedSetCard.Rulings?.Select(deserializedSetCardRuling => new ParsedAllPrintingsRuling
                    {
                        Date = deserializedSetCardRuling.Date,
                        Text = deserializedSetCardRuling.Text
                    }).ToArray(),
                    SetCode = deserializedSetCard.SetCode,
                    Subtypes = deserializedSetCard.Subtypes,
                    Supertypes = deserializedSetCard.Supertypes,
                    Text = deserializedSetCard.Text,
                    Type = deserializedSetCard.Type,
                    Types = deserializedSetCard.Types,
                    UUID = deserializedSetCard.UUID,
                    FlavorText = deserializedSetCard.FlavorText,
                    Power = deserializedSetCard.Power,
                    Toughness = deserializedSetCard.Toughness,
                    IsReserved = deserializedSetCard.IsReserved,
                    HasContentWarning = deserializedSetCard.HasContentWarning,
                    ColorIndicator = deserializedSetCard.ColorIndicator,
                    FaceConvertedManaCost = deserializedSetCard.FaceConvertedManaCost,
                    FaceFlavorName = deserializedSetCard.FaceFlavorName,
                    FaceManaValue = deserializedSetCard.FaceManaValue,
                    FaceName = deserializedSetCard.FaceName,
                    FlavorName = deserializedSetCard.FlavorName,
                    FrameEffects = deserializedSetCard.FrameEffects,
                    HandSizeModifier = deserializedSetCard.HandSizeModifier,
                    HasAlternativeDeckLimit = deserializedSetCard.HasAlternativeDeckLimit,
                    IsAlternativePrinting = deserializedSetCard.IsAlternativePrinting,
                    IsFullArt = deserializedSetCard.IsFullArt,
                    IsFunny = deserializedSetCard.IsFunny,
                    IsOnlineOnly = deserializedSetCard.IsOnlineOnly,
                    IsOversized = deserializedSetCard.IsOversized,
                    IsPromotionalPrinting = deserializedSetCard.IsPromotionalPrinting,
                    IsRebalancedForAlchemy = deserializedSetCard.IsRebalancedForAlchemy,
                    IsInStarterDeck = deserializedSetCard.IsInStarterDeck,
                    IsStorySpotlight = deserializedSetCard.IsStorySpotlight,
                    IsTextless = deserializedSetCard.IsTextless,
                    IsTimeshifted = deserializedSetCard.IsTimeshifted,
                    LeadershipSkills = deserializedSetCard.LeadershipSkills != null ? new ParsedAllPrintingsSetCardLeadershipSkills
                    {
                        IsBrawlLegal = deserializedSetCard.LeadershipSkills.IsBrawlLegal,
                        IsCommanderLegal = deserializedSetCard.LeadershipSkills.IsCommanderLegal,
                        IsOathbreakerLegal = deserializedSetCard.LeadershipSkills.IsOathbreakerLegal
                    } : null,
                    LifeTotalModifier = deserializedSetCard.LifeTotalModifier,
                    Loyalty = deserializedSetCard.Loyalty,
                    OriginalPrintingUUIDs = deserializedSetCard.OriginalPrintingUUIDs,
                    OriginalReleaseDate = deserializedSetCard.OriginalReleaseDate,
                    OtherFaceUUIDs = deserializedSetCard.OtherFaceUUIDs,
                    PromoTypes = deserializedSetCard.PromoTypes,
                    RebalancedPrintingUUIDs = deserializedSetCard.RebalancedPrintingUUIDs,
                    SecurityStamp = deserializedSetCard.SecurityStamp,
                    Side = deserializedSetCard.Side,
                    Signature = deserializedSetCard.Signature,
                    Variations = deserializedSetCard.Variations,
                    Watermark = deserializedSetCard.Watermark
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
