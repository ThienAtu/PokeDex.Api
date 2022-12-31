using Pokedex.Library.Model;

namespace Pokedex.Library.Data.Pokedex;

public interface IPokedexResponsitory
{
	Task<List<PokedexModel>> GetPokedexModelList();
	Task<PokedexModel?> GetPokedexModelById(int id);
	Task<PokedexModel> AddPokedexModel(PokedexModel model);
	Task<PokedexModel> UpdatePokedexModel(PokedexModel model);
	Task<PokedexModel> DeletePokedexModel(int id);
}
