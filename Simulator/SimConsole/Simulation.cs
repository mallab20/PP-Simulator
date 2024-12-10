using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using Simulator;

public class Simulation
{
    public Map Map { get; }
    private readonly List<Creature> _creatures;
    private readonly string _moves;

    public Simulation(Map map, List<Creature> creatures, List<Point> startingPositions, string moves)
    {
        Map = map;
        _creatures = creatures;
        _moves = moves;

        for (int i = 0; i < _creatures.Count; i++)
        {
            var creature = _creatures[i];
            var position = startingPositions[i];
            Map.Add(creature, position);
        }
    }

    public void Step(int stepIndex)
    {
        if (stepIndex < 0 || stepIndex >= _moves.Length) return;

        for (int i = 0; i < _creatures.Count; i++)
        {
            var direction = _moves[stepIndex] switch
            {
                'u' => Direction.Up,
                'd' => Direction.Down,
                'l' => Direction.Left,
                'r' => Direction.Right,
                _ => throw new ArgumentException($"Invalid move: {_moves[stepIndex]}")
            };

            var creature = _creatures[i];
            var currentPosition = creature.Position;
            var nextPosition = Map.Next(currentPosition, direction);

            Map.Remove(creature, currentPosition);
            Map.Add(creature, nextPosition);
        }
    }
}
