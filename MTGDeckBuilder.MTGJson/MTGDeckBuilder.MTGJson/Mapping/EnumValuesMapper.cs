using MTGDeckBuilder.MTGJson.DTO;
using MTGDeckBuilder.MTGJson.EnumValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGDeckBuilder.MTGJson.Mapping
{
    internal static class EnumValuesMapper
    {
        public static ParsedEnumValues MapToParsedEnumValues(MTGJsonEnumValues deserializedJson)
        {
            return new ParsedEnumValues
            {
                Meta = deserializedJson.Meta != null ? new ParsedEnumValuesMeta
                {
                    Date = deserializedJson.Meta.Date,
                    Version = deserializedJson.Meta.Version
                } : null,
                Data = deserializedJson.Data != null ? new ParsedEnumValuesData
                {
                    CardEnumValues = deserializedJson.Data.CardEnumValues != null ? new ParsedEnumValuesCard
                    {
                        Availabilities = deserializedJson.Data.CardEnumValues.Availabilities,
                        BoosterTypes = deserializedJson.Data.CardEnumValues.BoosterTypes,
                        BorderColors = deserializedJson.Data.CardEnumValues.BorderColors,
                        ColorIdentities = deserializedJson.Data.CardEnumValues.ColorIdentities,
                        ColorIndicators = deserializedJson.Data.CardEnumValues.ColorIndicators,
                        Colors = deserializedJson.Data.CardEnumValues.Colors,
                        DuelDecks = deserializedJson.Data.CardEnumValues.DuelDecks,
                        Finishes = deserializedJson.Data.CardEnumValues.Finishes,
                        FrameEffects = deserializedJson.Data.CardEnumValues.FrameEffects,
                        FrameVersions = deserializedJson.Data.CardEnumValues.FrameVersions,
                        Languages = deserializedJson.Data.CardEnumValues.Languages,
                        Layouts = deserializedJson.Data.CardEnumValues.Layouts,
                        PromoTypes = deserializedJson.Data.CardEnumValues.PromoTypes,
                        Rarities = deserializedJson.Data.CardEnumValues.Rarities,
                        SecurityStamps = deserializedJson.Data.CardEnumValues.SecurityStamps,
                        Sides = deserializedJson.Data.CardEnumValues.Sides,
                        Subtypes = deserializedJson.Data.CardEnumValues.Subtypes,
                        Supertypes = deserializedJson.Data.CardEnumValues.Supertypes,
                        Types = deserializedJson.Data.CardEnumValues.Types,
                        Watermarks = deserializedJson.Data.CardEnumValues.Watermarks
                    } : null,
                    DeckEnumValues = deserializedJson.Data.DeckEnumValues != null ? new ParsedEnumValuesDeck
                    {
                        Types = deserializedJson.Data.DeckEnumValues.Types
                    } : null,
                    ForeignDataEnumValues = deserializedJson.Data.ForeignDataEnumValues != null ? new ParsedEnumValuesForeignData
                    {
                        Languages = deserializedJson.Data.ForeignDataEnumValues.Languages
                    } : null,
                    KeywordEnumValues = deserializedJson.Data.KeywordEnumValues != null ? new ParsedEnumValuesKeywords
                    {
                        AbilityWords = deserializedJson.Data.KeywordEnumValues.AbilityWords,
                        KeywordAbilities = deserializedJson.Data.KeywordEnumValues.KeywordAbilities,
                        KeywordActions = deserializedJson.Data.KeywordEnumValues.KeywordActions
                    } : null,
                    SetEnumValues = deserializedJson.Data.SetEnumValues != null ? new ParsedEnumValuesSetValues
                    {
                        Types = deserializedJson.Data.SetEnumValues.Types
                    } : null,
                    TcgPlayerSkuValues = deserializedJson.Data.TcgPlayerSkuValues != null ? new ParsedEnumValuesTcgPlayerSkus
                    {
                        Conditions = deserializedJson.Data.TcgPlayerSkuValues.Conditions,
                        Finishes = deserializedJson.Data.TcgPlayerSkuValues.Finishes,
                        Languages = deserializedJson.Data.TcgPlayerSkuValues.Languages,
                        Printings = deserializedJson.Data.TcgPlayerSkuValues.Printings
                    } : null
                } : null
            };
        }
    }
}
