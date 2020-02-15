using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OSRSBarrowsChestSimulator
{
    public static class SeedBarrowsData
    {

        private const String BarrowsEquipmentFilePath = "data/barrows_equipment.json";
        private const String BarrowsBrothersFilePath = "data/barrows_brother.json";
        private const String BarrowsOtherLootFilePath = "data/other_loot.json";

        public static async Task Initialize(StoreContext store, HttpClient client)

        {
            var equipmentDefs = await client.GetJsonAsync<RewardItemDefinition[]>(BarrowsEquipmentFilePath);
            InitializeBarrowsEquipmentData(store, equipmentDefs);

            var otherLootDefs = await client.GetJsonAsync<RewardItemDefinition[]>(BarrowsOtherLootFilePath);
            InitializeOtherLootData(store, otherLootDefs);

            var combined = equipmentDefs.Concat(otherLootDefs).ToArray();
            InitializeMasterDefinitionList(store, combined);

            var brotherDefs = await client.GetJsonAsync<BarrowsBrother[]>(BarrowsBrothersFilePath);
            InitializeBrothersData(store, brotherDefs);

        }


        private static void InitializeBarrowsEquipmentData(StoreContext store, RewardItemDefinition[] definitions)
        {
            if (definitions != null)
            {
                foreach (var def in definitions)
                {
                    store.EquipmentRewardItemDefinitions.Add(def.Id, def);
                }
            }
        }

        private static void InitializeOtherLootData(StoreContext store, RewardItemDefinition[] definitions)
        {
            if (definitions != null)
            {
                foreach (var def in definitions)
                {
                    store.OtherRewardItemDefinitions.Add(def.Id, def);
                }
            }
        }

        private static void InitializeBrothersData(StoreContext store, BarrowsBrother[] definitions)
        {
            if (definitions != null)
            {
                foreach (var def in definitions)
                {
                    store.BarrowsBrothers.Add(def);
                }
            }
        }

        private static void InitializeMasterDefinitionList(StoreContext store, RewardItemDefinition[] definitions)
        {
            if (definitions != null)
            {
                foreach (var def in definitions)
                {
                    store.AllRewardItemDefinitions.Add(def);
                }
            }
                }

            
        
    }
}
