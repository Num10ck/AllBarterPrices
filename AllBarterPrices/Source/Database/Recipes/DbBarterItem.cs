using Newtonsoft.Json;

namespace AllBarterPrices.Source.Database.Recipes
{
	public record struct DbBarterItem(
			[property: JsonProperty("item")] string Identifier,
			[property: JsonProperty("amount")] int Amount
		);
}