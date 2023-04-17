using Spectre.Console;

namespace SchellingModelOfSegregation
{
    class ConsoleGUI
    {
        int _redTolerance = 0;

        int speed = 100;
        int selectedLine = 0;

        public void Go()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Schelling Model Of Segregation";
            Console.CursorVisible = false;

            //AnsiConsole.Write(new Text("  ", new Style(Color.White, new Color(76, 175, 80)))); - Green
            //AnsiConsole.Write(new Text("  ", new Style(Color.White, new Color(3, 169, 244)))); - Blue
            //AnsiConsole.Write(new Text("  ", new Style(Color.White, new Color(255, 235, 59)))); - Yellow
            //AnsiConsole.Write(new Text("  ", new Style(Color.White, new Color(244, 67, 54)))); - Red
            //AnsiConsole.Write(new Text("  ", new Style(Color.White, new Color(156, 39, 176)))); - Purple

            City city = EnteringStartParameters();
            Console.Clear();
            city.BildCity();
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

                //Console.SetCursorPosition(0, city.Height + 5);
                //Console.Write(cki.Key + "                    ");
                //Console.SetCursorPosition(0, city.Height + 6);
                //Console.Write(selectedLine + "               ");

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
                Console.Write("Speed:");
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
        }

        private City EnteringStartParameters()
        {
            int height = 0;
            int width = 0;
            int emptyPlace = 0;

            Console.WriteLine("Rozwiń okno konsoli do pełnego ekranu i naciśni -Enter-");
            Console.ReadLine();
            Console.WriteLine($"Wysokość świata (Min.-25 Max.-{Console.WindowHeight - 1})");
            if (int.TryParse(Console.ReadLine(), out int resulth))
            {
                height = resulth;
            }
            Console.WriteLine($"Szerokość świata (Min.-25 Max.-{(Console.WindowWidth - 1) / 2}");
            if (int.TryParse(Console.ReadLine(), out int resultw))
            {
                width = resultw;
            }
            Console.WriteLine("Puste miejsca.");
            if (int.TryParse(Console.ReadLine(), out int resulte))
            {
                emptyPlace = resulte;
            }
            return new(height, width, emptyPlace);
        }
    }
}
