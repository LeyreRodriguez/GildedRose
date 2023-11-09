using GildedRose.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Model
{
    internal class BackstagePasses : DegradableItem
    {
        public void Update(Item item)
        {
            UpdateItem.DecreaseSellIn(item);
            if (UpdateItem.IsPassed(item.SellIn))
            {
                item.Quality = 0;
                return;
            }
            var quantity = 1;
            if (item.SellIn < 11)
            {
                quantity = 2;
            }
            if (item.SellIn <6)
            {
                quantity = 3;
            }
            UpdateItem.IncreaseQuality(item, quantity);

        }


    }
}
