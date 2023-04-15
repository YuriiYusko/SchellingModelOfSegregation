using Spectre.Console;

namespace SchellingModelOfSegregation
{
    class Agent : Spot
    {
        public Agent(int coordinat_i, int coordinat_j, Color color, int neighbor) : base(coordinat_i, coordinat_j, color, neighbor) { }

        public override bool CheckHappiness(Spot[,] city, int height, int width)
        {
            int countNeighbor = 0;
            for (int i = Coordinat_i - 1; i <= Coordinat_i + 1; ++i)
            {
                for (int j = Coordinat_j - 1; j <= Coordinat_j + 1; ++j)
                {
                    if (0 <= i && i < height && 0 <= j && j < width && (i != Coordinat_i || j != Coordinat_j))
                    {
                        if (city[i, j].AgentColor == AgentColor) { countNeighbor++; }
                    }
                }
            }
            Happy = (countNeighbor >= needNeighbor ? true : false);
            DrawInCity();
            return Happy;
        }
    }
}
