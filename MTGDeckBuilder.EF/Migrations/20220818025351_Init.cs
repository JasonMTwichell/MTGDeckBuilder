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
                    pkCard = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                    table.PrimaryKey("PK_tblCard", x => x.pkCard);
                });

            migrationBuilder.CreateTable(
                name: "tblColor",
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
                name: "tblColorIdentity",
                columns: table => new
                {
                    pkColorIdentity = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColorIdentityName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblColorIdentity", x => x.pkColorIdentity);
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
                name: "tblSubType",
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
                        principalTable: "tblCard",
                        principalColumn: "pkCard",
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
                    fkColorIdentity = table.Column<int>(type: "INTEGER", nullable: false),
                    CardColorIdentityDatafkCard = table.Column<int>(type: "INTEGER", nullable: true),
                    CardColorIdentityDatafkColorIdentity = table.Column<int>(type: "INTEGER", nullable: true)
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
                        name: "FK_tblCardColorIdentity_tblCardColorIdentity_CardColorIdentityDatafkCard_CardColorIdentityDatafkColorIdentity",
                        columns: x => new { x.CardColorIdentityDatafkCard, x.CardColorIdentityDatafkColorIdentity },
                        principalTable: "tblCardColorIdentity",
                        principalColumns: new[] { "fkCard", "fkColorIdentity" });
                    table.ForeignKey(
                        name: "FK_tblCardColorIdentity_tblColorIdentity_fkColorIdentity",
                        column: x => x.fkColorIdentity,
                        principalTable: "tblColorIdentity",
                        principalColumn: "pkColorIdentity",
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

            migrationBuilder.CreateIndex(
                name: "IX_tblCardColor_fkColor",
                table: "tblCardColor",
                column: "fkColor");

            migrationBuilder.CreateIndex(
                name: "IX_tblCardColorIdentity_CardColorIdentityDatafkCard_CardColorIdentityDatafkColorIdentity",
                table: "tblCardColorIdentity",
                columns: new[] { "CardColorIdentityDatafkCard", "CardColorIdentityDatafkColorIdentity" });

            migrationBuilder.CreateIndex(
                name: "IX_tblCardColorIdentity_fkColorIdentity",
                table: "tblCardColorIdentity",
                column: "fkColorIdentity");

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
                name: "IX_tblLegality_fkCard",
                table: "tblLegality",
                column: "fkCard");

            migrationBuilder.CreateIndex(
                name: "IX_tblPurchaseInformation_fkCard",
                table: "tblPurchaseInformation",
                column: "fkCard");
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
                name: "tblCardSubType");

            migrationBuilder.DropTable(
                name: "tblCardSuperType");

            migrationBuilder.DropTable(
                name: "tblCardType");

            migrationBuilder.DropTable(
                name: "tblLegality");

            migrationBuilder.DropTable(
                name: "tblPurchaseInformation");

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
        }
    }
}
