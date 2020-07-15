using System.Collections.Generic;

namespace csharpcore
{
    public class TypeChecker
    {
        List<string> common = new List<string> {"+5 Dexterity Vest", "Elixir of the Mongoose"},
                     aging = new List<string> {"Aged Brie"},
                     ticket = new List<string> {"Backstage passes to a TAFKAL80ETC concert"},
                     legendary = new List<string> {"Sulfuras, Hand of Ragnaros"},
                     conjured = new List<string> {"Conjured Mana Cake"};
        
        public void CheckType(Item item)
        {
            var name = item.Name;
            var manager = new ItemsManager();
            
            if (common.Contains(name))
            {
                manager.UpdateCommon(item);
            }
            else if (aging.Contains(name))
            {
                manager.UpdateAging(item);
            }
            else if (ticket.Contains(name))
            {
                manager.UpdateTicket(item);
            }
            else if (legendary.Contains(name))
            {
                
            }
            else if (conjured.Contains(name))
            {
                
            }
        }
    }
}