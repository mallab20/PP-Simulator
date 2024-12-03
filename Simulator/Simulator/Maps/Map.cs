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
        public abstract List<IMappable>? At(int x, int y);


        protected Map(int sizeX, int sizeY)
        {
            if (sizeX < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow.");

            }
            if (sizeX < 5)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Too shorts.");

            }
            SizeX = sizeX;
            SizeY = sizeY;
        }

        public int SizeX { get;  }
        public int SizeY { get; }


        /// <summary>
        /// Check if give point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns></returns>
        public abstract bool Exist(Point p);

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Next diagonal position to the point in a given direction 
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point NextDiagonal(Point p, Direction d);
    }
}
