using MediatR;
using Pokedex.Library.Data.Pokedex;
using Pokedex.Library.Model;

namespace Pokedex.Library.Queries.Pokedex;

public class GetPokedexListQuery : IRequest<List<PokedexModel>>
{
	public class GetPokedexListQueryHandler : IRequestHandler<GetPokedexListQuery, List<PokedexModel>>
	{
		private readonly IPokedexResponsitory _pokedexResponsitory;

		public GetPokedexListQueryHandler(IPokedexResponsitory pokedexResponsitory)
		{
			_pokedexResponsitory = pokedexResponsitory;
		}

		public Task<List<PokedexModel>> Handle(GetPokedexListQuery request, CancellationToken cancellationToken)
		{
			var result = Task.FromResult(_pokedexResponsitory.GetPokedexModelList());
			return result;
		}
	}
}
