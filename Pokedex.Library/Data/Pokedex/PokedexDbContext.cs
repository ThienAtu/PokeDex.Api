using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pokedex.Library.Model;

namespace Pokedex.Library.Data.Pokedex;

public class PokedexDbContext : DbContext
{
	public PokedexDbContext(DbContextOptions options) : base(options)
	{
	}

	class DatacontextFatory : IDesignTimeDbContextFactory<PokedexDbContext>
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

	//protected override void OnModelCreating(ModelBuilder model)
	//{
	//	model.Entity<PokedexModel>().HasData(
	//			new PokedexModel
	//			{
	//				Id = 1,
	//				Number = "001",
	//				Name = "Bulbasaur",
	//				NameJapanese = "フシギダネ",
	//				NameRomanji = "Fushigidane",
	//				Type1 = "Grass",
	//				Type2 = "Poison",
	//				Height = 0.7m,
	//				Weight = 6.9m,
	//			},
	//			new PokedexModel
	//			{
	//				Id = 2,
	//				Number = "002",
	//				Name = "Ivysaur",
	//				NameJapanese = "フシギソウ",
	//				NameRomanji = "Fushigisou",
	//				Type1 = "Grass",
	//				Type2 = "Poison",
	//				Height = 1.0m,
	//				Weight = 13.0m,
	//			},
	//			new PokedexModel
	//			{
	//				Id = 3,
	//				Number = "003",
	//				Name = "Venusaur",
	//				NameJapanese = "フシギバナ",
	//				NameRomanji = "Fushigibana",
	//				Type1 = "Grass",
	//				Type2 = "Poison",
	//				Height = 2.0m,
	//				Weight = 100.0m,
	//			},
	//			new PokedexModel
	//			{
	//				Id = 4,
	//				Number = "004",
	//				Name = "Charmander",
	//				NameJapanese = "ヒトカゲ",
	//				NameRomanji = "Hitokage",
	//				Type1 = "Fire",
	//				Type2 = "",
	//				Height = 0.6m,
	//				Weight = 8.5m,
	//			},
	//			new PokedexModel
	//			{
	//				Id = 5,
	//				Number = "005",
	//				Name = "Charmeleon",
	//				NameJapanese = "リザード",
	//				NameRomanji = "Lizardo",
	//				Type1 = "Fire",
	//				Type2 = "",
	//				Height = 1.1m,
	//				Weight = 19.0m,
	//			},
	//			new PokedexModel
	//			{
	//				Id = 6,
	//				Number = "006",
	//				Name = "Charizard",
	//				NameJapanese = "リザードン",
	//				NameRomanji = "Lizardon",
	//				Type1 = "Fire",
	//				Type2 = "Flying",
	//				Height = 1.7m,
	//				Weight = 90.5m,
	//			},
	//			new PokedexModel
	//			{
	//				Id = 7,
	//				Number = "007",
	//				Name = "Squirtle",
	//				NameJapanese = "ゼニガメ",
	//				NameRomanji = "Zenigame",
	//				Type1 = "Water",
	//				Type2 = "",
	//				Height = 0.5m,
	//				Weight = 9.0m,
	//			},
	//			new PokedexModel
	//			{
	//				Id = 8,
	//				Number = "008",
	//				Name = "Wartortle",
	//				NameJapanese = "カメール",
	//				NameRomanji = "Kameil",
	//				Type1 = "Water",
	//				Type2 = "",
	//				Height = 1.0m,
	//				Weight = 22.5m,
	//			},
	//			new PokedexModel
	//			{
	//				Id = 9,
	//				Number = "009",
	//				Name = "Blastoise",
	//				NameJapanese = "カメックス",
	//				NameRomanji = "Kamex",
	//				Type1 = "Water",
	//				Type2 = "",
	//				Height = 1.6m,
	//				Weight = 85.5m,
	//			}
	//	);
	//}
}
