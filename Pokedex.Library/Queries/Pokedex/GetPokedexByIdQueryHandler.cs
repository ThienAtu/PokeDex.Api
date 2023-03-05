using MediatR;
using Pokedex.Library.Data.Pokedex;
using Pokedex.Library.Model;

namespace Pokedex.Library.Queries.Pokedex;

public class GetPokedexByIdQuery : IRequest<PokedexModel>
{
  public class GetPokedexByIdQueryHandler : IRequestHandler<GetPokedexByIdQuery, PokedexModel>
  {
    private readonly IPokedexResponsitory _responsitory;

    public GetPokedexByIdQueryHandler(IPokedexResponsitory responsitory)
    {
      _responsitory = responsitory;
    }
    public Task<PokedexModel> Handle(GetPokedexByIdQuery request, CancellationToken cancellationToken)
    {
      var result = Task.FromResult(_responsitory.GetPokedexById(request.Id)).Result;
      if (result is null) throw new Exception($"{nameof(PokedexModel)} was not found !");
      return result!;
    }
  }

  public int Id { get; set; }
}
