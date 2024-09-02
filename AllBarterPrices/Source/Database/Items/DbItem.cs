using AllBarterPrices.Source.Database.Shared;
using Newtonsoft.Json;

namespace AllBarterPrices.Source.Database.Items
{
	public record DbItem(
		[property: JsonProperty("id")] string Identifier,
		[property: JsonProperty("category")] string Category,
		[property: JsonProperty("name")] Name Name,
		[property: JsonProperty("color")] string Color
		);
}
