using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Model;
public class RegularItem : DegradableItem
{
    public void Update(Item item)
    {
        item.SellIn--;
        var quantity = 1;
        if (item.SellIn < 0) quantity = 2;
        item.Quality -= quantity;
        if (item.Quality < 0)
        {
            item.Quality = 0;
        }
    }
}
