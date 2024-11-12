using Simulator;

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
    }
}