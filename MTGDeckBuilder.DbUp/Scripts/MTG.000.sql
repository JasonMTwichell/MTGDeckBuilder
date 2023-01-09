BEGIN TRANSACTION;

CREATE TABLE "tblAvailability" (
    "pkAvailability" INTEGER NOT NULL CONSTRAINT "PK_tblAvailability" PRIMARY KEY AUTOINCREMENT,
    "AvailabilityDescription" TEXT NOT NULL
);

CREATE TABLE "tblBoosterType" (
    "pkBoosterType" INTEGER NOT NULL CONSTRAINT "PK_tblBoosterType" PRIMARY KEY AUTOINCREMENT,
    "BoosterTypeDescription" TEXT NOT NULL
);

CREATE TABLE "tblBorderColor" (
    "pkBorderColor" INTEGER NOT NULL CONSTRAINT "PK_tblBorderColor" PRIMARY KEY AUTOINCREMENT,
    "BorderColorDescription" TEXT NOT NULL
);

CREATE TABLE "tblColor" (
    "pkColor" INTEGER NOT NULL CONSTRAINT "PK_tblColor" PRIMARY KEY AUTOINCREMENT,
    "ColorDescription" TEXT NOT NULL
);

CREATE TABLE "tblColorIdentity" (
    "pkColorIdentity" INTEGER NOT NULL CONSTRAINT "PK_tblColorIdentity" PRIMARY KEY AUTOINCREMENT,
    "ColorIdentityDescription" TEXT NOT NULL
);

CREATE TABLE "tblColorIndicator" (
    "pkColorIndicator" INTEGER NOT NULL CONSTRAINT "PK_tblColorIndicator" PRIMARY KEY AUTOINCREMENT,
    "ColorIndicatorDescription" TEXT NOT NULL
);

CREATE TABLE "tblDeckType" (
    "pkDeckType" INTEGER NOT NULL CONSTRAINT "PK_tblDeckType" PRIMARY KEY AUTOINCREMENT,
    "DeckTypeDescription" TEXT NOT NULL
);

CREATE TABLE "tblDuelDeck" (
    "pkDuelDeck" INTEGER NOT NULL CONSTRAINT "PK_tblDuelDeck" PRIMARY KEY AUTOINCREMENT,
    "DuelDeckDescription" TEXT NOT NULL
);

CREATE TABLE "tblFinish" (
    "pkFinish" INTEGER NOT NULL CONSTRAINT "PK_tblFinish" PRIMARY KEY AUTOINCREMENT,
    "FinishDescription" TEXT NOT NULL
);

CREATE TABLE "tblForeignDataLanguage" (
    "pkForeignDataLanguage" INTEGER NOT NULL CONSTRAINT "PK_tblForeignDataLanguage" PRIMARY KEY AUTOINCREMENT,
    "ForeignDataLanguageDescription" TEXT NOT NULL
);

CREATE TABLE "tblFrameEffect" (
    "pkFrameEffect" INTEGER NOT NULL CONSTRAINT "PK_tblFrameEffect" PRIMARY KEY AUTOINCREMENT,
    "FrameEffectDescription" TEXT NOT NULL
);

CREATE TABLE "tblFrameVersion" (
    "pkFrameVersion" INTEGER NOT NULL CONSTRAINT "PK_tblFrameVersion" PRIMARY KEY AUTOINCREMENT,
    "FrameVersionDescription" TEXT NOT NULL
);

CREATE TABLE "tblKeywordType" (
    "pkKeywordType" INTEGER NOT NULL CONSTRAINT "PK_tblKeywordType" PRIMARY KEY AUTOINCREMENT,
    "KeywordTypeDescription" TEXT NOT NULL
);

CREATE TABLE "tblLanguage" (
    "pkLanguage" INTEGER NOT NULL CONSTRAINT "PK_tblLanguage" PRIMARY KEY AUTOINCREMENT,
    "LanguageDescription" TEXT NOT NULL
);

CREATE TABLE "tblLayout" (
    "pkLayout" INTEGER NOT NULL CONSTRAINT "PK_tblLayout" PRIMARY KEY AUTOINCREMENT,
    "LayoutDescription" TEXT NOT NULL
);

CREATE TABLE "tblPromoType" (
    "pkPromoType" INTEGER NOT NULL CONSTRAINT "PK_tblPromoType" PRIMARY KEY AUTOINCREMENT,
    "PromoTypeDescription" TEXT NOT NULL
);

CREATE TABLE "tblRarity" (
    "pkRarity" INTEGER NOT NULL CONSTRAINT "PK_tblRarity" PRIMARY KEY AUTOINCREMENT,
    "RarityDescription" TEXT NOT NULL
);

CREATE TABLE "tblSecurityStamp" (
    "pkSecurityStamp" INTEGER NOT NULL CONSTRAINT "PK_tblSecurityStamp" PRIMARY KEY AUTOINCREMENT,
    "SecurityStampDescription" TEXT NOT NULL
);

CREATE TABLE "tblSetType" (
    "pkSetType" INTEGER NOT NULL CONSTRAINT "PK_tblSetType" PRIMARY KEY AUTOINCREMENT,
    "SetTypeDescription" TEXT NOT NULL
);

CREATE TABLE "tblSide" (
    "pkSide" INTEGER NOT NULL CONSTRAINT "PK_tblSide" PRIMARY KEY AUTOINCREMENT,
    "SideDescription" TEXT NOT NULL
);

CREATE TABLE "tblSubtype" (
    "pkSubtype" INTEGER NOT NULL CONSTRAINT "PK_tblSubtype" PRIMARY KEY AUTOINCREMENT,
    "SubtypeDescription" TEXT NOT NULL
);

CREATE TABLE "tblSupertype" (
    "pkSupertype" INTEGER NOT NULL CONSTRAINT "PK_tblSupertype" PRIMARY KEY AUTOINCREMENT,
    "SupertypeDescription" TEXT NOT NULL
);

CREATE TABLE "tblTcgPlayerSkuCondition" (
    "pkTcgPlayerSkuCondition" INTEGER NOT NULL CONSTRAINT "PK_tblTcgPlayerSkuCondition" PRIMARY KEY AUTOINCREMENT,
    "ConditionDescription" TEXT NOT NULL
);

CREATE TABLE "tblTcgPlayerSkuFinish" (
    "pkTcgPlayerSkuFinish" INTEGER NOT NULL CONSTRAINT "PK_tblTcgPlayerSkuFinish" PRIMARY KEY AUTOINCREMENT,
    "FinishDescription" TEXT NOT NULL
);

CREATE TABLE "tblTcgPlayerSkuLanguage" (
    "pkTcgPlayerSkuLanguage" INTEGER NOT NULL CONSTRAINT "PK_tblTcgPlayerSkuLanguage" PRIMARY KEY AUTOINCREMENT,
    "LanguageDescription" TEXT NOT NULL
);

CREATE TABLE "tblTcgPlayerSkuPrinting" (
    "pkTcgPlayerSkuPrinting" INTEGER NOT NULL CONSTRAINT "PK_tblTcgPlayerSkuPrinting" PRIMARY KEY AUTOINCREMENT,
    "PrintingDescription" TEXT NOT NULL
);

CREATE TABLE "tblCardType" (
    "pkCardType" INTEGER NOT NULL CONSTRAINT "PK_tblCardType" PRIMARY KEY AUTOINCREMENT,
    "CardTypeDescription" TEXT NOT NULL
);

CREATE TABLE "tblWatermark" (
    "pkWatermark" INTEGER NOT NULL CONSTRAINT "PK_tblWatermark" PRIMARY KEY AUTOINCREMENT,
    "WatermarkDescription" TEXT NOT NULL
);

CREATE TABLE "tblKeyword" (
    "pkKeyword" INTEGER NOT NULL CONSTRAINT "PK_tblKeyword" PRIMARY KEY AUTOINCREMENT,
    "fkKeywordType" INTEGER NULL,
    "KeywordDescription" TEXT NOT NULL,
    CONSTRAINT "FK_tblKeyword_tblKeywordType_fkKeywordType" FOREIGN KEY ("fkKeywordType") REFERENCES "tblKeywordType" ("pkKeywordType")
);

CREATE INDEX "IX_tblKeyword_fkKeywordType" ON "tblKeyword" ("fkKeywordType");

COMMIT;