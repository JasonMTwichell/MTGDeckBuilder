using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTGDeckBuilder.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAvailability",
                columns: table => new
                {
                    pkAvailability = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AvailabilityDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAvailability", x => x.pkAvailability);
                });

            migrationBuilder.CreateTable(
                name: "tblBoosterType",
                columns: table => new
                {
                    pkBoosterType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BoosterTypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBoosterType", x => x.pkBoosterType);
                });

            migrationBuilder.CreateTable(
                name: "tblBorderColor",
                columns: table => new
                {
                    pkBorderColor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BorderColorDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBorderColor", x => x.pkBorderColor);
                });

            migrationBuilder.CreateTable(
                name: "tblCardType",
                columns: table => new
                {
                    pkCardType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardTypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardType", x => x.pkCardType);
                });

            migrationBuilder.CreateTable(
                name: "tblColor",
                columns: table => new
                {
                    pkColor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColorDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblColor", x => x.pkColor);
                });

            migrationBuilder.CreateTable(
                name: "tblColorIdentity",
                columns: table => new
                {
                    pkColorIdentity = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColorIdentityDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblColorIdentity", x => x.pkColorIdentity);
                });

            migrationBuilder.CreateTable(
                name: "tblColorIndicator",
                columns: table => new
                {
                    pkColorIndicator = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColorIndicatorDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblColorIndicator", x => x.pkColorIndicator);
                });

            migrationBuilder.CreateTable(
                name: "tblDeckType",
                columns: table => new
                {
                    pkDeckType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeckTypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDeckType", x => x.pkDeckType);
                });

            migrationBuilder.CreateTable(
                name: "tblDuelDeck",
                columns: table => new
                {
                    pkDuelDeck = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DuelDeckDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDuelDeck", x => x.pkDuelDeck);
                });

            migrationBuilder.CreateTable(
                name: "tblFinish",
                columns: table => new
                {
                    pkFinish = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FinishDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFinish", x => x.pkFinish);
                });

            migrationBuilder.CreateTable(
                name: "tblForeignDataLanguage",
                columns: table => new
                {
                    pkForeignDataLanguage = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ForeignDataLanguageDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblForeignDataLanguage", x => x.pkForeignDataLanguage);
                });

            migrationBuilder.CreateTable(
                name: "tblFrameEffect",
                columns: table => new
                {
                    pkFrameEffect = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FrameEffectDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFrameEffect", x => x.pkFrameEffect);
                });

            migrationBuilder.CreateTable(
                name: "tblFrameVersion",
                columns: table => new
                {
                    pkFrameVersion = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FrameVersionDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFrameVersion", x => x.pkFrameVersion);
                });

            migrationBuilder.CreateTable(
                name: "tblKeywordType",
                columns: table => new
                {
                    pkKeywordType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KeywordTypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKeywordType", x => x.pkKeywordType);
                });

            migrationBuilder.CreateTable(
                name: "tblLanguage",
                columns: table => new
                {
                    pkLanguage = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LanguageDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLanguage", x => x.pkLanguage);
                });

            migrationBuilder.CreateTable(
                name: "tblLayout",
                columns: table => new
                {
                    pkLayout = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LayoutDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLayout", x => x.pkLayout);
                });

            migrationBuilder.CreateTable(
                name: "tblMeta",
                columns: table => new
                {
                    pkMeta = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MetaDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    DateApplied = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMeta", x => x.pkMeta);
                });

            migrationBuilder.CreateTable(
                name: "tblPromoType",
                columns: table => new
                {
                    pkPromoType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PromoTypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPromoType", x => x.pkPromoType);
                });

            migrationBuilder.CreateTable(
                name: "tblRarity",
                columns: table => new
                {
                    pkRarity = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RarityDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRarity", x => x.pkRarity);
                });

            migrationBuilder.CreateTable(
                name: "tblSecurityStamp",
                columns: table => new
                {
                    pkSecurityStamp = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SecurityStampDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSecurityStamp", x => x.pkSecurityStamp);
                });

            migrationBuilder.CreateTable(
                name: "tblSet",
                columns: table => new
                {
                    pkSet = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseSetSize = table.Column<int>(type: "INTEGER", nullable: true),
                    Block = table.Column<string>(type: "TEXT", nullable: true),
                    CardsphereSetId = table.Column<int>(type: "INTEGER", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    IsFoilOnly = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsNonFoilOnly = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsOnlineOnly = table.Column<bool>(type: "INTEGER", nullable: true),
                    KeyruneCode = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TcgplayerGroupId = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalSetSize = table.Column<int>(type: "INTEGER", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSet", x => x.pkSet);
                    table.UniqueConstraint("AK_tblSet_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "tblSetType",
                columns: table => new
                {
                    pkSetType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SetTypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetType", x => x.pkSetType);
                });

            migrationBuilder.CreateTable(
                name: "tblSide",
                columns: table => new
                {
                    pkSide = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SideDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSide", x => x.pkSide);
                });

            migrationBuilder.CreateTable(
                name: "tblSubtype",
                columns: table => new
                {
                    pkSubtype = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubtypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSubtype", x => x.pkSubtype);
                });

            migrationBuilder.CreateTable(
                name: "tblSupertype",
                columns: table => new
                {
                    pkSupertype = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SupertypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSupertype", x => x.pkSupertype);
                });

            migrationBuilder.CreateTable(
                name: "tblTcgPlayerSkuCondition",
                columns: table => new
                {
                    pkTcgPlayerSkuCondition = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConditionDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTcgPlayerSkuCondition", x => x.pkTcgPlayerSkuCondition);
                });

            migrationBuilder.CreateTable(
                name: "tblTcgPlayerSkuFinish",
                columns: table => new
                {
                    pkTcgPlayerSkuFinish = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FinishDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTcgPlayerSkuFinish", x => x.pkTcgPlayerSkuFinish);
                });

            migrationBuilder.CreateTable(
                name: "tblTcgPlayerSkuLanguage",
                columns: table => new
                {
                    pkTcgPlayerSkuLanguage = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LanguageDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTcgPlayerSkuLanguage", x => x.pkTcgPlayerSkuLanguage);
                });

            migrationBuilder.CreateTable(
                name: "tblTcgPlayerSkuPrinting",
                columns: table => new
                {
                    pkTcgPlayerSkuPrinting = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrintingDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTcgPlayerSkuPrinting", x => x.pkTcgPlayerSkuPrinting);
                });

            migrationBuilder.CreateTable(
                name: "tblWatermark",
                columns: table => new
                {
                    pkWatermark = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WatermarkDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWatermark", x => x.pkWatermark);
                });

            migrationBuilder.CreateTable(
                name: "tblKeyword",
                columns: table => new
                {
                    pkKeyword = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fkKeywordType = table.Column<int>(type: "INTEGER", nullable: true),
                    KeywordDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKeyword", x => x.pkKeyword);
                    table.ForeignKey(
                        name: "FK_tblKeyword_tblKeywordType_fkKeywordType",
                        column: x => x.fkKeywordType,
                        principalTable: "tblKeywordType",
                        principalColumn: "pkKeywordType");
                });

            migrationBuilder.CreateTable(
                name: "tblSetCard",
                columns: table => new
                {
                    pkSetCard = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fkSet = table.Column<int>(type: "INTEGER", nullable: true),
                    Artist = table.Column<string>(type: "TEXT", nullable: true),
                    BorderColor = table.Column<string>(type: "TEXT", nullable: true),
                    ConvertedManaCost = table.Column<double>(type: "REAL", nullable: true),
                    EdhrecRank = table.Column<int>(type: "INTEGER", nullable: true),
                    FrameVersion = table.Column<string>(type: "TEXT", nullable: true),
                    HasFoil = table.Column<bool>(type: "INTEGER", nullable: true),
                    HasNonFoil = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsReprint = table.Column<bool>(type: "INTEGER", nullable: true),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Layout = table.Column<string>(type: "TEXT", nullable: true),
                    ManaCost = table.Column<string>(type: "TEXT", nullable: true),
                    ManaValue = table.Column<double>(type: "REAL", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<string>(type: "TEXT", nullable: true),
                    OriginalText = table.Column<string>(type: "TEXT", nullable: true),
                    OriginalType = table.Column<string>(type: "TEXT", nullable: true),
                    Rarity = table.Column<string>(type: "TEXT", nullable: true),
                    SetCode = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    UUID = table.Column<string>(type: "TEXT", nullable: false),
                    CardKingdomId = table.Column<string>(type: "TEXT", nullable: true),
                    CardsphereId = table.Column<string>(type: "TEXT", nullable: true),
                    McmId = table.Column<string>(type: "TEXT", nullable: true),
                    MtgjsonV4Id = table.Column<string>(type: "TEXT", nullable: true),
                    MultiverseId = table.Column<string>(type: "TEXT", nullable: true),
                    ScryfallId = table.Column<string>(type: "TEXT", nullable: true),
                    ScryfallIllustrationId = table.Column<string>(type: "TEXT", nullable: true),
                    ScryfallOracleId = table.Column<string>(type: "TEXT", nullable: true),
                    TcgplayerProductId = table.Column<string>(type: "TEXT", nullable: true),
                    IsCommanderFormatLegal = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsDuelFormatLegal = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsLegacyFormatLegal = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsOldschoolFormatLegal = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsPennyFormatLegal = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsPremodernFormatLegal = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsVintageFormatLegal = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCard", x => x.pkSetCard);
                    table.UniqueConstraint("AK_tblSetCard_UUID", x => x.UUID);
                    table.ForeignKey(
                        name: "FK_tblSetCard_tblSet_fkSet",
                        column: x => x.fkSet,
                        principalTable: "tblSet",
                        principalColumn: "pkSet");
                });

            migrationBuilder.CreateTable(
                name: "tblSetLanguage",
                columns: table => new
                {
                    fkSet = table.Column<int>(type: "INTEGER", nullable: false),
                    fkLanguage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetLanguage", x => new { x.fkLanguage, x.fkSet });
                    table.ForeignKey(
                        name: "FK_tblSetLanguage_tblLanguage_fkLanguage",
                        column: x => x.fkLanguage,
                        principalTable: "tblLanguage",
                        principalColumn: "pkLanguage",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSetLanguage_tblSet_fkSet",
                        column: x => x.fkSet,
                        principalTable: "tblSet",
                        principalColumn: "pkSet",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSetCardAvailability",
                columns: table => new
                {
                    fkSetCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkAvailability = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCardAvailability", x => new { x.fkAvailability, x.fkSetCard });
                    table.ForeignKey(
                        name: "FK_tblSetCardAvailability_tblAvailability_fkAvailability",
                        column: x => x.fkAvailability,
                        principalTable: "tblAvailability",
                        principalColumn: "pkAvailability",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSetCardAvailability_tblSetCard_fkSetCard",
                        column: x => x.fkSetCard,
                        principalTable: "tblSetCard",
                        principalColumn: "pkSetCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSetCardBoosterType",
                columns: table => new
                {
                    fkSetCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkBoosterType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCardBoosterType", x => new { x.fkBoosterType, x.fkSetCard });
                    table.ForeignKey(
                        name: "FK_tblSetCardBoosterType_tblBoosterType_fkBoosterType",
                        column: x => x.fkBoosterType,
                        principalTable: "tblBoosterType",
                        principalColumn: "pkBoosterType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSetCardBoosterType_tblSetCard_fkSetCard",
                        column: x => x.fkSetCard,
                        principalTable: "tblSetCard",
                        principalColumn: "pkSetCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSetCardColor",
                columns: table => new
                {
                    fkSetCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkColor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCardColor", x => new { x.fkColor, x.fkSetCard });
                    table.ForeignKey(
                        name: "FK_tblSetCardColor_tblColor_fkColor",
                        column: x => x.fkColor,
                        principalTable: "tblColor",
                        principalColumn: "pkColor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSetCardColor_tblSetCard_fkSetCard",
                        column: x => x.fkSetCard,
                        principalTable: "tblSetCard",
                        principalColumn: "pkSetCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSetCardColorIdentity",
                columns: table => new
                {
                    fkSetCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkColorIdentity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCardColorIdentity", x => new { x.fkColorIdentity, x.fkSetCard });
                    table.ForeignKey(
                        name: "FK_tblSetCardColorIdentity_tblColorIdentity_fkColorIdentity",
                        column: x => x.fkColorIdentity,
                        principalTable: "tblColorIdentity",
                        principalColumn: "pkColorIdentity",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSetCardColorIdentity_tblSetCard_fkSetCard",
                        column: x => x.fkSetCard,
                        principalTable: "tblSetCard",
                        principalColumn: "pkSetCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSetCardFinish",
                columns: table => new
                {
                    fkSetCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkFinish = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCardFinish", x => new { x.fkFinish, x.fkSetCard });
                    table.ForeignKey(
                        name: "FK_tblSetCardFinish_tblFinish_fkFinish",
                        column: x => x.fkFinish,
                        principalTable: "tblFinish",
                        principalColumn: "pkFinish",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSetCardFinish_tblSetCard_fkSetCard",
                        column: x => x.fkSetCard,
                        principalTable: "tblSetCard",
                        principalColumn: "pkSetCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSetCardForeignData",
                columns: table => new
                {
                    pkSetCardForeignData = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fkSetCard = table.Column<int>(type: "INTEGER", nullable: false),
                    FaceName = table.Column<string>(type: "TEXT", nullable: true),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    FlavorText = table.Column<string>(type: "TEXT", nullable: true),
                    MultiverseID = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCardForeignData", x => x.pkSetCardForeignData);
                    table.ForeignKey(
                        name: "FK_tblSetCardForeignData_tblSetCard_fkSetCard",
                        column: x => x.fkSetCard,
                        principalTable: "tblSetCard",
                        principalColumn: "pkSetCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSetCardKeyword",
                columns: table => new
                {
                    fkSetCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkKeyword = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCardKeyword", x => new { x.fkKeyword, x.fkSetCard });
                    table.ForeignKey(
                        name: "FK_tblSetCardKeyword_tblKeyword_fkKeyword",
                        column: x => x.fkKeyword,
                        principalTable: "tblKeyword",
                        principalColumn: "pkKeyword",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSetCardKeyword_tblSetCard_fkSetCard",
                        column: x => x.fkSetCard,
                        principalTable: "tblSetCard",
                        principalColumn: "pkSetCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSetCardPrinting",
                columns: table => new
                {
                    pkSetCardPrinting = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fkSetCard = table.Column<int>(type: "INTEGER", nullable: false),
                    PrintingSetCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCardPrinting", x => x.pkSetCardPrinting);
                    table.ForeignKey(
                        name: "FK_tblSetCardPrinting_tblSetCard_fkSetCard",
                        column: x => x.fkSetCard,
                        principalTable: "tblSetCard",
                        principalColumn: "pkSetCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSetCardRuling",
                columns: table => new
                {
                    pkSetCardRuling = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fkSetCard = table.Column<int>(type: "INTEGER", nullable: false),
                    RulingDate = table.Column<string>(type: "TEXT", nullable: true),
                    RulingText = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCardRuling", x => x.pkSetCardRuling);
                    table.ForeignKey(
                        name: "FK_tblSetCardRuling_tblSetCard_fkSetCard",
                        column: x => x.fkSetCard,
                        principalTable: "tblSetCard",
                        principalColumn: "pkSetCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSetCardSubtype",
                columns: table => new
                {
                    fkSetCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkSubtype = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCardSubtype", x => new { x.fkSubtype, x.fkSetCard });
                    table.ForeignKey(
                        name: "FK_tblSetCardSubtype_tblSetCard_fkSetCard",
                        column: x => x.fkSetCard,
                        principalTable: "tblSetCard",
                        principalColumn: "pkSetCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSetCardSubtype_tblSubtype_fkSubtype",
                        column: x => x.fkSubtype,
                        principalTable: "tblSubtype",
                        principalColumn: "pkSubtype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSetCardSupertype",
                columns: table => new
                {
                    fkSetCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkSupertype = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCardSupertype", x => new { x.fkSupertype, x.fkSetCard });
                    table.ForeignKey(
                        name: "FK_tblSetCardSupertype_tblSetCard_fkSetCard",
                        column: x => x.fkSetCard,
                        principalTable: "tblSetCard",
                        principalColumn: "pkSetCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSetCardSupertype_tblSupertype_fkSupertype",
                        column: x => x.fkSupertype,
                        principalTable: "tblSupertype",
                        principalColumn: "pkSupertype",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSetCardType",
                columns: table => new
                {
                    fkSetCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkCardType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSetCardType", x => new { x.fkCardType, x.fkSetCard });
                    table.ForeignKey(
                        name: "FK_tblSetCardType_tblCardType_fkCardType",
                        column: x => x.fkCardType,
                        principalTable: "tblCardType",
                        principalColumn: "pkCardType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblSetCardType_tblSetCard_fkSetCard",
                        column: x => x.fkSetCard,
                        principalTable: "tblSetCard",
                        principalColumn: "pkSetCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblKeyword_fkKeywordType",
                table: "tblKeyword",
                column: "fkKeywordType");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCard_fkSet",
                table: "tblSetCard",
                column: "fkSet");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCardAvailability_fkSetCard",
                table: "tblSetCardAvailability",
                column: "fkSetCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCardBoosterType_fkSetCard",
                table: "tblSetCardBoosterType",
                column: "fkSetCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCardColor_fkSetCard",
                table: "tblSetCardColor",
                column: "fkSetCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCardColorIdentity_fkSetCard",
                table: "tblSetCardColorIdentity",
                column: "fkSetCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCardFinish_fkSetCard",
                table: "tblSetCardFinish",
                column: "fkSetCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCardForeignData_fkSetCard",
                table: "tblSetCardForeignData",
                column: "fkSetCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCardKeyword_fkSetCard",
                table: "tblSetCardKeyword",
                column: "fkSetCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCardPrinting_fkSetCard",
                table: "tblSetCardPrinting",
                column: "fkSetCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCardRuling_fkSetCard",
                table: "tblSetCardRuling",
                column: "fkSetCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCardSubtype_fkSetCard",
                table: "tblSetCardSubtype",
                column: "fkSetCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCardSupertype_fkSetCard",
                table: "tblSetCardSupertype",
                column: "fkSetCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetCardType_fkSetCard",
                table: "tblSetCardType",
                column: "fkSetCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSetLanguage_fkSet",
                table: "tblSetLanguage",
                column: "fkSet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblBorderColor");

            migrationBuilder.DropTable(
                name: "tblColorIndicator");

            migrationBuilder.DropTable(
                name: "tblDeckType");

            migrationBuilder.DropTable(
                name: "tblDuelDeck");

            migrationBuilder.DropTable(
                name: "tblForeignDataLanguage");

            migrationBuilder.DropTable(
                name: "tblFrameEffect");

            migrationBuilder.DropTable(
                name: "tblFrameVersion");

            migrationBuilder.DropTable(
                name: "tblLayout");

            migrationBuilder.DropTable(
                name: "tblMeta");

            migrationBuilder.DropTable(
                name: "tblPromoType");

            migrationBuilder.DropTable(
                name: "tblRarity");

            migrationBuilder.DropTable(
                name: "tblSecurityStamp");

            migrationBuilder.DropTable(
                name: "tblSetCardAvailability");

            migrationBuilder.DropTable(
                name: "tblSetCardBoosterType");

            migrationBuilder.DropTable(
                name: "tblSetCardColor");

            migrationBuilder.DropTable(
                name: "tblSetCardColorIdentity");

            migrationBuilder.DropTable(
                name: "tblSetCardFinish");

            migrationBuilder.DropTable(
                name: "tblSetCardForeignData");

            migrationBuilder.DropTable(
                name: "tblSetCardKeyword");

            migrationBuilder.DropTable(
                name: "tblSetCardPrinting");

            migrationBuilder.DropTable(
                name: "tblSetCardRuling");

            migrationBuilder.DropTable(
                name: "tblSetCardSubtype");

            migrationBuilder.DropTable(
                name: "tblSetCardSupertype");

            migrationBuilder.DropTable(
                name: "tblSetCardType");

            migrationBuilder.DropTable(
                name: "tblSetLanguage");

            migrationBuilder.DropTable(
                name: "tblSetType");

            migrationBuilder.DropTable(
                name: "tblSide");

            migrationBuilder.DropTable(
                name: "tblTcgPlayerSkuCondition");

            migrationBuilder.DropTable(
                name: "tblTcgPlayerSkuFinish");

            migrationBuilder.DropTable(
                name: "tblTcgPlayerSkuLanguage");

            migrationBuilder.DropTable(
                name: "tblTcgPlayerSkuPrinting");

            migrationBuilder.DropTable(
                name: "tblWatermark");

            migrationBuilder.DropTable(
                name: "tblAvailability");

            migrationBuilder.DropTable(
                name: "tblBoosterType");

            migrationBuilder.DropTable(
                name: "tblColor");

            migrationBuilder.DropTable(
                name: "tblColorIdentity");

            migrationBuilder.DropTable(
                name: "tblFinish");

            migrationBuilder.DropTable(
                name: "tblKeyword");

            migrationBuilder.DropTable(
                name: "tblSubtype");

            migrationBuilder.DropTable(
                name: "tblSupertype");

            migrationBuilder.DropTable(
                name: "tblCardType");

            migrationBuilder.DropTable(
                name: "tblSetCard");

            migrationBuilder.DropTable(
                name: "tblLanguage");

            migrationBuilder.DropTable(
                name: "tblKeywordType");

            migrationBuilder.DropTable(
                name: "tblSet");
        }
    }
}
