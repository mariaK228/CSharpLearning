using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace hotel
{
    public partial class MainForm : Form
    {
        HotelSaving registration = new HotelSaving();
      //  GuestsStruct[] listguests;
        public MainForm()
        {
            InitializeComponent();
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            AddGuest addguest = new AddGuest();
            addguest.ShowDialog();

            string surname = addguest.GetSurname();
            string room = addguest.GetRoom();
            string dish = addguest.GetDish();

            registration.AddGuest(surname, room, dish);

            registration.WriteGuests();
            UpdateListBox();
        }

        private void choosePersonBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            var listguests = registration.GetPersons();

            int person = -1;
            for (int i = 0; i < listguests.Length; i++)
            {
                if (listguests[i].GetSurname() == choosePersonBox.Text)
                {
                    person = i;
                    infoBox.Text = listguests[person].GetSurname() + ", комната: " + listguests[person].GetRoom() + ", блюдо: " + listguests[person].GetDish();
                    break;
                }

                else
                    infoBox.Text = "Информация не найдена";
            }
            
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditGuest edit = new EditGuest(registration);
            edit.ShowDialog();

            registration.WriteGuests();
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            choosePersonBox.Items.Clear();
            var listguests = registration.GetPersons();

            for (int i = 0; i < listguests.Length; i++)
            {
                choosePersonBox.Items.Add(listguests[i].GetSurname());
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            registration.ReadGuests();
            UpdateListBox();
        }
    }
}
