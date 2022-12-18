using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Library.Model;
using Pokedex.Library.Queries.Pokedex;

namespace Pokedex.Api.Controllers
{
	[Route("api/pokedex")]
	[ApiController]
	public class PokedexModelsController : ControllerBase
	{
		private IMediator _mediator;

		public PokedexModelsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<List<PokedexModel>> GetPokedexModelList()
		{
			var result = await _mediator.Send(new GetPokedexListQuery());
			return result;
		}
	}
}
