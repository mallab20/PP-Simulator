using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// Reprezentacja stanu mapy po pojedynczej turze symulacji.
    /// </summary>
    public class SimulationTurnLog
    {
        /// <summary>
        /// Tekstowa reprezentacja obiektu wykonującego ruch w tej turze.
        /// </summary>
        public required string Mappable { get; init; }

        /// <summary>
        /// Tekstowa reprezentacja ruchu wykonanego w tej turze.
        /// </summary>
        public required string Move { get; init; }

        /// <summary>
        /// Słownik zawierający symbole obiektów na mapie w tej turze.
        /// </summary>
        public required Dictionary<Point, char> Symbols { get; init; }
    }
}

