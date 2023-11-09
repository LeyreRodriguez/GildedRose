namespace GildedRose
{
    public class GildedRose
    {
        public IList<Item> Items;
        private ItemsFactory factory;

        public GildedRose(IList<Item> items)
        {
            Items = items;
            factory = new ItemsFactory();
           // factory.Create(new Item());

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {

                var degradableItem = factory.Create(item);
                degradableItem.Update(item);



                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                            item.Quality--;
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item is { SellIn: < 11, Quality: < 50 }) item.Quality = item.Quality + 1;

                            if (item.SellIn < 6)
                                if (item.Quality < 50)
                                    item.Quality = item.Quality + 1;
                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros") item.SellIn = item.SellIn - 1;

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                    item.Quality = item.Quality - 1;
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50) item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }

    public interface DegradableItem
    {
        void Update(Item item);
    }

    

    
}