using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smalltalks.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Salutations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Bom dia" },
                    { 2L, "Boa tarde" },
                    { 3L, "Boa noite" }
                });

            migrationBuilder.InsertData(
                table: "Swearings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Caralho" },
                    { 2L, "Cacete" },
                    { 3L, "Puta" }
                });

            migrationBuilder.InsertData(
                table: "ToThanks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Obrigado" },
                    { 2L, "Agradecido" },
                    { 3L, "Agradeço" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
