using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    namespace Simulator
    {
        public class Animals
        {
            private string _description = "Unknown";
            private uint _size = 3;
            public string Description
            {
                get => _description;
                init => _description = Validator.Shortener(value, 3, 15, '#');
            }
            public uint Size
            {
                get => _size;
                set => _size = (uint)Validator.Limiter((int)value, 1, 100);
            }
            public void Info()
            {
                Console.WriteLine($"{Description} <{Size}>");
            }
        }
    }
}
