using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Simulator
{
    public abstract class Creature : IMappable
    {
        public Map? Map { get; set; }
        public Point Position { get; set; }

        public void InitMapAndPosition(Map map, Point position)
        {
            Map = map;
            Position = position;
        }

        private string name;
        private int level;
        public string Greeting;

        public string Name
        {
            get => name;
            set => name = Validator.Shortener(value, 3, 25, '#');
        }

        public int Level
        {
            get => level;
            set => level = Validator.Limiter(value, 1, 10);
        }

        public Creature(string? name = "Unknown", int level = 1)
        {
            Name = name;
            Level = level;
        }
        public abstract string Info { get; }
        public abstract int Power { get; }

        public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

        public string[] Go(Direction[] directions)
        {
            var result = new string[directions.Length];

            for (int i = 0; i < directions.Length; i++)
            {
                result[i] = Go(directions[i]);
            }
            return result;
        }
    }
}
