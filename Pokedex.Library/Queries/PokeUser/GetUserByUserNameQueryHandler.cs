using MediatR;
using Pokedex.Library.Data.PokeUser;
using Pokedex.Library.Model;

namespace Pokedex.Library.Queries.PokeUser;

public class GetUserByUserNameQuery : IRequest<PokeUserModel>
{
  public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, PokeUserModel>
  {
    private readonly IPokeUserRepository _repository;

    public GetUserByUserNameQueryHandler(IPokeUserRepository repository)
    {
      _repository = repository;
    }

    public async Task<PokeUserModel> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
    {
      var result = await Task.FromResult(_repository.GetUser(request.UserName)).Result;
      if (result is null) throw new Exception($"{nameof(PokeUserModel)} was not found !");
      return result;
    }
  }

  public string UserName { get; set; } = string.Empty;
}
