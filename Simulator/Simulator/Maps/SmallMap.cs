using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {
        protected SmallMap(int sizeX, int size Y) : base(sizeX, sizeY)
        {
            if (sizeX > 20)
            {
                throw ArgumentOutOfRangeException(nameof(sizeX), "Too wide.");

            }
            if (sizeX > 20)
            {
                throw ArgumentOutOfRangeException(nameof(sizeY), "Too high.");

            }
        }
    }
}
