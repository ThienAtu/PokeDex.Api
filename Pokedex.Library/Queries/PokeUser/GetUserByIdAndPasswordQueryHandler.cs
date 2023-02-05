using MediatR;
using Pokedex.Library.Data.PokeUser;
using Pokedex.Library.Model;

namespace Pokedex.Library.Queries.PokeUser;

public class GetUserByIdAndPasswordQuery : IRequest<PokeUserModel>
{
  public class GetUserByIdAndPasswordQueryHandler : IRequestHandler<GetUserByIdAndPasswordQuery, PokeUserModel>
  {
    private readonly IPokeUserRepository _repository;

    public GetUserByIdAndPasswordQueryHandler(IPokeUserRepository repository)
    {
      _repository = repository;
    }

    public async Task<PokeUserModel> Handle(GetUserByIdAndPasswordQuery request, CancellationToken cancellationToken)
    {
      var result = await Task.FromResult(_repository.CheckLogIn(request.UserName, request.Password)).Result;
      if (result is null) throw new Exception($"{nameof(PokeUserModel)} was not found !");
      return result;
    }
  }

  public string UserName { get; set; } = string.Empty;

  public string Password { get; set; } = string.Empty;
}
