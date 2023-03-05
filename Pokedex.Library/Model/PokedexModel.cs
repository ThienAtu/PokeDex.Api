using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Library.Model;

public class PokedexModel
{
  [Key]
  [StringLength(3)]
  public int Id { get; set; }

  [Column(TypeName = "nvarchar(3)")]
  public string Number { get; set; } = string.Empty;

  [Column(TypeName = "nvarchar(200)")]
  public string Name { get; set; } = string.Empty;

  [Column(TypeName = "nvarchar(200)")]
  public string NameJapanese { get; set; } = string.Empty;

  [Column(TypeName = "nvarchar(200)")]
  public string NameRomanji { get; set; } = string.Empty;

  [Column(TypeName = "nvarchar(200)")]
  public string Type1 { get; set; } = string.Empty;

  [Column(TypeName = "nvarchar(200)")]
  public string Type2 { get; set; } = string.Empty;

  [Column(TypeName = "decimal(18,1)")]
  public decimal Height { get; set; }

  [Column(TypeName = "decimal(18,1)")]
  public decimal Weight { get; set; }

  [Column(TypeName = "nvarchar(200)")]
  public string ImageUrl { get; set; } = string.Empty;
}
