namespace OSRSBarrowsChestSimulator
{
    public class BarrowsBrother
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public int[] Rewards { get; set; }


        public sealed class BarrowsBrotherName
        {

            private BarrowsBrotherName(string value) { Value = value; }

            public string Value { get; set; }

            public static BarrowsBrotherName AhrimTheBlighted { get { return new BarrowsBrotherName("Ahrim the Blighted"); } }
            public static BarrowsBrotherName DharokTheWretched { get { return new BarrowsBrotherName("Dharok the Wretched"); } }
            public static BarrowsBrotherName GuthanTheInfested { get { return new BarrowsBrotherName("Guthan the Infested"); } }
            public static BarrowsBrotherName VeracTheDefiled { get { return new BarrowsBrotherName("Verac the Defiled"); } }
            public static BarrowsBrotherName ToragTheCorrupted { get { return new BarrowsBrotherName("Torag the Corrupted"); } }
            public static BarrowsBrotherName KarilTheTainted { get { return new BarrowsBrotherName("Karil the Tainted"); } }

        }

    }

}
