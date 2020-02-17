using System.Collections.Generic;

namespace OSRSBarrowsChestSimulator
{
    public abstract class ItemContainer
    {


        public IDictionary<int, RewardItem> Items { get; } = new Dictionary<int, RewardItem>();


        public void AddItem(RewardItem item)
        {
            var id = item.Id;
            if(Items.ContainsKey(id))
            {
                Items[id].Amount += item.Amount;
                  
            } else {
                Items.Add(id, item);
            }
           
        }


        public void Clear()
        {
            Items.Clear();
        }
    }
}
