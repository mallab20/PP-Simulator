using System;
using System.Collections.Generic;
using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new SmallTorusMap(8, 6);

            var elf = new Creature("Elf", new Point(0, 0));
            var ork = new Creature("Ork", new Point(7, 5));
            var kroliki = CreateCreatures("Królik", 3, map, new List<Point> { new Point(1, 1), new Point(2, 2), new Point(3, 3) });
            var orly = CreateCreatures("Orzeł", 2, map, new List<Point> { new Point(5, 0), new Point(6, 1) });
            var strusie = CreateCreatures("Struś", 2, map, new List<Point> { new Point(7, 3), new Point(0, 4) });

            map.Add(elf, elf.Position);
            map.Add(ork, ork.Position);

            foreach (var krolik in kroliki) map.Add(krolik, krolik.Position);
            foreach (var orzel in orly) map.Add(orzel, orzel.Position);
            foreach (var strus in strusie) map.Add(strus, strus.Position);

            var movements = new List<(Creature, Direction)>
            {
                (elf, Direction.Right), (elf, Direction.Down), (elf, Direction.Left), (elf, Direction.Up),
                (ork, Direction.Up), (ork, Direction.Left), (ork, Direction.Down), (ork, Direction.Right),
                (kroliki[0], Direction.Right), (kroliki[1], Direction.Up), (kroliki[2], Direction.Left),
                (orly[0], Direction.Up), (orly[1], Direction.Right),
                (strusie[0], Direction.Left), (strusie[1], Direction.Down),
                (elf, Direction.Up), (elf, Direction.Left), (ork, Direction.Down), (ork, Direction.Right)
            };

            foreach (var (creature, direction) in movements)
            {
                var currentPos = creature.Position;
                var newPos = map.Next(currentPos, direction);
                Console.WriteLine($"{creature.Name} idzie z {currentPos} w kierunku {direction} na {newPos}");
                map.Remove(creature, currentPos);
                map.Add(creature, newPos);
            }

            Console.WriteLine("Symulacja zakończona.");
        }

        static List<Creature> CreateCreatures(string name, int count, Map map, List<Point> positions)
        {
            var creatures = new List<Creature>();
            for (int i = 0; i < count; i++)
            {
                var creature = new Creature(name + " " + (i + 1), positions[i]);
                creatures.Add(creature);
            }
            return creatures;
        }
    }
    public class Creature : IMappable
    {
        public string Name { get; }
        public Point Position { get; set; }
        public Map? Map { get; set; }

        public Creature(string name, Point position)
        {
            Name = name;
            Position = position;
        }

        public void InitMapAndPosition(Map map, Point position)
        {
            Map = map;
            Position = position;
        }
        public override string ToString() => $"{Name} at {Position}";
    }
}
