using Spectre.Console;

namespace SchellingModelOfSegregation
{
    internal class Сitizens
    {
        //Variables
        private readonly int needNeighbor = 0;
        private readonly static Color happyColor = new(0, 175, 0);
        private readonly static Color sadColor = new(175, 0, 0);

        //Constructors
        public Сitizens(int coordinat_i, int coordinat_j)
        {
            Symbol = "  ";
            Coordinat_i = coordinat_i;
            Coordinat_j = coordinat_j;
            Humor = happyColor;
        }
        public Сitizens(int coordinat_i, int coordinat_j, int chance, int neighbor)
        {
            Symbol = " ";
            switch (chance)
            {
                case 1:
                    this.Symbol = "🐶";
                    break;
                case 2:
                    this.Symbol = "🐱";
                    break;
            }
            Coordinat_i = coordinat_i;
            Coordinat_j = coordinat_j;
            needNeighbor = neighbor;
            Humor = happyColor;
        }

        //Properties
        public Color Humor { get; private set; }
        public string Symbol { get; private set; }
        public int Coordinat_i { get; private set; }
        public int Coordinat_j { get; private set; }

        //Methods

        public void DrawInCity()
        {
            Console.SetCursorPosition(Coordinat_j + Coordinat_j, Coordinat_i);
            AnsiConsole.Write(new Text(Symbol, new Style(Color.White, Humor)));
        }
        public string CheckHappiness(Сitizens[,] city, int height, int width)
        {
            if (Symbol != "  ")
            {
                int countNeighbor = 0;
                for (int i = Coordinat_i - 1; i <= Coordinat_i + 1; ++i)
                {
                    for (int j = Coordinat_j - 1; j <= Coordinat_j + 1; ++j)
                    {
                        if (0 <= i && i < height && 0 <= j && j < width && (i != Coordinat_i || j != Coordinat_j))
                        {
                            if (city[i, j].Symbol == Symbol) { countNeighbor++; }
                        }
                    }
                }
                Humor = (countNeighbor >= needNeighbor ? happyColor : sadColor);
            }
            DrawInCity();
            return Humor == sadColor ? "Sad" : "Happi";
        }
        public string CheckEmpty()
        {
            DrawInCity();
            return Symbol == "  " ? "Empty" : "NotEmpty";
        }
        public void Move(int coordinat_i, int coordinat_j)
        {
            this.Coordinat_i = coordinat_i;
            this.Coordinat_j = coordinat_j;
            DrawInCity() ;
        }
    }
}
