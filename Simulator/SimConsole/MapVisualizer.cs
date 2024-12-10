using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;
using System.Text;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.Clear();
        var separator = new string(Box.Horizontal, _map.SizeX * 3 + 1);

        Console.Write(Box.TopLeft);
        Console.Write(new string(Box.TopMid, _map.SizeX).Replace(Box.TopMid.ToString(), $"{Box.Horizontal}{Box.TopMid}{Box.Horizontal}"));
        Console.WriteLine(Box.TopRight);

        for (int y = 0; y < _map.SizeY; y++)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < _map.SizeX; x++)
            {
                var creatures = _map.At(x, y);
                string content;

                if (creatures == null || creatures.Count == 0)
                {
                    content = "   ";
                }
                else if (creatures.Count == 1)
                {
                    var creature = creatures[0];
                    content = creature switch
                    {
                        Orc orc => $" O{orc.Rage}",
                        Elf elf => $" E{elf.Agility}",
                        _ => " ???"                 
                    };
                }
                else
                {
                    content = " XX";
                }

                Console.Write(content.PadRight(3));
                Console.Write(Box.Vertical);
            }

            Console.WriteLine();

            if (y < _map.SizeY - 1)
            {
                Console.Write(Box.MidLeft);
                Console.Write(new string(Box.Cross, _map.SizeX).Replace(Box.Cross.ToString(), $"{Box.Horizontal}{Box.Cross}{Box.Horizontal}"));
                Console.WriteLine(Box.MidRight);
            }
            else
            {
                Console.Write(Box.BottomLeft);
                Console.Write(new string(Box.BottomMid, _map.SizeX).Replace(Box.BottomMid.ToString(), $"{Box.Horizontal}{Box.BottomMid}{Box.Horizontal}"));
                Console.WriteLine(Box.BottomRight);
            }
        }
    }
}
