using MediatR;
using Pokedex.Library.Data.Pokedex;

namespace Pokedex.Library.Command.Pokedex;

public class DeletePokedexCommand : IRequest<int>
{
	public class DeletePokedexCommandHandler : IRequestHandler<DeletePokedexCommand, int>
	{
		private readonly IPokedexResponsitory _responsitory;

		public DeletePokedexCommandHandler(IPokedexResponsitory responsitory)
		{
			_responsitory = responsitory;
		}
		public Task<int> Handle(DeletePokedexCommand request, CancellationToken cancellationToken)
		{
			var result = Task.FromResult(_responsitory.DeletePokedex().Result);
			return result;
		}
	}
}
