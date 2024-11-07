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
            set { name = CheckString(value); }
        }

        public int Level
        {
            get { return level; }
            set { level = CheckInt(value); }
        }

        public Creature(string? name = "Unknown", int level = 1)
        {
            this.Name = name;
            this.Level = level;
        }

        public Creature() : this("Unknown", 1) { }

        private string CheckString(string inputName)
        {
            if (string.IsNullOrWhiteSpace(inputName))
                inputName = "Unknown";

            inputName = inputName.Trim();
            if (inputName.Length > 25)
                inputName = inputName.Substring(0, 25).TrimEnd();

            if (inputName.Length < 3)
                inputName = inputName.PadRight(3, '#');

            if (char.IsLower(inputName[0]))
                inputName = char.ToUpper(inputName[0]) + inputName.Substring(1);

            return inputName;
        }

        private int CheckInt(int inputValue)
        {
            return Math.Clamp(inputValue, 1, 10);
        }

        public string Info => $"{CheckString(Name)}, Level {CheckInt(Level)}";

        public abstract void SayHi();

        public abstract int Power { get; }

        public void Upgrade()
        {
            Level = Math.Min(Level + 1, 10);
            Console.WriteLine($"{Name} has been upgraded to level {Level}.");
        }
    }
}
