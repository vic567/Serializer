using AreaFinder.Entities;
using System;
using System.Collections.Generic;
using AreaFinder.Enums;

namespace AreaFinder
{
    public static class Handler
    {
        public static void CreateCircle(List<Shp> shapes)
        {
            Console.WriteLine("New circle!\n      You must input value for R.\n");

            Console.Write("      R = ");
            int R = int.Parse(Console.ReadLine());
            Console.WriteLine();

            var circle = new Circle(R);
            shapes.Add(circle);
        }

        public static void CreateRectangle(List<Shp>  shapes)
        {
            Console.WriteLine("New rectangle!\n      You must input values for Width & Heigth.\n");

            Console.Write("      W = ");
            int W = int.Parse(Console.ReadLine());

            Console.Write("      H = ");
            int H = int.Parse(Console.ReadLine());
            Console.WriteLine();

            var rectangle = new Rectangle(W, H);
            shapes.Add(rectangle);
        }

        public static void PrintData(List<Shp> shapes)
        {
            int counter = 1;

            foreach (var s in shapes)
            {
                switch(s.Type)
                {
                    case ShapeType.Circle:
                        var c = (Circle)s;
                        Console.WriteLine("  ---------------------------");
                        Console.WriteLine("  | Object {0} - {1}       |\n  |    " +
                            "R = {2}                |\n  |    S = {3} |",
                            counter, c.Type, c.Radius, c.Area());
                        Console.WriteLine("  ---------------------------\n");
                        break;

                    case ShapeType.Rectangle:
                        var r = (Rectangle)s;
                        Console.WriteLine("  ---------------------------");
                        Console.WriteLine("  | Object {0} - {1}    |\n  |    " +
                            "W = {2}               |\n  |    H = {3}                |\n  |    S = {4}              |",
                            counter, r.Type, r.Width, r.Height, r.Area());
                        Console.WriteLine("  ---------------------------\n");
                        break;
                }

                counter++;
            }
        }
    }
}