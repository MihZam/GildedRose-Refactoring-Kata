using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class LegendaryItemsTests
    {
        [Fact]
        public void LegendaryItemSellInIsFixed()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 3, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(3, Items[0].SellIn);
        }

        [Fact]
        public void LegendaryItemQualityIsFixedBeforeSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 3, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void LegendaryItemQualityIsFixedAfterSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -3, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);
        }
    }
}