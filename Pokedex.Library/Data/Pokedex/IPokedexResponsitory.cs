using Pokedex.Library.Model;

namespace Pokedex.Library.Data.Pokedex;

public interface IPokedexResponsitory
{
	List<PokedexModel> GetPokedexModelList();
	PokedexModel GetPokedexModelById(int id);
	PokedexModel AddPokedexModel(PokedexModel model);
	PokedexModel UpdatePokedexModel(PokedexModel model);
	PokedexModel DeletePokedexModel(int id);
}
