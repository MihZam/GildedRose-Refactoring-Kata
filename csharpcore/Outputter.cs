using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class Outputter
    {
        public void DailyUpdate(int nr, IList<Item> Items)
        {
            var app = new GildedRose(Items);
            for (var i = 0; i < nr; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }

                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}