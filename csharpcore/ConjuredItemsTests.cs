using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class ConjuredItemsTests
    {
        [Fact]
        public void ConjuredItemSellInDecreasesBy1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn);
        }

        [Fact]
        public void ConjuredItemQualityDecreasesBy2BeforeSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(28, Items[0].Quality);
        }

        [Fact]
        public void ConjuredItemSellInGoesNegative()
        {
            IList<Item> Items = new List<Item> {new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 30}};
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
        }

        [Fact]
        public void ConjuredItemQualityDecreasesBy4AfterSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(26, Items[0].Quality);
        }

        [Fact]
        public void ConjuredItemQualityBothDecreasingTypesWork()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 1, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(24, Items[0].Quality);
        }

        [Fact]
        public void ConjuredItemQualityReaches0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void ConjuredItemQualityStaysNonNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
    }
}