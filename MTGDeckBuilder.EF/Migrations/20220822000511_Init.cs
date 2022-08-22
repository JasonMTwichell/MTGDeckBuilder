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
                name: "tblCard",
                columns: table => new
                {
                    ScryfallOracleID = table.Column<string>(type: "TEXT", nullable: false),
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
                    HasAlternateDeckLimit = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCard", x => x.ScryfallOracleID);
                });

            migrationBuilder.CreateTable(
                name: "tblColor",
                columns: table => new
                {
                    Color = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblColor", x => x.Color);
                });

            migrationBuilder.CreateTable(
                name: "tblColorIdentity",
                columns: table => new
                {
                    ColorIdentity = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblColorIdentity", x => x.ColorIdentity);
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
                name: "tblKeyword",
                columns: table => new
                {
                    Keyword = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKeyword", x => x.Keyword);
                });

            migrationBuilder.CreateTable(
                name: "tblLegality",
                columns: table => new
                {
                    Legality = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLegality", x => x.Legality);
                });

            migrationBuilder.CreateTable(
                name: "tblSubType",
                columns: table => new
                {
                    SubType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSubType", x => x.SubType);
                });

            migrationBuilder.CreateTable(
                name: "tblSuperType",
                columns: table => new
                {
                    SuperType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSuperType", x => x.SuperType);
                });

            migrationBuilder.CreateTable(
                name: "tblType",
                columns: table => new
                {
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblType", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "tblUserDeck",
                columns: table => new
                {
                    pkUserDeck = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeckName = table.Column<string>(type: "TEXT", nullable: false),
                    DeckDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserDeck", x => x.pkUserDeck);
                });

            migrationBuilder.CreateTable(
                name: "tblPurchaseInformation",
                columns: table => new
                {
                    pkPurchaseInformation = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fkCard = table.Column<string>(type: "TEXT", nullable: false),
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
                        principalColumn: "ScryfallOracleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardColor",
                columns: table => new
                {
                    fkCard = table.Column<string>(type: "TEXT", nullable: false),
                    fkColor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardColor", x => new { x.fkCard, x.fkColor });
                    table.ForeignKey(
                        name: "FK_tblCardColor_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "ScryfallOracleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardColor_tblColor_fkColor",
                        column: x => x.fkColor,
                        principalTable: "tblColor",
                        principalColumn: "Color",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardColorIdentity",
                columns: table => new
                {
                    fkCard = table.Column<string>(type: "TEXT", nullable: false),
                    fkColorIdentity = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardColorIdentity", x => new { x.fkCard, x.fkColorIdentity });
                    table.ForeignKey(
                        name: "FK_tblCardColorIdentity_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "ScryfallOracleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardColorIdentity_tblColorIdentity_fkColorIdentity",
                        column: x => x.fkColorIdentity,
                        principalTable: "tblColorIdentity",
                        principalColumn: "ColorIdentity",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardKeywordData",
                columns: table => new
                {
                    fkCard = table.Column<string>(type: "TEXT", nullable: false),
                    fkKeyword = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardKeywordData", x => new { x.fkCard, x.fkKeyword });
                    table.ForeignKey(
                        name: "FK_tblCardKeywordData_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "ScryfallOracleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardKeywordData_tblKeyword_fkKeyword",
                        column: x => x.fkKeyword,
                        principalTable: "tblKeyword",
                        principalColumn: "Keyword",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardLegality",
                columns: table => new
                {
                    fkCard = table.Column<string>(type: "TEXT", nullable: false),
                    fkLegality = table.Column<string>(type: "TEXT", nullable: false),
                    IsLegal = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardLegality", x => new { x.fkCard, x.fkLegality });
                    table.ForeignKey(
                        name: "FK_tblCardLegality_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "ScryfallOracleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardLegality_tblLegality_fkLegality",
                        column: x => x.fkLegality,
                        principalTable: "tblLegality",
                        principalColumn: "Legality",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardSubType",
                columns: table => new
                {
                    fkCard = table.Column<string>(type: "TEXT", nullable: false),
                    fkSubType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardSubType", x => new { x.fkCard, x.fkSubType });
                    table.ForeignKey(
                        name: "FK_tblCardSubType_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "ScryfallOracleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardSubType_tblSubType_fkSubType",
                        column: x => x.fkSubType,
                        principalTable: "tblSubType",
                        principalColumn: "SubType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardSuperType",
                columns: table => new
                {
                    fkCard = table.Column<string>(type: "TEXT", nullable: false),
                    fkSuperType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardSuperType", x => new { x.fkCard, x.fkSuperType });
                    table.ForeignKey(
                        name: "FK_tblCardSuperType_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "ScryfallOracleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardSuperType_tblSuperType_fkSuperType",
                        column: x => x.fkSuperType,
                        principalTable: "tblSuperType",
                        principalColumn: "SuperType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardType",
                columns: table => new
                {
                    fkCard = table.Column<string>(type: "TEXT", nullable: false),
                    fkType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardType", x => new { x.fkCard, x.fkType });
                    table.ForeignKey(
                        name: "FK_tblCardType_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "ScryfallOracleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardType_tblType_fkType",
                        column: x => x.fkType,
                        principalTable: "tblType",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserDeckCard",
                columns: table => new
                {
                    fkUserDeck = table.Column<int>(type: "INTEGER", nullable: false),
                    fkCard = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserDeckCard", x => new { x.fkUserDeck, x.fkCard });
                    table.ForeignKey(
                        name: "FK_tblUserDeckCard_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "ScryfallOracleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblUserDeckCard_tblUserDeck_fkUserDeck",
                        column: x => x.fkUserDeck,
                        principalTable: "tblUserDeck",
                        principalColumn: "pkUserDeck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserDeckSideboard",
                columns: table => new
                {
                    fkUserDeck = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserDeckSideboard", x => x.fkUserDeck);
                    table.ForeignKey(
                        name: "FK_tblUserDeckSideboard_tblUserDeck_fkUserDeck",
                        column: x => x.fkUserDeck,
                        principalTable: "tblUserDeck",
                        principalColumn: "pkUserDeck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDeckLegalityData",
                columns: table => new
                {
                    LegalitiesLegality = table.Column<string>(type: "TEXT", nullable: false),
                    UserDeckspkUserDeck = table.Column<int>(type: "INTEGER", nullable: false),
                    fkUserDeck = table.Column<int>(type: "INTEGER", nullable: false),
                    fkLegality = table.Column<string>(type: "TEXT", nullable: false),
                    DeckpkUserDeck = table.Column<int>(type: "INTEGER", nullable: false),
                    Legality1 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeckLegalityData", x => new { x.LegalitiesLegality, x.UserDeckspkUserDeck });
                    table.ForeignKey(
                        name: "FK_UserDeckLegalityData_tblLegality_LegalitiesLegality",
                        column: x => x.LegalitiesLegality,
                        principalTable: "tblLegality",
                        principalColumn: "Legality",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDeckLegalityData_tblLegality_Legality1",
                        column: x => x.Legality1,
                        principalTable: "tblLegality",
                        principalColumn: "Legality",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDeckLegalityData_tblUserDeck_DeckpkUserDeck",
                        column: x => x.DeckpkUserDeck,
                        principalTable: "tblUserDeck",
                        principalColumn: "pkUserDeck",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDeckLegalityData_tblUserDeck_UserDeckspkUserDeck",
                        column: x => x.UserDeckspkUserDeck,
                        principalTable: "tblUserDeck",
                        principalColumn: "pkUserDeck",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserDeckSideboardCard",
                columns: table => new
                {
                    fkCard = table.Column<string>(type: "TEXT", nullable: false),
                    fkUserDeckSideboard = table.Column<int>(type: "INTEGER", nullable: false),
                    CardDataScryfallOracleID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserDeckSideboardCard", x => new { x.fkUserDeckSideboard, x.fkCard });
                    table.ForeignKey(
                        name: "FK_tblUserDeckSideboardCard_tblCard_CardDataScryfallOracleID",
                        column: x => x.CardDataScryfallOracleID,
                        principalTable: "tblCard",
                        principalColumn: "ScryfallOracleID");
                    table.ForeignKey(
                        name: "FK_tblUserDeckSideboardCard_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalTable: "tblCard",
                        principalColumn: "ScryfallOracleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblUserDeckSideboardCard_tblUserDeckSideboard_fkUserDeckSideboard",
                        column: x => x.fkUserDeckSideboard,
                        principalTable: "tblUserDeckSideboard",
                        principalColumn: "fkUserDeck",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_tblCardColor_fkColor",
                table: "tblCardColor",
                column: "fkColor");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardColorIdentity_fkColorIdentity",
                table: "tblCardColorIdentity",
                column: "fkColorIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardKeywordData_fkKeyword",
                table: "tblCardKeywordData",
                column: "fkKeyword");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardLegality_fkLegality",
                table: "tblCardLegality",
                column: "fkLegality");

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
                column: "Color");

            migrationBuilder.CreateIndex(
                name: "IX_tblColorIdentity_ColorIdentity",
                table: "tblColorIdentity",
                column: "ColorIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_tblKeyword_Keyword",
                table: "tblKeyword",
                column: "Keyword");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseInformation_fkCard",
                table: "tblPurchaseInformation",
                column: "fkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblSubType_SubType",
                table: "tblSubType",
                column: "SubType");

            migrationBuilder.CreateIndex(
                name: "IX_tblSuperType_SuperType",
                table: "tblSuperType",
                column: "SuperType");

            migrationBuilder.CreateIndex(
                name: "IX_tblType_Type",
                table: "tblType",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserDeckCard_fkCard",
                table: "tblUserDeckCard",
                column: "fkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserDeckSideboardCard_CardDataScryfallOracleID",
                table: "tblUserDeckSideboardCard",
                column: "CardDataScryfallOracleID");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserDeckSideboardCard_fkCard",
                table: "tblUserDeckSideboardCard",
                column: "fkCard");

            migrationBuilder.CreateIndex(
                name: "IX_UserDeckLegalityData_DeckpkUserDeck",
                table: "UserDeckLegalityData",
                column: "DeckpkUserDeck");

            migrationBuilder.CreateIndex(
                name: "IX_UserDeckLegalityData_Legality1",
                table: "UserDeckLegalityData",
                column: "Legality1");

            migrationBuilder.CreateIndex(
                name: "IX_UserDeckLegalityData_UserDeckspkUserDeck",
                table: "UserDeckLegalityData",
                column: "UserDeckspkUserDeck");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCardColor");

            migrationBuilder.DropTable(
                name: "tblCardColorIdentity");

            migrationBuilder.DropTable(
                name: "tblCardKeywordData");

            migrationBuilder.DropTable(
                name: "tblCardLegality");

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
                name: "tblUserDeckSideboardCard");

            migrationBuilder.DropTable(
                name: "UserDeckLegalityData");

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
                name: "tblCard");

            migrationBuilder.DropTable(
                name: "tblUserDeckSideboard");

            migrationBuilder.DropTable(
                name: "tblLegality");

            migrationBuilder.DropTable(
                name: "tblUserDeck");
        }
    }
}
