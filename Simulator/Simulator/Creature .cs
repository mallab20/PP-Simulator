using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public abstract class Creature
    {
        private string name;
        private int level;

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
            this.Name = name;
            this.Level = level;
        }

        public Creature() : this("Unknown", 1) { }
        public abstract string Info { get; }
        public abstract int Power { get; }
        public abstract void SayHi();
        public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
        public void Upgrade()
        {
            Level = Math.Min(Level + 1, 10);
            Console.WriteLine($"{Name} has been upgraded to level {Level}.");
        }
    }
}
