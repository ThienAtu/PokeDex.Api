using MediatR;
using Pokedex.Library.Data.Pokedex;
using Pokedex.Library.Model;

namespace Pokedex.Library.Queries.Pokedex;

public class GetPokedexModelByIdQuery : IRequest<PokedexModel>
{
	public class GetPokedexModelByIdQueryHandler : IRequestHandler<GetPokedexModelByIdQuery, PokedexModel>
	{
		private readonly IPokedexResponsitory _responsitory;

		public GetPokedexModelByIdQueryHandler(IPokedexResponsitory responsitory)
		{
			_responsitory = responsitory;
		}
		public Task<PokedexModel> Handle(GetPokedexModelByIdQuery request, CancellationToken cancellationToken)
		{
			var result = Task.FromResult(_responsitory.GetPokedexModelById(request.Id)).Result;
			if (result is null) throw new Exception($"{nameof(PokedexModel)} was not found !");
			return result!;
		}
	}

	public int Id { get; set; }
}
