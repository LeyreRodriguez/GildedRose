using GildedRose.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Model
{
    internal class Conjured : DegradableItem
    {
        public void Update(Item item)
        {
            UpdateItem.DecreaseSellIn(item);
            var quantity = 2;
            if (UpdateItem.IsPassed(item.SellIn))
            {
                quantity = 4;
            }
            UpdateItem.DecreaseQuality(item, quantity);

        }
    }
}
