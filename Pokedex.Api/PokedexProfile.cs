using AutoMapper;
using Pokedex.Library.Dtos;
using Pokedex.Library.Model;

namespace Pokedex.Api;

public class PokedexProfile : Profile
{
  public PokedexProfile()
  {
    CreateMap<PokedexModel, PokedexModelDto>();
    CreateMap<PokedexModelDto, PokedexModel>();

    CreateMap<PokeUserModel, PokeUserModelDto>();
    CreateMap<PokeUserModelDto, PokeUserModel>();
  }
}
