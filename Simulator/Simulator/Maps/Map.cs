using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace Simulator.Maps
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {
        public abstract List<IMappable>? At(Point p);

        public abstract List<IMappable>? At(int x, int y);

        protected Map(int sizeX, int sizeY)
        {
            if (sizeX < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow.");
            }
            if (sizeY < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short.");
            }
            SizeX = sizeX;
            SizeY = sizeY;
        }

        public int SizeX { get; }
        public int SizeY { get; }

        /// <summary>
        /// Check if a given point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        public abstract bool Exist(Point p);

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Next diagonal position to the point in a given direction rotated 45 degrees clockwise.
        /// </summary>
        public abstract Point NextDiagonal(Point p, Direction d);

        /// <summary>
        /// Add an object to the map at a specific position.
        /// </summary>
        public abstract void Add(IMappable mappable, Point position);

        /// <summary>
        /// Remove an object from the map at a specific position.
        /// </summary>
        public abstract void Remove(IMappable mappable, Point position);
    }
}
