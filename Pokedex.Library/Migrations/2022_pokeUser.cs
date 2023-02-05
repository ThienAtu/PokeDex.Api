using Pokedex.Library.Migrations.Services;

namespace Pokedex.Library.Migrations;

public partial class UserMigrate : MigrationsExecute
{
  public UserMigrate()
    : base("pokeUser") { }
}
