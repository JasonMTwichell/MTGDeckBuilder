using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTGDeckBuilder.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MTG");

            migrationBuilder.CreateTable(
                name: "tblCard",
                schema: "MTG",
                columns: table => new
                {
                    pkCard = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AsciiName = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Layout = table.Column<string>(type: "TEXT", nullable: false),
                    Side = table.Column<string>(type: "TEXT", nullable: false),
                    ManaCost = table.Column<string>(type: "TEXT", nullable: false),
                    ManaValue = table.Column<int>(type: "INTEGER", nullable: false),
                    Loyalty = table.Column<int>(type: "INTEGER", nullable: true),
                    HandModifier = table.Column<int>(type: "INTEGER", nullable: true),
                    LifeModifier = table.Column<int>(type: "INTEGER", nullable: true),
                    Power = table.Column<int>(type: "INTEGER", nullable: true),
                    Toughness = table.Column<int>(type: "INTEGER", nullable: true),
                    IsFunny = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsReserved = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasAlternateDeckLimit = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCard", x => x.pkCard);
                });

            migrationBuilder.CreateTable(
                name: "tblColor",
                schema: "MTG",
                columns: table => new
                {
                    pkColor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColorName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblColor", x => x.pkColor);
                });

            migrationBuilder.CreateTable(
                name: "tblKeyword",
                schema: "MTG",
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
                name: "tblSubType",
                schema: "MTG",
                columns: table => new
                {
                    pkSubType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSubType", x => x.pkSubType);
                });

            migrationBuilder.CreateTable(
                name: "tblSuperType",
                schema: "MTG",
                columns: table => new
                {
                    pkSuperType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SuperTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSuperType", x => x.pkSuperType);
                });

            migrationBuilder.CreateTable(
                name: "tblType",
                schema: "MTG",
                columns: table => new
                {
                    pkType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblType", x => x.pkType);
                });

            migrationBuilder.CreateTable(
                name: "tblLegality",
                schema: "MTG",
                columns: table => new
                {
                    pkLegality = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    Format = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLegality", x => x.pkLegality);
                    table.ForeignKey(
                        name: "FK_tblLegality_tblCard_fkCard",
                        column: x => x.fkCard,
                        principalSchema: "MTG",
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPurchaseInformation",
                schema: "MTG",
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
                        principalSchema: "MTG",
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardColor",
                schema: "MTG",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkColor = table.Column<int>(type: "INTEGER", nullable: false),
                    CardspkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    ColorspkColor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardColor", x => new { x.fkCard, x.fkColor });
                    table.ForeignKey(
                        name: "FK_tblCardColor_tblCard_CardspkCard",
                        column: x => x.CardspkCard,
                        principalSchema: "MTG",
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardColor_tblColor_ColorspkColor",
                        column: x => x.ColorspkColor,
                        principalSchema: "MTG",
                        principalTable: "tblColor",
                        principalColumn: "pkColor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardColorIdentity",
                schema: "MTG",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkColor = table.Column<int>(type: "INTEGER", nullable: false),
                    CardIdentitiespkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    ColorIdentitiespkColor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardColorIdentity", x => new { x.fkCard, x.fkColor });
                    table.ForeignKey(
                        name: "FK_tblCardColorIdentity_tblCard_CardIdentitiespkCard",
                        column: x => x.CardIdentitiespkCard,
                        principalSchema: "MTG",
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardColorIdentity_tblColor_ColorIdentitiespkColor",
                        column: x => x.ColorIdentitiespkColor,
                        principalSchema: "MTG",
                        principalTable: "tblColor",
                        principalColumn: "pkColor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardKeywordData",
                schema: "MTG",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkKeyword = table.Column<int>(type: "INTEGER", nullable: false),
                    CardspkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    KeywordspkKeyword = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardKeywordData", x => new { x.fkCard, x.fkKeyword });
                    table.ForeignKey(
                        name: "FK_tblCardKeywordData_tblCard_CardspkCard",
                        column: x => x.CardspkCard,
                        principalSchema: "MTG",
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardKeywordData_tblKeyword_KeywordspkKeyword",
                        column: x => x.KeywordspkKeyword,
                        principalSchema: "MTG",
                        principalTable: "tblKeyword",
                        principalColumn: "pkKeyword",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardSubType",
                schema: "MTG",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkSubType = table.Column<int>(type: "INTEGER", nullable: false),
                    CardspkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    SubTypespkSubType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardSubType", x => new { x.fkCard, x.fkSubType });
                    table.ForeignKey(
                        name: "FK_tblCardSubType_tblCard_CardspkCard",
                        column: x => x.CardspkCard,
                        principalSchema: "MTG",
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardSubType_tblSubType_SubTypespkSubType",
                        column: x => x.SubTypespkSubType,
                        principalSchema: "MTG",
                        principalTable: "tblSubType",
                        principalColumn: "pkSubType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardSuperType",
                schema: "MTG",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkSuperType = table.Column<int>(type: "INTEGER", nullable: false),
                    CardspkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    SuperTypespkSuperType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardSuperType", x => new { x.fkCard, x.fkSuperType });
                    table.ForeignKey(
                        name: "FK_tblCardSuperType_tblCard_CardspkCard",
                        column: x => x.CardspkCard,
                        principalSchema: "MTG",
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardSuperType_tblSuperType_SuperTypespkSuperType",
                        column: x => x.SuperTypespkSuperType,
                        principalSchema: "MTG",
                        principalTable: "tblSuperType",
                        principalColumn: "pkSuperType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCardType",
                schema: "MTG",
                columns: table => new
                {
                    fkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    fkType = table.Column<int>(type: "INTEGER", nullable: false),
                    CardspkCard = table.Column<int>(type: "INTEGER", nullable: false),
                    TypespkType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCardType", x => new { x.fkCard, x.fkType });
                    table.ForeignKey(
                        name: "FK_tblCardType_tblCard_CardspkCard",
                        column: x => x.CardspkCard,
                        principalSchema: "MTG",
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCardType_tblType_TypespkType",
                        column: x => x.TypespkType,
                        principalSchema: "MTG",
                        principalTable: "tblType",
                        principalColumn: "pkType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCardColor_CardspkCard",
                schema: "MTG",
                table: "tblCardColor",
                column: "CardspkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardColor_ColorspkColor",
                schema: "MTG",
                table: "tblCardColor",
                column: "ColorspkColor");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardColorIdentity_CardIdentitiespkCard",
                schema: "MTG",
                table: "tblCardColorIdentity",
                column: "CardIdentitiespkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardColorIdentity_ColorIdentitiespkColor",
                schema: "MTG",
                table: "tblCardColorIdentity",
                column: "ColorIdentitiespkColor");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardKeywordData_CardspkCard",
                schema: "MTG",
                table: "tblCardKeywordData",
                column: "CardspkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardKeywordData_KeywordspkKeyword",
                schema: "MTG",
                table: "tblCardKeywordData",
                column: "KeywordspkKeyword");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardSubType_CardspkCard",
                schema: "MTG",
                table: "tblCardSubType",
                column: "CardspkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardSubType_SubTypespkSubType",
                schema: "MTG",
                table: "tblCardSubType",
                column: "SubTypespkSubType");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardSuperType_CardspkCard",
                schema: "MTG",
                table: "tblCardSuperType",
                column: "CardspkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardSuperType_SuperTypespkSuperType",
                schema: "MTG",
                table: "tblCardSuperType",
                column: "SuperTypespkSuperType");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardType_CardspkCard",
                schema: "MTG",
                table: "tblCardType",
                column: "CardspkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardType_TypespkType",
                schema: "MTG",
                table: "tblCardType",
                column: "TypespkType");

            migrationBuilder.CreateIndex(
                name: "IX_tblLegality_fkCard",
                schema: "MTG",
                table: "tblLegality",
                column: "fkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseInformation_fkCard",
                schema: "MTG",
                table: "tblPurchaseInformation",
                column: "fkCard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCardColor",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblCardColorIdentity",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblCardKeywordData",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblCardSubType",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblCardSuperType",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblCardType",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblLegality",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblPurchaseInformation",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblColor",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblKeyword",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblSubType",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblSuperType",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblType",
                schema: "MTG");

            migrationBuilder.DropTable(
                name: "tblCard",
                schema: "MTG");
        }
    }
}
