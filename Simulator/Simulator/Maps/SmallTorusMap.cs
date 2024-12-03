using System;

namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

        public override void Add(IMappable mappable, Point position)
        {
            var normalizedX = (position.X % SizeX + SizeX) % SizeX;
            var normalizedY = (position.Y % SizeY + SizeY) % SizeY;
            base.Add(mappable, new Point(normalizedX, normalizedY));
        }

        public override void Remove(IMappable mappable, Point position)
        {
            var normalizedX = (position.X % SizeX + SizeX) % SizeX;
            var normalizedY = (position.Y % SizeY + SizeY) % SizeY;
            base.Remove(mappable, new Point(normalizedX, normalizedY));
        }

        public override bool Exist(Point p)
        {
            return true;
        }

        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            int newX = (nextPoint.X % SizeX + SizeX) % SizeX;
            int newY = (nextPoint.Y % SizeY + SizeY) % SizeY;
            return new Point(newX, newY);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextPoint = p.NextDiagonal(d);
            int newX = (nextPoint.X % SizeX + SizeX) % SizeX;
            int newY = (nextPoint.Y % SizeY + SizeY) % SizeY;
            return new Point(newX, newY);
        }
    }
}
