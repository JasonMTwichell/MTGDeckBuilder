using Microsoft.EntityFrameworkCore;
using MTGDeckBuilder.Core.Service;
using MTGDeckBuilder.EF.Entities;

namespace MTGDeckBuilder.EF
{
    public class MTGDeckBuilderContext : DbContext
    {
        private readonly string _dbPath;

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
            #region Entities
            var version = modelBuilder.Entity<FileVersionData>();
            version.ToTable("tblFileVersion");
            version.HasKey(e => e.pkVersion);

            var set = modelBuilder.Entity<SetData>();
            set.ToTable("tblSet");
            set.HasKey(e => e.pkSet);
            set.Property(e => e.pkSet)
                .ValueGeneratedOnAdd();
            set.HasIndex(e => e.SetName)
               .IsUnique();
            set.HasIndex(e => e.SetCode)
                .IsUnique();
            set.HasMany(e => e.SetCards)
               .WithOne(e => e.Set)
               .HasForeignKey(e => e.fkSet);

            var card = modelBuilder.Entity<CardData>();
            card.ToTable("tblCard");
            card.HasKey(e => e.pkCard);            
            card.Property(e => e.pkCard)
                .ValueGeneratedOnAdd();
            card.HasAlternateKey(e => e.UUID);
            card.HasOne(e => e.Set)
                .WithMany(e => e.SetCards)
                .HasForeignKey(e => e.fkSet);
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
            card.HasMany(e => e.Formats)
                .WithMany(e => e.Cards)
                .UsingEntity<CardFormatData>();
            card.HasMany(e => e.PurchaseInformation)
                .WithOne(e => e.Card)
                .HasForeignKey(e => e.fkCard);
            card.HasMany(e => e.Keywords)
                .WithMany(e => e.Cards)
                .UsingEntity<CardKeywordData>();
            card.HasMany(e => e.CardListListCards)
                .WithOne(e => e.Card)
                .HasForeignKey(p => p.CardUUID)
                .HasPrincipalKey(p => p.UUID);
            card.HasIndex(e => e.Name);
            card.HasIndex(e => e.Type);            
            card.HasIndex(e => e.ManaValue);
            card.HasIndex(e => e.UUID)
                .IsUnique();                

            var color = modelBuilder.Entity<ColorData>();
            color.ToTable("tblColor");
            color.HasKey(e => e.pkColor);
            color.Property(e => e.pkColor)
                .ValueGeneratedOnAdd();
            color.HasMany(e => e.Cards)
                .WithMany(e => e.Colors)
                .UsingEntity<CardColorData>();
            color.HasIndex(e => e.Color)
                .IsUnique();

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
            colorIdentity.HasIndex(e => e.ColorIdentity)
                .IsUnique();

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
            type.HasIndex(e => e.Type)
                .IsUnique();

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
            superType.HasIndex(e => e.SuperType)
                .IsUnique();

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
            subType.HasIndex(e => e.SubType)
                .IsUnique();

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
            keyword.HasIndex(e => e.Keyword)
                .IsUnique();

            var cardKeywordData = modelBuilder.Entity<CardKeywordData>();
            cardKeywordData.ToTable("tblCardKeywordData");
            cardKeywordData.HasKey(e => new { e.fkCard, e.fkKeyword });
            cardKeywordData.HasOne(e => e.Card)
                .WithMany(e => e.CardKeywords)
                .HasForeignKey(e => e.fkCard);
            cardKeywordData.HasOne(e => e.Keyword)
                .WithMany(e => e.CardKeywords)
                .HasForeignKey(e => e.fkKeyword);

            var format = modelBuilder.Entity<FormatData>();
            format.ToTable("tblFormat");
            format.HasKey(e => e.pkFormat);
            format.Property(e => e.pkFormat)
                .ValueGeneratedOnAdd();
            format.HasAlternateKey(e => e.Format);
            format.HasIndex(e => e.Format)
                .IsUnique();
            format.HasMany(e => e.Cards)
                .WithMany(e => e.Formats)
                .UsingEntity<CardFormatData>();

            var cardFormatData = modelBuilder.Entity<CardFormatData>();
            cardFormatData.ToTable("tblCardFormat")
                .HasKey(e => new {e.fkCard, e.fkFormat });
            cardFormatData.HasOne(e => e.Card)
                .WithMany(e => e.CardFormats)
                .HasForeignKey(e => e.fkCard);
            cardFormatData.HasOne(e => e.Format)
                .WithMany(e => e.CardFormats)
                .HasForeignKey(e => e.fkFormat);

            var purchaseInformation = modelBuilder.Entity<PurchaseInformationData>();
            purchaseInformation.ToTable("tblPurchaseInformation");
            purchaseInformation.HasKey(p => p.pkPurchaseInformation);
            purchaseInformation.Property(e => e.pkPurchaseInformation)
                .ValueGeneratedOnAdd();
            purchaseInformation.HasOne(e => e.Card)
                .WithMany(e => e.PurchaseInformation)
                .HasForeignKey(e => e.fkCard);

            var cardList = modelBuilder.Entity<CardListData>();
            cardList.ToTable("tblCardList");
            cardList.HasKey(p => p.pkCardList);
            cardList.HasMany(e => e.ListCards)
                .WithOne(e => e.List)
                .HasForeignKey(e => e.fkCardList);

            var cardListCardData = modelBuilder.Entity<CardListCardData>();
            cardListCardData.ToTable("tblCardListCardData");
            cardListCardData.HasKey(p => new { p.fkCardList, p.CardUUID});
            cardListCardData.HasOne(e => e.Card)
                .WithMany(e => e.CardListListCards)
                .HasForeignKey(p => p.CardUUID)
                .HasPrincipalKey(p => p.UUID);
            cardListCardData.HasOne(e => e.List)
                .WithMany(e => e.ListCards)
                .HasForeignKey(p => p.fkCardList);

            var userDeck = modelBuilder.Entity<UserDeckData>();
            userDeck.ToTable("tblUserDeck");
            userDeck.HasKey(e => e.pkUserDeck);
            userDeck.Property(e => e.pkUserDeck)
                .ValueGeneratedOnAdd();
            userDeck.HasMany(e => e.Cards)
                .WithOne(e => e.UserDeck)
                .HasForeignKey(e => e.fkUserDeck);
            userDeck.HasOne(e => e.SideBoard)
                .WithOne(e => e.UserDeck)
                .HasForeignKey<UserDeckSideboardData>(e => e.fkUserDeck);
            userDeck.HasMany(e => e.Cards)
                .WithOne(e => e.UserDeck)
                .HasForeignKey(e => e.fkUserDeck);
            userDeck.HasMany(e => e.Formats)
                .WithOne(e => e.Deck)
                .HasForeignKey(e => e.fkUserDeck);
            userDeck.HasIndex(e => e.DeckName);
            userDeck.HasIndex(e => e.DateCreated);

            var userDeckFormat = modelBuilder.Entity<UserDeckFormatData>();
            userDeckFormat.ToTable("tblUserDeckFormat");
            userDeckFormat.HasKey(e => new { e.fkUserDeck, e.Format });
            userDeckFormat.HasOne(e => e.Deck)
                .WithMany(e => e.Formats)
                .HasForeignKey(e => e.fkUserDeck);
            userDeckFormat.HasOne(e => e.DeckFormat)
                .WithMany()
                .HasForeignKey(p => p.Format)
                .HasPrincipalKey(p => p.Format);

            var userDeckCard = modelBuilder.Entity<UserDeckCardData>();
            userDeckCard.ToTable("tblUserDeckCard");
            userDeckCard.HasKey(e => new { e.fkUserDeck, e.CardUUID });
            userDeckCard.HasOne(e => e.UserDeck)
                .WithMany(e => e.Cards)
                .HasForeignKey(e => e.fkUserDeck);
            userDeckCard.HasOne(e => e.CardData)
                .WithMany()
                .HasForeignKey(e => e.CardUUID)
                .HasPrincipalKey(p => p.UUID); 

            var userDeckSideboard = modelBuilder.Entity<UserDeckSideboardData>();
            userDeckSideboard.ToTable("tblUserDeckSideboard");
            userDeckSideboard.HasKey(e => e.pkUserDeckSideBoard);
            userDeckSideboard.Property(e => e.pkUserDeckSideBoard)
                .ValueGeneratedOnAdd();
            userDeckSideboard.HasOne(e => e.UserDeck)
                .WithOne(e => e.SideBoard)
                .HasForeignKey<UserDeckSideboardData>(e => e.fkUserDeck);
            userDeckSideboard.HasMany(e => e.Cards)
                .WithOne(e => e.UserDeckSideboard)
                .HasForeignKey(e => e.fkUserDeckSideboard);

            var userDeckSideboardCard = modelBuilder.Entity<UserDeckSideboardCardData>();
            userDeckSideboardCard.ToTable("tblUserDeckSideboardCard");
            userDeckSideboardCard.HasKey(e => new { e.fkUserDeckSideboard, e.CardUUID });
            userDeckSideboardCard.HasOne(e => e.UserDeckSideboard)
                .WithMany(e => e.Cards)
                .HasForeignKey(e => e.fkUserDeckSideboard);
            userDeckSideboardCard.HasOne(e => e.Card)
                .WithMany()
                .HasForeignKey(e => e.CardUUID)
                .HasPrincipalKey(p => p.UUID); 
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<FileVersionData> FileVersions { get; set; }
        public DbSet<SetData> Sets { get; set; }
        public DbSet<CardData> Cards { get; set; }
        public DbSet<ColorData> Colors { get; set; }
        public DbSet<ColorIdentityData> ColorIdentities { get; set; }
        public DbSet<TypeData> Types { get; set; }
        public DbSet<SuperTypeData> SuperTypes { get; set; }
        public DbSet<SubTypeData> SubTypes { get; set; }
        public DbSet<KeywordData> Keywords { get; set; }        
        public DbSet<UserDeckData> UserDecks { get; set; }
        public DbSet<FormatData> Formats { get; set; }       
        public DbSet<CardListData> CardLists { get; set; }
        public DbSet<CardListCardData> CardListCardData { get; set; }
    }
}
