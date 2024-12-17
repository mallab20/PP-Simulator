using System;
using Simulator.Maps;
namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX <= 0 || sizeY <= 0 || sizeX > 50 || sizeY > 50)
                throw new ArgumentException("Wymiary nie mogą przekraczać 50x50 i muszą być dodatnie.");
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
        public override Point NextDiagonal(Point current, Direction direction)
        {
            int newX = current.X;
            int newY = current.Y;

            switch (direction)
            {
                case Direction.Up:
                    newX = (current.X + 1) % SizeX;
                    newY = (current.Y - 1 + SizeY) % SizeY;
                    break;

                case Direction.Down:
                    newX = (current.X - 1 + SizeX) % SizeX;
                    newY = (current.Y + 1) % SizeY;
                    break;

                case Direction.Left:
                    newX = (current.X - 1 + SizeX) % SizeX;
                    newY = (current.Y - 1 + SizeY) % SizeY;
                    break;

                case Direction.Right:
                    newX = (current.X + 1) % SizeX;
                    newY = (current.Y + 1) % SizeY;
                    break;
            }

            return new Point(newX, newY);
        }
        public override bool Exist(Point point)
        {
            return true;
        }
        protected override Point WrapPosition(Point position)
        {
            int wrappedX = (position.X + SizeX) % SizeX;
            int wrappedY = (position.Y + SizeY) % SizeY;
            return new Point(wrappedX, wrappedY);
        }
    }
}
