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
            private set => _agility = Validator.Limiter(value, 0, 10);
        }
        public override int Power => Level * 8 + Agility * 2;
        public Elf() : base("Unknown Elf", 1)
        {
            Agility = 1;
        }
        public Elf(string name, int level = 1, int agility = 1) : base(name, level)
        {
            Agility = agility;
        }
        public override void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name} the Elf, at level {Level}.");
        }
        public void Sing()
        {
            _singCount++;
            Console.WriteLine($"{Name} is singing.");

            if (_singCount % 3 == 0)
            {
                Agility = Validator.Limiter(Agility + 1, 0, 10);
                Console.WriteLine($"{Name}'s agility increased to {Agility}.");
            }
        }
    }
}
