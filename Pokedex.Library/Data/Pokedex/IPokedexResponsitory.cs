using Pokedex.Library.Model;

namespace Pokedex.Library.Data.Pokedex;

public interface IPokedexResponsitory
{
	Task<List<PokedexModel>> GetPokedex();
	Task<PokedexModel?> GetPokedexById(int id);
	Task<PokedexModel?> AddPokedex(PokedexModel model);
	Task<PokedexModel?> UpdatePokedex(PokedexModel model);
	Task<int> DeletePokedex();
	Task<int> DeletePokedexById(int id);
}
