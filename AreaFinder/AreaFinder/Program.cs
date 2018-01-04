using System;
using System.Collections.Generic;
using AreaFinder.Entities;

namespace AreaFinder
{
    class Program
    {
        public static void Options()
        {
            Console.WriteLine("Press:\n      'C' - to create circle\n      " +
                    "'R' - to create rectangle\n      'P' - to print shapes\n      " +
                    "'S' - to serialize shapes\n      'T' - to terminate program\n");
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo choice;
            var shapes = new List<Shp>();

            Serialization.LoadData(shapes);

            while (true)
            {
                Options();
                choice = Console.ReadKey(true);

                switch (choice.Key)
                {
                    case ConsoleKey.C:
                        Handler.CreateCircle(shapes);
                        break;

                    case ConsoleKey.R:
                        Handler.CreateRectangle(shapes);
                        break;

                    case ConsoleKey.P:
                        Handler.PrintData(shapes);
                        break;

                    case ConsoleKey.S:
                        Serialization.Serialize(shapes);
                        Console.WriteLine("Data serialized.\n");
                        break;

                    case ConsoleKey.T:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalide comand!\n");
                        break;
                }
            }
        }
    }
}
