using Microsoft.EntityFrameworkCore;
using Pokedex.Library.Model;

namespace Pokedex.Library.Data.Pokedex;

public class PokedexResponsitory : IPokedexResponsitory
{
	private readonly PokedexDbContext _context;

	public PokedexResponsitory(PokedexDbContext context)
	{
		_context = context;
	}

	public Task<PokedexModel> AddPokedexModel(PokedexModel model)
	{
		throw new NotImplementedException();
	}

	public Task<PokedexModel> DeletePokedexModel(int id)
	{
		throw new NotImplementedException();
	}

	public Task<PokedexModel> GetPokedexModelById(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<List<PokedexModel>> GetPokedexModelList()
	{
		var result = await _context.PokedexModels.FromSqlRaw("EXEC GetPokedexList").ToListAsync();
		return result;
	}

	public Task<PokedexModel> UpdatePokedexModel(PokedexModel model)
	{
		throw new NotImplementedException();
	}
}
