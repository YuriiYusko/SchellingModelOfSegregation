using Spectre.Console;

namespace SchellingModelOfSegregation
{
    class ConsoleGUI
    {
        int speed = 100;
        int numberTypesAgents = 2;
        int selectedLine = 0;

        public void Go()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Schelling Model Of Segregation";
            Console.CursorVisible = false;

            City city = EnteringStartParameters();
            Console.Clear();
            city.BildCity(numberTypesAgents);
            city.BildSadAgentList();
            city.BildEmptyList();
            DrawMenu(city);

            ConsoleKeyInfo cki = new();
            while (true)
            {
                if (speed != 100) { city.Migration(); }

                if (Console.KeyAvailable == true)
                {
                    cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.A:
                            if (selectedLine == 0)
                            {
                                if (speed < 100) { speed += 20; DrawMenu(city); }
                            }
                            if (selectedLine == 4)
                            {
                                city.RedTolerance = --city.RedTolerance; ;
                                city.BildSadAgentList();
                                DrawMenu(city);
                            }
                            if (selectedLine == 8)
                            {
                                city.BlueTolerance = --city.BlueTolerance; ;
                                city.BildSadAgentList();
                                DrawMenu(city);
                            }
                            if (selectedLine == 12 && numberTypesAgents >= 3)
                            {
                                city.GreenTolerance = --city.GreenTolerance; ;
                                city.BildSadAgentList();
                                DrawMenu(city);
                            }
                            if (selectedLine == 16 && numberTypesAgents >= 4)
                            {
                                city.YellowTolerance = --city.YellowTolerance; ;
                                city.BildSadAgentList();
                                DrawMenu(city);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.D:
                            if (selectedLine == 0)
                            {
                                if (speed > 0) { speed -= 20; DrawMenu(city); }
                            }
                            if (selectedLine == 4)
                            {
                                city.RedTolerance = ++city.RedTolerance;
                                city.BildSadAgentList();
                                DrawMenu(city);
                            }
                            if (selectedLine == 8)
                            {
                                city.BlueTolerance = ++city.BlueTolerance; ;
                                city.BildSadAgentList();
                                DrawMenu(city);
                            }
                            if (selectedLine == 12 && numberTypesAgents >= 3)
                            {
                                city.GreenTolerance = ++city.GreenTolerance; ;
                                city.BildSadAgentList();
                                DrawMenu(city);
                            }
                            if (selectedLine == 16 && numberTypesAgents >= 4)
                            {
                                city.YellowTolerance = ++city.YellowTolerance; ;
                                city.BildSadAgentList();
                                DrawMenu(city);
                            }
                            break;
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S:
                            if (selectedLine < 20) { selectedLine += 4; DrawMenu(city); }
                            break;
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W:
                            if (selectedLine > 0) { selectedLine -= 4; DrawMenu(city); }
                            break;
                    }
                }

                Task.Run(() => Thread.Sleep(speed)).Wait();
            }
        }
        private void DrawMenu(City city)
        {
            //Сhoice
            Console.SetCursorPosition(city.Width + city.Width + 1, 0);
            for (int i = 0; i < 23; i++)
            {
                Console.SetCursorPosition(city.Width + city.Width + 1, i);
                Console.Write(" ");
            }
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(city.Width + city.Width + 1, selectedLine + i);
                Console.Write(">");
            }
            //Speed
            Console.SetCursorPosition(city.Width + city.Width + 3, 0);
            if (speed != 100)
            {
                Console.Write("Speed:" + city.GreenTolerance);
            }
            else
            {
                Console.Write("Pause:");
            }
            Console.SetCursorPosition(city.Width + city.Width + 3, 1);
            switch (speed)
            {
                case 0:
                    AnsiConsole.Write(new Text("||||||", new Style(Color.Black, Color.Grey)));
                    break;
                case 20:
                    AnsiConsole.Write(new Text("||||| ", new Style(Color.Black, Color.Grey)));
                    break;
                case 40:
                    AnsiConsole.Write(new Text("||||  ", new Style(Color.Black, Color.Grey)));
                    break;
                case 60:
                    AnsiConsole.Write(new Text("|||   ", new Style(Color.Black, Color.Grey)));
                    break;
                case 80:
                    AnsiConsole.Write(new Text("||    ", new Style(Color.Black, Color.Grey)));
                    break;
                case 100:
                    AnsiConsole.Write(new Text("|     ", new Style(Color.Black, Color.Grey)));
                    break;
            }
            //Red
            Console.SetCursorPosition(city.Width + city.Width + 3, 5);
            Console.WriteLine($"Red - {city.RedTolerance}");
            //Blue
            Console.SetCursorPosition(city.Width + city.Width + 3, 9);
            Console.WriteLine($"Blue - {city.BlueTolerance}");
            //Green
            Console.SetCursorPosition(city.Width + city.Width + 3, 13);
            Console.WriteLine($"Green - {city.GreenTolerance}");
            //Yellow
            Console.SetCursorPosition(city.Width + city.Width + 3, 17);
            Console.WriteLine($"Yellow - {city.YellowTolerance}");
        }

        private City EnteringStartParameters()
        {
            int height = 25;
            int width = 25;
            int emptyPlace = 100;

            Console.WriteLine("Rozwiń okno konsoli do pełnego ekranu i naciśni -Enter-");
            Console.ReadLine();
            Console.WriteLine($"Wysokość świata: (Min.-25 Max.-{Console.WindowHeight - 1})");
            if (int.TryParse(Console.ReadLine(), out int resulth))
            {
                height = resulth;
            }
            Console.WriteLine($"Szerokość świata: (Min.-25 Max.-{(Console.WindowWidth - 1) / 2})");
            if (int.TryParse(Console.ReadLine(), out int resultw))
            {
                width = resultw;
            }
            Console.WriteLine($"Puste miejsca: (15% ≈ {(height * width) * 0.15})");
            if (int.TryParse(Console.ReadLine(), out int resulte))
            {
                emptyPlace = resulte;
            }
            Console.WriteLine($"Liczba agentów: (2 - 4)");
            if (int.TryParse(Console.ReadLine(), out int resulta))
            {
                numberTypesAgents = resulta;
            }
            return new(height, width, emptyPlace);
        }
    }
}
