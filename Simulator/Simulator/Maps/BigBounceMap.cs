using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class BigBounceMap : BigMap
    {
        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            if (Exist(nextPoint))
            {
                return nextPoint;
            }
            Direction oppositeDirection = GetOppositeDirection(d);
            nextPoint = p.Next(oppositeDirection);

            return Exist(nextPoint) ? nextPoint : p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextPoint = p.NextDiagonal(d);
            if (Exist(nextPoint))
            {
                return nextPoint;
            }
            Direction oppositeDirection = GetOppositeDirection(d);
            nextPoint = p.NextDiagonal(oppositeDirection);

            return Exist(nextPoint) ? nextPoint : p;
        }

        /// <summary>
        /// Get the opposite direction (180° rotation).
        /// </summary>
        /// <param name="d">Original direction.</param>
        /// <returns>Opposite direction.</returns>
        private Direction GetOppositeDirection(Direction d)
        {
            return d switch
            {
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                _ => d
            };
        }
    }
}
