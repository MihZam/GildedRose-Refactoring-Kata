using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class TicketItemsTests
    {
        [Fact]
        public void TicketItemSellInDecreasesBy1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn);
        }

        [Fact]
        public void TicketItemQualityIncreasesBy1Before10DaysRemaining()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(31, Items[0].Quality);
        }

        [Fact]
        public void TicketItemQualityNeverExceeds50Before10DaysRemaining()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void TicketItemQualityIncreasesBy2After10DaysRemaining()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(32, Items[0].Quality);
        }

        [Fact]
        public void TicketItemQualityNeverExceeds50After10DaysRemaining()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
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
        public void TicketItemQualityNeverExceeds50After5DaysRemaining()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 48 } };
            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
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
    }
}