using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smalltalks.Migrations
{
    /// <inheritdoc />
    public partial class FinalDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Salutations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4L, "Oi" },
                    { 5L, "Tudo bem?" },
                    { 6L, "Olá" },
                    { 7L, "Como vai?" },
                    { 8L, "E ai" },
                    { 9L, "Beleza?" },
                    { 10L, "Bom dia!" },
                    { 11L, "Boa tarde!" },
                    { 12L, "Boa noite!" },
                    { 13L, "Como você está?" },
                    { 14L, "Como você está se sentindo hoje?" },
                    { 15L, "Tudo em ordem?" },
                    { 16L, "Que tal" },
                    { 17L, "Como estão as coisas?" },
                    { 18L, "Beleza pura?" },
                    { 19L, "Bom te ver!" },
                    { 20L, "Como tem passado?" },
                    { 21L, "De boa?" },
                    { 22L, "Que prazer te encontrar!" },
                    { 23L, "Tudo joia?" }
                });

            migrationBuilder.InsertData(
                table: "Swearings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4L, "É foda" },
                    { 5L, "E ai" },
                    { 6L, "Homossexual" },
                    { 7L, "Gay" },
                    { 8L, "Caralho" },
                    { 9L, "Que merda" },
                    { 11L, "Porra" },
                    { 12L, "Tudo em ordem?" },
                    { 13L, "Filho da puta" },
                    { 14L, "Vai tomar no cu" },
                    { 15L, "Tomar no cu" },
                    { 16L, "Viado" },
                    { 17L, "Boceta" },
                    { 18L, "Macaco" },
                    { 20L, "Macaca" },
                    { 21L, "Pau" },
                    { 22L, "Pau no cu" },
                    { 23L, "Piroca" },
                    { 24L, "Corno" },
                    { 25L, "Corna" },
                    { 26L, "Vagabunda" },
                    { 27L, "Vagabundo" },
                    { 28L, "Toma no cu" },
                    { 29L, "Filha da puta" },
                    { 30L, "Foda" }
                });

            migrationBuilder.InsertData(
                table: "ToThanks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4L, "Obrigado" },
                    { 5L, "Grato" },
                    { 6L, "Agradeço" },
                    { 7L, "Valeu" },
                    { 8L, "Muito obrigado" },
                    { 9L, "Obrigadão" },
                    { 10L, "Obrigadíssimo" },
                    { 11L, "Agradecimento" },
                    { 13L, "Gratidão" },
                    { 14L, "Obrigadinho" },
                    { 15L, "Muito obrigada" },
                    { 16L, "Agradecendo" },
                    { 17L, "Agradecidamente" },
                    { 18L, "Agradeço muito" },
                    { 19L, "Fico grato" },
                    { 20L, "Agradecemos" },
                    { 21L, "Muito agradecido" },
                    { 22L, "Obrigada" },
                    { 23L, "Agradecida" },
                    { 24L, "Grata" },
                    { 25L, "Obrigadona" },
                    { 26L, "Fico grata" },
                    { 27L, "Muito agradecida" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Salutations",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Swearings",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "ToThanks",
                keyColumn: "Id",
                keyValue: 27L);
        }
    }
}
