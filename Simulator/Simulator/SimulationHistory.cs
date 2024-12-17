using Simulator.Maps;
using System;
using System.Collections.Generic;

namespace Simulator
{
    public class SimulationHistory
    {
        private readonly Map _map;
        private readonly List<HistoryEntry> _history;

        public SimulationHistory(Map map)
        {
            _map = map;
            _history = new List<HistoryEntry>();
        }

        /// <param name="turnNumber">Numer tury.</param>
        /// <param name="movedObject">Obiekt, który wykonał ruch.</param>
        /// <param name="movement">Wykonany ruch.</param>
        public void RecordTurn(int turnNumber, IMappable movedObject, Direction movement)
        {
            var stateSnapshot = new Dictionary<Point, List<IMappable>>();

            for (int x = 0; x < _map.SizeX; x++)
            {
                for (int y = 0; y < _map.SizeY; y++)
                {
                    var position = new Point(x, y);
                    var objectsAtPosition = _map.At(position);

                    if (objectsAtPosition != null && objectsAtPosition.Count > 0)
                    {
                        stateSnapshot[position] = new List<IMappable>(objectsAtPosition);
                    }
                }
            }
            _history.Add(new HistoryEntry(turnNumber, stateSnapshot, movedObject, movement));
        }
        /// <param name="turnNumber">Numer tury.</param>
        public void ReplayTurn(int turnNumber)
        {
            var entry = _history.Find(e => e.TurnNumber == turnNumber);
            if (entry == null)
            {
                Console.WriteLine($"Tura {turnNumber} nie istnieje w historii.");
                return;
            }

            Console.WriteLine($"Odtwarzanie tury {turnNumber}:");
            Console.WriteLine($"Obiekt: {entry.MovedObject.GetType().Name} wykonał ruch: {entry.Movement}");

            foreach (var kvp in entry.StateSnapshot)
            {
                Console.WriteLine($"Pozycja {kvp.Key}: {string.Join(", ", kvp.Value)}");
            }
        }

        private class HistoryEntry
        {
            public int TurnNumber { get; }
            public Dictionary<Point, List<IMappable>> StateSnapshot { get; }
            public IMappable MovedObject { get; }
            public Direction Movement { get; }

            public HistoryEntry(int turnNumber, Dictionary<Point, List<IMappable>> stateSnapshot, IMappable movedObject, Direction movement)
            {
                TurnNumber = turnNumber;
                StateSnapshot = stateSnapshot;
                MovedObject = movedObject;
                Movement = movement;
            }
        }
    }
}
