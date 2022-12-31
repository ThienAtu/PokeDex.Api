using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pokedex.Library.Model;

namespace Pokedex.Library.Data.Pokedex;

public class PokedexDbContext : DbContext
{
	public PokedexDbContext(DbContextOptions options)
	: base(options) { }

	private class DatacontextFatory : IDesignTimeDbContextFactory<PokedexDbContext>
	{
		public PokedexDbContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			var optionBuilder = new DbContextOptionsBuilder<PokedexDbContext>();
			optionBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

			return new PokedexDbContext(optionBuilder.Options);
		}
	}

	public DbSet<PokedexModel> PokedexModels { get; set; }
}
