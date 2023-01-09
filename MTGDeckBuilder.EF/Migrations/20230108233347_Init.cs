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
                name: "tblType",
                columns: table => new
                {
                    pkType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblType", x => x.pkType);
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

            migrationBuilder.CreateIndex(
                name: "IX_tblKeyword_fkKeywordType",
                table: "tblKeyword",
                column: "fkKeywordType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAvailability");

            migrationBuilder.DropTable(
                name: "tblBoosterType");

            migrationBuilder.DropTable(
                name: "tblBorderColor");

            migrationBuilder.DropTable(
                name: "tblColor");

            migrationBuilder.DropTable(
                name: "tblColorIdentity");

            migrationBuilder.DropTable(
                name: "tblColorIndicator");

            migrationBuilder.DropTable(
                name: "tblDeckType");

            migrationBuilder.DropTable(
                name: "tblDuelDeck");

            migrationBuilder.DropTable(
                name: "tblFinish");

            migrationBuilder.DropTable(
                name: "tblForeignDataLanguage");

            migrationBuilder.DropTable(
                name: "tblFrameEffect");

            migrationBuilder.DropTable(
                name: "tblFrameVersion");

            migrationBuilder.DropTable(
                name: "tblKeyword");

            migrationBuilder.DropTable(
                name: "tblLanguage");

            migrationBuilder.DropTable(
                name: "tblLayout");

            migrationBuilder.DropTable(
                name: "tblPromoType");

            migrationBuilder.DropTable(
                name: "tblRarity");

            migrationBuilder.DropTable(
                name: "tblSecurityStamp");

            migrationBuilder.DropTable(
                name: "tblSetType");

            migrationBuilder.DropTable(
                name: "tblSide");

            migrationBuilder.DropTable(
                name: "tblSubtype");

            migrationBuilder.DropTable(
                name: "tblSupertype");

            migrationBuilder.DropTable(
                name: "tblTcgPlayerSkuCondition");

            migrationBuilder.DropTable(
                name: "tblTcgPlayerSkuFinish");

            migrationBuilder.DropTable(
                name: "tblTcgPlayerSkuLanguage");

            migrationBuilder.DropTable(
                name: "tblTcgPlayerSkuPrinting");

            migrationBuilder.DropTable(
                name: "tblType");

            migrationBuilder.DropTable(
                name: "tblWatermark");

            migrationBuilder.DropTable(
                name: "tblKeywordType");
        }
    }
}
