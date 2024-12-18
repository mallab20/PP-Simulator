
namespace Simulator.Maps
{
    internal static class MoveRules
    {
        public static Point Next(Map m, Point p, Direction d)
        {
            var moved = p.Next(d);
            if (!m.Exist(moved)) return p;
            return moved;
        }

        public static Point NextDiagonal(Map m, Point p, Direction d)
        {
            var moved = p.NextDiagonal(d);
            if (!m.Exist(moved)) return p;
            return moved;
        }


    }
}
