using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
namespace Simulator.Maps
{
    public class BigMap : Map
    {
        private readonly Dictionary<Point, List<IMappable>> _fields;

        public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 1000 || sizeY > 1000)
            {
                throw new ArgumentOutOfRangeException("Rozmiar mapy przekracza dopuszczalny limit.");
            }

            _fields = new Dictionary<Point, List<IMappable>>();
        }

        public override void Add(IMappable mappable, Point position)
        {
            if (!Exist(position))
                throw new ArgumentException("Pozycja jest poza granicami mapy.");

            if (!_fields.ContainsKey(position))
            {
                _fields[position] = new List<IMappable>();
            }

            _fields[position].Add(mappable);

            if (mappable is Creature creature)
            {
                creature.InitMapAndPosition(this, position);
            }
        }

        public override void Remove(IMappable mappable, Point position)
        {
            if (!Exist(position))
                throw new ArgumentException("Pozycja jest poza granicami mapy.");

            if (_fields.ContainsKey(position))
            {
                _fields[position].Remove(mappable);

                if (_fields[position].Count == 0)
                {
                    _fields.Remove(position);
                }
            }
        }

        public override List<IMappable>? At(int x, int y)
        {
            var point = new Point(x, y);
            return At(point);
        }

        public override List<IMappable>? At(Point p)
        {
            if (_fields.ContainsKey(p))
            {
                return _fields[p];
            }

            return null;
        }

        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
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
