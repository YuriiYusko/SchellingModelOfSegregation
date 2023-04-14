using Spectre.Console;

namespace SchellingModelOfSegregation
{
    class EmptyPlace : Spot
    {
        public EmptyPlace(int coordinat_i, int coordinat_j) : base(coordinat_i, coordinat_j, Color.White, 0) { }

        public override bool CheckHappiness(Spot[,] city, int height, int width)
        {
            DrawInCity();
            return true;
        }
    }
}
