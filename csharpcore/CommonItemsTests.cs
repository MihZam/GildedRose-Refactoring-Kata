using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class CommonItemsTests
    {
        [Fact]
        public void CommonItemSellInDecreasesBy1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 3, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn);
        }

        [Fact]
        public void CommonItemQualityDecreasesBy1BeforeSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 3, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(29, Items[0].Quality);
        }

        [Fact]
        public void CommonItemSellInGoesNegative()
        {
            IList<Item> Items = new List<Item> {new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 30}};
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
        }

        [Fact]
        public void CommonItemQualityDecreasesBy2AfterSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(28, Items[0].Quality);
        }

        [Fact]
        public void CommonItemQualityBothDecreasingTypesWork()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 1, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(27, Items[0].Quality);
        }

        [Fact]
        public void CommonItemQualityReaches0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void CommonItemQualityStaysNonNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
    }
}