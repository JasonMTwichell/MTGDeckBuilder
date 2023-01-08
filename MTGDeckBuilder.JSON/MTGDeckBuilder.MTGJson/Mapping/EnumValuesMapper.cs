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
                MetaData = deserializedJson.MetaData != null ? new ParsedEnumValuesMeta
                {
                    Date = deserializedJson.MetaData.Date,
                    Version = deserializedJson.MetaData.Version
                } : null,
                CardEnumValues = deserializedJson.CardEnumValues != null ? new ParsedEnumValuesCard
                {
                    Availabilities = deserializedJson.CardEnumValues.Availabilities,
                    BoosterTypes = deserializedJson.CardEnumValues.BoosterTypes,
                    BorderColors = deserializedJson.CardEnumValues.BorderColors,
                    ColorIdentities = deserializedJson.CardEnumValues.ColorIdentities,
                    ColorIndicators = deserializedJson.CardEnumValues.ColorIndicators,
                    Colors = deserializedJson.CardEnumValues.Colors,
                    DuelDecks = deserializedJson.CardEnumValues.DuelDecks,
                    Finishes = deserializedJson.CardEnumValues.Finishes,
                    FrameEffects = deserializedJson.CardEnumValues.FrameEffects,
                    FrameVersions = deserializedJson.CardEnumValues.FrameVersions,
                    Languages = deserializedJson.CardEnumValues.Languages,
                    Layouts = deserializedJson.CardEnumValues.Layouts,
                    PromoTypes = deserializedJson.CardEnumValues.PromoTypes,
                    Rarities = deserializedJson.CardEnumValues.Rarities,
                    SecurityStamps = deserializedJson.CardEnumValues.SecurityStamps,
                    Sides = deserializedJson.CardEnumValues.Sides,
                    Subtypes = deserializedJson.CardEnumValues.Subtypes,
                    Supertypes = deserializedJson.CardEnumValues.Supertypes,
                    Types = deserializedJson.CardEnumValues.Types,
                    Watermarks = deserializedJson.CardEnumValues.Watermarks
                } : null,
                DeckEnumValues = deserializedJson.DeckEnumValues != null ? new ParsedEnumValuesDeck
                {
                    Types = deserializedJson.DeckEnumValues.Types
                } : null,
                ForeignDataEnumValues = deserializedJson.ForeignDataEnumValues != null ? new ParsedEnumValuesForeignData
                {
                    Languages = deserializedJson.ForeignDataEnumValues.Languages
                } : null,
                KeywordEnumValues = deserializedJson.KeywordEnumValues != null ? new ParsedEnumValuesKeywords
                {
                    AbilityWords = deserializedJson.KeywordEnumValues.AbilityWords,
                    KeywordAbilities = deserializedJson.KeywordEnumValues.KeywordAbilities,
                    KeywordActions = deserializedJson.KeywordEnumValues.KeywordActions
                } : null,
                SetEnumValues = deserializedJson.SetEnumValues != null ? new ParsedEnumValuesSetValues
                {
                    Types = deserializedJson.SetEnumValues.Types
                } : null,
                TcgPlayerSkuValues = deserializedJson.TcgPlayerSkuValues != null ? new ParsedEnumValuesTcgPlayerSkus
                {
                    Conditions = deserializedJson.TcgPlayerSkuValues.Conditions,
                    Finishes = deserializedJson.TcgPlayerSkuValues.Finishes,
                    Languages = deserializedJson.TcgPlayerSkuValues.Languages,
                    Printings = deserializedJson.TcgPlayerSkuValues.Printings
                } : null
            };
        }
    }
}
