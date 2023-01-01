using MediatR;
using Pokedex.Library.Data.Pokedex;
using Pokedex.Library.Model;

namespace Pokedex.Library.Queries.Pokedex;

public class GetPokedexListQuery : IRequest<List<PokedexModel>>
{
	public class GetPokedexListQueryHandler : IRequestHandler<GetPokedexListQuery, List<PokedexModel>>
	{
		private readonly IPokedexResponsitory _responsitory;

		public GetPokedexListQueryHandler(IPokedexResponsitory responsitory)
		{
			_responsitory = responsitory;
		}

		public Task<List<PokedexModel>> Handle(GetPokedexListQuery request, CancellationToken cancellationToken)
		{
			var result = Task.FromResult(_responsitory.GetPokedex()).Result;
			if (result is null) throw new Exception($"{nameof(PokedexModel)} was not found !");
			return result;
		}
	}
}
