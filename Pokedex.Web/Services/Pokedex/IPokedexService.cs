using Pokedex.Library.Dtos;
using Pokedex.Library.Model;

namespace Pokedex.Web.Services.Pokedex;

public interface IPokedexService
{
  Task<IEnumerable<PokedexModelDto?>> Get();
}
