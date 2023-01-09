using Microsoft.EntityFrameworkCore;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.EF.Entities;

namespace MTGDeckBuilder.EF
{
    public class MTGDeckBuilderContext : DbContext
    {
        private readonly string? _dbPath;

        public MTGDeckBuilderContext(IMTGConfiguration cfg)
        {
            _dbPath = cfg.GetConfigurationValue("MTG_DB_PATH");
        }

        public MTGDeckBuilderContext(string connectionString)
        {
            _dbPath = connectionString;
        }

        //public MTGDeckBuilderContext()
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");            
            optionsBuilder.EnableSensitiveDataLogging();
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
