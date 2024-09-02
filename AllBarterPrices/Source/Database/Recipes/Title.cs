using AllBarterPrices.Source.Database.Shared;
using Newtonsoft.Json;

namespace AllBarterPrices.Source.Database.Recipes
{
	public record struct Title(
		[property: JsonProperty("lines")] Lines Lines
		);
}
