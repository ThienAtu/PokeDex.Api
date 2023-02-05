using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Library.Model;

public class PokeUserModel
{
  [Key]
  public int Id { get; set; }

  [Column(TypeName = "nvarchar(200)")]
  public string UserName { get; set; } = string.Empty;

  [Column(TypeName = "nvarchar(200)")]
  public string Password { get; set; } = string.Empty;

  [Column(TypeName = "int")]
  public int RoleId { get; set; }

  [Column(TypeName = "tinyint")]
  public int Status { get; set; }
}
