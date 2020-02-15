using System.Collections.Generic;

namespace OSRSBarrowsChestSimulator
{
    public class StoreContext
    {

        public StoreContext()
        {
        }

        public IDictionary<int, RewardItemDefinition> EquipmentRewardItemDefinitions { get; } = new Dictionary<int, RewardItemDefinition>();
        public IDictionary<int, RewardItemDefinition> OtherRewardItemDefinitions { get; } = new Dictionary<int, RewardItemDefinition>();
        public HashSet<RewardItemDefinition> AllRewardItemDefinitions { get; } = new HashSet<RewardItemDefinition>();


        public List<BarrowsBrother> BarrowsBrothers { get; } = new List<BarrowsBrother>();

    }
}
