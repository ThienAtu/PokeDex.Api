using MediatR;
using Pokedex.Library.Data.Pokedex;
using Pokedex.Library.Model;

namespace Pokedex.Library.Command.Pokedex;

public class InsertPokedexCommand : IRequest<PokedexModel>
{
  public class InsertPokedexCommandHandler : IRequestHandler<InsertPokedexCommand, PokedexModel>
  {
    private IPokedexResponsitory _responsitory;

    public InsertPokedexCommandHandler(IPokedexResponsitory responsitory)
    {
      _responsitory = responsitory;
    }

    public Task<PokedexModel> Handle(InsertPokedexCommand request, CancellationToken cancellationToken)
    {
      var pokedex = new PokedexModel
      {
        Number = request.Number,
        Name = request.Name,
        NameJapanese = request.NameJapanese,
        NameRomanji = request.NameRomanji,
        Type1 = request.Type1,
        Type2 = request.Type2,
        Height = request.Height,
        Weight = request.Height,
        ImageUrl = request.ImageUrl
      };

      var result = Task.FromResult(_responsitory.AddPokedex(pokedex).Result);
      return result!;
    }
  }

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
