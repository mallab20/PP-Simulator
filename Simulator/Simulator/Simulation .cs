using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Simulation
{
    private int _currentTurn;
    private readonly List<Direction> _parsedMoves;

    public Map Map { get; }
    public List<IMappable> IMappables { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; }

    public IMappable CurrentIMappable => IMappables[_currentTurn % IMappables.Count];
    public string CurrentMoveName => _parsedMoves[_currentTurn % _parsedMoves.Count].ToString().ToLower();

    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        if (mappables == null || mappables.Count == 0)
            throw new ArgumentException("IMappables list cannot be empty.", nameof(mappables));

        if (positions == null || positions.Count != mappables.Count)
            throw new ArgumentException("Number of positions must match the number of mappables.", nameof(positions));

        if (string.IsNullOrEmpty(moves))
            throw new ArgumentException("Moves string cannot be empty.", nameof(moves));

        Map = map;
        IMappables = mappables;
        Positions = positions;
        Moves = moves;

        _parsedMoves = DirectionParser.Parse(moves);
        if (_parsedMoves.Count == 0)
            throw new ArgumentException("No valid moves found in the moves string.", nameof(moves));

        _currentTurn = 0;
        Finished = false;

        for (int i = 0; i < IMappables.Count; i++)
        {
            Map.Add(IMappables[i], Positions[i]);
        }
    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is already finished.");

        IMappable currentIMappable = CurrentIMappable;
        Point currentPosition = currentIMappable.Position;
        Direction currentDirection = _parsedMoves[_currentTurn % _parsedMoves.Count];

        Point nextPosition = Map.Next(currentPosition, currentDirection);

        if (!nextPosition.Equals(currentPosition))
        {
            Map.Remove(currentIMappable, currentPosition);
            Map.Add(currentIMappable, nextPosition);
        }

        _currentTurn++;
        if (_currentTurn >= _parsedMoves.Count * IMappables.Count)
        {
            Finished = true;
        }
    }
}
