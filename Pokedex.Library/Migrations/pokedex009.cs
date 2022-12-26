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
          var file = Path.GetFullPath("Migrations/Scripts/pokedex_up.sql");
          var reader = new StreamReader(file);
          var data = reader.ReadToEnd();
          migrationBuilder.Sql(data);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          var file = Path.GetFullPath("Migrations/Scripts/pokedex_down.sql");
          var reader = new StreamReader(file);
          var data = reader.ReadToEnd();
          migrationBuilder.Sql(data);
		}
    }
}
