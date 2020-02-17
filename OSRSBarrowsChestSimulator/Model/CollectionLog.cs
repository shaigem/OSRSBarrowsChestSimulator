namespace OSRSBarrowsChestSimulator
{
    public class CollectionLog : ItemContainer
    {




        public void Reset()
        {
            foreach(var item in Items.Values)
            {
                item.Amount = 0;
            }
            ChestsOpenedCount = 0;
        }

        public int ChestsOpenedCount { get; set; }


    }
}
