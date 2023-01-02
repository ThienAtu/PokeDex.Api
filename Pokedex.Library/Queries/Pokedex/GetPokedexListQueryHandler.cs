using MediatR;
using Pokedex.Library.Data.Pokedex;
using Pokedex.Library.Model;

namespace Pokedex.Library.Queries.Pokedex;

public class GetPokedexListQuery : IRequest<IEnumerable<PokedexModel>>
{
	public class GetPokedexListQueryHandler : IRequestHandler<GetPokedexListQuery, IEnumerable<PokedexModel>>
	{
		private readonly IPokedexResponsitory _responsitory;

		public GetPokedexListQueryHandler(IPokedexResponsitory responsitory)
		{
			_responsitory = responsitory;
		}

		public Task<IEnumerable<PokedexModel>> Handle(GetPokedexListQuery request, CancellationToken cancellationToken)
		{
			var result = Task.FromResult(_responsitory.GetPokedex()).Result;
			if (result is null) throw new Exception($"{nameof(PokedexModel)} was not found !");
			return result;
		}
	}
}
