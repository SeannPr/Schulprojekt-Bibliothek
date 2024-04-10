using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schulprojekt_Bibliothek.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buche",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bücher = table.Column<string>(type: "TEXT", nullable: false),
                    Autor = table.Column<string>(type: "TEXT", nullable: false),
                    Titel = table.Column<string>(type: "TEXT", nullable: false),
                    Seiten = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buche", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vorname = table.Column<string>(type: "TEXT", nullable: false),
                    Nachname = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Tel = table.Column<int>(type: "INTEGER", nullable: false),
                    Stadt = table.Column<string>(type: "TEXT", nullable: false),
                    Userld = table.Column<int>(type: "INTEGER", nullable: false),
                    Pin = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ausleihungen",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Userld = table.Column<int>(type: "INTEGER", nullable: false),
                    Buch = table.Column<string>(type: "TEXT", nullable: false),
                    AusleihDatum = table.Column<int>(type: "INTEGER", nullable: false),
                    AbgabeDatum = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ausleihungen", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ausleihungen_Users_Userld",
                        column: x => x.Userld,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ausleihungen_Userld",
                table: "Ausleihungen",
                column: "Userld");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ausleihungen");

            migrationBuilder.DropTable(
                name: "Buche");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
