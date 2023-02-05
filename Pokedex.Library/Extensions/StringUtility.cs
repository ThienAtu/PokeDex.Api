namespace Pokedex.Library.Extensions;

public class StringUtility
{
  public static string ToEmpty(string value)
  {
    if(value is null
      || (value == string.Empty))
    {
      return string.Empty;
    }

    return value;
  }
}
