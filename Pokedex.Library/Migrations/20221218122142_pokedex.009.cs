using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pokedex.Library.Migrations
{
    /// <inheritdoc />
    public partial class pokedex009 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokedexModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    NameJapanese = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    NameRomanji = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Type1 = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Type2 = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,1)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokedexModels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PokedexModels",
                columns: new[] { "Id", "Height", "Name", "NameJapanese", "NameRomanji", "Number", "Type1", "Type2", "Weight" },
                values: new object[,]
                {
                    { 1, 0.7m, "Bulbasaur", "フシギダネ", "Fushigidane", "001", "Grass", "Poison", 6.9m },
                    { 2, 1.0m, "Ivysaur", "フシギソウ", "Fushigisou", "002", "Grass", "Poison", 13.0m },
                    { 3, 2.0m, "Venusaur", "フシギバナ", "Fushigibana", "003", "Grass", "Poison", 100.0m },
                    { 4, 0.6m, "Charmander", "ヒトカゲ", "Hitokage", "004", "Fire", "", 8.5m },
                    { 5, 1.1m, "Charmeleon", "リザード", "Lizardo", "005", "Fire", "", 19.0m },
                    { 6, 1.7m, "Charizard", "リザードン", "Lizardon", "006", "Fire", "Flying", 90.5m },
                    { 7, 0.5m, "Squirtle", "ゼニガメ", "Zenigame", "007", "Water", "", 9.0m },
                    { 8, 1.0m, "Wartortle", "カメール", "Kameil", "008", "Water", "", 22.5m },
                    { 9, 1.6m, "Blastoise", "カメックス", "Kamex", "009", "Water", "", 85.5m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokedexModels");
        }
    }
}
