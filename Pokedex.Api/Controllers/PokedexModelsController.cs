using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Library.Dtos;
using Pokedex.Library.Model;
using Pokedex.Library.Queries.Pokedex;

namespace Pokedex.Api.Controllers;

[Route("api/pokedex")]
[ApiController]
public class PokedexModelsController : ControllerBase
{
	private IMediator _mediator;
	private readonly IMapper _mapper;

	public PokedexModelsController(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<List<PokedexModel>>> GetPokedexModelList()
	{
		var pokedexList = await _mediator.Send(new GetPokedexListQuery());
		var result = pokedexList.Select(_ => _mapper.Map<PokedexModelDto>(_));
		return Ok(result);
	}

	[HttpGet("{Id}")]
	public async Task<ActionResult<PokedexModel>> GetPokedexModelById([FromRoute] GetPokedexModelByIdQuery request)
	{
		var pokedex = await _mediator.Send(request);
		var result = _mapper.Map<PokedexModelDto>(pokedex);
		return Ok(result);
	}
}
