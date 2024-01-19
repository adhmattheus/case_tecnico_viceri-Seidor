using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISuperHeroi.Migrations
{
    /// <inheritdoc />
    public partial class relacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuperPoderes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SuperPoder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPoderes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HeroisSuperPoderes",
                columns: table => new
                {
                    HeroiId = table.Column<int>(type: "int", nullable: false),
                    SuperPoderesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroisSuperPoderes", x => new { x.HeroiId, x.SuperPoderesId });
                    table.ForeignKey(
                        name: "FK_HeroisSuperPoderes_Herois_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroisSuperPoderes_SuperPoderes_SuperPoderesId",
                        column: x => x.SuperPoderesId,
                        principalTable: "SuperPoderes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_HeroisSuperPoderes_SuperPoderesId",
                table: "HeroisSuperPoderes",
                column: "SuperPoderesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroisSuperPoderes");

            migrationBuilder.DropTable(
                name: "SuperPoderes");
        }
    }
}
