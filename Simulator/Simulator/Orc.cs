using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Orc : Creature
    {
        private int rage;

        public int Rage
        {
            get => rage;
            private set => rage = Validator.Limiter(value, 0, 10);
        }

        private int huntCount = 0;

        public Orc(string name, int level = 1, int rage = 1) : base(name, level)
        {
            this.Rage = rage;
        }

        public Orc() : base() { }
        public override string Info => $"{Name} [{Level}][{Rage}]";
        public override int Power => 7 * Level + 3 * Rage;
        public string Greeting() => ($"Hi, I'm {Name}, my level is {Level}.");
        public void Hunt()
        {
            huntCount++;
            if (huntCount % 2 == 0)
            {
                Rage = Math.Min(Rage + 1, 10);
            }
        }
    }
}
