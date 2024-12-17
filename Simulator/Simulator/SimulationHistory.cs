using Simulator.Maps;
using System;
using System.Collections.Generic;

namespace Simulator
{
    public class SimulationHistory
    {
        private readonly Simulation _simulation;
        public int SizeX { get; }
        public int SizeY { get; }
        public List<SimulationTurnLog> TurnLogs { get; } = new();

        public SimulationHistory(Simulation simulation)
        {
            _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
            SizeX = _simulation.Map.SizeX;
            SizeY = _simulation.Map.SizeY;
            Run();
        }

        private void Run()
        {
            while (!_simulation.Finished)
            {
                var log = RecordTurn();
                TurnLogs.Add(log);
                _simulation.Turn();
            }
        }

        private SimulationTurnLog RecordTurn()
        {
            var currentMapState = new Dictionary<Point, char>();
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    var position = new Point(x, y);
                    var objectsAtPosition = _simulation.Map.At(position);

                    if (objectsAtPosition != null && objectsAtPosition.Count > 0)
                    {
                        currentMapState[position] = objectsAtPosition[0].Symbol;
                    }
                }
            }
            var currentMappable = _simulation.CurrentIMappable;
            var currentMove = _simulation.CurrentMoveName;

            return new SimulationTurnLog
            {
                Mappable = currentMappable.ToString(),
                Move = currentMove,
                Symbols = currentMapState
            };
        }
    }
}
