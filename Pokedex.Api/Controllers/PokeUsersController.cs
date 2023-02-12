using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Library.Data.PokeUser;
using Pokedex.Library.Dtos;
using Pokedex.Library.Model;
using Pokedex.Library.Queries.PokeUser;
using Pokedex.Library.Security;

namespace Pokedex.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokeUsersController : ControllerBase
{
  private readonly IMediator _mediator;
  private readonly IMapper _mapper;
  private readonly IConfiguration _configuration;
  private readonly IPokeUserRepository _repository;

  public PokeUsersController(IMediator mediator, IMapper mapper, IConfiguration configuration, IPokeUserRepository repository)
  {
    _mediator = mediator;
    _mapper = mapper;
    _configuration = configuration;
    _repository = repository;
  }

  [HttpPost("get")]
  public async Task<ActionResult<IEnumerable<PokeUserModel>>> Get()
  {
    var users = await _mediator.Send(new GetUserListQuery());
    var result = users.Select(_ => _mapper.Map<PokeUserModelDto>(_));
    return Ok(result);
  }

  [HttpPost("get/{Id}"), Authorize(Roles = "Admin")]
  public async Task<ActionResult<PokeUserModel>> GetById([FromRoute] GetUserByIdQuery request)
  {
    var user = await _mediator.Send(request);
    var result = _mapper.Map<PokeUserModelDto>(user);
    return Ok(result);
  }

  [HttpPost("login")]
  public async Task<ActionResult<string>> Login(GetUserByIdAndPasswordQuery request)
  {
    var token = string.Empty;
    var verifyPassword = await new PasswordHasher(_repository).VerifyPassword(request.UserName, request.Password);
    if (verifyPassword)
    {
      var user = await _repository.GetUser(request.UserName);
      token = new JwtProvider(_configuration).Generate(user!);
    }
    return Ok(token);
  }
}
