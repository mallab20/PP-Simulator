using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Orc : Creature
    {
        private int _rage;
        private int _huntCount;

        public int Rage
        {
            get => _rage;
            private set => _rage = Math.Clamp(value, 0, 10);
        }

        public Orc(string name = "Unknown Orc", int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }

        public Orc() : base() { }

        public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");

        public void Hunt()
        {
            Console.WriteLine($"{Name} is hunting.");
            _huntCount++;
            if (_huntCount % 2 == 0)
            {
                Rage++;
                Console.WriteLine($"{Name}'s rage increased to {Rage}.");
            }
        }

        public override int Power => Level * 7 + Rage * 3;
    }
}
