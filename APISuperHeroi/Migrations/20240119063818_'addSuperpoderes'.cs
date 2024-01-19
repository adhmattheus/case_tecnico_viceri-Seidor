using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APISuperHeroi.Migrations
{
    /// <inheritdoc />
    public partial class addSuperpoderes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SuperPoderes",
                columns: new[] { "Id", "Descricao", "SuperPoder" },
                values: new object[,]
                {
                    { 1, "Habilidade de voar.", "Voo" },
                    { 2, "Força muito além dos limites humanos.", "Força sobre-humana" },
                    { 3, "Capacidade de se mover em velocidades extremas.", "Hiper velocidade" },
                    { 4, "Capacidade de ler mentes e se comunicar mentalmente.", "Telepatia" },
                    { 5, "Capacidade de se tornar invisível aos olhos.", "Invisibilidade" },
                    { 6, "Controle sobre o fluxo do tempo.", "Manipulação do tempo" },
                    { 7, "Domínio sobre os elementos naturais: água, fogo, terra, ar.", "Controle elemental" },
                    { 8, "Habilidade de mover objetos com a mente.", "Telecinese" },
                    { 9, "Capacidade de alterar a aparência física.", "Transformação de forma" },
                    { 10, "Criação de uma barreira de proteção invisível.", "Geração de campo de força" },
                    { 11, "Capacidade de se curar rapidamente de ferimentos.", "Cura acelerada" },
                    { 12, "Deslocamento entre diferentes dimensões.", "Viagem interdimensional" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SuperPoderes",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
