using Newtonsoft.Json;

namespace AllBarterPrices.Source.Database.Recipes
{
	public record struct Offer(
			[property: JsonProperty("currency")] string Currency,
			[property: JsonProperty("cost")] int Price,
			[property: JsonProperty("requiredItems")] List<DbBarterItem> RequiredItems
		);
}