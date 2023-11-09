using FluentAssertions;

namespace GildedRose.Test
{
    public class GildedRoseShould
    {
        

        [Test]
        public void degrade_quality_twice_after_sell_in_expiration()
        {
            var items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 } };
            var gildedRose = new GildedRose(items);
            gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 18 } };

            items.Should().BeEquivalentTo(expectedItems);

        }


        [Test]
        public void prevent_quality_from_going_negative()
        {
            var items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 0 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 0 } };
            items.Should().BeEquivalentTo(expectedItems);
        }

        [Test]
        public void increase_aged_brie_quality()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 } };
            items.Should().BeEquivalentTo(expectedItems);
        }

        [Test]
        public void raise_aged_brie_quality_twice_when_sell_in_passes()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 2 } };
            items.Should().BeEquivalentTo(expectedItems);
        }

        [Test]
        public void ensure_quality_stays_below_fifty()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
            items.Should().BeEquivalentTo(expectedItems);
        }

     
        [Test]
        public void preserve_sulfuras_quality()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            items.Should().BeEquivalentTo(expectedItems);
        }


        [Test]
        public void raise_backstage_passes_quality()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 21 } };
            items.Should().BeEquivalentTo(expectedItems);
        }

        [Test]
        public void raise_backstage_passes_quality_twice_if_sell_in_under_eleven()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 22 } };
            items.Should().BeEquivalentTo(expectedItems);
        }

        [Test]
        public void raise_backstage_passes_quality_by_three_when_sell_in_under_six()
        {
            var items = new List<Item>
                { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 23 } };
            items.Should().BeEquivalentTo(expectedItems);
        }

        [Test]
        public void degrade_to_zero_quality_when_sell_in_passed()
        {
            var items = new List<Item>
                { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 } };
            items.Should().BeEquivalentTo(expectedItems);
        }

        [Test]
        public void degrade_conjured_quality_twice()
        {
            var items = new List<Item> { new Item { Name = "Conjured", SellIn = 1, Quality = 20 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 18 } };
            items.Should().BeEquivalentTo(expectedItems);
        }

        [Test]
        public void preserve_conjured_quality_under_zero()
        {
            var items = new List<Item> { new Item { Name = "Conjured", SellIn = 1, Quality = 1 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 0 } };
            items.Should().BeEquivalentTo(expectedItems);
        }

        [Test]
        public void degrade_conjured_quality_by_four_if_sell_in_passed()
        {
            var items = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 5 } };
            var gildedRose = new GildedRose(items);

            gildedRose.UpdateQuality();

            var expectedItems = new List<Item> { new Item { Name = "Conjured", SellIn = -1, Quality = 1 } };
            items.Should().BeEquivalentTo(expectedItems);
        }
    }
}