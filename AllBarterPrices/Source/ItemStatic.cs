using System.Diagnostics;

namespace AllBarterPrices.Source
{
	/// <summary>
	/// Provides static item information.
	/// </summary>
	public static class ItemStatic
	{
		/// <summary>
		/// Collection of resource identifiers and their prices. Readonly.
		/// </summary>
		public readonly static IReadOnlyDictionary<string, int> Resources = new Dictionary<string, int>()
		{
			{ "9dknl", 2 },
			{ "191kg", 1 },
			{ "w30g2", 3 },
			{ "j0z30", 4 },
			{ "rj6gv", 4},
			{ "pj52w", 4 },
			{ "vn0yr", 4 },
			{ "gn9l6", 6 },
			{ "556z1", 21 },
			{ "olzr6", 40},
			{ "77o96", 8 },
			{ "6ol3p", 5 },
			{ "9dkgl", 7 },
			{ "191ng", 66 },
			{ "vn0wr", 8 },
			{ "dr6nj", 10 },
			{ "21gkl", 7 },
			{ "77ov6", 42 },
			{ "21365", 15 },
			{ "34305", 12 },
			{ "6o7m0", 86 },
			{ "9d1qy", 240 },
			{ "19402", 200 },
		};

		/// <summary>
		/// Collection of Lyubech resources identifiers and their prices. Readonly.
		/// </summary>
		public readonly static IReadOnlyDictionary<string, int> LyubechResources = new Dictionary<string, int>()
		{
			{ "21365", 15 },
			{ "34305", 12 },
			{ "6o7m0", 86 },
			{ "9d1qy", 240 },
			{ "19402", 200 },
		};

		/// <summary>
		/// Recieves resource price by given identifier.
		/// </summary>
		/// <param name="identifier">Resource identifier</param>
		/// <returns>Resource price.</returns>
		public static int GetResourcePrice(string identifier)
		{
			return Resources[identifier];
		}

		/// <summary>
		/// Tries to recieve resource price by given identifier.
		/// </summary>
		/// <param name="identifier">Resource identifier</param>
		/// <returns>Resource price.</returns>
		public static int TryGetResourcePrice(string identifier)
		{
			Resources.TryGetValue(identifier, out int value);
			return value;
		}

		/// <summary>
		/// Collection of identifiers with ratio of basic and rare (big) resource. Readonly.
		/// </summary>
		public readonly static IReadOnlyDictionary<string, string> ResourcesRatio = new Dictionary<string, string>()
		{
			{ "9dknl", "gn9y6" },
			{ "191kg", "z30yy" },
			{ "w30g2", "kr53y" },
			{ "j0z30", "009n9" },
			{ "rj6gv", "olz36" },
			{ "pj52w", "34z1l" },
			{ "vn0yr", "77oy6" },
			{ "gn9l6", "y40kk" },
			{ "556z1", "4k5gr" },
			{ "21gpl", "olzr6"},
			{ "77o96", "gn956" },
			{ "6ol3p", "z301y" },
			{ "9dkgl", "55621" },
			{ "191ng", "y409k" },
			{ "vn0wr", "gn976" },
			{ "dr6nj", "z30my" },
			{ "21gkl", "9dk7y" },
			{ "77ov6", "gn975" },
			{ "21365", "gnpr5" },
			{ "34305", "z3ogm" },
			{ "6o7m0", "y4y33" },
			{ "9d1qy", "w3zj3" },
			{ "19402", "4k3qo" },
		};
	}
}
