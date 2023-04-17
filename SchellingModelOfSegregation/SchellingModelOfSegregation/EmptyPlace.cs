using Spectre.Console;

namespace SchellingModelOfSegregation
{
    class EmptyPlace : Spot
    {
        public EmptyPlace(int coordinat_i, int coordinat_j) : base(coordinat_i, coordinat_j, Color.White) { }

        public override bool CheckHappiness(Spot[,] city, int needNeighbor)
        {
            DrawInCity();
            return true;
        }
    }
}
