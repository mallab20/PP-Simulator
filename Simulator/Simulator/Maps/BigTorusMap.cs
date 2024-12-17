using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class BigTorusMap : Map
    {
        public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 1000 || sizeY > 1000)
                throw new ArgumentOutOfRangeException("Wymiary nie mogą przekraczać 1000x1000.");
        }

        public override bool Exist(Point p) => true;

        public override Point Next(Point p, Direction d) => WrapPosition(p.Next(d));

        public override Point NextDiagonal(Point p, Direction d) => WrapPosition(p.NextDiagonal(d));

        protected override Point WrapPosition(Point position)
        {
            int wrappedX = (position.X + SizeX) % SizeX;
            int wrappedY = (position.Y + SizeY) % SizeY;
            return new Point(wrappedX, wrappedY);
        }
    }
}
