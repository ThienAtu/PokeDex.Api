using Microsoft.AspNetCore.Components;
using Pokedex.Library.Dtos;
using Pokedex.Web.Services.Pokedex;

namespace Pokedex.Web.Pages;

public class PokedexBase : ComponentBase
{
	[Inject]
	public IPokedexService? PokedexService { get; set; }

	public IEnumerable<PokedexModelDto?>? Pokedexs { get; set; }

	protected override async Task OnInitializedAsync()
	{
		Pokedexs = await PokedexService!.Get();
	}
}
