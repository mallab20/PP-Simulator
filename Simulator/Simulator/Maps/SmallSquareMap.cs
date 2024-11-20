using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Simulator.Maps
{
    public class SmallSquareMap : SmallMap
    {

        public SmallSquareMap(int sizeX, int size, Y ) : base(sizeX, size, )
        {
        }

        public SmallSquareMap(int size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException(nameof(size), "Nieprawidłowy rozmiar mapy");

            Size = size;
            bounds = new Rectangle(0, 0, Size - 1, Size - 1);
        }

        public override bool Exist(Point p)
        {
            return bounds.Contains(p);
        }
        public override Point Next(Point p, Direction d)
        {
            Point nextPoint = p.Next(d);
            return Exist(nextPoint) ? nextPoint : p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point nextDiagonalPoint = p.NextDiagonal(d);
            return Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
        }

    }
}
