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

    CREATE TABLE "tblKeyword" (
        "pkKeyword" INTEGER NOT NULL CONSTRAINT "PK_tblKeyword" PRIMARY KEY AUTOINCREMENT,
        "Keyword" TEXT NOT NULL
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

    CREATE TABLE "tblLegality" (
        "pkLegality" INTEGER NOT NULL CONSTRAINT "PK_tblLegality" PRIMARY KEY AUTOINCREMENT,
        "fkCard" INTEGER NOT NULL,
        "Format" TEXT NOT NULL,
        "Status" TEXT NOT NULL,
        CONSTRAINT "FK_tblLegality_tblCard_fkCard" FOREIGN KEY ("fkCard") REFERENCES "tblCard" ("pkCard") ON DELETE CASCADE
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

    CREATE INDEX "IX_tblCard_ManaValue" ON "tblCard" ("ManaValue");

    CREATE INDEX "IX_tblCard_Name" ON "tblCard" ("Name");

    CREATE INDEX "IX_tblCard_Type" ON "tblCard" ("Type");

    CREATE INDEX "IX_tblCardColor_fkColor" ON "tblCardColor" ("fkColor");

    CREATE INDEX "IX_tblCardColorIdentity_fkColorIdentity" ON "tblCardColorIdentity" ("fkColorIdentity");

    CREATE INDEX "IX_tblCardKeywordData_fkKeyword" ON "tblCardKeywordData" ("fkKeyword");

    CREATE INDEX "IX_tblCardSubType_fkSubType" ON "tblCardSubType" ("fkSubType");

    CREATE INDEX "IX_tblCardSuperType_fkSuperType" ON "tblCardSuperType" ("fkSuperType");

    CREATE INDEX "IX_tblCardType_fkType" ON "tblCardType" ("fkType");

    CREATE INDEX "IX_tblColor_ColorName" ON "tblColor" ("ColorName");

    CREATE INDEX "IX_tblColorIdentity_ColorIdentityName" ON "tblColorIdentity" ("ColorIdentityName");

    CREATE INDEX "IX_tblKeyword_Keyword" ON "tblKeyword" ("Keyword");

    CREATE INDEX "IX_tblLegality_fkCard" ON "tblLegality" ("fkCard");

    CREATE INDEX "IX_tblPurchaseInformation_fkCard" ON "tblPurchaseInformation" ("fkCard");

    CREATE INDEX "IX_tblSubType_SubTypeName" ON "tblSubType" ("SubTypeName");

    CREATE INDEX "IX_tblSuperType_SuperTypeName" ON "tblSuperType" ("SuperTypeName");

    CREATE INDEX "IX_tblType_TypeName" ON "tblType" ("TypeName");

COMMIT;