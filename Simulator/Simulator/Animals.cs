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

        public virtual string Info => $"{Validator.Shortener(Description, 3, 15, '#')} <{Size}>";

        public override string ToString()
        {
            return $"{this.GetType().Name.ToUpper()}: {Info}";
        }
    }
}