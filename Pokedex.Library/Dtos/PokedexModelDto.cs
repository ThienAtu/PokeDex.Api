namespace Pokedex.Library.Dtos;

public class PokedexModelDto
{
  public string Number { get; set; } = string.Empty;

  public string Name { get; set; } = string.Empty;

  public string NameJapanese { get; set; } = string.Empty;

  public string NameRomanji { get; set; } = string.Empty;

  public string Type1 { get; set; } = string.Empty;

  public string Type2 { get; set; } = string.Empty;

  public decimal Height { get; set; }

  public decimal Weight { get; set; }

  public string ImageUrl { get; set; } = string.Empty;
}
