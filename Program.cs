using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PacketAssembler
{
    class Program
    {
        static List<string> str_packets = new List<string>();
        static List<Packet> packets = new List<Packet>();

        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                String packetInput = sr.ReadToEnd();
                str_packets = packetInput.Split("\n").ToList();
            }

            for (int i = 0; i < str_packets.Count; i++)
            {
                Packet y = new Packet();
                y.SetID(Int32.Parse(str_packets[i].Substring(0, 4)));
                y.SetSubID(Int32.Parse(str_packets[i].Substring(8, 2)));
                y.SetContents(str_packets[i].Substring(16));
                packets.Add(y);
            }

            packets = new List<Packet>(packets.OrderBy(x => x.ID));

            bool sorting = true;
            List<int> IDToSort = new List<int>();
            for (int i = 0; i < packets.Count; i++)
            {
                if (IDToSort.Count == 0)
                    IDToSort.Add(packets[i].ID);
                else if (!IDToSort.Any(x => x == packets[i].ID))
                    IDToSort.Add(packets[i].ID);
            }
            
            int IDCountIndex = -1;
            List<Packet> sortedPackets = new List<Packet>();
            while (sorting)
            {
                IDCountIndex++;
                List<Packet> tempPacket = new List<Packet>(
                    packets.Where(x => x.ID == IDToSort[IDCountIndex]));
                tempPacket = new List<Packet>(tempPacket.OrderBy(x => x.subID));
                foreach (Packet x in tempPacket)
                    sortedPackets.Add(x);
                if (IDCountIndex + 1 == IDToSort.Count)
                    sorting = false;
            }

            string packetOutput = "";
            for (int i = 0; i < sortedPackets.Count; i++)
            {
                if (sortedPackets[i].subID < 10)
                    packetOutput += sortedPackets[i].ID + "    " + sortedPackets[i].subID + "    " + sortedPackets[i].contents + "\n";
                else
                    packetOutput += sortedPackets[i].ID + "    " + sortedPackets[i].subID + "   " + sortedPackets[i].contents + "\n";
            }
            Console.WriteLine(packetOutput);
        }
    }

    class Packet
    {
        public int ID { get; private set; }
        public int subID { get; private set; }
        public string contents { get; private set;}
        
        public void SetID(int _ID)
        {
            ID = _ID;
        }

        public void SetSubID(int _subID)
        {
            subID = _subID;
        }

        public void SetContents(string _contents)
        {
            contents = _contents;
        }
    }
}
