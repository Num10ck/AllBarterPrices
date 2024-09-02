using Newtonsoft.Json;

namespace AllBarterPrices.Source.Database.Recipes
{
	public record struct Recipe(
		[property: JsonProperty("settlementRequiredLevel")] int Reputation,
		[property: JsonProperty("item")] string Item,
		[property: JsonProperty("offers")] List<Offer> Offers
		);
}
