using Spectre.Console;

namespace SchellingModelOfSegregation
{
    class ConsoleGUI
    {
        int height = 0;
        int width = 0;
        int emptyPlace = 0;
        int neighbor = 0;
        int speed = 100;
        int selectedLine = 1;

        public void Go()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Schelling Model Of Segregation";
            Console.CursorVisible = false;

            //AnsiConsole.Write(new Text("  ", new Style(Color.White, new Color(76, 175, 80)))); - Green
            //AnsiConsole.Write(new Text("  ", new Style(Color.White, new Color(3, 169, 244)))); - Light Blue
            //AnsiConsole.Write(new Text("  ", new Style(Color.White, new Color(255, 235, 59)))); - Yellow
            //AnsiConsole.Write(new Text("  ", new Style(Color.White, new Color(244, 67, 54)))); - Red
            //AnsiConsole.Write(new Text("  ", new Style(Color.White, new Color(156, 39, 176)))); - Purple

            Start();

            City city = new(height, width, emptyPlace);
            Console.Clear();

            city.BildCity(neighbor);
            city.BildSadAgentList();
            city.BildEmptyList();
            DrawMenu();
            Console.ReadLine();

            ConsoleKeyInfo cki = new();
            bool pause = false;
            while (true)
            {
                if (!pause) { city.Migration(); }

                if (Console.KeyAvailable == true)
                {
                    cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {
                        case ConsoleKey.Add:
                        case ConsoleKey.OemPlus:
                            if (speed > 0) { speed -= 20; DrawMenu(); }
                            break;
                        case ConsoleKey.Subtract:
                        case ConsoleKey.OemMinus:
                            if (speed < 100) { speed += 20; DrawMenu(); }
                            break;
                        case ConsoleKey.Spacebar:
                            pause = !pause;
                            break;
                        case ConsoleKey.UpArrow:
                            if (selectedLine < 6) { selectedLine += 1; DrawMenu(); }
                            break;
                        case ConsoleKey.DownArrow:
                            if (selectedLine > 1) { selectedLine -= 1; DrawMenu(); }
                            break;
                    }
                }

                Console.SetCursorPosition(0, height);
                Console.Write(cki.Key + "                    ");
                Console.SetCursorPosition(0, height + 1);
                Console.Write(selectedLine);

                Task.Run(() => Thread.Sleep(speed)).Wait();
            }
        }
        private void DrawMenu()
        {
            Console.SetCursorPosition(width + width + 3, 0);
            Console.Write("Speed:");
            Console.SetCursorPosition(width + width + 3, 1);

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
        }

        private void Start()
        {
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
            Console.WriteLine("Poziom tolerancji (Optymalny: 3-5).");
            if (int.TryParse(Console.ReadLine(), out int resultn))
            {
                neighbor = resultn;
            }
        }
    }
}
