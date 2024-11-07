using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public static class Validator
    {
        public static int Limiter(int value, int min, int max)
        {
            return Math.Clamp(value, min, max);
        }
        public static string Shortener(string value, int min, int max, char placeholder)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                value = new string(placeholder, min);
            }

            value = value.Trim();

            if (value.Length > max)
            {
                value = value.Substring(0, max).TrimEnd();
            }

            if (value.Length < min)
            {
                value = value.PadRight(min, placeholder);
            }

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }

            return value;
        }
    }
}
