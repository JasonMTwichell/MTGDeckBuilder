BEGIN TRANSACTION;

    CREATE TABLE "tblCard" (
        "pkCard" INTEGER NOT NULL CONSTRAINT "PK_tblCard" PRIMARY KEY AUTOINCREMENT,
        "Name" TEXT NULL,
        "AsciiName" TEXT NULL,
        "Text" TEXT NULL,
        "Type" TEXT NULL,
        "Layout" TEXT NULL,
        "Side" TEXT NULL,
        "ManaCost" TEXT NULL,
        "ManaValue" REAL NULL,
        "Loyalty" TEXT NULL,
        "HandModifier" INTEGER NULL,
        "LifeModifier" INTEGER NULL,
        "Power" TEXT NULL,
        "Toughness" TEXT NULL,
        "IsFunny" INTEGER NULL,
        "IsReserved" INTEGER NULL,
        "HasAlternateDeckLimit" INTEGER NULL
    );

    CREATE TABLE "tblColor" (
        "pkColor" INTEGER NOT NULL CONSTRAINT "PK_tblColor" PRIMARY KEY AUTOINCREMENT,
        "ColorName" TEXT NOT NULL
    );

    CREATE TABLE "tblColorIdentity" (
        "pkColorIdentity" INTEGER NOT NULL CONSTRAINT "PK_tblColorIdentity" PRIMARY KEY AUTOINCREMENT,
        "ColorIdentityName" TEXT NOT NULL
    );

    CREATE TABLE "tblFileVersion" (
        "pkVersion" INTEGER NOT NULL CONSTRAINT "PK_tblFileVersion" PRIMARY KEY AUTOINCREMENT,
        "Version" TEXT NOT NULL,
        "VersionDate" TEXT NOT NULL
    );

    CREATE TABLE "tblKeyword" (
        "pkKeyword" INTEGER NOT NULL CONSTRAINT "PK_tblKeyword" PRIMARY KEY AUTOINCREMENT,
        "Keyword" TEXT NOT NULL
    );

    CREATE TABLE "tblLegality" (
        "pkLegality" INTEGER NOT NULL CONSTRAINT "PK_tblLegality" PRIMARY KEY AUTOINCREMENT,
        "Format" TEXT NOT NULL
    );

    CREATE TABLE "tblSubType" (
        "pkSubType" INTEGER NOT NULL CONSTRAINT "PK_tblSubType" PRIMARY KEY AUTOINCREMENT,
        "SubTypeName" TEXT NOT NULL
    );

    CREATE TABLE "tblSuperType" (
        "pkSuperType" INTEGER NOT NULL CONSTRAINT "PK_tblSuperType" PRIMARY KEY AUTOINCREMENT,
        "SuperTypeName" TEXT NOT NULL
    );

    CREATE TABLE "tblType" (
        "pkType" INTEGER NOT NULL CONSTRAINT "PK_tblType" PRIMARY KEY AUTOINCREMENT,
        "TypeName" TEXT NOT NULL
    );

    CREATE TABLE "tblUserDeck" (
        "pkUserDeck" INTEGER NOT NULL CONSTRAINT "PK_tblUserDeck" PRIMARY KEY AUTOINCREMENT,
        "DeckName" TEXT NOT NULL,
        "DeckDescription" TEXT NOT NULL
    );

    CREATE TABLE "tblPurchaseInformation" (
        "pkPurchaseInformation" INTEGER NOT NULL CONSTRAINT "PK_tblPurchaseInformation" PRIMARY KEY AUTOINCREMENT,
        "fkCard" INTEGER NOT NULL,
        "StorefrontName" TEXT NOT NULL,
        "CardURI" TEXT NOT NULL,
        CONSTRAINT "FK_tblPurchaseInformation_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE
    );

    CREATE TABLE "tblCardColor" (
        "fkCard" INTEGER NOT NULL,
        "fkColor" INTEGER NOT NULL,
        CONSTRAINT "PK_tblCardColor" PRIMARY KEY ("fkCard", "fkColor"),
        CONSTRAINT "FK_tblCardColor_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE,
        CONSTRAINT "FK_tblCardColor_tblColor_fkColor" FOREIGN KEY ("fkColor") REFERENCES "tblColor" ("pkColor") ON DELETE CASCADE
    );

    CREATE TABLE "tblCardColorIdentity" (
        "fkCard" INTEGER NOT NULL,
        "fkColorIdentity" INTEGER NOT NULL,
        CONSTRAINT "PK_tblCardColorIdentity" PRIMARY KEY ("fkCard", "fkColorIdentity"),
        CONSTRAINT "FK_tblCardColorIdentity_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE,
        CONSTRAINT "FK_tblCardColorIdentity_tblColorIdentity_fkColorIdentity" FOREIGN KEY ("fkColorIdentity") REFERENCES "tblColorIdentity" ("pkColorIdentity") ON DELETE CASCADE
    );

    CREATE TABLE "tblCardKeywordData" (
        "fkCard" INTEGER NOT NULL,
        "fkKeyword" INTEGER NOT NULL,
        CONSTRAINT "PK_tblCardKeywordData" PRIMARY KEY ("fkCard", "fkKeyword"),
        CONSTRAINT "FK_tblCardKeywordData_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE,
        CONSTRAINT "FK_tblCardKeywordData_tblKeyword_fkKeyword" FOREIGN KEY ("fkKeyword") REFERENCES "tblKeyword" ("pkKeyword") ON DELETE CASCADE
    );

    CREATE TABLE "tblCardLegality" (
        "fkCard" INTEGER NOT NULL,
        "fkLegality" INTEGER NOT NULL,
        "IsLegal" INTEGER NOT NULL,
        CONSTRAINT "PK_tblCardLegality" PRIMARY KEY ("fkCard", "fkLegality"),
        CONSTRAINT "FK_tblCardLegality_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE,
        CONSTRAINT "FK_tblCardLegality_tblLegality_fkLegality" FOREIGN KEY ("fkLegality") REFERENCES "tblLegality" ("pkLegality") ON DELETE CASCADE
    );

    CREATE TABLE "tblCardSubType" (
        "fkCard" INTEGER NOT NULL,
        "fkSubType" INTEGER NOT NULL,
        CONSTRAINT "PK_tblCardSubType" PRIMARY KEY ("fkCard", "fkSubType"),
        CONSTRAINT "FK_tblCardSubType_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE,
        CONSTRAINT "FK_tblCardSubType_tblSubType_fkSubType" FOREIGN KEY ("fkSubType") REFERENCES "tblSubType" ("pkSubType") ON DELETE CASCADE
    );

    CREATE TABLE "tblCardSuperType" (
        "fkCard" INTEGER NOT NULL,
        "fkSuperType" INTEGER NOT NULL,
        CONSTRAINT "PK_tblCardSuperType" PRIMARY KEY ("fkCard", "fkSuperType"),
        CONSTRAINT "FK_tblCardSuperType_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE,
        CONSTRAINT "FK_tblCardSuperType_tblSuperType_fkSuperType" FOREIGN KEY ("fkSuperType") REFERENCES "tblSuperType" ("pkSuperType") ON DELETE CASCADE
    );

    CREATE TABLE "tblCardType" (
        "fkCard" INTEGER NOT NULL,
        "fkType" INTEGER NOT NULL,
        CONSTRAINT "PK_tblCardType" PRIMARY KEY ("fkCard", "fkType"),
        CONSTRAINT "FK_tblCardType_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE,
        CONSTRAINT "FK_tblCardType_tblType_fkType" FOREIGN KEY ("fkType") REFERENCES "tblType" ("pkType") ON DELETE CASCADE
    );

    CREATE TABLE "tblUserDeckCard" (
        "fkUserDeck" INTEGER NOT NULL,
        "fkCard" INTEGER NOT NULL,
        CONSTRAINT "PK_tblUserDeckCard" PRIMARY KEY ("fkUserDeck", "fkCard"),
        CONSTRAINT "FK_tblUserDeckCard_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE,
        CONSTRAINT "FK_tblUserDeckCard_tblUserDeck_fkUserDeck" FOREIGN KEY ("fkUserDeck") REFERENCES "tblUserDeck" ("pkUserDeck") ON DELETE CASCADE
    );

    CREATE TABLE "tblUserDeckSideboard" (
        "fkUserDeck" INTEGER NOT NULL CONSTRAINT "PK_tblUserDeckSideboard" PRIMARY KEY,
        CONSTRAINT "FK_tblUserDeckSideboard_tblUserDeck_fkUserDeck" FOREIGN KEY ("fkUserDeck") REFERENCES "tblUserDeck" ("pkUserDeck") ON DELETE CASCADE
    );

    CREATE TABLE "UserDeckLegalityData" (
        "LegalitiespkLegality" INTEGER NOT NULL,
        "UserDeckspkUserDeck" INTEGER NOT NULL,
        "fkUserDeck" INTEGER NOT NULL,
        "fkLegality" INTEGER NOT NULL,
        "DeckpkUserDeck" INTEGER NOT NULL,
        "LegalitypkLegality" INTEGER NOT NULL,
        CONSTRAINT "PK_UserDeckLegalityData" PRIMARY KEY ("LegalitiespkLegality", "UserDeckspkUserDeck"),
        CONSTRAINT "FK_UserDeckLegalityData_tblLegality_LegalitiespkLegality" FOREIGN KEY ("LegalitiespkLegality") REFERENCES "tblLegality" ("pkLegality") ON DELETE CASCADE,
        CONSTRAINT "FK_UserDeckLegalityData_tblLegality_LegalitypkLegality" FOREIGN KEY ("LegalitypkLegality") REFERENCES "tblLegality" ("pkLegality") ON DELETE CASCADE,
        CONSTRAINT "FK_UserDeckLegalityData_tblUserDeck_DeckpkUserDeck" FOREIGN KEY ("DeckpkUserDeck") REFERENCES "tblUserDeck" ("pkUserDeck") ON DELETE CASCADE,
        CONSTRAINT "FK_UserDeckLegalityData_tblUserDeck_UserDeckspkUserDeck" FOREIGN KEY ("UserDeckspkUserDeck") REFERENCES "tblUserDeck" ("pkUserDeck") ON DELETE CASCADE
    );

    CREATE TABLE "tblUserDeckSideboardCard" (
        "fkCard" INTEGER NOT NULL,
        "fkUserDeckSideboard" INTEGER NOT NULL,
        "CardDatapkCard" INTEGER NULL,
        CONSTRAINT "PK_tblUserDeckSideboardCard" PRIMARY KEY ("fkUserDeckSideboard", "fkCard"),
        CONSTRAINT "FK_tblUserDeckSideboardCard_tblCard_CardDatapkCard" FOREIGN KEY ("CardDatapkCard") REFERENCES "tblCard" ("pkCard"),
        CONSTRAINT "FK_tblUserDeckSideboardCard_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE,
        CONSTRAINT "FK_tblUserDeckSideboardCard_tblUserDeckSideboard_fkUserDeckSideboard" FOREIGN KEY ("fkUserDeckSideboard") REFERENCES "tblUserDeckSideboard" ("fkUserDeck") ON DELETE CASCADE
    );

    CREATE INDEX "IX_tblCard_ManaValue" ON "tblCard" ("ManaValue");

    CREATE INDEX "IX_tblCard_Name" ON "tblCard" ("Name");

    CREATE INDEX "IX_tblCard_Type" ON "tblCard" ("Type");

    CREATE INDEX "IX_tblCardColor_fkColor" ON "tblCardColor" ("fkColor");

    CREATE INDEX "IX_tblCardColorIdentity_fkColorIdentity" ON "tblCardColorIdentity" ("fkColorIdentity");

    CREATE INDEX "IX_tblCardKeywordData_fkKeyword" ON "tblCardKeywordData" ("fkKeyword");

    CREATE INDEX "IX_tblCardLegality_fkLegality" ON "tblCardLegality" ("fkLegality");

    CREATE INDEX "IX_tblCardSubType_fkSubType" ON "tblCardSubType" ("fkSubType");

    CREATE INDEX "IX_tblCardSuperType_fkSuperType" ON "tblCardSuperType" ("fkSuperType");

    CREATE INDEX "IX_tblCardType_fkType" ON "tblCardType" ("fkType");

    CREATE INDEX "IX_tblColor_ColorName" ON "tblColor" ("ColorName");

    CREATE INDEX "IX_tblColorIdentity_ColorIdentityName" ON "tblColorIdentity" ("ColorIdentityName");

    CREATE INDEX "IX_tblKeyword_Keyword" ON "tblKeyword" ("Keyword");

    CREATE INDEX "IX_tblPurchaseInformation_fkCard" ON "tblPurchaseInformation" ("fkCard");

    CREATE INDEX "IX_tblSubType_SubTypeName" ON "tblSubType" ("SubTypeName");

    CREATE INDEX "IX_tblSuperType_SuperTypeName" ON "tblSuperType" ("SuperTypeName");

    CREATE INDEX "IX_tblType_TypeName" ON "tblType" ("TypeName");

    CREATE INDEX "IX_tblUserDeckCard_fkCard" ON "tblUserDeckCard" ("fkCard");

    CREATE INDEX "IX_tblUserDeckSideboardCard_CardDatapkCard" ON "tblUserDeckSideboardCard" ("CardDatapkCard");

    CREATE INDEX "IX_tblUserDeckSideboardCard_fkCard" ON "tblUserDeckSideboardCard" ("fkCard");

    CREATE INDEX "IX_UserDeckLegalityData_DeckpkUserDeck" ON "UserDeckLegalityData" ("DeckpkUserDeck");

    CREATE INDEX "IX_UserDeckLegalityData_LegalitypkLegality" ON "UserDeckLegalityData" ("LegalitypkLegality");

    CREATE INDEX "IX_UserDeckLegalityData_UserDeckspkUserDeck" ON "UserDeckLegalityData" ("UserDeckspkUserDeck");

COMMIT;