using Pokedex.Library.Dtos;

namespace Pokedex.Web.Services.Pokedex;

public interface IPokedexService
{
  Task<IEnumerable<PokedexModelDto>> GetPokedex();
  Task<PokedexModelDto?> GetPokedexById(int id);
}
