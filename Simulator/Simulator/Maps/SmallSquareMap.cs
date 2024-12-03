using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallSquareMap : SmallMap
    {
        private readonly Rectangle bounds;

        public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            bounds = new Rectangle(0, 0, sizeX - 1, sizeY - 1);
        }

        public SmallSquareMap(int size) : this(size, size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException(nameof(size), "Nieprawidłowy rozmiar mapy.");
        }

        /// <summary>
        /// Add an IMappable object to the map at a specific position.
        /// </summary>
        public override void Add(IMappable mappable, Point position)
        {
            if (!Exist(position))
                throw new ArgumentException("Pozycja jest poza granicami mapy.");

            var listAtPosition = At(position.X, position.Y);
            if (listAtPosition != null)
            {
                listAtPosition.Add(mappable);

                if (mappable is Creature creature)
                {
                    creature.InitMapAndPosition(this, position);
                }
            }
            else
            {
                throw new InvalidOperationException("Nie można dodać obiektu - pole jest null.");
            }
        }

        /// <summary>
        /// Remove an IMappable object from the map at a specific position.
        /// </summary>
        public override void Remove(IMappable mappable, Point position)
        {
            if (!Exist(position))
                throw new ArgumentException("Pozycja jest poza granicami mapy.");

            var listAtPosition = At(position.X, position.Y);
            if (listAtPosition != null)
            {
                if (!listAtPosition.Remove(mappable))
                {
                    throw new InvalidOperationException("Nie można usunąć obiektu - nie znaleziono go w pozycji.");
                }
            }
            else
            {
                throw new InvalidOperationException("Nie można usunąć obiektu - pole jest null.");
            }
        }

        /// <summary>
        /// Check if a point exists within the bounds of the map.
        /// </summary>
        public override bool Exist(Point p)
        {
            return bounds.Contains(p);
        }

        /// <summary>
        /// Get the next point in a given direction.
        /// </summary>
        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            return Exist(nextPoint) ? nextPoint : p;
        }

        /// <summary>
        /// Get the next diagonal point in a given direction rotated 45 degrees clockwise.
        /// </summary>
        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextPoint = p.NextDiagonal(d);
            return Exist(nextPoint) ? nextPoint : p;
        }
    }
}
