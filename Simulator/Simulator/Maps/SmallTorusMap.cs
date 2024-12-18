﻿using System.Collections.Generic;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 50 || sizeY > 50)
                throw new ArgumentOutOfRangeException("Wymiary nie mogą przekraczać 50x50.");
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
