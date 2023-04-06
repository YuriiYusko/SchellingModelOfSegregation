using static System.Console;
using Spectre.Console;

namespace SchellingModelOfSegregation
{
    internal class Worlds
    {
        int height = 0;
        int width = 0;
        Сitizens[,] world;

        public Worlds(int height, int width) 
        {
            this.height = height;
            this.width = width;
            this.world = new Сitizens[height, width];
        }

        public void BildWorlds()
        {
            Random r = new Random();
            int chance = 1;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                   chance = r.Next(1, 3);
                   world[i, j] = new Сitizens(chance);
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
        }

        public void CauntСitizencs()
        {
            int red = 0;
            int blue = 0;
            
            foreach (Сitizens i in world)
            {
                if (i.color == Color.Red)
                {
                    red++;
                } 
                else
                {
                    blue++;
                }
            }
            WriteLine(red);
            WriteLine(blue);
        }
    }
}
