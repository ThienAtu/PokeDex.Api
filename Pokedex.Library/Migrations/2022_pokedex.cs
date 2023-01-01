using Pokedex.Library.Migrations.Services;

namespace Pokedex.Library.Migrations;

public partial class PokedexMigrate : MigrationsExecute
{
	public PokedexMigrate()
		: base("pokedex") { }
}
