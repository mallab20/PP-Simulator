using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    internal class LogVisualizer
    {
        private readonly SimulationHistory _log;

        public LogVisualizer(SimulationHistory log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Draw(int turnIndex)
        {
            if (turnIndex < 0 || turnIndex >= _log.TurnLogs.Count)
                throw new ArgumentOutOfRangeException(nameof(turnIndex), "Nieprawidłowy indeks tury.");

            Console.Clear();

            var turnLog = _log.TurnLogs[turnIndex];
            var symbols = turnLog.Symbols;

            var separator = new string(Box.Horizontal, _log.SizeX * 3 + 1);

            Console.Write(Box.TopLeft);
            Console.Write(new string(Box.TopMid, _log.SizeX).Replace(Box.TopMid.ToString(), $"{Box.Horizontal}{Box.TopMid}{Box.Horizontal}"));
            Console.WriteLine(Box.TopRight);

            for (int y = 0; y < _log.SizeY; y++)
            {
                Console.Write(Box.Vertical);
                for (int x = 0; x < _log.SizeX; x++)
                {
                    var point = new Point(x, y);
                    string content = symbols.ContainsKey(point) ? $" {symbols[point]} " : "   ";
                    Console.Write(content.PadRight(3));
                    Console.Write(Box.Vertical);
                }

                Console.WriteLine();

                if (y < _log.SizeY - 1)
                {
                    Console.Write(Box.MidLeft);
                    Console.Write(new string(Box.Cross, _log.SizeX).Replace(Box.Cross.ToString(), $"{Box.Horizontal}{Box.Cross}{Box.Horizontal}"));
                    Console.WriteLine(Box.MidRight);
                }
                else
                {
                    Console.Write(Box.BottomLeft);
                    Console.Write(new string(Box.BottomMid, _log.SizeX).Replace(Box.BottomMid.ToString(), $"{Box.Horizontal}{Box.BottomMid}{Box.Horizontal}"));
                    Console.WriteLine(Box.BottomRight);
                }
            }

            Console.WriteLine($"\nTurn: {turnIndex}");
            Console.WriteLine($"Moved Object: {turnLog.Mappable}");
            Console.WriteLine($"Move: {turnLog.Move}");
        }
    }
}
