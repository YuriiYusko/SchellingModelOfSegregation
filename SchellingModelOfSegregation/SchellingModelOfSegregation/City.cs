using Spectre.Console;
using System;

namespace SchellingModelOfSegregation
{
    internal class City
    {
        //Variables
        private Random random = new Random();
        private int height = 0;
        private int width = 0;
        private int emptyPlace = 0;
        private Сitizens[,] city;

        //Constructors
        public City(int height, int width, int emptyPlace) 
        {
            this.height = height;
            this.width = width;
            this.emptyPlace = emptyPlace;
            this.city = new Сitizens[height, width];
        }

        //Methods
        public void BildCity()
        {
            //Create City
            int chance = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    chance = random.Next(1, 3);
                    city[i, j] = new Сitizens(i, j ,chance);
                }
            }

            //Create empty place in city
            for (int x = 0; x < emptyPlace;)
            {
                int i, j;
                i = random.Next(0, height);
                j = random.Next(0, width);
                if (city[i,j].symbol != " ")
                {
                    city[i, j] = new Сitizens(i,j);
                    x++;
                }
            }
        }
        public void DrawCity()
        {
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    AnsiConsole.Write(new Text(city[i, j].symbol, new Style(Color.White, city[i, j].humor)));
                }
                AnsiConsole.WriteLine();
            }
            AnsiConsole.WriteLine();
            CauntСitizencs();
        }
        public void checkHappiness()
        {
            foreach (Сitizens c in city)
            {
                if (c.symbol != "  ")
                {
                    c.checkHappiness(city, height, width);
                }
            }
        }
        private void CauntСitizencs()
        {
            int dog = 0;
            int cat = 0;
            int empty = 0;
            
            foreach (Сitizens i in city)
            {
                if (i.symbol == "🐶")
                {
                    dog++;
                } 
                else if (i.symbol == "🐱")
                {
                    cat++;
                }
                else
                {
                    empty++;
                }
            }
            Console.WriteLine($"🐶 - {dog}");
            Console.WriteLine($"🐱 - {cat}");
            Console.WriteLine($"Emppty - {empty}");
        }
    }
}
