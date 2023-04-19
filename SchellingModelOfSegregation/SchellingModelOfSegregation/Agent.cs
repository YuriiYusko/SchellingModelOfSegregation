using Spectre.Console;

namespace SchellingModelOfSegregation
{
    class Agent : Spot
    {
        public Agent(int coordinat_i, int coordinat_j, Color color) : base(coordinat_i, coordinat_j, color) { }

        public override bool CheckHappiness(Spot[,] city, double percentSameNeighbors)
        {
            double countSameNeighbor = 0;
            double countOthersNeighbor = 0;
            for (int i = Coordinat_i - 1; i <= Coordinat_i + 1; ++i)
            {
                for (int j = Coordinat_j - 1; j <= Coordinat_j + 1; ++j)
                {
                    if (0 <= i && i < city.GetLength(0) && 0 <= j && j < city.GetLength(1) && (i != Coordinat_i || j != Coordinat_j))
                    {
                        if (city[i, j].IntColor == this.IntColor) { countSameNeighbor++; }
                        else if (city[i, j].IntColor != 0) { countOthersNeighbor++; }
                    }
                }
            }
            //double resolt = countSameNeighbor / (countSameNeighbor + countOthersNeighbor) * 100;
            Happy = percentSameNeighbors <= (countSameNeighbor / (countSameNeighbor + countOthersNeighbor) * 100);
            DrawInCity();
            return Happy;
        }
    }
}
