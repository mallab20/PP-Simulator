using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {

        List<IMappable>?[,] _fields; 

        protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide.");

            }
            if (sizeX > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high.");

            }
            _fields = new List<IMappable>?[sizeX, sizeY];
        }
    }
}
