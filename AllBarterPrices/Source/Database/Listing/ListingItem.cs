using AllBarterPrices.Source.Database.Shared;
using Newtonsoft.Json;

namespace AllBarterPrices.Source.Database.Listing
{
	public record struct ListingItem(
			[property: JsonProperty("data")] string Data,
			[property: JsonProperty("icon")] string Icon,
			[property: JsonProperty("name")] Name Name
		);
}
