namespace csharpcore
{
    public class ItemsManager
    {
        public void UpdateCommon(Item item)
        {
            if (item.SellIn > 0)
            {
                item.Quality = modifyQuality(item.Quality, -1);
            }
            else
            {
                item.Quality = modifyQuality(item.Quality, -2);
            }
            
            item.SellIn--;
        }

        public void UpdateAging(Item item)
        {

            if (item.SellIn > 0)
            {
                item.Quality = modifyQuality(item.Quality, 1);
            }
            else
            {
                item.Quality = modifyQuality(item.Quality, 2);
            }
            
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