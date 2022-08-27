BEGIN TRANSACTION;

CREATE TABLE "tblColor" (
    "pkColor" INTEGER NOT NULL CONSTRAINT "PK_tblColor" PRIMARY KEY AUTOINCREMENT,
    "Color" TEXT NOT NULL
);

CREATE TABLE "tblColorIdentity" (
    "pkColorIdentity" INTEGER NOT NULL CONSTRAINT "PK_tblColorIdentity" PRIMARY KEY AUTOINCREMENT,
    "ColorIdentity" TEXT NOT NULL
);

CREATE TABLE "tblFileVersion" (
    "pkVersion" INTEGER NOT NULL CONSTRAINT "PK_tblFileVersion" PRIMARY KEY AUTOINCREMENT,
    "Version" TEXT NOT NULL,
    "VersionDate" TEXT NOT NULL
);

CREATE TABLE "tblFormat" (
    "pkFormat" INTEGER NOT NULL CONSTRAINT "PK_tblFormat" PRIMARY KEY AUTOINCREMENT,
    "Format" TEXT NOT NULL
);

CREATE TABLE "tblKeyword" (
    "pkKeyword" INTEGER NOT NULL CONSTRAINT "PK_tblKeyword" PRIMARY KEY AUTOINCREMENT,
    "Keyword" TEXT NOT NULL
);

CREATE TABLE "tblSet" (
    "pkSet" INTEGER NOT NULL CONSTRAINT "PK_tblSet" PRIMARY KEY AUTOINCREMENT,
    "SetCode" TEXT NOT NULL,
    "SetName" TEXT NOT NULL,
    "BaseSetSize" INTEGER NOT NULL,
    "TotalSetSize" INTEGER NOT NULL,
    "ReleaseDate" TEXT NOT NULL,
    "SetType" TEXT NOT NULL
);

CREATE TABLE "tblSubType" (
    "pkSubType" INTEGER NOT NULL CONSTRAINT "PK_tblSubType" PRIMARY KEY AUTOINCREMENT,
    "SubType" TEXT NOT NULL
);

CREATE TABLE "tblSuperType" (
    "pkSuperType" INTEGER NOT NULL CONSTRAINT "PK_tblSuperType" PRIMARY KEY AUTOINCREMENT,
    "SuperType" TEXT NOT NULL
);

CREATE TABLE "tblType" (
    "pkType" INTEGER NOT NULL CONSTRAINT "PK_tblType" PRIMARY KEY AUTOINCREMENT,
    "Type" TEXT NOT NULL
);

CREATE TABLE "tblCard" (
    "pkCard" INTEGER NOT NULL CONSTRAINT "PK_tblCard" PRIMARY KEY AUTOINCREMENT,
    "fkSet" INTEGER NOT NULL,
    "UUID" TEXT NOT NULL,
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
    "HasAlternateDeckLimit" INTEGER NULL,
    "FlavorText" TEXT NULL,
    "Rarity" TEXT NULL,
    "FaceName" TEXT NULL,
    "NumberInSet" TEXT NULL,
    CONSTRAINT "FK_tblCard_tblSet_fkSet" FOREIGN KEY ("fkSet") REFERENCES "tblSet" ("pkSet") ON DELETE CASCADE
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

CREATE TABLE "tblCardFormat" (
    "fkCard" INTEGER NOT NULL,
    "fkFormat" INTEGER NOT NULL,
    "IsLegal" INTEGER NOT NULL,
    CONSTRAINT "PK_tblCardFormat" PRIMARY KEY ("fkCard", "fkFormat"),
    CONSTRAINT "FK_tblCardFormat_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE,
    CONSTRAINT "FK_tblCardFormat_tblFormat_fkFormat" FOREIGN KEY ("fkFormat") REFERENCES "tblFormat" ("pkFormat") ON DELETE CASCADE
);

CREATE TABLE "tblCardKeywordData" (
    "fkCard" INTEGER NOT NULL,
    "fkKeyword" INTEGER NOT NULL,
    CONSTRAINT "PK_tblCardKeywordData" PRIMARY KEY ("fkCard", "fkKeyword"),
    CONSTRAINT "FK_tblCardKeywordData_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE,
    CONSTRAINT "FK_tblCardKeywordData_tblKeyword_fkKeyword" FOREIGN KEY ("fkKeyword") REFERENCES "tblKeyword" ("pkKeyword") ON DELETE CASCADE
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

CREATE TABLE "tblPurchaseInformation" (
    "pkPurchaseInformation" INTEGER NOT NULL CONSTRAINT "PK_tblPurchaseInformation" PRIMARY KEY AUTOINCREMENT,
    "fkCard" INTEGER NOT NULL,
    "StorefrontName" TEXT NOT NULL,
    "CardURI" TEXT NOT NULL,
    CONSTRAINT "FK_tblPurchaseInformation_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE
);

CREATE TABLE "tblUserDeck" (
    "pkUserDeck" INTEGER NOT NULL CONSTRAINT "PK_tblUserDeck" PRIMARY KEY AUTOINCREMENT,
    "DeckName" TEXT NOT NULL,
    "DeckDescription" TEXT NOT NULL,
    "DateCreated" TEXT NOT NULL,
    "CardDatapkCard" INTEGER NULL,
    "FormatDatapkFormat" INTEGER NULL,
    CONSTRAINT "FK_tblUserDeck_tblCard_CardDatapkCard" FOREIGN KEY ("CardDatapkCard") REFERENCES "tblCard" ("pkCard"),
    CONSTRAINT "FK_tblUserDeck_tblFormat_FormatDatapkFormat" FOREIGN KEY ("FormatDatapkFormat") REFERENCES "tblFormat" ("pkFormat")
);

CREATE TABLE "tblUserDeckCard" (
    "fkUserDeck" INTEGER NOT NULL,
    "CardUUID" TEXT NOT NULL,
    "NumCopies" INTEGER NOT NULL,
    "CardDatapkCard" INTEGER NULL,
    CONSTRAINT "PK_tblUserDeckCard" PRIMARY KEY ("fkUserDeck", "CardUUID"),
    CONSTRAINT "FK_tblUserDeckCard_tblCard_CardDatapkCard" FOREIGN KEY ("CardDatapkCard") REFERENCES "tblCard" ("pkCard"),
    CONSTRAINT "FK_tblUserDeckCard_tblUserDeck_fkUserDeck" FOREIGN KEY ("fkUserDeck") REFERENCES "tblUserDeck" ("pkUserDeck") ON DELETE CASCADE
);

CREATE TABLE "tblUserDeckFormat" (
    "fkUserDeck" INTEGER NOT NULL,
    "Format" TEXT NOT NULL,
    CONSTRAINT "PK_tblUserDeckFormat" PRIMARY KEY ("fkUserDeck", "Format"),
    CONSTRAINT "FK_tblUserDeckFormat_tblUserDeck_fkUserDeck" FOREIGN KEY ("fkUserDeck") REFERENCES "tblUserDeck" ("pkUserDeck") ON DELETE CASCADE
);

CREATE TABLE "tblUserDeckSideboard" (
    "fkUserDeck" INTEGER NOT NULL CONSTRAINT "PK_tblUserDeckSideboard" PRIMARY KEY,
    "pkSideBoardData" INTEGER NOT NULL,
    "CardDatapkCard" INTEGER NULL,
    CONSTRAINT "FK_tblUserDeckSideboard_tblCard_CardDatapkCard" FOREIGN KEY ("CardDatapkCard") REFERENCES "tblCard" ("pkCard"),
    CONSTRAINT "FK_tblUserDeckSideboard_tblUserDeck_fkUserDeck" FOREIGN KEY ("fkUserDeck") REFERENCES "tblUserDeck" ("pkUserDeck") ON DELETE CASCADE
);

CREATE TABLE "tblUserDeckSideboardCard" (
    "fkUserDeckSideboard" INTEGER NOT NULL,
    "CardUUID" TEXT NOT NULL,
    "NumCopies" INTEGER NOT NULL,
    "CardDatapkCard" INTEGER NULL,
    CONSTRAINT "PK_tblUserDeckSideboardCard" PRIMARY KEY ("fkUserDeckSideboard", "CardUUID"),
    CONSTRAINT "FK_tblUserDeckSideboardCard_tblCard_CardDatapkCard" FOREIGN KEY ("CardDatapkCard") REFERENCES "tblCard" ("pkCard"),
    CONSTRAINT "FK_tblUserDeckSideboardCard_tblUserDeckSideboard_fkUserDeckSideboard" FOREIGN KEY ("fkUserDeckSideboard") REFERENCES "tblUserDeckSideboard" ("fkUserDeck") ON DELETE CASCADE
);

CREATE INDEX "IX_tblCard_fkSet" ON "tblCard" ("fkSet");

CREATE INDEX "IX_tblCard_ManaValue" ON "tblCard" ("ManaValue");

CREATE INDEX "IX_tblCard_Name" ON "tblCard" ("Name");

CREATE INDEX "IX_tblCard_Type" ON "tblCard" ("Type");

CREATE UNIQUE INDEX "IX_tblCard_UUID" ON "tblCard" ("UUID");

CREATE INDEX "IX_tblCardColor_fkColor" ON "tblCardColor" ("fkColor");

CREATE INDEX "IX_tblCardColorIdentity_fkColorIdentity" ON "tblCardColorIdentity" ("fkColorIdentity");

CREATE INDEX "IX_tblCardFormat_fkFormat" ON "tblCardFormat" ("fkFormat");

CREATE INDEX "IX_tblCardKeywordData_fkKeyword" ON "tblCardKeywordData" ("fkKeyword");

CREATE INDEX "IX_tblCardSubType_fkSubType" ON "tblCardSubType" ("fkSubType");

CREATE INDEX "IX_tblCardSuperType_fkSuperType" ON "tblCardSuperType" ("fkSuperType");

CREATE INDEX "IX_tblCardType_fkType" ON "tblCardType" ("fkType");

CREATE UNIQUE INDEX "IX_tblColor_Color" ON "tblColor" ("Color");

CREATE UNIQUE INDEX "IX_tblColorIdentity_ColorIdentity" ON "tblColorIdentity" ("ColorIdentity");

CREATE UNIQUE INDEX "IX_tblFormat_Format" ON "tblFormat" ("Format");

CREATE UNIQUE INDEX "IX_tblKeyword_Keyword" ON "tblKeyword" ("Keyword");

CREATE INDEX "IX_tblPurchaseInformation_fkCard" ON "tblPurchaseInformation" ("fkCard");

CREATE UNIQUE INDEX "IX_tblSet_SetCode" ON "tblSet" ("SetCode");

CREATE UNIQUE INDEX "IX_tblSet_SetName" ON "tblSet" ("SetName");

CREATE UNIQUE INDEX "IX_tblSubType_SubType" ON "tblSubType" ("SubType");

CREATE UNIQUE INDEX "IX_tblSuperType_SuperType" ON "tblSuperType" ("SuperType");

CREATE UNIQUE INDEX "IX_tblType_Type" ON "tblType" ("Type");

CREATE INDEX "IX_tblUserDeck_CardDatapkCard" ON "tblUserDeck" ("CardDatapkCard");

CREATE INDEX "IX_tblUserDeck_DateCreated" ON "tblUserDeck" ("DateCreated");

CREATE INDEX "IX_tblUserDeck_DeckName" ON "tblUserDeck" ("DeckName");

CREATE INDEX "IX_tblUserDeck_FormatDatapkFormat" ON "tblUserDeck" ("FormatDatapkFormat");

CREATE INDEX "IX_tblUserDeckCard_CardDatapkCard" ON "tblUserDeckCard" ("CardDatapkCard");

CREATE INDEX "IX_tblUserDeckSideboard_CardDatapkCard" ON "tblUserDeckSideboard" ("CardDatapkCard");

CREATE INDEX "IX_tblUserDeckSideboardCard_CardDatapkCard" ON "tblUserDeckSideboardCard" ("CardDatapkCard");

COMMIT;