using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            var checker = new TypeChecker();
            for (var i = 0; i < Items.Count; i++)
            {
                checker.CheckType(Items[i]);
            }
        }
    }
}
