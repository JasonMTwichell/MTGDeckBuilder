using Microsoft.EntityFrameworkCore;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.EF.Entities;

namespace MTGDeckBuilder.EF
{
    public class MTGDeckBuilderContext : DbContext
    {
        private readonly string? _dbPath;

        public MTGDeckBuilderContext()
        {

        } 

        public MTGDeckBuilderContext(string connectionString)
        {
            _dbPath = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");            
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Meta
            var metaEntity = modelBuilder.Entity<MetaData>();
            metaEntity.ToTable("tblMeta");
            metaEntity.HasKey(k => k.pkMeta);
            #endregion

            #region Reference
            var availabilityEntity = modelBuilder.Entity<AvailabilityData>();
            availabilityEntity.ToTable("tblAvailability");
            availabilityEntity.HasKey(k => k.pkAvailability);

            var boosterTypeEntity = modelBuilder.Entity<BoosterTypeData>();
            boosterTypeEntity.ToTable("tblBoosterType");
            boosterTypeEntity.HasKey(k => k.pkBoosterType);

            var borderColorEntity = modelBuilder.Entity<BorderColorData>();
            borderColorEntity.ToTable("tblBorderColor");
            borderColorEntity.HasKey(k => k.pkBorderColor);

            var colorIdentityEntity = modelBuilder.Entity<ColorIdentityData>();
            colorIdentityEntity.ToTable("tblColorIdentity");
            colorIdentityEntity.HasKey(k => k.pkColorIdentity);

            var colorIndicatorEntity = modelBuilder.Entity<ColorIndicatorData>();
            colorIndicatorEntity.ToTable("tblColorIndicator");
            colorIndicatorEntity.HasKey(k => k.pkColorIndicator);

            var colorEntity = modelBuilder.Entity<ColorData>();
            colorEntity.ToTable("tblColor");
            colorEntity.HasKey(k => k.pkColor);

            var duelDeckEntity = modelBuilder.Entity<DuelDeckData>();
            duelDeckEntity.ToTable("tblDuelDeck");
            duelDeckEntity.HasKey(k => k.pkDuelDeck);

            var finishEntity = modelBuilder.Entity<FinishData>();
            finishEntity.ToTable("tblFinish");
            finishEntity.HasKey(k => k.pkFinish);

            var frameEffectEntity = modelBuilder.Entity<FrameEffectData>();
            frameEffectEntity.ToTable("tblFrameEffect");
            frameEffectEntity.HasKey(k => k.pkFrameEffect);

            var frameVersionEntity = modelBuilder.Entity<FrameVersionData>();
            frameVersionEntity.ToTable("tblFrameVersion");
            frameVersionEntity.HasKey(k => k.pkFrameVersion);

            var languageEntity = modelBuilder.Entity<LanguageData>();
            languageEntity.ToTable("tblLanguage");
            languageEntity.HasKey(k => k.pkLanguage);

            var layoutEntity = modelBuilder.Entity<LayoutData>();
            layoutEntity.ToTable("tblLayout");
            layoutEntity.HasKey(k => k.pkLayout);

            var promoTypeEntity = modelBuilder.Entity<PromoTypeData>();
            promoTypeEntity.ToTable("tblPromoType");
            promoTypeEntity.HasKey(k => k.pkPromoType);

            var rarityEntity = modelBuilder.Entity<RarityData>();
            rarityEntity.ToTable("tblRarity");
            rarityEntity.HasKey(k => k.pkRarity);

            var securityStampEntity = modelBuilder.Entity<SecurityStampData>();
            securityStampEntity.ToTable("tblSecurityStamp");
            securityStampEntity.HasKey(k => k.pkSecurityStamp);

            var sideEntity = modelBuilder.Entity<SideData>();
            sideEntity.ToTable("tblSide");
            sideEntity.HasKey(k => k.pkSide);

            var subtypeEntity = modelBuilder.Entity<SubtypeData>();
            subtypeEntity.ToTable("tblSubtype");
            subtypeEntity.HasKey(k => k.pkSubtype);

            var supertypeEntity = modelBuilder.Entity<SupertypeData>();
            supertypeEntity.ToTable("tblSupertype");
            supertypeEntity.HasKey(k => k.pkSupertype);

            var typeEntity = modelBuilder.Entity<CardTypeData>();
            typeEntity.ToTable("tblCardType");
            typeEntity.HasKey(k => k.pkCardType);

            var watermarkEntity = modelBuilder.Entity<WatermarkData>();
            watermarkEntity.ToTable("tblWatermark");
            watermarkEntity.HasKey(k => k.pkWatermark);

            var deckTypeEntity = modelBuilder.Entity<DeckTypeData>();
            deckTypeEntity.ToTable("tblDeckType");
            deckTypeEntity.HasKey(k => k.pkDeckType);

            var foreignDataLanguageEntity = modelBuilder.Entity<ForeignDataLanguageData>();
            foreignDataLanguageEntity.ToTable("tblForeignDataLanguage");
            foreignDataLanguageEntity.HasKey(k => k.pkForeignDataLanguage);

            var keywordTypeEntity = modelBuilder.Entity<KeywordTypeData>();
            keywordTypeEntity.ToTable("tblKeywordType");
            keywordTypeEntity.HasKey(k => k.pkKeywordType);

            var keywordEntity = modelBuilder.Entity<KeywordData>();
            keywordEntity.ToTable("tblKeyword");
            keywordEntity.HasKey(k => k.pkKeyword);
            keywordEntity.HasOne(n => n.KeywordType)
                .WithMany()
                .HasForeignKey(fk => fk.fkKeywordType);

            var setTypeEntity = modelBuilder.Entity<SetTypeData>();
            setTypeEntity.ToTable("tblSetType");
            setTypeEntity.HasKey(k => k.pkSetType);

            var tcgPlayerSkuConditionEntity = modelBuilder.Entity<TcgPlayerSkuConditionData>();
            tcgPlayerSkuConditionEntity.ToTable("tblTcgPlayerSkuCondition");
            tcgPlayerSkuConditionEntity.HasKey(k => k.pkTcgPlayerSkuCondition);

            var tcgPlayerSkuFinishEntity = modelBuilder.Entity<TcgPlayerSkuFinishData>();
            tcgPlayerSkuFinishEntity.ToTable("tblTcgPlayerSkuFinish");
            tcgPlayerSkuFinishEntity.HasKey(k => k.pkTcgPlayerSkuFinish);

            var tcgPlayerSkuLanguageEntity = modelBuilder.Entity<TcgPlayerSkuLanguageData>();
            tcgPlayerSkuLanguageEntity.ToTable("tblTcgPlayerSkuLanguage");
            tcgPlayerSkuLanguageEntity.HasKey(k => k.pkTcgPlayerSkuLanguage);

            var tcgPlayerSkuPrintingEntity = modelBuilder.Entity<TcgPlayerSkuPrintingData>();
            tcgPlayerSkuPrintingEntity.ToTable("tblTcgPlayerSkuPrinting");
            tcgPlayerSkuPrintingEntity.HasKey(k => k.pkTcgPlayerSkuPrinting);
            #endregion

            #region Set
            var setCfg = modelBuilder.Entity<SetData>();
            setCfg.ToTable("tblSet");
            setCfg.HasKey(k => k.pkSet);
            setCfg.HasAlternateKey(k => k.Code);
            setCfg.HasMany(set => set.SetCards)
                .WithOne(card => card.Set)
                .HasForeignKey(card => card.fkSet);
            setCfg.HasMany(p => p.Languages)
                .WithMany(p => p.Sets)
                .UsingEntity<SetLanguageData>();

            var setLanguageCfg = modelBuilder.Entity<SetLanguageData>();
            setLanguageCfg.ToTable("tblSetLanguage");
            setLanguageCfg.HasKey(k => new {k.fkLanguage, k.fkSet});
            setLanguageCfg.HasOne(p => p.Set)
                .WithMany(p => p.SetLanguages)
                .HasForeignKey(p => p.fkSet);
            setLanguageCfg.HasOne(p => p.Language)
                .WithMany()
                .HasForeignKey(p => p.fkLanguage);
            #endregion

            #region SetCard
            var setCardCfg = modelBuilder.Entity<SetCardData>();
            setCardCfg.ToTable("tblSetCard");
            setCardCfg.HasKey(k => k.pkSetCard);
            setCardCfg.HasAlternateKey(k => k.UUID);                
            setCardCfg.HasMany(p => p.CardTypes)
                .WithMany(p => p.SetCards)
                .UsingEntity<SetCardCardTypeData>();
            setCardCfg.HasMany(p => p.Subtypes)
                .WithMany(p => p.SetCards)
                .UsingEntity<SetCardSubtypeData>();
            setCardCfg.HasMany(p => p.SuperTypes)
                .WithMany(p => p.SetCards)
                .UsingEntity<SetCardSupertypeData>();
            setCardCfg.HasMany(p => p.Colors)
                .WithMany(p => p.SetCards)
                .UsingEntity<SetCardColorData>();
            setCardCfg.HasMany(p => p.Keywords)
                .WithMany(p => p.SetCards)
                .UsingEntity<SetCardKeywordData>();
            setCardCfg.HasMany(p => p.ColorIdentities)
                .WithMany(p => p.SetCards)
                .UsingEntity<SetCardColorIdentityData>();
            setCardCfg.HasMany(p => p.Availabilities)
                .WithMany(p => p.SetCards)
                .UsingEntity<SetCardAvailabilityData>();
            setCardCfg.HasMany(p => p.BoosterTypes)
                .WithMany(p => p.SetCards)
                .UsingEntity<SetCardBoosterTypeData>();
            setCardCfg.HasMany(p => p.Finishes)
                .WithMany(p => p.SetCards)
                .UsingEntity<SetCardFinishData>();
            setCardCfg.HasMany(p => p.Rulings)
                .WithOne()
                .HasForeignKey(k => k.fkSetCard);
            setCardCfg.HasMany(p => p.ForeignData)
                .WithOne()
                .HasForeignKey(k => k.fkSetCard);
            setCardCfg.HasMany(p => p.Printings)
                .WithOne()
                .HasForeignKey(k => k.fkSetCard);

            var setCardTypeCfg = modelBuilder.Entity<SetCardCardTypeData>();
            setCardTypeCfg.ToTable("tblSetCardType");
            setCardTypeCfg.HasKey(k => new { k.fkCardType, k.fkSetCard });
            setCardTypeCfg.HasOne(p => p.SetCard)
                .WithMany(p => p.SetCardTypes)
                .HasForeignKey(p => p.fkSetCard);
            setCardTypeCfg.HasOne(p => p.CardType)
                .WithMany()
                .HasForeignKey(p => p.fkCardType);

            var setCardSubtypeCfg = modelBuilder.Entity<SetCardSubtypeData>();
            setCardSubtypeCfg.ToTable("tblSetCardSubtype");
            setCardSubtypeCfg.HasKey(k => new { k.fkSubtype, k.fkSetCard });
            setCardSubtypeCfg.HasOne(p => p.SetCard)
                .WithMany(p => p.SetCardSubtypes)
                .HasForeignKey(p => p.fkSetCard);
            setCardSubtypeCfg.HasOne(p => p.Subtype)
                .WithMany()
                .HasForeignKey(p => p.fkSubtype);

            var setCardSupertypeCfg = modelBuilder.Entity<SetCardSupertypeData>();
            setCardSupertypeCfg.ToTable("tblSetCardSupertype");
            setCardSupertypeCfg.HasKey(k => new {k.fkSupertype, k.fkSetCard });
            setCardSupertypeCfg.HasOne(p => p.SetCard)
                .WithMany(p => p.SetCardSupertypes)
                .HasForeignKey(p => p.fkSetCard);
            setCardSupertypeCfg.HasOne(p => p.Supertype)
                .WithMany()
                .HasForeignKey(p => p.fkSupertype);

            var setCardColorCfg = modelBuilder.Entity<SetCardColorData>();
            setCardColorCfg.ToTable("tblSetCardColor");
            setCardColorCfg.HasKey(k => new { k.fkColor, k.fkSetCard });
            setCardColorCfg.HasOne(p => p.SetCard)
                .WithMany(p => p.SetCardColors)
                .HasForeignKey(p => p.fkSetCard);
            setCardColorCfg.HasOne(p => p.Color)
                .WithMany()
                .HasForeignKey(p => p.fkColor);

            var setCardColorIdentityCfg = modelBuilder.Entity<SetCardColorIdentityData>();
            setCardColorIdentityCfg.ToTable("tblSetCardColorIdentity");
            setCardColorIdentityCfg.HasKey(k => new { k.fkColorIdentity, k.fkSetCard });
            setCardColorIdentityCfg.HasOne(p => p.SetCard)
                .WithMany(p => p.SetCardColorIdentities)
                .HasForeignKey(p => p.fkSetCard);
            setCardColorIdentityCfg.HasOne(p => p.ColorIdentity)
                .WithMany()
                .HasForeignKey(p => p.fkColorIdentity);

            var setCardKeywordCfg = modelBuilder.Entity<SetCardKeywordData>();
            setCardKeywordCfg.ToTable("tblSetCardKeyword");
            setCardKeywordCfg.HasKey(k => new { k.fkKeyword, k.fkSetCard });
            setCardKeywordCfg.HasOne(p => p.SetCard)
                .WithMany(p => p.SetCardKeywords)
                .HasForeignKey(p => p.fkSetCard);
            setCardKeywordCfg.HasOne(p => p.Keyword)
                .WithMany()
                .HasForeignKey(p => p.fkKeyword);

            var setCardAvailabilityCfg = modelBuilder.Entity<SetCardAvailabilityData>();
            setCardAvailabilityCfg.ToTable("tblSetCardAvailability");
            setCardAvailabilityCfg.HasKey(k => new { k.fkAvailability, k.fkSetCard });
            setCardAvailabilityCfg.HasOne(p => p.SetCard)
                .WithMany(p => p.SetCardAvailabilities)
                .HasForeignKey(p => p.fkSetCard);
            setCardAvailabilityCfg.HasOne(p => p.AvailabilityData)
                .WithMany()
                .HasForeignKey(p => p.fkAvailability);

            var setCardBoosterTypeCfg = modelBuilder.Entity<SetCardBoosterTypeData>();
            setCardBoosterTypeCfg.ToTable("tblSetCardBoosterType");
            setCardBoosterTypeCfg.HasKey(k => new { k.fkBoosterType, k.fkSetCard });
            setCardBoosterTypeCfg.HasOne(p => p.SetCard)
                .WithMany(p => p.SetCardBoosterTypes)
                .HasForeignKey(p => p.fkSetCard);
            setCardBoosterTypeCfg.HasOne(p => p.BoosterType)
                .WithMany()
                .HasForeignKey(p => p.fkBoosterType);

            var setCardFinishCfg = modelBuilder.Entity<SetCardFinishData>();
            setCardFinishCfg.ToTable("tblSetCardFinish");
            setCardFinishCfg.HasKey(k => new { k.fkFinish, k.fkSetCard });
            setCardFinishCfg.HasOne(p => p.SetCard)
                .WithMany(p => p.SetCardFinishes)
                .HasForeignKey(p => p.fkSetCard);
            setCardFinishCfg.HasOne(p => p.Finish)
                .WithMany()
                .HasForeignKey(p => p.fkFinish);

            var setCardRulingCfg = modelBuilder.Entity<SetCardRulingData>();
            setCardRulingCfg.ToTable("tblSetCardRuling");
            setCardRulingCfg.HasKey(p => p.pkSetCardRuling);
            setCardRulingCfg.HasOne(p => p.SetCard)
                .WithMany(p => p.Rulings)
                .HasForeignKey(p => p.fkSetCard);

            var setCardForeignDataCfg = modelBuilder.Entity<SetCardForeignDataData>();
            setCardForeignDataCfg.ToTable("tblSetCardForeignData");
            setCardForeignDataCfg.HasKey(p => p.pkSetCardForeignData);
            setCardForeignDataCfg.HasOne(p => p.SetCard)
                .WithMany(p => p.ForeignData)
                .HasForeignKey(p => p.fkSetCard);

            var setCardPrintingCfg = modelBuilder.Entity<SetCardPrintingData>();
            setCardPrintingCfg.ToTable("tblSetCardPrinting");
            setCardPrintingCfg.HasKey(p => p.pkSetCardPrinting);
            setCardPrintingCfg.HasOne(p => p.SetCard)
                .WithMany(p => p.Printings)
                .HasForeignKey(p => p.fkSetCard);
            #endregion
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MetaData> Meta { get; set; }
        public DbSet<AvailabilityData> Availabilities { get; set; }
        public DbSet<BoosterTypeData> BoosterTypes { get; set; }
        public DbSet<BorderColorData> BorderColors { get; set; }
        public DbSet<CardTypeData> CardTypes { get; set; }
        public DbSet<ColorData> Colors { get; set; }
        public DbSet<ColorIdentityData> ColorIdentities { get; set; }
        public DbSet<ColorIndicatorData> ColorIndicators { get; set; }
        public DbSet<DeckTypeData> DeckTypes { get; set; }
        public DbSet<DuelDeckData> DuelDecks { get; set; }
        public DbSet<FinishData> Finishes { get; set; }
        public DbSet<ForeignDataLanguageData> ForeignDataLanguages { get; set; }
        public DbSet<FrameEffectData> FrameEffects { get; set; }
        public DbSet<FrameVersionData> FrameVersions { get; set; }
        public DbSet<KeywordData> Keywords { get; set; }
        public DbSet<KeywordTypeData> KeywordTypes { get; set; }
        public DbSet<LanguageData> Languages { get; set; }
        public DbSet<LayoutData> Layouts { get; set; }
        public DbSet<PromoTypeData> PromoTypes { get; set; }
        public DbSet<RarityData> Rarities { get; set; }
        public DbSet<SecurityStampData> SecurityStamps { get; set; }
        public DbSet<SetTypeData> SetTypes { get; set; }
        public DbSet<SideData> Sides { get; set; }
        public DbSet<SubtypeData> Subtypes { get; set; }
        public DbSet<SupertypeData> Supertypes { get; set; }
        public DbSet<TcgPlayerSkuConditionData> TcgPlayerSkuConditions { get; set; }
        public DbSet<TcgPlayerSkuFinishData> TcgPlayerSkuFinishes { get; set; }
        public DbSet<TcgPlayerSkuLanguageData> TcgPlayerSkuLanguages { get; set; }
        public DbSet<TcgPlayerSkuPrintingData> TcgPlayerSkuPrintings { get; set; }
        public DbSet<WatermarkData> Watermarks { get; set; }
    }
}
