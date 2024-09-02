using AllBarterPrices.Source.App;
using AllBarterPrices.Source.Database.Items;
using AllBarterPrices.Source.Database.Listing;
using AllBarterPrices.Source.Database.Recipes;
using Newtonsoft.Json;

namespace AllBarterPrices.Source.Database
{
	/// <summary>
	/// Provides methods for parsing STALCRAFT Database
	/// </summary>
	public static class Parser
	{
		public static readonly IReadOnlyList<SettlementRecipes> _settlements = GetAllRecipes();
		public static readonly IReadOnlyList<ListingItem> _listing = GetListing();

		/// <summary>
		/// Deserializing recipes file.
		/// </summary>
		/// <returns>Deserialized recipes</returns>
		public static List<SettlementRecipes> GetAllRecipes()
		{
			return JsonConvert.DeserializeObject<List<SettlementRecipes>>(File.ReadAllText(Preferences.CurrentPreferences.BarterRecipesPath))!;
		}

		/// <summary>
		/// Deserializing listing file.
		/// </summary>
		/// <returns>Deserialized listing</returns>
		public static List<ListingItem> GetListing()
		{
			return JsonConvert.DeserializeObject<List<ListingItem>>(File.ReadAllText(Preferences.CurrentPreferences.ListingPath))!;
		}

		/// <summary>
		/// Parsing STALCRAFT Database to get all barter items.
		/// </summary>
		/// <returns>Collection of parsed items.</returns>
		public static List<Item> GetAllBarterItems()
		{
			List<Item> items = [];
			List<string> temp = [];

			string name = string.Empty;
			int price = 0;
			Location location = Location.None;

			foreach (SettlementRecipes settlementRecipes in _settlements)
			{
				foreach (Recipe recipe in settlementRecipes.Recipes)
				{
					if (temp.Contains(recipe.Item))
					{
						continue;
					}

					foreach (Offer offer in recipe.Offers)
					{
						name = _listing.Where(v => SanitizeData(v.Data) == recipe.Item).First().Name.Lines.Ru; ;
						price = 0;
						location = Location.None;
						foreach (DbBarterItem dbBarterItem in offer.RequiredItems)
						{
							price += ItemStatic.TryGetResourcePrice(dbBarterItem.Identifier) * dbBarterItem.Amount;

							if (location != Location.Special && ItemStatic.LyubechResources.ContainsKey(dbBarterItem.Identifier))
							{
								location = Location.Special;
							}
						}
						temp.Add(recipe.Item);
						items.Add(new(name, price, location));
					}
				}
			}
			return items;
		}

		/// <summary>
		/// Sanitizes given item file path to an identifier only.
		/// </summary>
		/// <param name="s">String to sanitize.</param>
		/// <returns>Sanitized string.</returns>
		public static string SanitizeData(string s)
		{
			string reversed = new(s.Reverse().ToArray());
			for (int i = 0; i < s.Length; i++)
			{
				if (reversed[i] == '/')
				{
					return s[^i..].Replace(".json", ""); ;
				}
			}
			return string.Empty;
		}
    }
}
