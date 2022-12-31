using Pokedex.Library.Migrations.Services;

namespace Pokedex.Library.Migrations;

public partial class Pokedex : MigrationsExecute
{
	public Pokedex()
		: base("pokedex") { }
}
