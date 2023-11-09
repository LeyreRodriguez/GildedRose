using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Helper;
public class UpdateItem
{
    public static void DecreaseSellIn(Item item)
    {
        item.SellIn -= 1;
    }

    public static void IncreaseQuality(Item item, int quantity = 1)
    {
        item.Quality += quantity;
        if (item.Quality > 50)
        {
            item.Quality = 50;
        }
    }

    public static void DecreaseQuality(Item item, int quantity = 1)
    {
        item.Quality -= quantity;
        if (item.Quality < 0)
        {
            item.Quality = 0;
        }
    }

    public static bool IsPassed(int sellIn)
    {
        return sellIn < 0;
    }
}
