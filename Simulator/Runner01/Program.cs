using Simulator;
using Simulator.Maps;
using System.Drawing;

namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator!\n");

            Point p = new(10, 25);
            Console.WriteLine(p.Next(Direction.Right));
            Console.WriteLine(p.NextDiagonal(Direction.Right));

            Lab5a();
        }
        static void Lab5a()
        {
            try
            {
                Console.WriteLine("\nTesty");

                try
                {
                    Rectangle rec1 = new Rectangle(8, 2, 8, 2);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("\nBłąd przy tworzeniu prostokąta: " + ex.Message);
                }

                Rectangle rec2 = new Rectangle(8, 8, 2, 2);
                Console.WriteLine("\nUtworzono prostokąt");

                Point p1 = new Point(2, 2);
                Point p2 = new Point(8, 8);
                Rectangle rec3 = new Rectangle(p1, p2);
                Console.WriteLine("\nUtworzono prostokąt " + rec3);

                TestContains(rec3, new Point(4, 4), true);
                TestContains(rec3, new Point(10, 5), false);

                static void TestContains(Rectangle rec3, Point point, bool expectedResult)
                {
                    bool result = rec3.Contains(point);
                    Console.WriteLine($"\nTest dla punktu {point}: wynik {result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Lab5b()
        {
            SmallSquareMap map = new SmallSquareMap(10);

            Console.WriteLine($"Exist (0,0): {map.Exist(new Point(5, 5))}");
            Console.WriteLine($"Exist (10,10): {map.Exist(new Point(10, 10))}");

            Console.WriteLine($"Next (5,5) Up: {map.Next(new Point(5, 5), Direction.Up)}");
            Console.WriteLine($"Next (0,0) Left: {map.Next(new Point(0, 0), Direction.Left)}");

            Console.WriteLine($"NextDiagonal (5,5) Up: {map.NextDiagonal(new Point(5, 5), Direction.Up)}");
            Console.WriteLine($"NextDiagonal (0,0) Down: {map.NextDiagonal(new Point(0, 0), Direction.Down)}");

            try
            {
                SmallSquareMap invalidMap = new SmallSquareMap(3);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}