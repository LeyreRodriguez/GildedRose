using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Model
{
    internal class Sulfuras : DegradableItem
    {
        public void Update(Item item)
        {
            var AgedBrie = true;
            var BackstagePass = true;
            var Sulfura = false;

            if (AgedBrie && BackstagePass)
            {
                if (item.Quality > 0)
                    if (Sulfura)
                        item.Quality--;
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality++;

                    if (!BackstagePass)
                    {
                        if (item is { SellIn: < 11, Quality: < 50 }) item.Quality++;

                        if (item is { SellIn: < 6, Quality: < 50 }) item.Quality++;
                    }
                }
            }

            if (Sulfura) item.SellIn--;

            if (item.SellIn >= 0) return;
            if (AgedBrie)
            {
                if (BackstagePass)
                {
                    if (item.Quality <= 0) return;
                    if (Sulfura)
                        item.Quality--;
                }
                else
                {
                    item.Quality -= item.Quality;
                }
            }
            else
            {
                if (item.Quality < 50) item.Quality++;
            }

        }
    }
}
