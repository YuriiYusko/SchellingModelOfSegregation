using Spectre.Console;

namespace SchellingModelOfSegregation
{
    internal class City
    {
        //Variables
        private readonly Random random = new Random();
        private readonly int height = 0;
        private readonly int width = 0;
        private int iteracija = 0;
        private readonly int emptyPlaceCount = 0;
        private readonly Color happyColor = new(0, 175, 0);
        private List<Spot> emptyPlacesList = new();
        private List<Spot> sadСitizensList = new();
        private Spot[,] city;

        //Constructors
        public City(int height, int width, int emptyPlace)
        {
            this.height = height;
            this.width = width;
            emptyPlaceCount = emptyPlace;
            city = new Spot[height, width];
        }

        //Methods
        public void BildCity(int neighbor)
        {
            //Create City
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var chance = random.Next(2);
                    switch (chance)
                    {
                        case 0:
                            city[i, j] = new Agent(i, j, new Color(3, 169, 244), neighbor);
                            break;
                        case 1:
                            city[i, j] = new Agent(i, j, new Color(244, 67, 54), neighbor);
                            break;
                    }
                }
            }
            //Create empty place in city
            emptyPlacesList.Clear();
            for (int x = 0; x < emptyPlaceCount;)
            {
                int i = random.Next(height);
                int j = random.Next(width);
                if (city[i, j].agentColor != Color.White)
                {
                    city[i, j] = new EmptyPlace(i, j);
                    x++;
                }
            }
            CheckEmpty();
        }
        public void DrawCity()
        {
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    city[i, j].DrawInCity();
                    //AnsiConsole.Write(new Text(city[i, j].Symbol, new Style(Color.White, city[i, j].Humor)));
                }
                AnsiConsole.WriteLine();
            }
            AnsiConsole.WriteLine();
            CauntСitizencs();
        }
        public void CheckHappiness()
        {
            sadСitizensList.Clear();
            foreach (Spot c in city)
            {
                if (!c.CheckHappiness(city, height, width)) { sadСitizensList.Add(c); }
            }
        }
        public void CheckEmpty()
        {
            emptyPlacesList.Clear();
            foreach (Spot c in city)
            {
                if (c.CheckEmpty() == "Empty") { emptyPlacesList.Add(c); }
            }
        }
        public void Migration()
        {
            if (sadСitizensList.Count > 0)
            {
                Spot sadСitizens = sadСitizensList[random.Next(sadСitizensList.Count)];
                Spot emptyPlaces = emptyPlacesList[random.Next(emptyPlacesList.Count)];

                city[emptyPlaces.Coordinat_i, emptyPlaces.Coordinat_j] = sadСitizens;
                city[sadСitizens.Coordinat_i, sadСitizens.Coordinat_j] = emptyPlaces;

                var iForEmpty = sadСitizens.Coordinat_i;
                var jForEmpty = sadСitizens.Coordinat_j;
                sadСitizens.Move(emptyPlaces.Coordinat_i, emptyPlaces.Coordinat_j);
                emptyPlaces.Move(iForEmpty, jForEmpty);

                sadСitizens.CheckHappiness(city, height, width);

                for (int i = sadСitizens.Coordinat_i - 1; i <= sadСitizens.Coordinat_i + 1; ++i)
                {
                    for (int j = sadСitizens.Coordinat_j - 1; j <= sadСitizens.Coordinat_j + 1; ++j)
                    {
                        if (0 <= i && i < height && 0 <= j && j < width && (i != sadСitizens.Coordinat_i || j != sadСitizens.Coordinat_j))
                        {
                            if (!city[i, j].CheckHappiness(city, height, width))
                            {
                                sadСitizensList.Add(city[i, j]);
                            }
                        }
                    }
                }

                for (int i = emptyPlaces.Coordinat_i - 1; i <= emptyPlaces.Coordinat_i + 1; ++i)
                {
                    for (int j = emptyPlaces.Coordinat_j - 1; j <= emptyPlaces.Coordinat_j + 1; ++j)
                    {
                        if (0 <= i && i < height && 0 <= j && j < width && (i != emptyPlaces.Coordinat_i || j != emptyPlaces.Coordinat_j))
                        {
                            if (!city[i, j].CheckHappiness(city, height, width))
                            {
                                sadСitizensList.Add(city[i, j]);
                            }
                        }
                    }
                }

                sadСitizensList.RemoveAll(citizen => citizen.happy == true);
                iteracija++;
            }
        }
        private void CauntСitizencs()
        {
            int redCount = 0;
            int blueCount = 0;
            int emptyCount = 0;

            Color red = new Color(244, 67, 54);
            Color blue = new Color(3, 169, 244);

            foreach (Agent i in city)
            {
                if (i.agentColor == red)
                {
                    redCount++;
                }
                else if (i.agentColor == blue)
                {
                    blueCount++;
                }
                else
                {
                    emptyCount++;
                }
            }
            Console.WriteLine($"Red - {redCount}");
            Console.WriteLine($"Blue - {blueCount}");
            Console.WriteLine($"Emppty - {emptyCount} ");
            Console.WriteLine($"Iteracija - {iteracija}");
            Console.WriteLine("");
        }
    }
}
