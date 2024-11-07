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
            private set => _rage = Validator.Limiter(value, 0, 10);
        }
        public override int Power => Level * 7 + Rage * 3;
        public Orc() : base("Unknown Orc", 1)
        {
            Rage = 1;
        }
        public Orc(string name, int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }
        public override void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name} the Orc, at level {Level}.");
        }
        public void Hunt()
        {
            _huntCount++;
            Console.WriteLine($"{Name} is hunting.");

            if (_huntCount % 2 == 0)
            {
                Rage = Validator.Limiter(Rage + 1, 0, 10);
                Console.WriteLine($"{Name}'s rage increased to {Rage}.");
            }
        }
    }
}
