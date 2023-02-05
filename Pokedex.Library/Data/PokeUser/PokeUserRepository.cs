using Microsoft.EntityFrameworkCore;
using Pokedex.Library.Model;

namespace Pokedex.Library.Data.PokeUser;

public class PokeUserRepository : IPokeUserRepository
{
  private readonly PokedexDbContext _context;

  public PokeUserRepository(PokedexDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<PokeUserModel>> GetUser()
  {
    var result = await _context.Users.FromSqlRaw("EXEC sp_PokeUser_Get").ToArrayAsync();
    return result;
  }

  public async Task<PokeUserModel?> GetUser(int id)
  {
    var result = await _context.Users.FromSqlRaw($"EXEC sp_PokeUser_GetById {id}").ToArrayAsync();
    return result.FirstOrDefault();
  }

  public async Task<PokeUserModel?> GetUser(string userName)
  {
    var result = await _context.Users.FromSqlRaw($"EXEC sp_PokeUser_GetByUserName {userName}").ToArrayAsync();
    return result.FirstOrDefault();
  }

  public async Task<PokeUserModel?> CheckLogIn(string userName, string password)
  {
    var result = await _context.Users.FromSqlRaw($"EXEC sp_PokeUser_CheckLogIn {userName}, {password}").ToArrayAsync();
    return result.FirstOrDefault();
  }

  private string CreateParam(PokeUserModel model, bool hasId = false)
  {
    var param = hasId ? $"{model.Id}," : string.Empty;
    param += string.Join(
      ",",
      model.UserName,
      model.Password,
      model.Status);

    return param;
  }

  public async Task<string> GetPasswordSalt(string userName)
  {
    var result = await _context.Database.SqlQueryRaw<string>($"EXEC sp_PokeUser_GetPasswordSalt {userName}").ToArrayAsync();
    return result.FirstOrDefault()!;
  }
}
