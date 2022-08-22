BEGIN TRANSACTION;

CREATE TABLE "tblCard" (
    "ScryfallOracleID" TEXT NOT NULL CONSTRAINT "PK_tblCard" PRIMARY KEY,
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
    "Color" TEXT NOT NULL CONSTRAINT "PK_tblColor" PRIMARY KEY
);

CREATE TABLE "tblColorIdentity" (
    "ColorIdentity" TEXT NOT NULL CONSTRAINT "PK_tblColorIdentity" PRIMARY KEY
);

CREATE TABLE "tblFileVersion" (
    "pkVersion" INTEGER NOT NULL CONSTRAINT "PK_tblFileVersion" PRIMARY KEY AUTOINCREMENT,
    "Version" TEXT NOT NULL,
    "VersionDate" TEXT NOT NULL
);

CREATE TABLE "tblKeyword" (
    "Keyword" TEXT NOT NULL CONSTRAINT "PK_tblKeyword" PRIMARY KEY
);

CREATE TABLE "tblLegality" (
    "Legality" TEXT NOT NULL CONSTRAINT "PK_tblLegality" PRIMARY KEY
);

CREATE TABLE "tblSubType" (
    "SubType" TEXT NOT NULL CONSTRAINT "PK_tblSubType" PRIMARY KEY
);

CREATE TABLE "tblSuperType" (
    "SuperType" TEXT NOT NULL CONSTRAINT "PK_tblSuperType" PRIMARY KEY
);

CREATE TABLE "tblType" (
    "Type" TEXT NOT NULL CONSTRAINT "PK_tblType" PRIMARY KEY
);

CREATE TABLE "tblUserDeck" (
    "pkUserDeck" INTEGER NOT NULL CONSTRAINT "PK_tblUserDeck" PRIMARY KEY AUTOINCREMENT,
    "DeckName" TEXT NOT NULL,
    "DeckDescription" TEXT NOT NULL
);

CREATE TABLE "tblPurchaseInformation" (
    "pkPurchaseInformation" INTEGER NOT NULL CONSTRAINT "PK_tblPurchaseInformation" PRIMARY KEY AUTOINCREMENT,
    "fkCard" TEXT NOT NULL,
    "StorefrontName" TEXT NOT NULL,
    "CardURI" TEXT NOT NULL,
    CONSTRAINT "FK_tblPurchaseInformation_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("ScryfallOracleID") ON DELETE CASCADE
);

CREATE TABLE "tblCardColor" (
    "fkCard" TEXT NOT NULL,
    "fkColor" TEXT NOT NULL,
    CONSTRAINT "PK_tblCardColor" PRIMARY KEY ("fkCard", "fkColor"),
    CONSTRAINT "FK_tblCardColor_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("ScryfallOracleID") ON DELETE CASCADE,
    CONSTRAINT "FK_tblCardColor_tblColor_fkColor" FOREIGN KEY ("fkColor") REFERENCES "tblColor" ("Color") ON DELETE CASCADE
);

CREATE TABLE "tblCardColorIdentity" (
    "fkCard" TEXT NOT NULL,
    "fkColorIdentity" TEXT NOT NULL,
    CONSTRAINT "PK_tblCardColorIdentity" PRIMARY KEY ("fkCard", "fkColorIdentity"),
    CONSTRAINT "FK_tblCardColorIdentity_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("ScryfallOracleID") ON DELETE CASCADE,
    CONSTRAINT "FK_tblCardColorIdentity_tblColorIdentity_fkColorIdentity" FOREIGN KEY ("fkColorIdentity") REFERENCES "tblColorIdentity" ("ColorIdentity") ON DELETE CASCADE
);

CREATE TABLE "tblCardKeywordData" (
    "fkCard" TEXT NOT NULL,
    "fkKeyword" TEXT NOT NULL,
    CONSTRAINT "PK_tblCardKeywordData" PRIMARY KEY ("fkCard", "fkKeyword"),
    CONSTRAINT "FK_tblCardKeywordData_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("ScryfallOracleID") ON DELETE CASCADE,
    CONSTRAINT "FK_tblCardKeywordData_tblKeyword_fkKeyword" FOREIGN KEY ("fkKeyword") REFERENCES "tblKeyword" ("Keyword") ON DELETE CASCADE
);

CREATE TABLE "tblCardLegality" (
    "fkCard" TEXT NOT NULL,
    "fkLegality" TEXT NOT NULL,
    "IsLegal" INTEGER NOT NULL,
    CONSTRAINT "PK_tblCardLegality" PRIMARY KEY ("fkCard", "fkLegality"),
    CONSTRAINT "FK_tblCardLegality_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("ScryfallOracleID") ON DELETE CASCADE,
    CONSTRAINT "FK_tblCardLegality_tblLegality_fkLegality" FOREIGN KEY ("fkLegality") REFERENCES "tblLegality" ("Legality") ON DELETE CASCADE
);

CREATE TABLE "tblCardSubType" (
    "fkCard" TEXT NOT NULL,
    "fkSubType" TEXT NOT NULL,
    CONSTRAINT "PK_tblCardSubType" PRIMARY KEY ("fkCard", "fkSubType"),
    CONSTRAINT "FK_tblCardSubType_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("ScryfallOracleID") ON DELETE CASCADE,
    CONSTRAINT "FK_tblCardSubType_tblSubType_fkSubType" FOREIGN KEY ("fkSubType") REFERENCES "tblSubType" ("SubType") ON DELETE CASCADE
);

CREATE TABLE "tblCardSuperType" (
    "fkCard" TEXT NOT NULL,
    "fkSuperType" TEXT NOT NULL,
    CONSTRAINT "PK_tblCardSuperType" PRIMARY KEY ("fkCard", "fkSuperType"),
    CONSTRAINT "FK_tblCardSuperType_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("ScryfallOracleID") ON DELETE CASCADE,
    CONSTRAINT "FK_tblCardSuperType_tblSuperType_fkSuperType" FOREIGN KEY ("fkSuperType") REFERENCES "tblSuperType" ("SuperType") ON DELETE CASCADE
);

CREATE TABLE "tblCardType" (
    "fkCard" TEXT NOT NULL,
    "fkType" TEXT NOT NULL,
    CONSTRAINT "PK_tblCardType" PRIMARY KEY ("fkCard", "fkType"),
    CONSTRAINT "FK_tblCardType_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("ScryfallOracleID") ON DELETE CASCADE,
    CONSTRAINT "FK_tblCardType_tblType_fkType" FOREIGN KEY ("fkType") REFERENCES "tblType" ("Type") ON DELETE CASCADE
);

CREATE TABLE "tblUserDeckCard" (
    "fkUserDeck" INTEGER NOT NULL,
    "fkCard" TEXT NOT NULL,
    CONSTRAINT "PK_tblUserDeckCard" PRIMARY KEY ("fkUserDeck", "fkCard"),
    CONSTRAINT "FK_tblUserDeckCard_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("ScryfallOracleID") ON DELETE CASCADE,
    CONSTRAINT "FK_tblUserDeckCard_tblUserDeck_fkUserDeck" FOREIGN KEY ("fkUserDeck") REFERENCES "tblUserDeck" ("pkUserDeck") ON DELETE CASCADE
);

CREATE TABLE "tblUserDeckSideboard" (
    "fkUserDeck" INTEGER NOT NULL CONSTRAINT "PK_tblUserDeckSideboard" PRIMARY KEY,
    CONSTRAINT "FK_tblUserDeckSideboard_tblUserDeck_fkUserDeck" FOREIGN KEY ("fkUserDeck") REFERENCES "tblUserDeck" ("pkUserDeck") ON DELETE CASCADE
);

CREATE TABLE "UserDeckLegalityData" (
    "LegalitiesLegality" TEXT NOT NULL,
    "UserDeckspkUserDeck" INTEGER NOT NULL,
    "fkUserDeck" INTEGER NOT NULL,
    "fkLegality" TEXT NOT NULL,
    "DeckpkUserDeck" INTEGER NOT NULL,
    "Legality1" TEXT NOT NULL,
    CONSTRAINT "PK_UserDeckLegalityData" PRIMARY KEY ("LegalitiesLegality", "UserDeckspkUserDeck"),
    CONSTRAINT "FK_UserDeckLegalityData_tblLegality_LegalitiesLegality" FOREIGN KEY ("LegalitiesLegality") REFERENCES "tblLegality" ("Legality") ON DELETE CASCADE,
    CONSTRAINT "FK_UserDeckLegalityData_tblLegality_Legality1" FOREIGN KEY ("Legality1") REFERENCES "tblLegality" ("Legality") ON DELETE CASCADE,
    CONSTRAINT "FK_UserDeckLegalityData_tblUserDeck_DeckpkUserDeck" FOREIGN KEY ("DeckpkUserDeck") REFERENCES "tblUserDeck" ("pkUserDeck") ON DELETE CASCADE,
    CONSTRAINT "FK_UserDeckLegalityData_tblUserDeck_UserDeckspkUserDeck" FOREIGN KEY ("UserDeckspkUserDeck") REFERENCES "tblUserDeck" ("pkUserDeck") ON DELETE CASCADE
);

CREATE TABLE "tblUserDeckSideboardCard" (
    "fkCard" TEXT NOT NULL,
    "fkUserDeckSideboard" INTEGER NOT NULL,
    "CardDataScryfallOracleID" TEXT NULL,
    CONSTRAINT "PK_tblUserDeckSideboardCard" PRIMARY KEY ("fkUserDeckSideboard", "fkCard"),
    CONSTRAINT "FK_tblUserDeckSideboardCard_tblCard_CardDataScryfallOracleID" FOREIGN KEY ("CardDataScryfallOracleID") REFERENCES "tblCard" ("ScryfallOracleID"),
    CONSTRAINT "FK_tblUserDeckSideboardCard_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("ScryfallOracleID") ON DELETE CASCADE,
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

CREATE INDEX "IX_tblColor_Color" ON "tblColor" ("Color");

CREATE INDEX "IX_tblColorIdentity_ColorIdentity" ON "tblColorIdentity" ("ColorIdentity");

CREATE INDEX "IX_tblKeyword_Keyword" ON "tblKeyword" ("Keyword");

CREATE INDEX "IX_tblPurchaseInformation_fkCard" ON "tblPurchaseInformation" ("fkCard");

CREATE INDEX "IX_tblSubType_SubType" ON "tblSubType" ("SubType");

CREATE INDEX "IX_tblSuperType_SuperType" ON "tblSuperType" ("SuperType");

CREATE INDEX "IX_tblType_Type" ON "tblType" ("Type");

CREATE INDEX "IX_tblUserDeckCard_fkCard" ON "tblUserDeckCard" ("fkCard");

CREATE INDEX "IX_tblUserDeckSideboardCard_CardDataScryfallOracleID" ON "tblUserDeckSideboardCard" ("CardDataScryfallOracleID");

CREATE INDEX "IX_tblUserDeckSideboardCard_fkCard" ON "tblUserDeckSideboardCard" ("fkCard");

CREATE INDEX "IX_UserDeckLegalityData_DeckpkUserDeck" ON "UserDeckLegalityData" ("DeckpkUserDeck");

CREATE INDEX "IX_UserDeckLegalityData_Legality1" ON "UserDeckLegalityData" ("Legality1");

CREATE INDEX "IX_UserDeckLegalityData_UserDeckspkUserDeck" ON "UserDeckLegalityData" ("UserDeckspkUserDeck");

COMMIT;
