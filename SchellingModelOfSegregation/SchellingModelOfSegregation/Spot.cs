using Spectre.Console;

namespace SchellingModelOfSegregation
{
    abstract class Spot
    {
        protected readonly Color Red = new Color(244, 67, 54);
        protected readonly Color Blue = new Color(3, 169, 244);

        public Spot(int coordinat_i, int coordinat_j, Color color)
        {
            Coordinat_i = coordinat_i;
            Coordinat_j = coordinat_j;
            AgentColor = color;
            Happy = true;
            StringColor = "Error";
            if (color == Color.White)
            {
                StringColor = "White";
            }
            if (color == Red)
            {
                StringColor = "Red";
            }
            if (color == Blue)
            {
                StringColor = "Blue";
            }
        }
        public string StringColor { get; private set; }
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
        public abstract bool CheckHappiness(Spot[,] city, int needNeighbor);
    }
}
