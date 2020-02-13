using System.Collections.Generic;

namespace OSRSBarrowsChestSimulator
{
    public abstract class ItemContainer
    {


        public IDictionary<int, RewardItem> Items { get; } = new Dictionary<int, RewardItem>();


        public void AddItem(RewardItem item)
        {
            RewardItem rewardItemFromChest;

            if (Items.TryGetValue(item.Id, out rewardItemFromChest))
            {

                rewardItemFromChest.Amount += item.Amount;
            }
            else
            {
                Items.Add(item.Id, item);
            }
        }


        public void Clear()
        {
            Items.Clear();
        }
    }
}
