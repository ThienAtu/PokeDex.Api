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
    var pokeList = new List<PokedexModelDto?>();
    if (this.Id == 0) pokeList.AddRange(await PokedexService!.GetPokedex());
    else
    {
      var poke = await PokedexService!.GetPokedexById(this.Id);
      pokeList.Add(poke);
    }

    Pokedexs = pokeList;
  }

  protected override Task OnParametersSetAsync()
  {
    return base.OnParametersSetAsync();
  }

  [Parameter]
  public int Id { get; set; }
}