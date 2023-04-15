using Spectre.Console;

namespace SchellingModelOfSegregation
{
    abstract class Spot
    {
        protected int needNeighbor = 0;

        public Spot(int coordinat_i, int coordinat_j, Color color, int neighbor)
        {
            Coordinat_i = coordinat_i;
            Coordinat_j = coordinat_j;
            needNeighbor = neighbor;
            AgentColor = color;
            Happy = true;
        }

        public int Coordinat_i { get; private set; }
        public int Coordinat_j { get; private set; }
        public Color AgentColor { get; private set; }
        public bool Happy { get; set; }

        public void Move(int coordinat_i, int coordinat_j)
        {
            this.Coordinat_i = coordinat_i;
            this.Coordinat_j = coordinat_j;
            DrawInCity();
        }
        public void DrawInCity()
        {
            if (Happy)
            {
                Console.SetCursorPosition(Coordinat_j + Coordinat_j, Coordinat_i);
                AnsiConsole.Write(new Text("  ", new Style(Color.Black, AgentColor)));
            }
            else
            {
                Console.SetCursorPosition(Coordinat_j + Coordinat_j, Coordinat_i);
                AnsiConsole.Write(new Text("}{", new Style(Color.Black, AgentColor)));
            }
        }
        public string CheckEmpty()
        {
            DrawInCity();
            return AgentColor == Color.White ? "Empty" : "NotEmpty";
        }
        public abstract bool CheckHappiness(Spot[,] city, int height, int width);
    }
}
