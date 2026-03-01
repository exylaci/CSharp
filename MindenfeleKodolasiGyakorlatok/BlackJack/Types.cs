namespace BlackJack
{
    public class Types
    {
        public readonly static string[] Colors = { "Kör", "Treff", "Pick", "Káró" };
        public readonly static string[] Figures = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Bubi", "Dáma", "Király", "Ász" };

        public static int GetValue(string figure)
        {
            switch (figure)
            {
                case "2": return 2;
                case "3": return 3;
                case "4": return 4;
                case "5": return 5;
                case "6": return 6;
                case "7": return 7;
                case "8": return 8;
                case "9": return 9;
                case "10": return 10;
                case "Bubi": return 10;
                case "Dáma": return 10;
                case "Király": return 10;
                case "Ász": return 11;
                default: return 0;
            }
        }
    }
}
