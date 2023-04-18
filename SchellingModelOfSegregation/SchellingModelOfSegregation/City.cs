﻿using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        private int _redTolerance;
        private int _blueTolerance;
        private int _greenTolerance;
        private int _yellowTolerance;

        //Constructors
        public City(int height, int width, int emptyPlace)
        {
            Height = height;
            Width = width;
            city = new Spot[height, width];
            emptyPlaceCount = emptyPlace;
            RedTolerance = 0;
            BlueTolerance = 0;
            GreenTolerance = 0;
            YellowTolerance = 0;
        }

        public int Height { get; private set; }
        public int Width { get; private set; }
        public int RedTolerance
        {
            get { return _redTolerance; }
            set { if ((value >= 0) && (value <= 8)) { _redTolerance = value; } }
        }
        public int GreenTolerance
        {
            get { return _greenTolerance; }
            set { if ((value >= 0) && (value <= 8)) { _greenTolerance = value; } }
        }
        public int YellowTolerance
        {
            get { return _yellowTolerance; }
            set { if ((value >= 0) && (value <= 8)) { _yellowTolerance = value; } }
        }
        public int BlueTolerance
        {
            get { return _blueTolerance; }
            set { if ((value >= 0) && (value <= 8)) { _blueTolerance = value; } }
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
                            //Blue
                            city[i, j] = new Agent(i, j, new Color(3, 169, 244));
                            break;
                        case 1:
                            //Red
                            city[i, j] = new Agent(i, j, new Color(244, 67, 54));
                            break;
                        case 2:
                            //Green
                            city[i, j] = new Agent(i, j, new Color(76, 175, 80));
                            break;
                        case 3:
                            //Yellow
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
                if (city[i, j].AgentColor != Color.White)
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
                if (c.StringColor == "Red")
                {
                    if (!c.CheckHappiness(city, RedTolerance)) { sadAgentList.Add(c); }
                }
                if (c.StringColor == "Blue")
                {
                    if (!c.CheckHappiness(city, BlueTolerance)) { sadAgentList.Add(c); }
                }
                if (c.StringColor == "Green")
                {
                    if (!c.CheckHappiness(city, GreenTolerance)) { sadAgentList.Add(c); }
                }
                if (c.StringColor == "Yellow")
                {
                    if (!c.CheckHappiness(city, YellowTolerance)) { sadAgentList.Add(c); }
                }
            }
        }
        public void BildEmptyList()
        {
            emptyPlacesList.Clear();
            foreach (Spot c in city)
            {
                if (c.StringColor == "White")
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
            switch (city[i, j].StringColor)
            {
                case "Red":
                    if (!city[i, j].CheckHappiness(city, RedTolerance))
                    {
                        sadAgentList.Add(city[i, j]);
                    }
                    break;
                case "Blue":
                    if (!city[i, j].CheckHappiness(city, BlueTolerance))
                    {
                        sadAgentList.Add(city[i, j]);
                    }
                    break;
                case "Green":
                    if (!city[i, j].CheckHappiness(city, GreenTolerance))
                    {
                        sadAgentList.Add(city[i, j]);
                    }
                    break;
                case "Yellow":
                    if (!city[i, j].CheckHappiness(city, YellowTolerance))
                    {
                        sadAgentList.Add(city[i, j]);
                    }
                    break;
            }
        }
    }
}
