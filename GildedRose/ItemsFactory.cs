namespace GildedRose
{
    public class ItemsFactory
    {

        public DegradableItem Create(Item item)
        {
            switch (item.Name)
            {
                case "Sulfuras":
                      return new Sulfuras();
                      


                default:
                    return new AgeBrie();
                     
            }
            
        }
    }

    internal class AgeBrie : DegradableItem
    {
        public void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }

    internal class Sulfuras : DegradableItem
    {
        public void Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}