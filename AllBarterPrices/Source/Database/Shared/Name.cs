using Newtonsoft.Json;

namespace AllBarterPrices.Source.Database.Shared
{
	public record struct Name(
		[property: JsonProperty("key")] string Key,
		[property: JsonProperty("lines")] Lines Lines
		);
}
