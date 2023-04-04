using Spectre.Console;
using System;
using static System.Console;

namespace SchellingModelOfSegregation
{
    internal class Worlds
    {
        int[,] world = new int[20, 20];

        public void BildWorlds()
        {
            int x = 0;  
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    world[i, j] = x;
                    x++;
                }
            }
        }

        public void DrawWorlds()
        {
            var grid = new Grid();

            for (int i = 0; i < 20; i++) grid.AddColumn();

            Text[] worldRow = new Text[20]; 
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    worldRow[j] = new Text(world[i,j].ToString());
                }
                grid.AddRow(worldRow);
            }

            AnsiConsole.Write(grid);


            //for (int i = 0; i < 20; i++)
            //{
            //    for (int j = 0; j < 20; j++)
            //    {
            //        Write(world[i,j]);
            //    }
            //    WriteLine("");
            //}
        }
    }
}
