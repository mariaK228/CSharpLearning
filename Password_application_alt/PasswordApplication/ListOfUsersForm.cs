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

        private AccountRegistry account;
        private Account[] accMass;
        private int p = 0; 

        public ListOfUsersForm(AccountRegistry acc)
        {
            InitializeComponent();
            account = acc;

            accMass = account.GetAccounts();

            UpdateData();

        }

        public bool GetBan()
        {

            if (checkBoxBan.Checked)

                return true;

            else
                return false;
        }

        public bool GetRestrictions()
        {

            if (checkBoxRestr.Checked)

                return true;

            else
                return false;
        }


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

    }
}
