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
        private List<Spot> emptyPlacesList = new();
        private List<Spot> sadAgentList = new();
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
                if (city[i, j].AgentColor != Color.White)
                {
                    city[i, j] = new EmptyPlace(i, j);
                    x++;
                }
            }
            BildEmptyList();
        }
        public void BildSadAgentList()
        {
            sadAgentList.Clear();
            foreach (Spot c in city)
            {
                if (!c.CheckHappiness(city, height, width)) { sadAgentList.Add(c); }
            }
        }
         public void BildEmptyList()
        {
            emptyPlacesList.Clear();
            foreach (Spot c in city)
            {
                if (c.CheckEmpty() == "Empty") { emptyPlacesList.Add(c); }
            }
        }       
        public void DrawCity()
        {
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    city[i, j].DrawInCity();
                }
                AnsiConsole.WriteLine();
            }
            AnsiConsole.WriteLine();
            CauntСitizencs();
        }
        public void Migration()
        {
            if (sadAgentList.Count > 0)
            {
                Spot sadСitizens = sadAgentList[random.Next(sadAgentList.Count)];
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
                                sadAgentList.Add(city[i, j]);
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
                                sadAgentList.Add(city[i, j]);
                            }
                        }
                    }
                }

                sadAgentList.RemoveAll(Spot => Spot.Happy == true);
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
                if (i.AgentColor == red)
                {
                    redCount++;
                }
                else if (i.AgentColor == blue)
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
