using AllBarterPrices.Source.App;
using AllBarterPrices.Source.Database;

namespace AllBarterPrices
{
	public class Program
	{
		public static void Main(string[] args)
		{
			List<Item> items = Parser.GetAllBarterItems();

			using (StreamWriter fileStream = File.CreateText(Path.Combine(Environment.CurrentDirectory, "result.csv")))
			{
				string[] lines = ["Item", "Price"];
				foreach (Item item in items)
				{
					fileStream.WriteLine(string.Join(";", lines));
					lines = [string.Concat(item.Name, item.Location == Location.Special ? " (Любеч)" : string.Empty), item.Price.ToString()];
				}
			}
		}
	}
}