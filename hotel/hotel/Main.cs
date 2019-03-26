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
            if (surname != "")
            {
                registration.AddGuest(surname, room, dish);

                registration.WriteGuests();
                UpdateListBox();
            }
        }

        private void choosePersonBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listguests = registration.GetPersons();

            int person = -1;
            for (int i = 0; i < listguests.Length; i++)
            {
                if (listguests[i].GetSurname() == choosePersonBox.Text && choosePersonBox.Text != "")
                {
                    person = i;
                    infoBox.Text = listguests[person].GetSurname() + ", комната: " + listguests[person].GetRoom() + ", блюдо: " + listguests[person].GetDish();
                    break;
                }
                else if (choosePersonBox.Text == "")
                    infoBox.Text = "";
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
            WriteInSortBy();
        }

        public void WriteInSortBy()
        {
            List<string> position = new List<string>() { "Фамилия", "Комната", "Блюдо" };

            for (int i = 0; i < position.Count; i++)
                sortBy.Items.Add(position[i]);
            sortBy.SelectedIndex = 0;
        }

        public GuestsStruct[] SortBySurname(GuestsStruct[] guest)
        {
            for (int i = 0; i < guest.Length; i++)
            {
                for (int j = i + 1; j < guest.Length; j++)
                {
                    if (guest[i].GetSurname()[0] > guest[j].GetSurname()[0])
                    {
                        GuestsStruct buf = guest[i];
                        guest[i] = guest[j];
                        guest[j] = buf;
                    }
                }
            }
            return guest.ToArray();
        }

        public GuestsStruct[] SortByRoom(GuestsStruct[] guest)
        {
            for (int i = 0; i < guest.Length; i++)
            {
                for (int j = i + 1; j < guest.Length; j++)
                {
                    if (guest[i].GetRoom()[0] > guest[j].GetRoom()[0])
                    {
                        GuestsStruct buf = guest[i];
                        guest[i] = guest[j];
                        guest[j] = buf;
                    }
                }
            }
            return guest.ToArray();
        }

        public GuestsStruct[] SortByDish(GuestsStruct[] guest)
        {
            for (int i = 0; i < guest.Length; i++)
            {
                for (int j = i + 1; j < guest.Length; j++)
                {
                    if (guest[i].GetDish()[0] > guest[j].GetDish()[0])
                    {
                        GuestsStruct buf = guest[i];
                        guest[i] = guest[j];
                        guest[j] = buf;
                    }
                }
            }
            return guest.ToArray();
        }
        private void sortButton_Click(object sender, EventArgs e)
        {
            var listguests = registration.GetPersons();

            if (sortBy.Text == "Фамилия")
                listguests = SortBySurname(listguests);
            
            else if (sortBy.Text == "Комната")
                listguests = SortByRoom(listguests);

            else
                listguests = SortByDish(listguests);
            resultSort.Clear();
            for (int i = 0; i < listguests.Length; i++)
            {
                resultSort.Text += listguests[i].GetSurname() + ", комната: " + listguests[i].GetRoom() + ", блюдо: " + listguests[i].GetDish() + Environment.NewLine;
            }
        }
    }
}
