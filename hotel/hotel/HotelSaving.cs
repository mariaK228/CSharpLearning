using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace hotel
{
    class HotelSaving
    {
        List<GuestsStruct> guest = new List<GuestsStruct>();
        
        public GuestsStruct AddGuest(string surname, string room, string dish)
        {
            GuestsStruct newguest = new GuestsStruct(surname, room, dish);
            guest.Add(newguest);

            return newguest;
        }

        public void EditGuest(string surname, string room, string dish)
        {
            for(int i = 0; i < guest.Count; i++)
            {
                if (surname == guest[i].GetSurname())
                {
                    GuestsStruct edit = new GuestsStruct(surname, room, dish);
                    guest[i] = edit;
                    break;
                }
            }
        }
        public GuestsStruct[] GetPersons()
        {
            return guest.ToArray();
        }

        public byte[] GetBytes(GuestsStruct guest)
        {
            byte[] bufSurname = Encoding.Default.GetBytes(guest.GetSurname());
            byte[] bufRoom = Encoding.Default.GetBytes(guest.GetRoom());
            byte[] bufDish = Encoding.Default.GetBytes(guest.GetDish());

            List<byte> result = new List<byte>();
            result.AddRange(bufSurname);
            result.Add(01);

            result.AddRange(bufRoom);
            result.Add(01);

            result.AddRange(bufDish);
            result.Add(01);

            return result.ToArray();

        }

        public GuestsStruct ReadNext(FileStream file)
        {
            string surname, room, dish;

            List<byte> buf = new List<byte>();

            ReadToSeparator(file, buf);

            surname = Encoding.Default.GetString(buf.ToArray());
            buf.Clear();

            ReadToSeparator(file, buf);

            room = Encoding.Default.GetString(buf.ToArray());
            buf.Clear();

            ReadToSeparator(file, buf);

            dish = Encoding.Default.GetString(buf.ToArray());
            buf.Clear();

            GuestsStruct g = new GuestsStruct(surname, room, dish);

            return g;
        }

        void ReadToSeparator(FileStream file, List<byte> buf)
        {
            while (true)
            {
                int b = file.ReadByte();
                if (b == -1)
                    break;
                if (b != 01)
                {
                    buf.Add((byte)b);
                }
                else
                    break;
            }
        }
        void SaveToFile (FileStream stream)
        {
            foreach (GuestsStruct g in guest)
            {
                byte[] mas = GetBytes(g);
                stream.Write(mas, 0, mas.Length);
            }
        }

        void ReadFile(FileStream stream)
        {
            guest.Clear();

            while((stream.Length - stream.Position) > 0)
            {
                guest.Add(ReadNext(stream));
            }
        }
        public void WriteGuests()
        {
            FileStream file = new FileStream ("guests.txt", FileMode.OpenOrCreate);

            SaveToFile(file);

            file.Close();

        }

        public void ReadGuests()
        {
            FileStream file = new FileStream("guests.txt", FileMode.OpenOrCreate);

            ReadFile(file);

            file.Close();

        }
    }
}
