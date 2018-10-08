using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordApplication.AccountManagement;

namespace PasswordApplication
{
    public partial class ListOfUsersForm : Form
    {
<<<<<<< HEAD
        private AccountRegistry account;
        private Account[] accMass;
        private int p = 0; 
=======

        private AccountRegistry account;
        private Account[] accMass;
        private int p = 0; 

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        public ListOfUsersForm(AccountRegistry acc)
        {
            InitializeComponent();
            account = acc;
<<<<<<< HEAD
            accMass = account.GetAccounts();

            UpdateData();
=======

            accMass = account.GetAccounts();

            UpdateData();

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        }

        public bool GetBan()
        {
<<<<<<< HEAD
            if (checkBoxBan.Checked)
=======

            if (checkBoxBan.Checked)

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
                return true;

            else
                return false;
        }

        public bool GetRestrictions()
        {
<<<<<<< HEAD
            if (checkBoxRestr.Checked)
=======

            if (checkBoxRestr.Checked)

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
                return true;

            else
                return false;
        }

<<<<<<< HEAD
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        private void Next_Click(object sender, EventArgs e)
        {
            SaveData();
            p++;
            if (p >= accMass.Length)
                p = 0;
            UserName.Text = accMass[p].GetUsername();
            UpdateData();

        }
        private void SaveData()
        {
            account.SetBanState(UserName.Text, GetBan());
            account.SetPasswordRestrictions(UserName.Text, GetRestrictions());
        }
        private void ListOfUsersForm_Load(object sender, EventArgs e)
        {
            UserName.Text = accMass[0].GetUsername();
        }

        public string GetCurrentName()
        {
            return UserName.Text;
        }

        private void UpdateData()
        {
            checkBoxBan.Checked = accMass[p].IsBanned();
            checkBoxRestr.Checked = accMass[p].HasPasswordRestrictions();
        }
<<<<<<< HEAD
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
    }
}
