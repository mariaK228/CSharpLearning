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
        public AccountRegistry account;
        private Account[] accMass;
        public ListOfUsersForm(AccountRegistry acc)
        {
            InitializeComponent();
            account = acc;
        }

        public void SetUser(object sender, EventArgs e)
        {
            accMass = account.GetAccounts();
            for (int i = 0; i < accMass.Length; i++)
            {
                UserName.Text = accMass[i].GetUsername();
            }
        }

        public bool GetBan()
        {
            if (checkBox1.Checked)
                return true;

            else
                return false;
        }

        public bool GetRestrictions()
        {
            if (checkBox2.Checked)
                return true;

            else
                return false;
        }

    }
}
