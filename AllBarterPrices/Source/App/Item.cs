using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllBarterPrices.Source.App
{
    /// <summary>
    /// Represents parsed Item.
    /// </summary>
	public readonly struct Item
	{
        /// <summary>
        /// Item user-friendly name.
        /// </summary>
		public string Name { get; init; }

        /// <summary>
        /// Item price in exchange tokens.
        /// </summary>
		public int Price { get; init; }

        public Item(string name, int price)
        {
            Name = name; 
            Price = price;
        }
    }
}
