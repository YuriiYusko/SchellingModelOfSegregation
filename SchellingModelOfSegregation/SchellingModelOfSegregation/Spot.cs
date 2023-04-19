using Spectre.Console;

namespace SchellingModelOfSegregation
{
    abstract class Spot
    {
        protected readonly Color Blue = new Color(3, 169, 244);     //1
        protected readonly Color Red = new Color(244, 67, 54);      //2
        protected readonly Color Green = new Color(76, 175, 80);    //3
        protected readonly Color Yellow = new Color(255, 235, 59);  //4

        public Spot(int coordinat_i, int coordinat_j, Color color)
        {
            Coordinat_i = coordinat_i;
            Coordinat_j = coordinat_j;
            AgentColor = color;
            Happy = true;
            IntColor = 99;
            if (color == Color.White) // 0
            {
                IntColor = 0;
            }
            if (color == Blue) // 1
            {
                IntColor = 1;
            }
            if (color == Red) // 2
            {
                IntColor = 2;
            }
            if (color == Green) //3
            {
                IntColor = 3;
            }
            if (color == Yellow) //4
            {
                IntColor = 4;
            }
        }

        public int IntColor { get; private set; }
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
        public abstract bool CheckHappiness(Spot[,] city, double needNeighbor);
    }
}
