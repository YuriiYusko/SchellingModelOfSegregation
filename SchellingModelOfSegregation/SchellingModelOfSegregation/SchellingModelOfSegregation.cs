using Spectre.Console;

namespace SchellingModelOfSegregation;

public class ModelOfSegregation
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int height = 0;
        int width = 0;
        int emptyPlace = 0;

        Console.WriteLine("World height (1-100)");
        if (int.TryParse(Console.ReadLine(), out int resulth))
        {
            height = resulth;
        }

        Console.WriteLine("World width (1-100)");
        if (int.TryParse(Console.ReadLine(), out int resultw))
        {
            width = resultw;
        }

        Console.WriteLine("Empty place (1-100)");
        if (int.TryParse(Console.ReadLine(), out int resulte))
        {
            emptyPlace = resulte;
        }

        City city = new City(height, width, emptyPlace);

        Console.Clear();
        while (true)
        {
            city.BildCity();
            city.checkHappiness();
            city.DrawCity();

            Thread.Sleep(100);
            char i = Console.ReadKey().KeyChar;
            if (i == '0')
            {
                break;
            }
            Console.Clear();
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
