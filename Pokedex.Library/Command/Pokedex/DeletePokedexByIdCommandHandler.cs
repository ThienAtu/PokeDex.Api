using MediatR;
using Pokedex.Library.Data.Pokedex;

namespace Pokedex.Library.Command.Pokedex;

public class DeletePokedexByIdCommand : IRequest<int>
{
  public class DeletePokedexByIdCommandHandler : IRequestHandler<DeletePokedexByIdCommand, int>
  {
    private IPokedexResponsitory _responsitory;

    public DeletePokedexByIdCommandHandler(IPokedexResponsitory responsitory)
    {
      _responsitory = responsitory;
    }
    public Task<int> Handle(DeletePokedexByIdCommand request, CancellationToken cancellationToken)
    {
      var result = Task.FromResult(_responsitory.DeletePokedexById(request.Id).Result);
      return result;
    }
  }

  public int Id { get; set; }
}
