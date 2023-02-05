using MediatR;
using Pokedex.Library.Data.PokeUser;
using Pokedex.Library.Model;

namespace Pokedex.Library.Queries.PokeUser;

public class GetUserListQuery : IRequest<IEnumerable<PokeUserModel>>
{
  public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, IEnumerable<PokeUserModel>>
  {
    private readonly IPokeUserRepository _repository;

    public GetUserListQueryHandler(IPokeUserRepository repository)
    {
      _repository = repository;
    }

    public async Task<IEnumerable<PokeUserModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
      var result = await Task.FromResult(_repository.GetUser()).Result;
      if (result is null) throw new Exception($"{nameof(PokeUserModel)} was not found !");
      return result;
    }
  }
}
