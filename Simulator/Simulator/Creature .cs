using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public class Creature
    {
        private string name;
        private int level;


        public string Name
        {
            get { return name; }
            set
            {
                name = CheckString(value);
            }
        }

        public int Level
        {
            get { return level; }
            set
            {
                level = CheckInt(value);

            }
        }

        public Creature(string? name = "Unknown", int level = 1)
        {

            this.Name = name;
            this.Level = level;
        }

        public Creature()
        {
            this.Name = "Unknown";
            this.Level = 1;
        }

        private string CheckString(string inputName)
        {
            if (string.IsNullOrWhiteSpace(inputName))
            {
                inputName = "Unknown";
            }

            inputName = inputName.Trim();

            if (inputName.Length > 25)
            {
                inputName = inputName.Substring(0, 25).TrimEnd();
            }

            if (inputName.Length < 3)
            {
                inputName = inputName.PadRight(3, '#');
            }

            if (char.IsLower(inputName[0]))
            {
                inputName = char.ToUpper(inputName[0]) +
                inputName.Substring(1);
            }

            return inputName;
        }

        private int CheckInt(int inputValue)
        {
            if (inputValue < 1)
            {
                inputValue = 1;
            }

            if (inputValue > 10)
            {
                inputValue = 10;
            }

            return inputValue;
        }

        public string Info
        {

            get
            {


                string outputValue = string.Empty;

                outputValue = CheckString(this.Name);

                int outputInt = 0;

                outputInt = CheckInt(this.Level);

                return $"{outputValue}, Level {outputInt}";

            }

        }

        public void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
        }

        public int Upgrade(int localLevel)
        {
            localLevel = localLevel + 1;

            if (localLevel > 10)
            {
                localLevel = 10;
            }

            return localLevel;
        }
        public void Upgrade()
        {
            Level = Level + 1;

            if (Level > 10)
            {
                Level = 10;
            }

        }
        public void Go(Direction direction)
        {
            string directionName = direction.ToString().ToLower();
            Console.WriteLine($"{Name} goes {directionName}.");
        }
        public void Go(Direction[] directions)
        {
            foreach (Direction direction in directions)
            {
                Go(direction);
            }
        }
        public void Go(string directions)
        {
            Direction[] parsedDirections = DirectionParser.Parse(directions);
            Go(parsedDirections);
        }
    }
}
