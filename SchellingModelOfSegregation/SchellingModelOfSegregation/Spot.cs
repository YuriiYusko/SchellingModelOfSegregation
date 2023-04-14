using Spectre.Console;

namespace SchellingModelOfSegregation
{
    abstract class Spot
    {
        protected int needNeighbor = 0;
        protected bool happu = true;

        public Spot(int coordinat_i, int coordinat_j, Color color, int neighbor)
        {
            Coordinat_i = coordinat_i;
            Coordinat_j = coordinat_j;
            needNeighbor = neighbor;
            agentColor = color;
        }

        public int Coordinat_i { get; private set; }
        public int Coordinat_j { get; private set; }
        public Color agentColor { get; private set; }
        public bool happy { get; private set; }

        public void Move(int coordinat_i, int coordinat_j)
        {
            this.Coordinat_i = coordinat_i;
            this.Coordinat_j = coordinat_j;
            DrawInCity();
        }
        public void DrawInCity()
        {
            if (happu)
            {
                Console.SetCursorPosition(Coordinat_j + Coordinat_j, Coordinat_i);
                AnsiConsole.Write(new Text("  ", new Style(Color.White, agentColor)));
            }
            else
            {
                Console.SetCursorPosition(Coordinat_j + Coordinat_j, Coordinat_i);
                AnsiConsole.Write(new Text("><", new Style(Color.White, agentColor)));
            }
        }
        public string CheckEmpty()
        {
            DrawInCity();
            return agentColor == Color.White ? "Empty" : "NotEmpty";
        }

        public abstract bool CheckHappiness(Spot[,] city, int height, int width);
    }
}
