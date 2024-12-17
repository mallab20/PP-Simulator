using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public interface IMappable
    {
        Point Position { get; }
        public char Symbol { get; } // umowny symbol obiektu
        public string ToString();
        // sugerujemy override, bo object.ToString() zwraca string?
    }
}
