using System;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        private readonly List<Creature>[,] _fields;

        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            _fields = new List<Creature>[sizeX, sizeY];
            for (int x = 0; x < sizeX; x++)
                for (int y = 0; y < sizeY; y++)
                    _fields[x, y] = new List<Creature>();
        }

        public override void Add(Creature creature, Point position)
        {
            var normalizedX = (position.X % SizeX + SizeX) % SizeX;
            var normalizedY = (position.Y % SizeY + SizeY) % SizeY;

            _fields[normalizedX, normalizedY].Add(creature);
            creature.InitMapAndPosition(this, new Point(normalizedX, normalizedY));
        }

        public override void Remove(Creature creature, Point position)
        {
            var normalizedX = (position.X % SizeX + SizeX) % SizeX;
            var normalizedY = (position.Y % SizeY + SizeY) % SizeY;

            _fields[normalizedX, normalizedY].Remove(creature);
        }

        public override List<Creature>? At(int x, int y)
        {
            var normalizedX = (x % SizeX + SizeX) % SizeX;
            var normalizedY = (y % SizeY + SizeY) % SizeY;

            return _fields[normalizedX, normalizedY];
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
