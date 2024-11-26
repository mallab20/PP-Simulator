using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        private readonly List<Creature>[,] _fields;
        private readonly Rectangle bounds;

        public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            _fields = new List<Creature>[sizeX, sizeY];
            for (int x = 0; x < sizeX; x++)
                for (int y = 0; y < sizeY; y++)
                    _fields[x, y] = new List<Creature>();

            bounds = new Rectangle(0, 0, sizeX - 1, sizeY - 1);
        }

        public SmallSquareMap(int size) : this(size, size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException(nameof(size), "Nieprawidłowy rozmiar mapy.");
        }

        public override void Add(Creature creature, Point position)
        {
            if (!Exist(position))
                throw new ArgumentException("Pozycja jest poza granicami mapy.");

            _fields[position.X, position.Y].Add(creature);
            creature.InitMapAndPosition(this, position);
        }

        public override void Remove(Creature creature, Point position)
        {
            if (!Exist(position))
                throw new ArgumentException("Pozycja jest poza granicami mapy.");

            _fields[position.X, position.Y].Remove(creature);
        }

        public override List<Creature>? At(int x, int y)
        {
            if (x < 0 || x >= SizeX || y < 0 || y >= SizeY)
                return null;

            return _fields[x, y];
        }

        public override bool Exist(Point p)
        {
            return bounds.Contains(p);
        }

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
