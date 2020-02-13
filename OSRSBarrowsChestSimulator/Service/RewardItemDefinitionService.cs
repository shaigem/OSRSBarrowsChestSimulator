using System.Collections.Generic;

namespace OSRSBarrowsChestSimulator
{
    public class RewardItemDefinitionService
    {

        private readonly StoreContext _store;

        public RewardItemDefinitionService(StoreContext store)
        {
            _store = store;
        }



        public RewardItemDefinition FindBarrowsEquipmentDefinition(int id)
        {
            return _store.EquipmentRewardItemDefinitions[id];
        }

        public bool IsBarrowsEquipment(int id)
        {
            return _store.EquipmentRewardItemDefinitions.ContainsKey(id);
        }

        public RewardItemDefinition FindAnyItemDefinitionInStore(int id)
        {
            if (_store.EquipmentRewardItemDefinitions.ContainsKey(id))
            {
                return FindBarrowsEquipmentDefinition(id);
            }
            return FindOtherRewardDefinition(id);
        }


        public RewardItemDefinition FindOtherRewardDefinition(int id)
        {
            return _store.OtherRewardItemDefinitions[id];
        }

        public IDictionary<int, RewardItemDefinition> GetOtherRewardDefinitions()
        {
            return _store.OtherRewardItemDefinitions;
        }




    }
}
