using System;
using Simulator.Maps;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int SizeX { get; }
        public int SizeY { get; }

        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX <= 0 || sizeY <= 0)
                throw new ArgumentException("Sizes must be positive.");

            SizeX = sizeX;
            SizeY = sizeY;
        }
        public SmallTorusMap(int size) : this(size, size) { }

        public override Point Next(Point current, Direction direction)
        {
            int newX = current.X;
            int newY = current.Y;

            switch (direction)
            {
                case Direction.Up:
                    newY = (current.Y - 1 + SizeY) % SizeY;
                    break;

                case Direction.Down:
                    newY = (current.Y + 1) % SizeY;
                    break;

                case Direction.Left:
                    newX = (current.X - 1 + SizeX) % SizeX;
                    break;

                case Direction.Right:
                    newX = (current.X + 1) % SizeX;
                    break;
            }

            return new Point(newX, newY);
        }

        public override bool IsValid(Point point)
        {
            return true;
        }
    }
}
