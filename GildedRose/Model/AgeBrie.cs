using GildedRose.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Model
{
    internal class AgeBrie : DegradableItem
    {
        public void Update(Item item)
        {
            UpdateItem.DecreaseSellIn(item);
            var quantity = 1;
            if (UpdateItem.IsPassed(item.SellIn))
            {
                quantity = 2;
            }
            UpdateItem.IncreaseQuality(item, quantity);

        }
    }
}
