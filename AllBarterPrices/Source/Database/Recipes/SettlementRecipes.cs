using Newtonsoft.Json;

namespace AllBarterPrices.Source.Database.Recipes
{
	public record struct SettlementRecipes(
		[property: JsonProperty("settlementTitle")] Title Title,
		[property: JsonProperty("recipes")] List<Recipe> Recipes
		);
}
