using Spectre.Console;
using System;
using System.Net.Security;

namespace SchellingModelOfSegregation;

public class ModelOfSegregation
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Rozwiń okno konsoli do pełnego ekranu i naciśni -Enter-");
        Console.ReadLine();
        Console.Clear();

        int height = 0;
        int width = 0;
        int emptyPlace = 0;

        Console.WriteLine($"Wysokość świata (Min.-25 Max.-{Console.WindowHeight - 1})");
        if (int.TryParse(Console.ReadLine(), out int resulth))
        {
            height = resulth;
        }
        Console.WriteLine($"Szerokość świata (Min.-25 Max.-{(Console.WindowWidth - 1)/2}");
        if (int.TryParse(Console.ReadLine(), out int resultw))
        {
            width = resultw;
        }
        Console.WriteLine("Empty place");
        if (int.TryParse(Console.ReadLine(), out int resulte))
        {
            emptyPlace = resulte;
        }



        City city = new City(height, width, emptyPlace);
        Console.Clear();

        city.BildCity();
        city.CheckHappiness();
        city.CheckEmpty();
        Console.ReadLine();

        ConsoleKeyInfo cki = new ConsoleKeyInfo();
        while (true)
        {
            city.Migration();
            if (Console.KeyAvailable == true)
            {
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.X)
                {
                    Console.WriteLine("Stop");
                    Console.ReadLine();
                }
            }
        }

        static void Test()
        {
            Console.SetCursorPosition(0,0);
            char[,] charArray = new char[35, 120];

            for (var i = 0; i < 35; i++)
            {
                for (var j = 0; j < 120; j++)
                {
                    charArray[i, j] = 'O';
                }
            }

            for (var i = 0; i < 35; i++)
            {
                for (var j = 0; j < 120; j++)
                {
                    Console.Write(charArray[i, j]);
                }
                Console.WriteLine("");
            }

            for (var i = 0; i < 35; i++)
            {
                for (var j = 0; j < 120; j++)
                {
                    Console.SetCursorPosition(j,i);
                    Console.Write('X');
                    Thread.Sleep(10);
                }
            }
        }

        static void ShowSimplePercentage()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.Write($"\rProgress: {i}%   ");
                Thread.Sleep(25);
            }

            Console.Write("\rDone!          ");
        }

        static void ShowSpinner()
        {
            var counter = 0;
            for (int i = 0; i < 50; i++)
            {
                switch (counter % 5)
                {
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 3: Console.Write("|"); break;
                    case 2: Console.Write("\\"); break;
                    case 4: Console.Write("|"); break;
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                counter++;
                Thread.Sleep(100);
            }
        }

        static void MultiLineAnimation()
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("╔════╤╤╤╤════╗");
                            Console.WriteLine("║    │││ \\   ║");
                            Console.WriteLine("║    │││  O  ║");
                            Console.WriteLine("║    OOO     ║");

                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("╔════╤╤╤╤════╗");
                            Console.WriteLine("║    ││││    ║");
                            Console.WriteLine("║    ││││    ║");
                            Console.WriteLine("║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("╔════╤╤╤╤════╗");
                            Console.WriteLine("║   / │││    ║");
                            Console.WriteLine("║  O  │││    ║");
                            Console.WriteLine("║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("╔════╤╤╤╤════╗");
                            Console.WriteLine("║    ││││    ║");
                            Console.WriteLine("║    ││││    ║");
                            Console.WriteLine("║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }

    }
}
