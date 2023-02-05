using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Pokedex.Library.Extensions;
using Pokedex.Library.Security;

namespace Pokedex.Library.Migrations.Services;

public abstract class MigrationsExecute : Migration
{
  private readonly string _sqlFile;

  public MigrationsExecute(string sqlFile)
  {
    _sqlFile = sqlFile;
  }

  protected override void Up(MigrationBuilder migrationBuilder)
  {
    RunSqlQuery(migrationBuilder, "up");
  }

  protected override void Down(MigrationBuilder migrationBuilder)
  {
    RunSqlQuery(migrationBuilder, "down");
  }

  private void RunSqlQuery(MigrationBuilder migrationBuilder, string action)
  {
    var file = Path.GetFullPath($"Migrations/Scripts/{_sqlFile}_{action}.sql");
    var data = File.ReadAllText(file);

    if (_sqlFile is "pokeUser")
    {
      var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
      var password = configuration.GetSection("Password:DefaultPassword").Value;
      var passwordHash = PasswordHasher.CreatePasswordHash(StringUtility.ToEmpty(password!));
      data = data.Replace("{{ password }}", passwordHash);
    }

    migrationBuilder.Sql(data);
  }
}
