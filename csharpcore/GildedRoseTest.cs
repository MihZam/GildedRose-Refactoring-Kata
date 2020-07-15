using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }
        
        /*
         * -------------------
         * Common items tests
         * -------------------
        */
        
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
        public void CommonItemQualityStaysNonNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
        
        /*
         * -------------------
         * Rare items tests
         * -------------------
        */
        
        [Fact]
        public void RareItemSellInDecreasesBy1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn);
        }
        
        [Fact]
        public void RareItemQualityIncreasesBy1BeforeSelDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(31, Items[0].Quality);
        }
        
        [Fact]
        public void RareItemQualityNeverExceeds50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }
        
        /*
         * -------------------
         * Aging items tests
         * -------------------
        */
        
        [Fact]
        public void AgingItemQualityIncreasesBy2AfterSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(32, Items[0].Quality);
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
        
        /*
         * -------------------
         * Ticket items tests
         * -------------------
        */
        
        [Fact]
        public void TicketItemQualityIncreasesBy2After10DaysRemaining()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(32, Items[0].Quality);
        }
        
        [Fact]
        public void TicketItemQualityIncreasesBy3After5DaysRemaining()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(33, Items[0].Quality);
        }
        
        [Fact]
        public void TicketItemQualityBecomes0AfterSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
        
        [Fact]
        public void TicketItemQualityRemains0OnNegativeSellDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -3, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
        
        /*
         * -------------------
         * Legendary items tests
         * -------------------
        */
        
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
        
        /*
         * -------------------
         * Conjured items tests
         * -------------------
        */
        
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
        public void ConjuredItemQualityStaysNonNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
        
        
    }
}