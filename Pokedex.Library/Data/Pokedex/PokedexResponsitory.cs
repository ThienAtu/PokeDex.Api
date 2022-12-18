using Pokedex.Library.Model;

namespace Pokedex.Library.Data.Pokedex;

public class PokedexResponsitory : IPokedexResponsitory
{
	private readonly PokedexDbContext _context;

	public PokedexResponsitory(PokedexDbContext context)
	{
		_context = context;
	}

	public PokedexModel AddPokedexModel(PokedexModel model)
	{
		throw new NotImplementedException();
	}

	public PokedexModel DeletePokedexModel(int id)
	{
		throw new NotImplementedException();
	}

	public PokedexModel GetPokedexModelById(int id)
	{
		throw new NotImplementedException();
	}

	public List<PokedexModel> GetPokedexModelList()
	{
		var result = _context.PokedexModels.ToList();
		return result;
	}

	public PokedexModel UpdatePokedexModel(PokedexModel model)
	{
		throw new NotImplementedException();
	}
}
