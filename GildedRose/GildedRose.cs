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

                
            }
        }
    }

    public interface DegradableItem
    {
        void Update(Item item);
    }

    

    
}