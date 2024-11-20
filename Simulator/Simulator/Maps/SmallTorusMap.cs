using System;

using System;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
        }

        public override Point Next(Point p, Direction d)
        {
            return new Point(
                (p.Next(d).X % Size + Size) % Size,
                (p.Next(d).Y % Size + Size) % Size
            );
        }
        public override Point NextDiagonal(Point p, Direction d)
        {
            return new Point(
                (p.NextDiagonal(d).X % Size + Size) % Size,
                (p.NextDiagonal(d).Y % Size + Size) % Size
            );
        }
    }
}
