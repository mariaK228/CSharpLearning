using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel
{
    public struct GuestsStruct
    {
        private string _surname;
        private string _room;
        private string _dish;

        internal GuestsStruct(string surname, string room, string dish)
        {
            _surname = surname;
            _room = room;
            _dish = dish;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public string GetRoom()
        {
            return _room;
        }

        public string GetDish()
        {
            return _dish;
        }
    }
}
