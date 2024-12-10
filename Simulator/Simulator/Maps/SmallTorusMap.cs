using System.Collections.Generic;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        private readonly List<IMappable>[,] _mapGrid;
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            _mapGrid = new List<IMappable>[sizeX, sizeY];
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    _mapGrid[x, y] = new List<IMappable>();
                }
            }
        }
        public SmallTorusMap(int size) : this(size, size) { }

        /// <summary>
        /// Get the objects at a specific position.
        /// </summary>
        public override List<IMappable>? At(int x, int y)
        {
            if (x < 0 || y < 0 || x >= SizeX || y >= SizeY)
                return null;

            return _mapGrid[x, y];
        }

        /// <summary>
        /// Get the objects at a specific position using a Point object.
        /// </summary>
        /// <summary>
        public override List<IMappable>? At(Point p)
        {
            int wrappedX = (p.X + SizeX) % SizeX;
            int wrappedY = (p.Y + SizeY) % SizeY;

            return _mapGrid[wrappedX, wrappedY];
        }


        /// <summary>
        /// Check if a given point belongs to the map (always true for toroidal maps).
        /// </summary>
        public override bool Exist(Point p)
        {
            return true;
        }

        /// <summary>
        /// Calculate the next position in a given direction.
        /// </summary>
        public override Point Next(Point p, Direction d)
        {
            int newX = p.X;
            int newY = p.Y;

            switch (d)
            {
                case Direction.Up:
                    newY = (p.Y - 1 + SizeY) % SizeY;
                    break;
                case Direction.Down:
                    newY = (p.Y + 1) % SizeY;
                    break;
                case Direction.Left:
                    newX = (p.X - 1 + SizeX) % SizeX;
                    break;
                case Direction.Right:
                    newX = (p.X + 1) % SizeX;
                    break;
            }

            return new Point(newX, newY);
        }

        /// <summary>
        /// Calculate the next diagonal position (45 degrees rotated) in a given direction.
        /// </summary>
        public override Point NextDiagonal(Point p, Direction d)
        {
            int newX = p.X;
            int newY = p.Y;

            switch (d)
            {
                case Direction.Up:
                    newX = (p.X + 1) % SizeX;
                    newY = (p.Y - 1 + SizeY) % SizeY;
                    break;

                case Direction.Down:
                    newX = (p.X - 1 + SizeX) % SizeX;
                    newY = (p.Y + 1) % SizeY;
                    break;

                case Direction.Left:
                    newX = (p.X - 1 + SizeX) % SizeX;
                    newY = (p.Y - 1 + SizeY) % SizeY;
                    break;

                case Direction.Right:
                    newX = (p.X + 1) % SizeX;
                    newY = (p.Y + 1) % SizeY;
                    break;
            }

            return new Point(newX, newY);
        }

        /// <summary>
        /// Add an object to the map at a specific position.
        /// </summary>
        public override void Add(IMappable mappable, Point position)
        {
            var wrappedPosition = WrapPosition(position);
            _mapGrid[wrappedPosition.X, wrappedPosition.Y].Add(mappable);

            if (mappable is Creature creature)
            {
                creature.Map = this;
                creature.Position = wrappedPosition;
            }
        }

        /// <summary>
        /// Remove an object from the map at a specific position.
        /// </summary>
        public override void Remove(IMappable mappable, Point position)
        {
            var wrappedPosition = WrapPosition(position);
            _mapGrid[wrappedPosition.X, wrappedPosition.Y].Remove(mappable);
        }

        /// <summary>
        /// Wrap a position to the toroidal bounds of the map.
        /// </summary>
        private Point WrapPosition(Point position)
        {
            int wrappedX = (position.X + SizeX) % SizeX;
            int wrappedY = (position.Y + SizeY) % SizeY;
            return new Point(wrappedX, wrappedY);
        }
    }
}
