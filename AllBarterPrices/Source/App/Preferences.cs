using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace AllBarterPrices.Source.App
{
	/// <summary>
	/// Represents application preferences.
	/// </summary>
	internal readonly struct Preferences
	{
		private const string FILE_NAME = "preferences.json";

		private readonly static string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILE_NAME);

		/// <summary>
		/// Empty <see cref="Preferences"/> instance.
		/// </summary>
		public readonly static Preferences Empty = new();

		private static Preferences _instance;

		/// <summary>
		/// Current <see cref="Preferences"/> instance.
		/// </summary>
		public static Preferences CurrentPreferences
		{
			get => _instance != Empty ? _instance : (_instance = Deserialize());
		}

		/// <summary>
		/// Path to barter recipes file.
		/// </summary>
		public readonly string BarterRecipesPath;

		/// <summary>
		/// Path to items listing.
		/// </summary>
		public readonly string ListingPath;

		/// <summary>
		/// Deserializes preferences from <see cref="AppDomain.CurrentDomain.BaseDirectory"/>.
		/// </summary>
		/// <returns>Deserialized <see cref="Preferences"/> instance.</returns>
		/// <exception cref="ApplicationException"></exception>
		public static Preferences Deserialize()
		{
			Preferences p = default;
			try
			{
				p = JsonConvert.DeserializeObject<Preferences>(File.ReadAllText(FilePath));
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine($"Preferences file ({FILE_NAME}) not found at {AppDomain.CurrentDomain.BaseDirectory}" +
					$"{Environment.NewLine} New preferences file will be generated.");
				Generate();
			}

			if (p == Empty)
			{
				throw new ApplicationException($"Define STALCRAFT Database files paths at {FilePath}.");
			}
			return p;
		}

		/// <summary>
		/// Generates empty <see cref="Preferences"/> instance and writes with <see cref="StreamWriter"/>. Then throw <see cref="ApplicationException"/>.
		/// </summary>
		/// <exception cref="ApplicationException"></exception>
		public static void Generate()
		{
			string json = JsonConvert.SerializeObject(new Preferences(), Formatting.Indented);

			using (StreamWriter sw = File.CreateText(FilePath))
			{
				sw.Write(json);
			}
			throw new ApplicationException($"Define STALCRAFT Database files paths at {FilePath}.");
		}

		public override bool Equals([NotNullWhen(true)] object? obj)
		{
			Preferences preferences = (Preferences)obj!;
			bool recipesPath = BarterRecipesPath == preferences.BarterRecipesPath;
			bool listingPath = ListingPath == preferences.ListingPath;
			if (recipesPath && listingPath)
			{
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[JsonConstructor]
		private Preferences(string barterRecipesPath, string listingPath)
		{
			BarterRecipesPath = barterRecipesPath;
			ListingPath = listingPath;
		}

		public static bool operator ==(Preferences left, Preferences right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Preferences left, Preferences right)
		{
			return !(left == right);
		}
	}
}
