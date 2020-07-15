namespace csharpcore
{
    public class ItemsManager
    {
        public void UpdateCommon(Item item)
        {
            item.Quality = item.SellIn > 0 ? modifyQuality(item.Quality, -1) : modifyQuality(item.Quality, -2);

            item.SellIn--;
        }

        public void UpdateAging(Item item)
        {
            item.Quality = modifyQuality(item.Quality, item.SellIn > 0 ? 1 : 2);

            item.SellIn--;
        }

        public void UpdateTicket(Item item)
        {
            if (item.SellIn > 10)
            {
                item.Quality = modifyQuality(item.Quality, 1);
            }
            else if (item.SellIn > 5 && item.SellIn <= 10)
            {
                item.Quality = modifyQuality(item.Quality, 2);
            }
            else if (item.SellIn > 0 && item.SellIn <= 5)
            {
                item.Quality = modifyQuality(item.Quality, 3);
            }
            else
            {
                item.Quality = 0;
            }

            item.SellIn--;
        }

        public void UpdateLegendary(Item item)
        {
            
        }

        public void UpdateConjured(Item item)
        {
            item.Quality = modifyQuality(item.Quality, item.SellIn > 0 ? -2 : -4);

            item.SellIn--;
        }

        private int modifyQuality(int quality, int rate)
        {
            quality += rate;
            if (quality < 0)
            {
                quality = 0;
            }
            else if (quality > 50)
            {
                quality = 50;
            }

            return quality;
        }
    }
}