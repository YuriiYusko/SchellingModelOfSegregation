using Spectre.Console;

namespace SchellingModelOfSegregation
{
    internal class City
    {
        //Variables
        private readonly Random random = new Random();
        private readonly int emptyPlaceCount = 0;
        private List<Spot> emptyPlacesList = new();
        private List<Spot> sadAgentList = new();
        private Spot[,] city;

        private double _redNeighbors;
        private double _blueNeighbors;
        private double _greenNeighbors;
        private double _yellowNeighbors;

        //Constructors
        public City(int height, int width, int emptyPlace)
        {
            Height = height;
            Width = width;
            city = new Spot[height, width];
            emptyPlaceCount = emptyPlace;
            RedPercentSameNeighbors = 0;
            BluePercentSameNeighbors = 0;
            GreenPercentSameNeighbors = 0;
            YellowPercentSameNeighbors = 0;
        }

        public int Height { get; private set; }
        public int Width { get; private set; }
        public double RedPercentSameNeighbors
        {
            get { return _redNeighbors; }
            set { if ((value >= 0) && (value <= 100)) { _redNeighbors = value; } }
        }
        public double GreenPercentSameNeighbors
        {
            get { return _greenNeighbors; }
            set { if ((value >= 0) && (value <= 100)) { _greenNeighbors = value; } }
        }
        public double YellowPercentSameNeighbors
        {
            get { return _yellowNeighbors; }
            set { if ((value >= 0) && (value <= 100)) { _yellowNeighbors = value; } }
        }
        public double BluePercentSameNeighbors
        {
            get { return _blueNeighbors; }
            set { if ((value >= 0) && (value <= 100)) { _blueNeighbors = value; } }
        }

        //Methods
        public void BildCity(int numberTypesAgents)
        {
            //Agents
            for (int i = 0; i < city.GetLength(0); i++)
            {
                for (int j = 0; j < city.GetLength(1); j++)
                {
                    var chance = random.Next(numberTypesAgents);
                    switch (chance)
                    {
                        case 0:
                            //Blue - 1
                            city[i, j] = new Agent(i, j, new Color(3, 169, 244));
                            break;
                        case 1:
                            //Red - 2
                            city[i, j] = new Agent(i, j, new Color(244, 67, 54));
                            break;
                        case 2:
                            //Green - 3
                            city[i, j] = new Agent(i, j, new Color(76, 175, 80));
                            break;
                        case 3:
                            //Yellow - 4
                            city[i, j] = new Agent(i, j, new Color(255, 235, 59));
                            break;
                    }
                }
            }
            //Empty places
            for (int x = 0; x < emptyPlaceCount;)
            {
                int i = random.Next(city.GetLength(0));
                int j = random.Next(city.GetLength(1));
                if (city[i, j].IntColor != 0)
                {
                    city[i, j] = new EmptyPlace(i, j);
                    x++;
                }
            }
        }

        public void BildSadAgentList()
        {
            sadAgentList.Clear();
            foreach (Spot c in city)
            {
                if (c.IntColor == 1 ) //Blue
                {
                    if (!c.CheckHappiness(city, BluePercentSameNeighbors)) { sadAgentList.Add(c); }
                }
                if (c.IntColor == 2) //Red
                {
                    if (!c.CheckHappiness(city, RedPercentSameNeighbors)) { sadAgentList.Add(c); }
                }
                if (c.IntColor == 3) //Green 
                {
                    if (!c.CheckHappiness(city, GreenPercentSameNeighbors)) { sadAgentList.Add(c); }
                }
                if (c.IntColor == 4) // Yellow
                {
                    if (!c.CheckHappiness(city, YellowPercentSameNeighbors)) { sadAgentList.Add(c); }
                }
            }
        }

        public void BildEmptyList()
        {
            emptyPlacesList.Clear();
            foreach (Spot c in city)
            {
                if (c.IntColor == 0)
                {
                    emptyPlacesList.Add(c);
                    c.DrawInCity();
                }

            }
        }

        public void DrawCity()
        {
            for (var i = 0; i < city.GetLength(0); i++)
            {
                for (var j = 0; j < city.GetLength(1); j++)
                {
                    city[i, j].DrawInCity();
                }
                AnsiConsole.WriteLine();
            }
            AnsiConsole.WriteLine();
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

                CheckHappiness(sadСitizens.Coordinat_i, sadСitizens.Coordinat_j);

                for (int i = sadСitizens.Coordinat_i - 1; i <= sadСitizens.Coordinat_i + 1; ++i)
                {
                    for (int j = sadСitizens.Coordinat_j - 1; j <= sadСitizens.Coordinat_j + 1; ++j)
                    {
                        if (0 <= i && i < city.GetLength(0) && 0 <= j && j < city.GetLength(1) && (i != sadСitizens.Coordinat_i || j != sadСitizens.Coordinat_j))
                        {
                            CheckHappiness(i, j);
                        }
                    }
                }

                for (int i = emptyPlaces.Coordinat_i - 1; i <= emptyPlaces.Coordinat_i + 1; ++i)
                {
                    for (int j = emptyPlaces.Coordinat_j - 1; j <= emptyPlaces.Coordinat_j + 1; ++j)
                    {
                        if (0 <= i && i < city.GetLength(0) && 0 <= j && j < city.GetLength(1) && (i != emptyPlaces.Coordinat_i || j != emptyPlaces.Coordinat_j))
                        {
                            CheckHappiness(i, j);
                        }
                    }
                }
                sadAgentList.RemoveAll(Spot => Spot.Happy == true);
            }
        }

        private void CheckHappiness(int i, int j)
        {
            switch (city[i, j].IntColor)
            {
                case 1:
                    if (!city[i, j].CheckHappiness(city, BluePercentSameNeighbors))
                    {
                        sadAgentList.Add(city[i, j]);
                    }
                    break;
                case 2:
                    if (!city[i, j].CheckHappiness(city, RedPercentSameNeighbors))
                    {
                        sadAgentList.Add(city[i, j]);
                    }
                    break;
                case 3:
                    if (!city[i, j].CheckHappiness(city, GreenPercentSameNeighbors))
                    {
                        sadAgentList.Add(city[i, j]);
                    }
                    break;
                case 4:
                    if (!city[i, j].CheckHappiness(city, YellowPercentSameNeighbors))
                    {
                        sadAgentList.Add(city[i, j]);
                    }
                    break;
            }
        }
    }
}
