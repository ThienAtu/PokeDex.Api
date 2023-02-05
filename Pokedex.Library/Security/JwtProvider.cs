using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pokedex.Library.Abstractions;
using Pokedex.Library.Extensions;
using Pokedex.Library.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pokedex.Library.Security;

public class JwtProvider : IJwtProvider
{
  private readonly IConfiguration _configuration;

  public JwtProvider( IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public string Generate(PokeUserModel user)
  {
    var claims = new Claim[]
    {
      new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
      new (JwtRegisteredClaimNames.Name, user.UserName),
    };

    var secretKey = _configuration.GetSection("JwtOption:SecretKey").Value;
    var signingCredentials = new SigningCredentials(
      new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StringUtility.ToEmpty(secretKey!))),
      SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
      claims: claims,
      expires: DateTime.Now.AddHours(1),
      signingCredentials: signingCredentials);

    var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
    return tokenValue;
  }
}
