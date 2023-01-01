using MediatR;
using Pokedex.Library.Data.Pokedex;
using Pokedex.Library.Model;

namespace Pokedex.Library.Command.Pokedex;

public class UpdatePokedexCommand : IRequest<PokedexModel>
{
	public class UpdatePokedexCommandHandler : IRequestHandler<UpdatePokedexCommand, PokedexModel>
	{
		private IPokedexResponsitory _responsitory;

		public UpdatePokedexCommandHandler(IPokedexResponsitory responsitory)
		{
			_responsitory = responsitory;
		}

		public Task<PokedexModel> Handle(UpdatePokedexCommand request, CancellationToken cancellationToken)
		{
			var pokedex = new PokedexModel
			{
				Id = request.Id,
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

			var result = Task.FromResult(_responsitory.UpdatePokedex(pokedex).Result);
			return result!;
		}
	}

	public int Id { get; set; }

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
