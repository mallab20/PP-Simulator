using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Elf : Creature
    {
        private int _agility;
        private int _singCount;

        public int Agility
        {
            get => _agility;
            private set => _agility = Math.Clamp(value, 0, 10);
        }

        public Elf(string name = "Unknown Elf", int level = 1, int agility = 1) : base(name, level)
        {
            Agility = agility;
        }

        public Elf() : base() { }

        public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");

        public void Sing()
        {
            Console.WriteLine($"{Name} is singing.");
            _singCount++;
            if (_singCount % 3 == 0)
            {
                Agility++;
                Console.WriteLine($"{Name}'s agility increased to {Agility}.");
            }
        }

        public override int Power => Level * 8 + Agility * 2;
    }
}
