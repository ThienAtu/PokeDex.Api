using Pokedex.Library.Data.PokeUser;
using System.Security.Cryptography;
using System.Text;

namespace Pokedex.Library.Security;

public class PasswordHasher
{
  private const int PASSWORD_SALT_LENGHT = 172;
  private readonly IPokeUserRepository _repository;

  public PasswordHasher(IPokeUserRepository repository)
  {
    _repository = repository;
  }

  public static string CreatePasswordHash(string password)
  {
    using (var hmac = new HMACSHA512())
    {
      var passwordSalt = hmac.Key;
      var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

      var result = string.Concat(
        Convert.ToBase64String(passwordSalt),
        Convert.ToBase64String(passwordHash));
      return result;
    }
  }

  public async Task<bool> VerifyPassword(string userName, string password)
  {
    var passwordSalt = await _repository.GetPasswordSalt(userName);
    if (string.IsNullOrEmpty(passwordSalt)) return false;
    using (var hmac = new HMACSHA512(Convert.FromBase64String(passwordSalt)))
    {
      var user = await _repository.GetUser(userName);
      var passwordHash = user!.Password.Substring(passwordSalt.Length);
      var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
      var result = computeHash.SequenceEqual(Convert.FromBase64String(passwordHash));
      return result;
    }
  }
}
