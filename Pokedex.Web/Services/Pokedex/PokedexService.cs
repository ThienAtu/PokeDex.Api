using Pokedex.Library.Dtos;
using System.Net.Http.Json;

namespace Pokedex.Web.Services.Pokedex;

public class PokedexService : IPokedexService
{
  private readonly HttpClient _httpClient;

  public PokedexService(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }
    
  public async Task<IEnumerable<PokedexModelDto>> GetPokedex()
  {
    try
    {
      var pokedexs = await _httpClient.PostAsJsonAsync("api/pokedex/get", new { });
      var result = await pokedexs.Content.ReadFromJsonAsync<List<PokedexModelDto>>();
      return result!;
    }
    catch (Exception)
    {
      throw;
    }
  }

  public async Task<PokedexModelDto?> GetPokedexById(int id)
  {
    try
    {
      var pokedexs = await _httpClient.PostAsJsonAsync($"api/pokedex/get/{id}", new { });
      //var pokedexs = await _httpClient.PostAsync($"api/pokedex/get/{id}", null);
      var result = await pokedexs.Content.ReadFromJsonAsync<PokedexModelDto>();
      return result!;
    }
    catch (Exception)
    {
      throw;
    }
  }
}
