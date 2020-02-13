using System;
using System.Collections.Generic;

namespace OSRSBarrowsChestSimulator
{
    public class RewardChestService
    {

        private readonly RewardItemDefinitionService _rewardItemDefinitionService;
        public RewardChestService(RewardItemDefinitionService rewardItemDefinitionService)
        {
            _rewardItemDefinitionService = rewardItemDefinitionService;
        }

        public IList<RewardItem> SimulateBarrowsRewardChest(List<BarrowsBrother> brothersKilled, int totalLevelOfCryptMonstersKilled)
        {

            var rewardItems = new List<RewardItem>();
            var potentialBarrowsEquipment = new List<RewardItem>();

            var totalLevel = totalLevelOfCryptMonstersKilled;

            var numBrothersKilled = brothersKilled.Count;

            if (numBrothersKilled > 0)
            {

                foreach (var barrowsBrother in brothersKilled)
                {
                    foreach (var rewardItemId in barrowsBrother.Rewards)
                    {
                        var rewardItem = new RewardItem { Id = rewardItemId };
                        potentialBarrowsEquipment.Add(rewardItem);
                    }
                }


                foreach (var barrowsBrother in brothersKilled)
                {
                    totalLevel += barrowsBrother.Level;
                }
            }

            var totalRolls = 1 + numBrothersKilled;
            int totalRewardPotential = ChanceHelper.CalculateRewardPotential(totalLevel, numBrothersKilled);


            Console.WriteLine($"Total Rolls = {totalRolls}, Total Level / Potential = {totalLevel}/{totalRewardPotential}, Potential Barrows = {potentialBarrowsEquipment.Count}");

            for (var roll = 1; roll <= totalRolls; roll++)
            {

                bool wonBarrowsItem = numBrothersKilled == 0 ? false : ChanceHelper.RollAgainstBarrowsItem(numBrothersKilled);

                if (wonBarrowsItem)
                {
                    var randomIndex = RandomHelper.Instance.Next(potentialBarrowsEquipment.Count);
                    var chosenItem = potentialBarrowsEquipment[randomIndex];
                    // remove the item from the potential list so we don't roll for it again
                    potentialBarrowsEquipment.RemoveAt(randomIndex);
                    rewardItems.Add(chosenItem);
                }
                else
                {

                    var rolledRewardPotential = RandomHelper.Instance.Next(0, totalRewardPotential + 1);

                    foreach (var itemDefinition in _rewardItemDefinitionService.GetOtherRewardDefinitions().Values)
                    {
                        if (rolledRewardPotential < itemDefinition.RewardPotentialRequirement) continue;


                        var minQuantity = Math.Floor(itemDefinition.RewardPotentialRequirement / itemDefinition.Divisor);
                        var maxQuantity = Math.Floor(Math.Min(itemDefinition.MaxRewardPotentialRequirement, rolledRewardPotential) /
                                                     itemDefinition.Divisor);


                        var randomQuantity = RandomHelper.Instance.Next((int)minQuantity, (int)(maxQuantity + 1));


                        var itemToAdd = new RewardItem { Id = itemDefinition.Id, Amount = randomQuantity };

                        Console.WriteLine($"Total = {totalRewardPotential}, rolled = {rolledRewardPotential}, minQty = {minQuantity}, maxQty = {maxQuantity}, randomQty = {randomQuantity}, recieved = {itemToAdd}");

                        rewardItems.Add(itemToAdd);

                    }

                }

            }

            // shuffle the items in the list so it mimics how it is in OSRS
            int count = rewardItems.Count;
            while (count > 1)
            {
                count--;
                int k = RandomHelper.Instance.Next(count + 1);
                RewardItem value = rewardItems[k];
                rewardItems[k] = rewardItems[count];
                rewardItems[count] = value;
            }

            return rewardItems;
        }

    }

}
