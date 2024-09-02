using Newtonsoft.Json;

namespace AllBarterPrices.Source.Database.Shared
{
	public record struct Lines(
		[property: JsonProperty("ru")] string Ru,
		[property: JsonProperty("en")] string En
		);
}
