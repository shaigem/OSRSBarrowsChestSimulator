using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OSRSBarrowsChestSimulator
{
    public static class RSItemAmountStringHelper
    {

        private const int KModifier = 1000;

        private const int MModifier = 1_000_000;

        private const string Yellow = "#ffff00";

        private const string White = "#fff";

        private const string Green = "#00FF80";


        public static string GetFormattedAmount(int amount)
        {
            if (amount >= 0 && amount < 99_999)
                return amount.ToString();
            else if (amount >= 100_000 && amount < 9_999_999)
                return amount / KModifier + "K";
            else if (amount >= 1_0000_000)
                return amount / MModifier + "M";

            return amount.ToString();
        }


        public static String GetColorForFormattedAmount(int amount)
        {
            if (amount >= 1 && amount < 99_999)
                return Yellow;

            else if (amount >= 100_000 && amount < 9_999_999)
                return White;
            else if (amount >= 1_0000_000)
                return Green;

            return Yellow;
        }



    }
}
