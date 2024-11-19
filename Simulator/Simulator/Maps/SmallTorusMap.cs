using System;

using System;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int Size { get; }
        public SmallTorusMap(int size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException(nameof(size));
            Size = size;
        }
        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
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
