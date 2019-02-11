using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zadataka03.Migrations
{
    public partial class prvaMigracijaPromjenaModela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kancelarije",
                columns: table => new
                {
                    KancelarijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kancelarije", x => x.KancelarijaId);
                });

            migrationBuilder.CreateTable(
                name: "Uredjaji",
                columns: table => new
                {
                    UredjajId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImeUredjaja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uredjaji", x => x.UredjajId);
                });

            migrationBuilder.CreateTable(
                name: "Osobe",
                columns: table => new
                {
                    OsobaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    KancelarijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobe", x => x.OsobaId);
                    table.ForeignKey(
                        name: "FK_Osobe_Kancelarije_KancelarijaId",
                        column: x => x.KancelarijaId,
                        principalTable: "Kancelarije",
                        principalColumn: "KancelarijaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UredjajUzetVraceni",
                columns: table => new
                {
                    UredjajUzetVracenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Uzet = table.Column<DateTime>(nullable: false),
                    Vracen = table.Column<DateTime>(nullable: true),
                    OsobaId = table.Column<int>(nullable: false),
                    UredjajId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UredjajUzetVraceni", x => x.UredjajUzetVracenId);
                    table.ForeignKey(
                        name: "FK_UredjajUzetVraceni_Osobe_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osobe",
                        principalColumn: "OsobaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UredjajUzetVraceni_Uredjaji_UredjajId",
                        column: x => x.UredjajId,
                        principalTable: "Uredjaji",
                        principalColumn: "UredjajId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Osobe_KancelarijaId",
                table: "Osobe",
                column: "KancelarijaId");

            migrationBuilder.CreateIndex(
                name: "IX_UredjajUzetVraceni_OsobaId",
                table: "UredjajUzetVraceni",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_UredjajUzetVraceni_UredjajId",
                table: "UredjajUzetVraceni",
                column: "UredjajId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UredjajUzetVraceni");

            migrationBuilder.DropTable(
                name: "Osobe");

            migrationBuilder.DropTable(
                name: "Uredjaji");

            migrationBuilder.DropTable(
                name: "Kancelarije");
        }
    }
}
