using Pokedex.Library.Model;

namespace Pokedex.Library.Data.PokeUser;

public interface IPokeUserRepository
{
  Task<IEnumerable<PokeUserModel>> GetUser();
  Task<PokeUserModel?> GetUser(int id);
  Task<PokeUserModel?> GetUser(string userName);
  Task<PokeUserModel?> CheckLogIn(string userName, string password);
  Task<string> GetPasswordSalt(string userName);
}
