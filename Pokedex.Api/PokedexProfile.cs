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
	}
}
