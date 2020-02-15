using System;
using System.Collections.Generic;

namespace OSRSBarrowsChestSimulator
{

    public static class ChanceHelper
    {

        private const int MaximumCryptMonstersCombatLevel = 1000;

        public static int CalculateBarrowsItemChance(int numberOfBrothersKilled)
        {
            return 450 - 58 * numberOfBrothersKilled;
        }

        public static int CalculateRewardPotential(int sumOfCryptMonstersCombatLevels, List<BarrowsBrother> brothersKilled)
        {

            var level = sumOfCryptMonstersCombatLevels;

            foreach (var barrowsBrother in brothersKilled)
            {
                level += barrowsBrother.Level;
            }

            return Math.Min(level, MaximumCryptMonstersCombatLevel) + 2 * brothersKilled.Count;
        }

        public static bool RollAgainstBarrowsItem(int numberOfBrothersKilled)
        {
            int chance = CalculateBarrowsItemChance(numberOfBrothersKilled);
            int roll = RandomHelper.Instance.Next(chance);
            return roll == 0;
        }

    }
}
