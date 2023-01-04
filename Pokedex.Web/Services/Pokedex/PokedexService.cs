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

	public async Task<IEnumerable<PokedexModelDto?>> Get()
	{
		try
		{
			var pokedexs = await _httpClient.PostAsJsonAsync("api/pokedex/get", new {});
			var result = await pokedexs.Content.ReadFromJsonAsync<List<PokedexModelDto>>();
			return result!;
		}
		catch (Exception)
		{
			throw;
		}
	}
}
