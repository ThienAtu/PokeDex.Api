using MediatR;
using Pokedex.Library.Data.PokeUser;
using Pokedex.Library.Model;

namespace Pokedex.Library.Queries.PokeUser;

public class GetUserByIdQuery : IRequest<PokeUserModel>
{
  public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, PokeUserModel>
  {
    private readonly IPokeUserRepository _repository;

    public GetUserByIdQueryHandler(IPokeUserRepository repository)
    {
      _repository = repository;
    }

    public async Task<PokeUserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
      var result = await Task.FromResult(_repository.GetUser(request.Id)).Result;
      if (result is null) throw new Exception($"{nameof(PokeUserModel)} was not found !");
      return result;
    }
  }

  public int Id { get; set; }
}
