namespace MTGDeckBuilder.EF.Entities
{
    public class SetCardData
    {
        public int? pkSetCard { get; set; }
        public int? fkSet { get; set; }
        public string? Artist { get; set; }
        public string? BorderColor { get; set; }
        public double? ConvertedManaCost { get; set; }
        public int? EdhrecRank { get; set; }
        public string? FrameVersion { get; set; }
        public bool? HasFoil { get; set; }
        public bool? HasNonFoil { get; set; }
        public bool? IsReprint { get; set; }
        public string? Language { get; set; }
        public string? Layout { get; set; }
        public string? ManaCost { get; set; }
        public double? ManaValue { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? OriginalText { get; set; }
        public string? OriginalType { get; set; }
        public string? Rarity { get; set; }
        public string? SetCode { get; set; }
        public string? Text { get; set; }
        public string? Type { get; set; }
        public string? UUID { get; set; }
        public string? CardKingdomId { get; set; }
        public string? CardsphereId { get; set; }
        public string? McmId { get; set; }
        public string? MtgjsonV4Id { get; set; }
        public string? MultiverseId { get; set; }
        public string? ScryfallId { get; set; }
        public string? ScryfallIllustrationId { get; set; }
        public string? ScryfallOracleId { get; set; }
        public string? TcgplayerProductId { get; set; }
        public bool? IsCommanderFormatLegal { get; set; }
        public bool? IsDuelFormatLegal { get; set; }
        public bool? IsLegacyFormatLegal { get; set; }
        public bool? IsOldschoolFormatLegal { get; set; }
        public bool? IsPennyFormatLegal { get; set; }
        public bool? IsPremodernFormatLegal { get; set; }
        public bool? IsVintageFormatLegal { get; set; }
        public virtual SetData Set { get; set; }

        public virtual ICollection<CardTypeData>? CardTypes { get; set; }
        public virtual ICollection<SetCardCardTypeData>? SetCardTypes { get; set; }

        public virtual ICollection<SubtypeData>? Subtypes { get; set; }
        public virtual ICollection<SetCardSubtypeData>? SetCardSubtypes { get; set; }

        public virtual ICollection<SupertypeData>? SuperTypes { get; set; }
        public virtual ICollection<SetCardSupertypeData>? SetCardSupertypes { get; set; }

        public virtual ICollection<ColorData>? Colors { get; set; }
        public virtual ICollection<SetCardColorData>? SetCardColors { get; set; }

        public virtual ICollection<KeywordData>? Keywords { get; set; }
        public virtual ICollection<SetCardKeywordData>? SetCardKeywords { get; set; }

        public virtual ICollection<ColorIdentityData>? ColorIdentities { get; set; }
        public virtual ICollection<SetCardColorIdentityData>? SetCardColorIdentities { get; set; }

        public virtual ICollection<AvailabilityData>? Availabilities { get; set; }
        public virtual ICollection<SetCardAvailabilityData>? SetCardAvailabilities { get; set; }

        public virtual ICollection<BoosterTypeData>? BoosterTypes { get; set; }
        public virtual ICollection<SetCardBoosterTypeData>? SetCardBoosterTypes { get; set; }

        public virtual ICollection<FinishData>? Finishes { get; set; }
        public virtual ICollection<SetCardFinishData>? SetCardFinishes { get; set; }

        public virtual ICollection<SetCardRulingData>? Rulings { get; set; }
        public virtual ICollection<SetCardForeignDataData>? ForeignData { get; set; }
        public virtual ICollection<SetCardPrintingData>? Printings { get; set; }
    }   
}
