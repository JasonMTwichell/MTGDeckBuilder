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

CREATE TABLE "tblCardType" (
    "pkCardType" INTEGER NOT NULL CONSTRAINT "PK_tblCardType" PRIMARY KEY AUTOINCREMENT,
    "CardTypeDescription" TEXT NOT NULL
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

CREATE TABLE "tblMeta" (
    "pkMeta" INTEGER NOT NULL CONSTRAINT "PK_tblMeta" PRIMARY KEY AUTOINCREMENT,
    "MetaDate" TEXT NOT NULL,
    "Version" TEXT NOT NULL,
    "DateApplied" TEXT NOT NULL
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

CREATE TABLE "tblSet" (
    "pkSet" INTEGER NOT NULL CONSTRAINT "PK_tblSet" PRIMARY KEY AUTOINCREMENT,
    "BaseSetSize" INTEGER NULL,
    "Block" TEXT NULL,
    "CardsphereSetId" INTEGER NULL,
    "Code" TEXT NOT NULL,
    "IsFoilOnly" INTEGER NULL,
    "IsNonFoilOnly" INTEGER NULL,
    "IsOnlineOnly" INTEGER NULL,
    "KeyruneCode" TEXT NULL,
    "Name" TEXT NULL,
    "ReleaseDate" TEXT NULL,
    "TcgplayerGroupId" INTEGER NULL,
    "TotalSetSize" INTEGER NULL,
    "Type" TEXT NULL,
    CONSTRAINT "AK_tblSet_Code" UNIQUE ("Code")
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

CREATE TABLE "tblSetCard" (
    "pkSetCard" INTEGER NOT NULL CONSTRAINT "PK_tblSetCard" PRIMARY KEY AUTOINCREMENT,
    "fkSet" INTEGER NULL,
    "Artist" TEXT NULL,
    "BorderColor" TEXT NULL,
    "ConvertedManaCost" REAL NULL,
    "EdhrecRank" INTEGER NULL,
    "FrameVersion" TEXT NULL,
    "HasFoil" INTEGER NULL,
    "HasNonFoil" INTEGER NULL,
    "IsReprint" INTEGER NULL,
    "Language" TEXT NULL,
    "Layout" TEXT NULL,
    "ManaCost" TEXT NULL,
    "ManaValue" REAL NULL,
    "Name" TEXT NULL,
    "Number" TEXT NULL,
    "OriginalText" TEXT NULL,
    "OriginalType" TEXT NULL,
    "Rarity" TEXT NULL,
    "SetCode" TEXT NULL,
    "Text" TEXT NULL,
    "Type" TEXT NULL,
    "UUID" TEXT NOT NULL,
    "CardKingdomId" TEXT NULL,
    "CardsphereId" TEXT NULL,
    "McmId" TEXT NULL,
    "MtgjsonV4Id" TEXT NULL,
    "MultiverseId" TEXT NULL,
    "ScryfallId" TEXT NULL,
    "ScryfallIllustrationId" TEXT NULL,
    "ScryfallOracleId" TEXT NULL,
    "TcgplayerProductId" TEXT NULL,
    "IsCommanderFormatLegal" INTEGER NULL,
    "IsDuelFormatLegal" INTEGER NULL,
    "IsLegacyFormatLegal" INTEGER NULL,
    "IsOldschoolFormatLegal" INTEGER NULL,
    "IsPennyFormatLegal" INTEGER NULL,
    "IsPremodernFormatLegal" INTEGER NULL,
    "IsVintageFormatLegal" INTEGER NULL,
    CONSTRAINT "AK_tblSetCard_UUID" UNIQUE ("UUID"),
    CONSTRAINT "FK_tblSetCard_tblSet_fkSet" FOREIGN KEY ("fkSet") REFERENCES "tblSet" ("pkSet")
);

CREATE TABLE "tblSetLanguage" (
    "fkSet" INTEGER NOT NULL,
    "fkLanguage" INTEGER NOT NULL,
    CONSTRAINT "PK_tblSetLanguage" PRIMARY KEY ("fkLanguage", "fkSet"),
    CONSTRAINT "FK_tblSetLanguage_tblLanguage_fkLanguage" FOREIGN KEY ("fkLanguage") REFERENCES "tblLanguage" ("pkLanguage") ON DELETE CASCADE,
    CONSTRAINT "FK_tblSetLanguage_tblSet_fkSet" FOREIGN KEY ("fkSet") REFERENCES "tblSet" ("pkSet") ON DELETE CASCADE
);

CREATE TABLE "tblSetCardAvailability" (
    "fkSetCard" INTEGER NOT NULL,
    "fkAvailability" INTEGER NOT NULL,
    CONSTRAINT "PK_tblSetCardAvailability" PRIMARY KEY ("fkAvailability", "fkSetCard"),
    CONSTRAINT "FK_tblSetCardAvailability_tblAvailability_fkAvailability" FOREIGN KEY ("fkAvailability") REFERENCES "tblAvailability" ("pkAvailability") ON DELETE CASCADE,
    CONSTRAINT "FK_tblSetCardAvailability_tblSetCard_fkSetCard" FOREIGN KEY ("fkSetCard") REFERENCES "tblSetCard" ("pkSetCard") ON DELETE CASCADE
);

CREATE TABLE "tblSetCardBoosterType" (
    "fkSetCard" INTEGER NOT NULL,
    "fkBoosterType" INTEGER NOT NULL,
    CONSTRAINT "PK_tblSetCardBoosterType" PRIMARY KEY ("fkBoosterType", "fkSetCard"),
    CONSTRAINT "FK_tblSetCardBoosterType_tblBoosterType_fkBoosterType" FOREIGN KEY ("fkBoosterType") REFERENCES "tblBoosterType" ("pkBoosterType") ON DELETE CASCADE,
    CONSTRAINT "FK_tblSetCardBoosterType_tblSetCard_fkSetCard" FOREIGN KEY ("fkSetCard") REFERENCES "tblSetCard" ("pkSetCard") ON DELETE CASCADE
);

CREATE TABLE "tblSetCardColor" (
    "fkSetCard" INTEGER NOT NULL,
    "fkColor" INTEGER NOT NULL,
    CONSTRAINT "PK_tblSetCardColor" PRIMARY KEY ("fkColor", "fkSetCard"),
    CONSTRAINT "FK_tblSetCardColor_tblColor_fkColor" FOREIGN KEY ("fkColor") REFERENCES "tblColor" ("pkColor") ON DELETE CASCADE,
    CONSTRAINT "FK_tblSetCardColor_tblSetCard_fkSetCard" FOREIGN KEY ("fkSetCard") REFERENCES "tblSetCard" ("pkSetCard") ON DELETE CASCADE
);

CREATE TABLE "tblSetCardColorIdentity" (
    "fkSetCard" INTEGER NOT NULL,
    "fkColorIdentity" INTEGER NOT NULL,
    CONSTRAINT "PK_tblSetCardColorIdentity" PRIMARY KEY ("fkColorIdentity", "fkSetCard"),
    CONSTRAINT "FK_tblSetCardColorIdentity_tblColorIdentity_fkColorIdentity" FOREIGN KEY ("fkColorIdentity") REFERENCES "tblColorIdentity" ("pkColorIdentity") ON DELETE CASCADE,
    CONSTRAINT "FK_tblSetCardColorIdentity_tblSetCard_fkSetCard" FOREIGN KEY ("fkSetCard") REFERENCES "tblSetCard" ("pkSetCard") ON DELETE CASCADE
);

CREATE TABLE "tblSetCardFinish" (
    "fkSetCard" INTEGER NOT NULL,
    "fkFinish" INTEGER NOT NULL,
    CONSTRAINT "PK_tblSetCardFinish" PRIMARY KEY ("fkFinish", "fkSetCard"),
    CONSTRAINT "FK_tblSetCardFinish_tblFinish_fkFinish" FOREIGN KEY ("fkFinish") REFERENCES "tblFinish" ("pkFinish") ON DELETE CASCADE,
    CONSTRAINT "FK_tblSetCardFinish_tblSetCard_fkSetCard" FOREIGN KEY ("fkSetCard") REFERENCES "tblSetCard" ("pkSetCard") ON DELETE CASCADE
);

CREATE TABLE "tblSetCardForeignData" (
    "pkSetCardForeignData" INTEGER NOT NULL CONSTRAINT "PK_tblSetCardForeignData" PRIMARY KEY AUTOINCREMENT,
    "fkSetCard" INTEGER NOT NULL,
    "FaceName" TEXT NULL,
    "Language" TEXT NULL,
    "Name" TEXT NULL,
    "Type" TEXT NULL,
    "FlavorText" TEXT NULL,
    "MultiverseID" TEXT NULL,
    "Text" TEXT NULL,
    CONSTRAINT "FK_tblSetCardForeignData_tblSetCard_fkSetCard" FOREIGN KEY ("fkSetCard") REFERENCES "tblSetCard" ("pkSetCard") ON DELETE CASCADE
);

CREATE TABLE "tblSetCardKeyword" (
    "fkSetCard" INTEGER NOT NULL,
    "fkKeyword" INTEGER NOT NULL,
    CONSTRAINT "PK_tblSetCardKeyword" PRIMARY KEY ("fkKeyword", "fkSetCard"),
    CONSTRAINT "FK_tblSetCardKeyword_tblKeyword_fkKeyword" FOREIGN KEY ("fkKeyword") REFERENCES "tblKeyword" ("pkKeyword") ON DELETE CASCADE,
    CONSTRAINT "FK_tblSetCardKeyword_tblSetCard_fkSetCard" FOREIGN KEY ("fkSetCard") REFERENCES "tblSetCard" ("pkSetCard") ON DELETE CASCADE
);

CREATE TABLE "tblSetCardPrinting" (
    "pkSetCardPrinting" INTEGER NOT NULL CONSTRAINT "PK_tblSetCardPrinting" PRIMARY KEY AUTOINCREMENT,
    "fkSetCard" INTEGER NOT NULL,
    "PrintingSetCode" TEXT NOT NULL,
    CONSTRAINT "FK_tblSetCardPrinting_tblSetCard_fkSetCard" FOREIGN KEY ("fkSetCard") REFERENCES "tblSetCard" ("pkSetCard") ON DELETE CASCADE
);

CREATE TABLE "tblSetCardRuling" (
    "pkSetCardRuling" INTEGER NOT NULL CONSTRAINT "PK_tblSetCardRuling" PRIMARY KEY AUTOINCREMENT,
    "fkSetCard" INTEGER NOT NULL,
    "RulingDate" TEXT NULL,
    "RulingText" TEXT NULL,
    CONSTRAINT "FK_tblSetCardRuling_tblSetCard_fkSetCard" FOREIGN KEY ("fkSetCard") REFERENCES "tblSetCard" ("pkSetCard") ON DELETE CASCADE
);

CREATE TABLE "tblSetCardSubtype" (
    "fkSetCard" INTEGER NOT NULL,
    "fkSubtype" INTEGER NOT NULL,
    CONSTRAINT "PK_tblSetCardSubtype" PRIMARY KEY ("fkSubtype", "fkSetCard"),
    CONSTRAINT "FK_tblSetCardSubtype_tblSetCard_fkSetCard" FOREIGN KEY ("fkSetCard") REFERENCES "tblSetCard" ("pkSetCard") ON DELETE CASCADE,
    CONSTRAINT "FK_tblSetCardSubtype_tblSubtype_fkSubtype" FOREIGN KEY ("fkSubtype") REFERENCES "tblSubtype" ("pkSubtype") ON DELETE CASCADE
);

CREATE TABLE "tblSetCardSupertype" (
    "fkSetCard" INTEGER NOT NULL,
    "fkSupertype" INTEGER NOT NULL,
    CONSTRAINT "PK_tblSetCardSupertype" PRIMARY KEY ("fkSupertype", "fkSetCard"),
    CONSTRAINT "FK_tblSetCardSupertype_tblSetCard_fkSetCard" FOREIGN KEY ("fkSetCard") REFERENCES "tblSetCard" ("pkSetCard") ON DELETE CASCADE,
    CONSTRAINT "FK_tblSetCardSupertype_tblSupertype_fkSupertype" FOREIGN KEY ("fkSupertype") REFERENCES "tblSupertype" ("pkSupertype") ON DELETE CASCADE
);

CREATE TABLE "tblSetCardType" (
    "fkSetCard" INTEGER NOT NULL,
    "fkCardType" INTEGER NOT NULL,
    CONSTRAINT "PK_tblSetCardType" PRIMARY KEY ("fkCardType", "fkSetCard"),
    CONSTRAINT "FK_tblSetCardType_tblCardType_fkCardType" FOREIGN KEY ("fkCardType") REFERENCES "tblCardType" ("pkCardType") ON DELETE CASCADE,
    CONSTRAINT "FK_tblSetCardType_tblSetCard_fkSetCard" FOREIGN KEY ("fkSetCard") REFERENCES "tblSetCard" ("pkSetCard") ON DELETE CASCADE
);

CREATE INDEX "IX_tblKeyword_fkKeywordType" ON "tblKeyword" ("fkKeywordType");

CREATE INDEX "IX_tblSetCard_fkSet" ON "tblSetCard" ("fkSet");

CREATE INDEX "IX_tblSetCardAvailability_fkSetCard" ON "tblSetCardAvailability" ("fkSetCard");

CREATE INDEX "IX_tblSetCardBoosterType_fkSetCard" ON "tblSetCardBoosterType" ("fkSetCard");

CREATE INDEX "IX_tblSetCardColor_fkSetCard" ON "tblSetCardColor" ("fkSetCard");

CREATE INDEX "IX_tblSetCardColorIdentity_fkSetCard" ON "tblSetCardColorIdentity" ("fkSetCard");

CREATE INDEX "IX_tblSetCardFinish_fkSetCard" ON "tblSetCardFinish" ("fkSetCard");

CREATE INDEX "IX_tblSetCardForeignData_fkSetCard" ON "tblSetCardForeignData" ("fkSetCard");

CREATE INDEX "IX_tblSetCardKeyword_fkSetCard" ON "tblSetCardKeyword" ("fkSetCard");

CREATE INDEX "IX_tblSetCardPrinting_fkSetCard" ON "tblSetCardPrinting" ("fkSetCard");

CREATE INDEX "IX_tblSetCardRuling_fkSetCard" ON "tblSetCardRuling" ("fkSetCard");

CREATE INDEX "IX_tblSetCardSubtype_fkSetCard" ON "tblSetCardSubtype" ("fkSetCard");

CREATE INDEX "IX_tblSetCardSupertype_fkSetCard" ON "tblSetCardSupertype" ("fkSetCard");

CREATE INDEX "IX_tblSetCardType_fkSetCard" ON "tblSetCardType" ("fkSetCard");

CREATE INDEX "IX_tblSetLanguage_fkSet" ON "tblSetLanguage" ("fkSet");

COMMIT;