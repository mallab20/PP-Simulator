using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public class Animals
    {

        private string _description = "Unknown";

        public required string Description { get; init; }
        public uint Size { get; set; } = 3;

        public void Info()
        {
            Console.WriteLine($"{Description} <{Size}>");
        }
        private string ValidateDescription(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                input = "Unknown";
            }

            input = input.Trim();

            if (input.Length > 15)
            {
                input = input.Substring(0, 15).TrimEnd();
            }

            if (input.Length < 3)
            {
                input = input.PadRight(3, '#');
            }

            if (char.IsLower(input[0]))
            {
                input = char.ToUpper(input[0]) + input.Substring(1);
            }

            return input;
        }
    }
}
