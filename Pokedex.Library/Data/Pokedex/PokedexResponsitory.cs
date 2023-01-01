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

	public async Task<PokedexModel?> AddPokedex(PokedexModel model)
	{
		var param = string.Join(",", model.Number, model.Name, model.NameJapanese, model.NameRomanji, model.Type1, model.Type2, model.Height, model.Weight);
		var rowAffected = await _context.Database.ExecuteSqlRawAsync($"EXEC sp_Pokedex_Insert {param}");
		var result = (rowAffected > 0) ? model : null;
		return result;
	}

	public async Task<int> DeletePokedex()
	{
		var result = await _context.Database.ExecuteSqlRawAsync($"EXEC sp_Pokedex_Delete");
		return result;
	}

	public async Task<int> DeletePokedexById(int id)
	{
		var result = await _context.Database.ExecuteSqlRawAsync($"EXEC sp_Pokedex_DeleteById {id}");
		return result;
	}

	public async Task<PokedexModel?> GetPokedexById(int id)
	{
		var result = await _context.Pokedexs.FromSqlRaw($"EXEC sp_Pokedex_GetById {id}").ToListAsync();
		return result.FirstOrDefault();
	}

	public async Task<List<PokedexModel>> GetPokedex()
	{
		var result = await _context.Pokedexs.FromSqlRaw("EXEC sp_Pokedex_Get").ToListAsync();
		return result;
	}

	public async Task<PokedexModel?> UpdatePokedex(PokedexModel model)
	{
		var param = string.Join(",", model.Id, model.Number, model.Name, model.NameJapanese, model.NameRomanji, model.Type1, model.Type2, model.Height, model.Weight);
		var rowAffected = await _context.Database.ExecuteSqlRawAsync($"EXEC sp_Pokedex_Update {param}");
		var result = (rowAffected > 0) ? model : null;
		return result;
	}
}
