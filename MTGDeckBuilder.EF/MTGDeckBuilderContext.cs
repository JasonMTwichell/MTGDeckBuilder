using Microsoft.EntityFrameworkCore;
using MTGDeckBuilder.EF.Entities;

namespace MTGDeckBuilder.EF
{
    public class MTGDeckBuilderContext : DbContext
    {
        private readonly string _dbPath;
        public MTGDeckBuilderContext(string connectionString)
        {
            _dbPath = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");            
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Entities
            var card = modelBuilder.Entity<CardData>();
            card.ToTable("tblCard");
            card.HasKey(e => e.pkCard);
            card.Property(e => e.pkCard)
                .ValueGeneratedOnAdd();
            card.HasMany(e => e.Colors)
                .WithMany(e => e.Cards)
                .UsingEntity<CardColorData>();
            card.HasMany(e => e.ColorIdentities)
                .WithMany(e => e.Cards)
                .UsingEntity<CardColorIdentityData>();
            card.HasMany(e => e.Types)
                .WithMany(e => e.Cards)
                .UsingEntity<CardTypeData>();
            card.HasMany(e => e.SuperTypes)
                .WithMany(e => e.Cards)
                .UsingEntity<CardSuperTypeData>();
            card.HasMany(e => e.SubTypes)
                .WithMany(e => e.Cards)
                .UsingEntity<CardSubTypeData>();           
            card.HasMany(e => e.Legalities)
                .WithOne(e => e.Card)
                .HasForeignKey(e => e.fkCard);
            card.HasMany(e => e.PurchaseInformation)
                .WithOne(e => e.Card)
                .HasForeignKey(e => e.fkCard);
            card.HasMany(e => e.Keywords)
                .WithMany(e => e.Cards)
                .UsingEntity<CardKeywordData>();
            card.HasIndex(e => e.Name);
            card.HasIndex(e => e.Type);
            card.HasIndex(e => e.ManaValue);
                

            var color = modelBuilder.Entity<ColorData>();
            color.ToTable("tblColor");
            color.HasKey(e => e.pkColor);
            color.Property(e => e.pkColor)
                .ValueGeneratedOnAdd();                            
            color.HasMany(e => e.Cards)
                .WithMany(e => e.Colors)
                .UsingEntity<CardColorData>();
            color.HasIndex(e => e.ColorName);

            var cardColor = modelBuilder.Entity<CardColorData>();
            cardColor.ToTable("tblCardColor");
            cardColor.HasKey(e => new { e.fkCard, e.fkColor });
            cardColor.HasOne(e => e.Card)
                .WithMany(e => e.CardColors)
                .HasForeignKey(e => e.fkCard);
            cardColor.HasOne(e => e.Color)
                .WithMany()
                .HasForeignKey(e => e.fkColor);

            var colorIdentity = modelBuilder.Entity<ColorIdentityData>();
            colorIdentity.ToTable("tblColorIdentity");
            colorIdentity.HasKey(e => e.pkColorIdentity);
            colorIdentity.Property(e => e.pkColorIdentity)
                .ValueGeneratedOnAdd();
            colorIdentity.HasMany(e => e.Cards)
                .WithMany(e => e.ColorIdentities)
                .UsingEntity<CardColorIdentityData>();
            colorIdentity.HasIndex(e => e.ColorIdentityName);

            var cardColorIdentity = modelBuilder.Entity<CardColorIdentityData>();
            cardColorIdentity.ToTable("tblCardColorIdentity");
            cardColorIdentity.HasKey(e => new { e.fkCard, e.fkColorIdentity });
            cardColorIdentity.HasOne(e => e.Card)
                .WithMany(e => e.CardColorIdentities)
                .HasForeignKey(e => e.fkCard);
            cardColorIdentity.HasOne(e => e.ColorIdentity)
                .WithMany(e => e.CardColorIdentities)
                .HasForeignKey(e => e.fkColorIdentity);

           
            var type = modelBuilder.Entity<TypeData>();
            type.ToTable("tblType");
            type.HasKey(e => e.pkType);
            type.Property(e => e.pkType)
                .ValueGeneratedOnAdd();
            type.HasMany(e => e.Cards)
                .WithMany(e => e.Types)
                .UsingEntity<CardTypeData>();
            type.HasIndex(e => e.TypeName);

            var cardType = modelBuilder.Entity<CardTypeData>();
            cardType.ToTable("tblCardType");
            cardType.HasKey(e => new { e.fkCard, e.fkType });
            cardType.HasOne(e => e.Card)
                .WithMany(e => e.CardTypes)
                .HasForeignKey(e => e.fkCard);
            cardType.HasOne(e => e.Type)
                .WithMany(e => e.CardTypes)
                .HasForeignKey(e => e.fkType);

            var superType = modelBuilder.Entity<SuperTypeData>();
            superType.ToTable("tblSuperType");
            superType.HasKey(e => e.pkSuperType);
            superType.Property(e => e.pkSuperType)
                .ValueGeneratedOnAdd();
            superType.HasMany(e => e.Cards)
                .WithMany(e => e.SuperTypes)
                .UsingEntity<CardSuperTypeData>();
            superType.HasIndex(e => e.SuperTypeName);

            var cardSuperType = modelBuilder.Entity<CardSuperTypeData>();
            cardSuperType.ToTable("tblCardSuperType");
            cardSuperType.HasKey(e => new { e.fkCard, e.fkSuperType });
            cardSuperType.HasOne(e => e.Card)
                .WithMany(e => e.CardSuperTypes)
                .HasForeignKey(e => e.fkCard);
            cardSuperType.HasOne(e => e.SuperType)
                .WithMany(e => e.CardSuperTypes)
                .HasForeignKey(e => e.fkSuperType);

            var subType = modelBuilder.Entity<SubTypeData>();
            subType.ToTable("tblSubType");
            subType.HasKey(e => e.pkSubType);
            subType.Property(e => e.pkSubType)
                .ValueGeneratedOnAdd();
            subType.HasMany(e => e.Cards)
                .WithMany(e => e.SubTypes)
                .UsingEntity<CardSubTypeData>();
            subType.HasIndex(e => e.SubTypeName);

            var cardSubType = modelBuilder.Entity<CardSubTypeData>();
            cardSubType.ToTable("tblCardSubType");
            cardSubType.HasKey(e => new { e.fkCard, e.fkSubType });
            cardSubType.HasOne(e => e.Card)
                .WithMany(e => e.CardSubTypes)
                .HasForeignKey(e => e.fkCard);
            cardSubType.HasOne(e => e.SubType)
                .WithMany(e => e.CardSubTypes)
                .HasForeignKey(e => e.fkSubType);

            var keyword = modelBuilder.Entity<KeywordData>();
            keyword.ToTable("tblKeyword");
            keyword.HasKey(e => e.pkKeyword);
            keyword.Property(e => e.pkKeyword)
                .ValueGeneratedOnAdd();
            keyword.HasMany(e => e.Cards)
                .WithMany(e => e.Keywords)
                .UsingEntity<CardKeywordData>();
            keyword.HasIndex(e => e.Keyword);

            var cardKeywordData = modelBuilder.Entity<CardKeywordData>();
            cardKeywordData.ToTable("tblCardKeywordData");
            cardKeywordData.HasKey(e => new { e.fkCard, e.fkKeyword });
            cardKeywordData.HasOne(e => e.Card)
                .WithMany(e => e.CardKeywords)
                .HasForeignKey(e => e.fkCard);
            cardKeywordData.HasOne(e => e.Keyword)
                .WithMany(e => e.CardKeywords)
                .HasForeignKey(e => e.fkKeyword);

            var legality = modelBuilder.Entity<LegalityData>();
            legality.ToTable("tblLegality");
            legality.HasKey(e => e.pkLegality);
            legality.Property(e => e.pkLegality)
                .ValueGeneratedOnAdd();
            legality.HasOne(e => e.Card)
                .WithMany(e => e.Legalities)
                .HasForeignKey(e => e.fkCard);

            var purchaseInformation = modelBuilder.Entity<PurchaseInformationData>();
            purchaseInformation.ToTable("tblPurchaseInformation");
            purchaseInformation.HasKey(p => p.pkPurchaseInformation);
            purchaseInformation.Property(e => e.pkPurchaseInformation)
                .ValueGeneratedOnAdd();
            purchaseInformation.HasOne(e => e.Card)
                .WithMany(e => e.PurchaseInformation)
                .HasForeignKey(e => e.fkCard);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CardData> Cards { get; set; }
        public DbSet<ColorData> Colors { get; set; }
        public DbSet<ColorIdentityData> ColorIdentities { get; set; }
        public DbSet<TypeData> Types { get; set; }
        public DbSet<SuperTypeData> SuperTypes { get; set; }
        public DbSet<SubTypeData> SubTypes { get; set; }
        public DbSet<KeywordData> Keywords { get; set; }        
    }
}
