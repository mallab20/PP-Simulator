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
    public List<Creature> Creatures { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; }

    public Creature CurrentCreature => Creatures[_currentTurn % Creatures.Count];
    public string CurrentMoveName => _parsedMoves[_currentTurn % _parsedMoves.Count].ToString().ToLower();

    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty.", nameof(creatures));

        if (positions == null || positions.Count != creatures.Count)
            throw new ArgumentException("Number of positions must match the number of creatures.", nameof(positions));

        if (string.IsNullOrEmpty(moves))
            throw new ArgumentException("Moves string cannot be empty.", nameof(moves));

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        _parsedMoves = DirectionParser.Parse(moves);
        if (_parsedMoves.Count == 0)
            throw new ArgumentException("No valid moves found in the moves string.", nameof(moves));

        _currentTurn = 0;
        Finished = false;

        for (int i = 0; i < Creatures.Count; i++)
        {
            Map.Add(Creatures[i], Positions[i]);
        }
    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is already finished.");

        Creature currentCreature = CurrentCreature;
        Point currentPosition = currentCreature.Position;
        Direction currentDirection = _parsedMoves[_currentTurn % _parsedMoves.Count];

        Point nextPosition = Map.Next(currentPosition, currentDirection);

        if (!nextPosition.Equals(currentPosition))
        {
            Map.Remove(currentCreature, currentPosition);
            Map.Add(currentCreature, nextPosition);
        }

        _currentTurn++;
        if (_currentTurn >= _parsedMoves.Count * Creatures.Count)
        {
            Finished = true;
        }
    }
}
