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
        private List<Сitizens> emptyPlacesList = new();
        private List<Сitizens> sadСitizensList = new();
        private Сitizens[,] city;

        //Constructors
        public City(int height, int width, int emptyPlace)
        {
            this.height = height;
            this.width = width;
            emptyPlaceCount = emptyPlace;
            city = new Сitizens[height, width];
        }

        //Methods
        public void BildCity(int neighbor)
        {
            //Create City
            int chance = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    chance = random.Next(1, 3);
                    city[i, j] = new Сitizens(i, j, chance, neighbor);
                }
            }
            //Create empty place in city
            emptyPlacesList.Clear();
            for (int x = 0; x < emptyPlaceCount;)
            {
                int i = random.Next(height);
                int j = random.Next(width);
                if (city[i, j].Symbol != "  ")
                {
                    city[i, j] = new Сitizens(i, j);
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
                    AnsiConsole.Write(new Text(city[i, j].Symbol, new Style(Color.White, city[i, j].Humor)));
                }
                AnsiConsole.WriteLine();
            }
            AnsiConsole.WriteLine();
            CauntСitizencs();
        }
        public void CheckHappiness()
        {
            sadСitizensList.Clear();
            foreach (Сitizens c in city)
            {
                if (c.Symbol != "  ")
                {
                    if (c.CheckHappiness(city, height, width) == "Sad") { sadСitizensList.Add(c); }
                }
            }
        }
        public void CheckEmpty()
        {
            emptyPlacesList.Clear();
            foreach (Сitizens c in city)
            {
                if (c.CheckEmpty() == "Empty") { emptyPlacesList.Add(c); }
            }
        }
        public void Migration()
        {
            Color color = new Color(0, 175, 0);
            if (sadСitizensList.Count > 0)
            {
                Сitizens sadСitizens = sadСitizensList[random.Next(sadСitizensList.Count)];
                Сitizens emptyPlaces = emptyPlacesList[random.Next(emptyPlacesList.Count)];

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
                            if (city[i, j].CheckHappiness(city, height, width) == "Sad"){
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
                            if (city[i, j].CheckHappiness(city, height, width) == "Sad")
                            {
                                sadСitizensList.Add(city[i, j]);
                            }
                        }
                    }
                }

                sadСitizensList.RemoveAll(citizen => citizen.Humor == happyColor);
                iteracija++;
            }
        }
        private void CauntСitizencs()
        {
            int dog = 0;
            int cat = 0;
            int empty = 0;

            foreach (Сitizens i in city)
            {
                if (i.Symbol == "🐶")
                {
                    dog++;
                }
                else if (i.Symbol == "🐱")
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
            Console.WriteLine($"Emppty - {empty} ");
            Console.WriteLine($"Iteracija - {iteracija}");
            Console.WriteLine("");
        }
    }
}
