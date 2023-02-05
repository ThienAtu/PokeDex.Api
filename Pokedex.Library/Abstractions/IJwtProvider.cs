using Pokedex.Library.Model;

namespace Pokedex.Library.Abstractions;

public interface IJwtProvider
{
  string Generate(PokeUserModel user);
}
