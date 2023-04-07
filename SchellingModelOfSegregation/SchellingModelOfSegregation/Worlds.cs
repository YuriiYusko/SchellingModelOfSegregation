using Spectre.Console;
using static System.Console;

namespace SchellingModelOfSegregation
{
    internal class Worlds
    {
        private Random random = new Random();

        private int height = 0;
        private int width = 0;
        private int emptyPlace = 0;
        private Сitizens[,] world;

        public Worlds(int height, int width, int emptyPlace) 
        {
            this.height = height;
            this.width = width;
            this.emptyPlace = emptyPlace;
            this.world = new Сitizens[height, width];
        }

        public void BildWorlds()
        {
            //Create world
            int chance = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    chance = random.Next(1, 3);
                    world[i, j] = new Сitizens(chance);
                }
            }

            //Create empty place in world
            for (int i = 0; i < emptyPlace;)
            {
                int h, w;
                h = random.Next(0, height);
                w = random.Next(0, width);
                if (world[h,w].color != Color.Black)
                {
                    world[h, w] = new Сitizens();
                    i++;
                }
            }
        }

        public void DrawWorlds()
        {
            var canvas = new Canvas(height, width);

            for (var i = 0; i < canvas.Width; i++)
            {
                for (var j = 0; j < canvas.Height; j++)
                {
                    canvas.SetPixel(i, j, world[i,j].color);
                }
            }
            AnsiConsole.Write(canvas);
            CauntСitizencs();
        }

        private void CauntСitizencs()
        {
            int red = 0;
            int blue = 0;
            int empty = 0;
            
            foreach (Сitizens i in world)
            {
                if (i.color == Color.Red)
                {
                    red++;
                } 
                else if (i.color == Color.Blue)
                {
                    blue++;
                }
                else
                {
                    empty++;
                }
            }
            WriteLine($"Red - {red}");
            WriteLine($"Blue - {blue}");
            WriteLine($"Emppty - {empty}");
        }
    }
}
