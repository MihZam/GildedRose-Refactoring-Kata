using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class AgingItemsTests
    {
        [Fact]
        public void AgingItemSellInDecreasesBy1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn);
        }

        [Fact]
        public void AgingItemQualityIncreasesBy1BeforeSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(31, Items[0].Quality);
        }

        [Fact]
        public void AgingItemQualityNeverExceeds50BeforeSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void AgingItemQualityIncreasesBy2AfterSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(32, Items[0].Quality);
        }

        [Fact]
        public void AgingItemQualityNeverExceeds50AfterSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void AgingItemQualityBothIncreasingTypesWork()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(33, Items[0].Quality);
        }
    }
}