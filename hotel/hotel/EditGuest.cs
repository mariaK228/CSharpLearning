using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel
{
     partial class EditGuest : Form
    {
        List<string> rooms = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        List<string> dishes = new List<string> { "Яичница", "Овсяная каша", "Манная каша", "Запеканка", "Хлопья с молоком" };
        HotelSaving hotel;
        public EditGuest(HotelSaving hoteldata)
        {
            InitializeComponent();

            hotel = hoteldata;
        }

        private void EditGuest_Load(object sender, EventArgs e)
        {
            WriteInDishes();
            WriteInRooms();
            WriteInPersons();
        }

        public void WriteInRooms()
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                roomBox.Items.Add(rooms[i]);
            }
        }

        public void WriteInDishes()
        {
            for (int i = 0; i < dishes.Count; i++)
            {
                dishBox.Items.Add(dishes[i]);
            }
        }

        public void WriteInPersons()
        {
            for (int i = 0; i < hotel.GetPersons().Length; i++)
            {
                surnameBox.Items.Add(hotel.GetPersons()[i].GetSurname());
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            hotel.EditGuest(surnameBox.Text, roomBox.Text, dishBox.Text);
            Close();
        }
    }
}
