namespace OSRSBarrowsChestSimulator
{
    public class RewardItem
    {
        public int Id { get; set; }
        public int Amount { get; set; } = 1;
        public string GetRSFormattedAmount()
        {
            return RSItemAmountStringHelper.GetFormattedAmount(Amount);
        }

        public string GetFormattedNumberString()
        {
            return string.Format("{0:#,0}", Amount);
        }
    }
}
