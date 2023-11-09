using GildedRose.Model;

namespace GildedRose
{
    public class ItemsFactory
    {

        public DegradableItem Create(Item item)
        {
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                      return new Sulfuras();

                case "Conjured":
                    return new Conjured();

                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePasses();

                case "Aged Brie":
                    return new AgeBrie();



                default:
                    return new RegularItem();
                     
            }
            
        }
    }

   
}