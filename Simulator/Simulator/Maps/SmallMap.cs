using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Simulator.Maps
{
    public class SmallMap : Map
    {
        public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 50 || sizeY > 50)
                throw new ArgumentOutOfRangeException("Wymiary nie mogą przekraczać 50x50.");
        }

        public override bool Exist(Point p) => p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;

        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            return Exist(nextPoint) ? nextPoint : p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextPoint = p.NextDiagonal(d);
            return Exist(nextPoint) ? nextPoint : p;
        }
    }
}
