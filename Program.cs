using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PacketAssembler
{
    class Program
    {
        static List<string> packets = new List<string>();

        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                String packetInput = sr.ReadToEnd();
                packets = packetInput.Split("\n").ToList();
            }

            packets = new List<string>(packets.OrderBy(x => Int32.Parse(x.Substring(0, 4))));
            
            string packetOutput = "";
            for (int i = 0; i < packets.Count; i++)
            {
                packetOutput += packets[i] + "\n";
            }
            Console.WriteLine(packetOutput);
        }
    }
}
