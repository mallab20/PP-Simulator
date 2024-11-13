using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Elf : Creature
    {
        private int agility;

        public int Agility
        {
            get => agility;
            private set => agility = Validator.Limiter(value, 0, 10);
        }

        private int singCount = 0;

        public Elf(string name, int level = 1, int agility = 1) : base(name, level)
        {
            this.Agility = agility;
        }

        public Elf() : base() { }
        public override string Info => $"{Name} [{Level}][{Agility}]";
        public override int Power => 8 * Level + 2 * Agility;
        public string Greeting() => ($"Hi, I'm {Name}, my level is {Level}.");
        public void Sing()
        {
            singCount++;
            if (singCount % 3 == 0)
            {
                Agility = Math.Min(Agility + 1, 10);
            }
        }
    }
}
