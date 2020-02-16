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

        public IList<RewardItem> SimulateBarrowsRewardChest(List<BarrowsBrother> brothersKilled, int totalLevelOfCryptMonstersKilled, bool completedHardDiary)
        {

            var rewardItems = new List<RewardItem>();
            var potentialBarrowsEquipment = new List<RewardItem>();

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

            }

            var totalRolls = 1 + numBrothersKilled;
            int totalRewardPotential = ChanceHelper.CalculateRewardPotential(totalLevelOfCryptMonstersKilled, brothersKilled);


        //    Console.WriteLine($"Total Rolls = {totalRolls}, Total Level / Potential = {totalLevel}/{totalRewardPotential}, Potential Barrows = {potentialBarrowsEquipment.Count}");

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

                        var min = itemDefinition.RewardPotentialRequirement;
                        var max = itemDefinition.MaxRewardPotentialRequirement;

                        // in order to receive an item, rolled RP should be between the item's minimum unlock requirement and the maximum unlock requirement of the next item in the table
                        if (rolledRewardPotential >= min && rolledRewardPotential <= max)
                        {

                            var minQuantity = Math.Floor(min / itemDefinition.Divisor);
                            var maxQuantity = Math.Floor(Math.Min(max, rolledRewardPotential) /
                                                         itemDefinition.Divisor);

                            
                            if(itemDefinition.Rune && completedHardDiary)
                            {
                                minQuantity = Math.Floor(minQuantity * 1.5);
                                maxQuantity = Math.Floor(maxQuantity * 1.5);
                            }

                            var randomQuantity = RandomHelper.Instance.Next((int)minQuantity, (int)(maxQuantity + 1));


                            var itemToAdd = new RewardItem { Id = itemDefinition.Id, Amount = randomQuantity };

                   //         Console.WriteLine($"Total = {totalRewardPotential}, rolled = {rolledRewardPotential}, minQty = {minQuantity}, maxQty = {maxQuantity}, randomQty = {randomQuantity}, recieved = {itemDefinition.Name}, {itemDefinition.RewardPotentialRequirement}, {itemDefinition.MaxRewardPotentialRequirement}");


                            rewardItems.Add(itemToAdd);
                        }

                    }

                }

            }

            return rewardItems;
        }

    }

}
