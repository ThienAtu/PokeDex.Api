using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Library.Command.Pokedex;
using Pokedex.Library.Dtos;
using Pokedex.Library.Model;
using Pokedex.Library.Queries.Pokedex;

namespace Pokedex.Api.Controllers;

[Route("api/pokedex")]
[ApiController]
public class PokedexsController : ControllerBase
{
  private IMediator _mediator;
  private readonly IMapper _mapper;

  public PokedexsController(IMediator mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  [HttpPost("get")]
  public async Task<ActionResult<IEnumerable<PokedexModel>>> Get()
  {
    var pokedexList = await _mediator.Send(new GetPokedexListQuery());
    var result = pokedexList.Select(_ => _mapper.Map<PokedexModelDto>(_));
    return Ok(result);
  }

  [HttpPost("get/{Id}")]
  public async Task<ActionResult<PokedexModel>> GetPokedexModelById([FromRoute] GetPokedexByIdQuery request)
  {
    var pokedex = await _mediator.Send(request);
    var result = _mapper.Map<PokedexModelDto>(pokedex);
    return Ok(result);
  }

  [HttpPost("update")]
  public async Task<ActionResult<PokedexModel>> Update([FromBody] UpdatePokedexCommand request)
  {
    var pokedex = await _mediator.Send(request);
    var result = _mapper.Map<PokedexModelDto>(pokedex);
    return Ok(result);
  }

  [HttpPost("delete")]
  public async Task<ActionResult<int>> Delete()
  {
    var result = await _mediator.Send(new DeletePokedexCommand());
    return Ok(result);
  }

  [HttpPost("delete/{Id}")]
  public async Task<ActionResult<int>> Delete([FromRoute] DeletePokedexByIdCommand request)
  {
    var result = await _mediator.Send(request);
    return Ok(result);
  }

  [HttpPost("create")]
  public async Task<ActionResult<PokedexModel>> Create([FromBody] InsertPokedexCommand request)
  {
    var pokedex = await _mediator.Send(request);
    var result = _mapper.Map<PokedexModelDto>(pokedex);
    return Ok(result);
  }
}
