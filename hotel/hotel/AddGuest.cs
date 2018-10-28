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
    public partial class AddGuest : Form
    {
        List<string> rooms = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        List<string> dishes = new List<string> { "Яичница", "Овсяная каша", "Манная каша", "Запеканка", "Хлопья с молоком" , "Пирог", "Салат", "Фрукты", "Кефир"}; 
        public AddGuest()
        {
            InitializeComponent();
        }

        public string GetSurname()
        {
            return surnameTextBox.Text;
        }

        public string GetRoom()
        {
            return roomBox.Text;
        }

        public string GetDish()
        {
            return dishBox.Text;
        }

        public void WriteInRooms()
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                roomBox.Items.Add(rooms[i]);
            }
            roomBox.SelectedIndex = 0;
        }

        public void WriteInDishes()
        {
            for (int i = 0; i < dishes.Count; i++)
            {
                dishBox.Items.Add(dishes[i]);
            }
            dishBox.SelectedIndex = 0;
        }

        private void AddGuest_Load(object sender, EventArgs e)
        {
            WriteInRooms();
            WriteInDishes(); 
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (surnameTextBox.Text != "")
                Close();
            else
                MessageBox.Show("Поле фамилии пустое");
        }
    }
}
