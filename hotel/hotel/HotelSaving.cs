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
       List <GuestsStruct> guest = new List <GuestsStruct>();

       public GuestsStruct AddGuest (string surname, string room, string dish)
       {
           GuestsStruct newguest = new GuestsStruct(surname, room, dish);
           guest.Add(newguest);

           return newguest;
       }


        public GuestsStruct[] GetPersons()
        {
            return guest.ToArray();
        }
        public void WriteGuests(Stream stream)
       {
         
           
       }
    }
}
