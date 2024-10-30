using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    internal class Creature
    {
        private string name;
        private int level;

        public Creature(string name, int level = 1)
        {
            this.name = name;
            this.level = level;
        }
        public Creature()
        {
        }
        public string Info()
        {
            return $"{name}, Level {level}";
        }

        public void SayHi()
        {
            Console.WriteLine($"Hi, I'm {name}, my level is {level}.");
        }

    }
}
