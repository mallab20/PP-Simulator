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
            get { return name; }
            set { name = Validator.Shortener(value, 3, 25, '#'); }
        }

        public int Level
        {
            get { return level; }
            set { level = Validator.Limiter(value, 1, 10); }
        }

        public Creature(string? name = "Unknown", int level = 1)
        {
            this.Name = name;
            this.Level = level;
        }

        public Creature() : this("Unknown", 1) { }

        public string Info => $"{Name}, Level {Level}";

        public abstract void SayHi();

        public abstract int Power { get; }

        public void Upgrade()
        {
            Level = Validator.Limiter(Level + 1, 1, 10);
            Console.WriteLine($"{Name} has been upgraded to level {Level}.");
        }
    }

}
