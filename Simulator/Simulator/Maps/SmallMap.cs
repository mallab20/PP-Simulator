using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {
        private readonly List<IMappable>?[,] _fields;

        public override List<IMappable>? At(int x, int y)
        {
            if (x < 0 || x >= SizeX || y < 0 || y >= SizeY)
                return null;

            return _fields[x, y];
        }

        protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide.");
            }

            if (sizeY > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high.");
            }

            _fields = new List<IMappable>?[sizeX, sizeY];
            for (int x = 0; x < sizeX; x++)
                for (int y = 0; y < sizeY; y++)
                    _fields[x, y] = new List<IMappable>();
        }

        /// <summary>
        /// Adds an object to the map at the specified position.
        /// </summary>
        public virtual void Add(IMappable mappable, Point position)
        {
            if (!Exist(position))
                throw new ArgumentException("Position is out of bounds.");

            var listAtPosition = _fields[position.X, position.Y];
            listAtPosition?.Add(mappable);

            if (mappable is Creature creature)
            {
                creature.InitMapAndPosition(this, position);
            }
        }

        /// <summary>
        /// Removes an object from the map at the specified position.
        /// </summary>
        public virtual void Remove(IMappable mappable, Point position)
        {
            if (!Exist(position))
                throw new ArgumentException("Position is out of bounds.");

            var listAtPosition = _fields[position.X, position.Y];
            listAtPosition?.Remove(mappable);
        }
    }
}
