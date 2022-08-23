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
                name: "tblColor",
                columns: table => new
                {
                    pkColor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Color = table.Column<string>(type: "TEXT", nullable: false)
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
                    ColorIdentity = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblColorIdentity", x => x.pkColorIdentity);
                });

            migrationBuilder.CreateTable(
                name: "tblFileVersion",
                columns: table => new
                {
                    pkVersion = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    VersionDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFileVersion", x => x.pkVersion);
                });

            migrationBuilder.CreateTable(
                name: "tblFormat",
                columns: table => new
                {
                    pkFormat = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Format = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFormat", x => x.pkFormat);
                });

            migrationBuilder.CreateTable(
                name: "tblKeyword",
                columns: table => new
                {
                    pkKeyword = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Keyword = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKeyword", x => x.pkKeyword);
                });

            migrationBuilder.CreateTable(
                name: "tblSet",
                columns: table => new
                {
                    pkSet = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SetCode = table.Column<string>(type: "TEXT", nullable: false),
                    SetName = table.Column<string>(type: "TEXT", nullable: false),
                    BaseSetSize = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalSetSize = table.Column<int>(type: "INTEGER", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SetType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSet", x => x.pkSet);
                });

            migrationBuilder.CreateTable(
                name: "tblSubType",
                columns: table => new
                {
                    pkSubType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSubType", x => x.pkSubType);
                });

            migrationBuilder.CreateTable(
                name: "tblSuperType",
                columns: table => new
                {
                    pkSuperType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SuperType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSuperType", x => x.pkSuperType);
                });

            migrationBuilder.CreateTable(
                name: "tblType",
                columns: table => new
                {
                    pkType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblType", x => x.pkType);
                });

            migrationBuilder.CreateTable(
                name: "tblCard",
                columns: table => new
                {
                    pkCard = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fkSet = table.Column<int>(type: "INTEGER", nullable: false),
                    UUID = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    AsciiName = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Layout = table.Column<string>(type: "TEXT", nullable: true),
                    Side = table.Column<string>(type: "TEXT", nullable: true),
                    ManaCost = table.Column<string>(type: "TEXT", nullable: true),
                    ManaValue = table.Column<double>(type: "REAL", nullable: true),
                    Loyalty = table.Column<string>(type: "TEXT", nullable: true),
                    HandModifier = table.Column<int>(type: "INTEGER", nullable: true),
                    LifeModifier = table.Column<int>(type: "INTEGER", nullable: true),
                    Power = table.Column<string>(type: "TEXT", nullable: true),
                    Toughness = table.Column<string>(type: "TEXT", nullable: true),
                    IsFunny = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsReserved = table.Column<bool>(type: "INTEGER", nullable: true),
                    HasAlternateDeckLimit = table.Column<bool>(type: "INTEGER", nullable: true),
                    FlavorText = table.Column<string>(type: "TEXT", nullable: true),
                    Rarity = table.Column<string>(type: "TEXT", nullable: true),
                    FaceName = table.Column<string>(type: "TEXT", nullable: true),
                    NumberInSet = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCard", x => x.pkCard);
                    table.ForeignKey(
                        name: "FK_tblCard_tblSet_fkSet",
                        column: x => x.fkSet,
                        principalTable: "tblSet",
                        principalColumn: "pkSet",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardColor",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkColor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardColor", x => new { x.fkCard, x.fkColor });
                    table.ForeignKey(
                        name: "FK_tblCardColor_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardColor_tblColor_fkColor",
                        column: x => x.fkColor,
                        principalTable: "tblColor",
                        principalColumn: "pkColor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardColorIdentity",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkColorIdentity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardColorIdentity", x => new { x.fkCard, x.fkColorIdentity });
                    table.ForeignKey(
                        name: "FK_tblCardColorIdentity_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardColorIdentity_tblColorIdentity_fkColorIdentity",
                        column: x => x.fkColorIdentity,
                        principalTable: "tblColorIdentity",
                        principalColumn: "pkColorIdentity",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardFormat",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkFormat = table.Column<int>(type: "INTEGER", nullable: false),
                    IsLegal = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardFormat", x => new { x.fkCard, x.fkFormat });
                    table.ForeignKey(
                        name: "FK_tblCardFormat_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardFormat_tblFormat_fkFormat",
                        column: x => x.fkFormat,
                        principalTable: "tblFormat",
                        principalColumn: "pkFormat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardKeywordData",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkKeyword = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardKeywordData", x => new { x.fkCard, x.fkKeyword });
                    table.ForeignKey(
                        name: "FK_tblCardKeywordData_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardKeywordData_tblKeyword_fkKeyword",
                        column: x => x.fkKeyword,
                        principalTable: "tblKeyword",
                        principalColumn: "pkKeyword",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardSubType",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkSubType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardSubType", x => new { x.fkCard, x.fkSubType });
                    table.ForeignKey(
                        name: "FK_tblCardSubType_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardSubType_tblSubType_fkSubType",
                        column: x => x.fkSubType,
                        principalTable: "tblSubType",
                        principalColumn: "pkSubType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardSuperType",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkSuperType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardSuperType", x => new { x.fkCard, x.fkSuperType });
                    table.ForeignKey(
                        name: "FK_tblCardSuperType_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardSuperType_tblSuperType_fkSuperType",
                        column: x => x.fkSuperType,
                        principalTable: "tblSuperType",
                        principalColumn: "pkSuperType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardType",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardType", x => new { x.fkCard, x.fkType });
                    table.ForeignKey(
                        name: "FK_tblCardType_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardType_tblType_fkType",
                        column: x => x.fkType,
                        principalTable: "tblType",
                        principalColumn: "pkType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPurchaseInformation",
                columns: table => new
                {
                    pkPurchaseInformation = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    StorefrontName = table.Column<string>(type: "TEXT", nullable: false),
                    CardURI = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPurchaseInformation", x => x.pkPurchaseInformation);
                    table.ForeignKey(
                        name: "FK_tblPurchaseInformation_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserDeck",
                columns: table => new
                {
                    pkUserDeck = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeckName = table.Column<string>(type: "TEXT", nullable: false),
                    DeckDescription = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CardDatapkCard = table.Column<int>(type: "INTEGER", nullable: true),
                    FormatDatapkFormat = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserDeck", x => x.pkUserDeck);
                    table.ForeignKey(
                        name: "FK_tblUserDeck_tblCard_CardDatapkCard",
                        column: x => x.CardDatapkCard,
                        principalTable: "tblCard",
                        principalColumn: "pkCard");
                    table.ForeignKey(
                        name: "FK_tblUserDeck_tblFormat_FormatDatapkFormat",
                        column: x => x.FormatDatapkFormat,
                        principalTable: "tblFormat",
                        principalColumn: "pkFormat");
                });

            migrationBuilder.CreateTable(
                name: "tblUserDeckCard",
                columns: table => new
                {
                    fkUserDeck = table.Column<int>(type: "INTEGER", nullable: false),
                    CardUUID = table.Column<string>(type: "TEXT", nullable: false),
                    NumCopies = table.Column<int>(type: "INTEGER", nullable: false),
                    CardDatapkCard = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserDeckCard", x => new { x.fkUserDeck, x.CardUUID });
                    table.ForeignKey(
                        name: "FK_tblUserDeckCard_tblCard_CardDatapkCard",
                        column: x => x.CardDatapkCard,
                        principalTable: "tblCard",
                        principalColumn: "pkCard");
                    table.ForeignKey(
                        name: "FK_tblUserDeckCard_tblUserDeck_fkUserDeck",
                        column: x => x.fkUserDeck,
                        principalTable: "tblUserDeck",
                        principalColumn: "pkUserDeck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserDeckFormat",
                columns: table => new
                {
                    fkUserDeck = table.Column<int>(type: "INTEGER", nullable: false),
                    Format = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserDeckFormat", x => new { x.fkUserDeck, x.Format });
                    table.ForeignKey(
                        name: "FK_tblUserDeckFormat_tblUserDeck_fkUserDeck",
                        column: x => x.fkUserDeck,
                        principalTable: "tblUserDeck",
                        principalColumn: "pkUserDeck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserDeckSideboard",
                columns: table => new
                {
                    fkUserDeck = table.Column<int>(type: "INTEGER", nullable: false),
                    pkSideBoardData = table.Column<int>(type: "INTEGER", nullable: false),
                    CardDatapkCard = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserDeckSideboard", x => x.fkUserDeck);
                    table.ForeignKey(
                        name: "FK_tblUserDeckSideboard_tblCard_CardDatapkCard",
                        column: x => x.CardDatapkCard,
                        principalTable: "tblCard",
                        principalColumn: "pkCard");
                    table.ForeignKey(
                        name: "FK_tblUserDeckSideboard_tblUserDeck_fkUserDeck",
                        column: x => x.fkUserDeck,
                        principalTable: "tblUserDeck",
                        principalColumn: "pkUserDeck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserDeckSideboardCard",
                columns: table => new
                {
                    fkUserDeckSideboard = table.Column<int>(type: "INTEGER", nullable: false),
                    CardUUID = table.Column<string>(type: "TEXT", nullable: false),
                    NumCopies = table.Column<int>(type: "INTEGER", nullable: false),
                    CardDatapkCard = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserDeckSideboardCard", x => new { x.fkUserDeckSideboard, x.CardUUID });
                    table.ForeignKey(
                        name: "FK_tblUserDeckSideboardCard_tblCard_CardDatapkCard",
                        column: x => x.CardDatapkCard,
                        principalTable: "tblCard",
                        principalColumn: "pkCard");
                    table.ForeignKey(
                        name: "FK_tblUserDeckSideboardCard_tblUserDeckSideboard_fkUserDeckSideboard",
                        column: x => x.fkUserDeckSideboard,
                        principalTable: "tblUserDeckSideboard",
                        principalColumn: "fkUserDeck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCard_fkSet",
                table: "tblCard",
                column: "fkSet");

            migrationBuilder.CreateIndex(
                name: "IX_tblCard_ManaValue",
                table: "tblCard",
                column: "ManaValue");

            migrationBuilder.CreateIndex(
                name: "IX_tblCard_Name",
                table: "tblCard",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_tblCard_Type",
                table: "tblCard",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_tblCard_UUID",
                table: "tblCard",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblCardColor_fkColor",
                table: "tblCardColor",
                column: "fkColor");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardColorIdentity_fkColorIdentity",
                table: "tblCardColorIdentity",
                column: "fkColorIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardFormat_fkFormat",
                table: "tblCardFormat",
                column: "fkFormat");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardKeywordData_fkKeyword",
                table: "tblCardKeywordData",
                column: "fkKeyword");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardSubType_fkSubType",
                table: "tblCardSubType",
                column: "fkSubType");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardSuperType_fkSuperType",
                table: "tblCardSuperType",
                column: "fkSuperType");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardType_fkType",
                table: "tblCardType",
                column: "fkType");

            migrationBuilder.CreateIndex(
                name: "IX_tblColor_Color",
                table: "tblColor",
                column: "Color",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblColorIdentity_ColorIdentity",
                table: "tblColorIdentity",
                column: "ColorIdentity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblFormat_Format",
                table: "tblFormat",
                column: "Format",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblKeyword_Keyword",
                table: "tblKeyword",
                column: "Keyword",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseInformation_fkCard",
                table: "tblPurchaseInformation",
                column: "fkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSet_SetCode",
                table: "tblSet",
                column: "SetCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblSet_SetName",
                table: "tblSet",
                column: "SetName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblSubType_SubType",
                table: "tblSubType",
                column: "SubType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblSuperType_SuperType",
                table: "tblSuperType",
                column: "SuperType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblType_Type",
                table: "tblType",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblUserDeck_CardDatapkCard",
                table: "tblUserDeck",
                column: "CardDatapkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserDeck_DateCreated",
                table: "tblUserDeck",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserDeck_DeckName",
                table: "tblUserDeck",
                column: "DeckName");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserDeck_FormatDatapkFormat",
                table: "tblUserDeck",
                column: "FormatDatapkFormat");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserDeckCard_CardDatapkCard",
                table: "tblUserDeckCard",
                column: "CardDatapkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserDeckSideboard_CardDatapkCard",
                table: "tblUserDeckSideboard",
                column: "CardDatapkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserDeckSideboardCard_CardDatapkCard",
                table: "tblUserDeckSideboardCard",
                column: "CardDatapkCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCardColor");

            migrationBuilder.DropTable(
                name: "tblCardColorIdentity");

            migrationBuilder.DropTable(
                name: "tblCardFormat");

            migrationBuilder.DropTable(
                name: "tblCardKeywordData");

            migrationBuilder.DropTable(
                name: "tblCardSubType");

            migrationBuilder.DropTable(
                name: "tblCardSuperType");

            migrationBuilder.DropTable(
                name: "tblCardType");

            migrationBuilder.DropTable(
                name: "tblFileVersion");

            migrationBuilder.DropTable(
                name: "tblPurchaseInformation");

            migrationBuilder.DropTable(
                name: "tblUserDeckCard");

            migrationBuilder.DropTable(
                name: "tblUserDeckFormat");

            migrationBuilder.DropTable(
                name: "tblUserDeckSideboardCard");

            migrationBuilder.DropTable(
                name: "tblColor");

            migrationBuilder.DropTable(
                name: "tblColorIdentity");

            migrationBuilder.DropTable(
                name: "tblKeyword");

            migrationBuilder.DropTable(
                name: "tblSubType");

            migrationBuilder.DropTable(
                name: "tblSuperType");

            migrationBuilder.DropTable(
                name: "tblType");

            migrationBuilder.DropTable(
                name: "tblUserDeckSideboard");

            migrationBuilder.DropTable(
                name: "tblUserDeck");

            migrationBuilder.DropTable(
                name: "tblCard");

            migrationBuilder.DropTable(
                name: "tblFormat");

            migrationBuilder.DropTable(
                name: "tblSet");
        }
    }
}
