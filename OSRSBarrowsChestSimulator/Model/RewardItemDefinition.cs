namespace OSRSBarrowsChestSimulator
{
    public class RewardItemDefinition
    {

        public const string RuneLiteImageUrl = "https://static.runelite.net/cache/item/icon/";
        public const string LocalImageDirectory = "./img/coins/";

        public int Id { get; set; }
        public string Name { get; set; }
        public int RewardPotentialRequirement { get; set; }
        public int MaxRewardPotentialRequirement { get; set; }
        public double Divisor { get; set; }
        public bool Rune { get; set; }

        public string ImageUrl(int amount = 1)
        {


            if (Name.Equals("Coins"))
            {


                if (amount >= 0 && amount < 25)
                {

                 
                    if (amount > 0 && amount <= 5)

                        return LocalImageDirectory + $"coins_{amount}.png";
                    
                    else
                        return LocalImageDirectory + $"coins_5.png";

                }
                else if (amount >= 25 && amount < 100)
                {

                    return LocalImageDirectory + "coins_25.png";

                }
                else if (amount >= 100 && amount < 1000)
                {
                    return LocalImageDirectory + "coins_100.png";
                }
                else if (amount >= 1000 && amount < 10000)
                {
                    return LocalImageDirectory + "coins_1000.png";
                }

            }


            return RuneLiteImageUrl + Id + ".png";

        }




    }
}
