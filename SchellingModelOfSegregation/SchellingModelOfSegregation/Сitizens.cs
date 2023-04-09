using Spectre.Console;
using System.Diagnostics.Contracts;

namespace SchellingModelOfSegregation
{
    internal class Сitizens
    {
        //Variables
        int needNeighbor = 3;
        private static Color happyColor = new Color(0, 175, 0);
        private static Color sadColor = new Color(175, 0, 0);

        //Constructors
        public Сitizens(int coordinat_i, int coordinat_j)
        {
            symbol = "  ";
            this.coordinat_i = coordinat_i;
            this.coordinat_j = coordinat_j;
            humor = happyColor;
        }
        public Сitizens(int coordinat_i, int coordinat_j, int chance)
        {
            symbol = " ";
            switch (chance)
            {
                case 1:
                    this.symbol = "🐶";
                    break;
                case 2:
                    this.symbol = "🐱";
                    break;
            }
            this.coordinat_i = coordinat_i;
            this.coordinat_j = coordinat_j;
            humor = happyColor;
        }

        //Properties
        public Color humor { get; private set; }
        public string symbol { get; private set; }
        public int coordinat_i { get; private set; }
        public int coordinat_j { get; private set; }

        //Methods
        public void checkHappiness(Сitizens[,] world, int height, int width)
        {
            int countNeighbor = 0;

            for (int i = coordinat_i - 1; i <= coordinat_i + 1; ++i)
            {
                for (int j = coordinat_j - 1; j <= coordinat_j + 1; ++j)
                {
                    if (0 <= i && i < height && 0 <= j && j < width && (i != coordinat_i || j != coordinat_j))
                    {
                        if (world[i, j].symbol == symbol) { countNeighbor++; }
                    }
                }
            }

            humor = (countNeighbor >= needNeighbor ? happyColor : sadColor);
        }
    }
}
