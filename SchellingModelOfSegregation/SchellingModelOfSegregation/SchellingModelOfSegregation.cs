﻿using static System.Console;

namespace SchellingModelOfSegregation;

public class ModelOfSegregation
{
    public static void Main(string[] args)
    {
        int height = 0; 
        int width = 0;
        int emptyPlace = 0;

        WriteLine("World height (1-100)");
        if (int.TryParse(ReadLine(), out int resulth))
        {
            height = resulth;
        }

        WriteLine("World width (1-100)");
        if (int.TryParse(ReadLine(), out int resultw))
        {
            width = resultw;
        }

        WriteLine("Empty place (1-100)");
        if (int.TryParse(ReadLine(), out int resulte))
        {
            emptyPlace = resulte;
        }

        Worlds worlds = new Worlds(height, width, emptyPlace);

        Clear();
        while (true)
        {
            worlds.BildWorlds();
            worlds.DrawWorlds();
            char i = ReadKey().KeyChar;
            if (i == '0')
            {
                break;
            }
            Clear();
        }
    }

    static void ShowSimplePercentage()
    {
        for (int i = 0; i <= 100; i++)
        {
            Write($"\rProgress: {i}%   ");
            Thread.Sleep(25);
        }

        Write("\rDone!          ");
    }

    static void ShowSpinner()
    {
        var counter = 0;
        for (int i = 0; i < 50; i++)
        {
            switch (counter % 5)
            {
                case 0: Write("/"); break;
                case 1: Write("-"); break;
                case 3: Write("|"); break;
                case 2: Write("\\"); break;
                case 4: Write("|"); break;
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
                        WriteLine("╔════╤╤╤╤════╗");
                        WriteLine("║    │││ \\   ║");
                        WriteLine("║    │││  O  ║");
                        WriteLine("║    OOO     ║");
                        break;
                    };
                case 1:
                    {
                        WriteLine("╔════╤╤╤╤════╗");
                        WriteLine("║    ││││    ║");
                        WriteLine("║    ││││    ║");
                        WriteLine("║    OOOO    ║");
                        break;
                    };
                case 2:
                    {
                        WriteLine("╔════╤╤╤╤════╗");
                        WriteLine("║   / │││    ║");
                        WriteLine("║  O  │││    ║");
                        WriteLine("║     OOO    ║");
                        break;
                    };
                case 3:
                    {
                        WriteLine("╔════╤╤╤╤════╗");
                        WriteLine("║    ││││    ║");
                        WriteLine("║    ││││    ║");
                        WriteLine("║    OOOO    ║");
                        break;
                    };
            }

            counter++;
            Thread.Sleep(200);
        }
    }

    static void ColorfulAnimation()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                Console.Clear();

                // steam
                Write("       . . . . o o o o o o");
                for (int s = 0; s < j / 2; s++)
                {
                    Write(" o");
                }
                WriteLine();

                var margin = "".PadLeft(j);
                WriteLine(margin + "                _____      o");
                WriteLine(margin + "       ____====  ]OO|_n_n__][.");
                WriteLine(margin + "      [________]_|__|________)< ");
                WriteLine(margin + "       oo    oo  'oo OOOO-| oo\\_");
                WriteLine("   +--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+");

                Thread.Sleep(200);
            }
        }
    }

}
