using System;

namespace OSRSBarrowsChestSimulator
{

    public static class ChanceHelper
    {

        private const int MaximumCryptMonstersCombatLevel = 1000;

        public static int CalculateBarrowsItemChance(int numberOfBrothersKilled)
        {
            return 450 - 58 * numberOfBrothersKilled;
        }

        public static int CalculateRewardPotential(int sumOfCombatLevels, int numberOfBrothersKilled)
        {
            return Math.Min(sumOfCombatLevels, MaximumCryptMonstersCombatLevel) + 2 * numberOfBrothersKilled;
        }

        public static bool RollAgainstBarrowsItem(int numberOfBrothersKilled)
        {
            int chance = CalculateBarrowsItemChance(numberOfBrothersKilled);
            int roll = RandomHelper.Instance.Next(chance);
            return roll == 0;
        }

    }
}
