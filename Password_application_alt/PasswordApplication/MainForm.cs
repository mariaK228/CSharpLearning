using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordApplication.AccountManagement;

namespace PasswordApplication
{
    public partial class MainForm : Form
    {

        private const string RegFileName = "accounts.db";

        private AccountRegistry _reg;

        private Random _rnd;

        private Account currentUser; 
        public MainForm()
        {
            InitializeComponent();

            _rnd = new Random();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _reg = new AccountRegistry();

            FileStream stream;

            if (File.Exists(RegFileName))
            {
                stream = new FileStream(RegFileName, FileMode.Open);
                _reg.ReadAccounts(stream);
            }
            else
            {
                stream = new FileStream(RegFileName, FileMode.CreateNew);
                _reg.CreateDefaulRegistry(stream);

                _reg.WriteAccounts(stream);
            }

            stream.Close();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            LogInForm Enter = new LogInForm();
            string username, password;
            Enter.ShowDialog();
            username = Enter.GetUserName();
            password = Enter.GetPassword();
            try
            {
                Account account = _reg.FindAccount(username);
                string checkpass = account.GetPassword();

                if (checkpass == password)
                {
                    currentUser = account;
                    if (username == "ADMIN")
                        UnblockAdminFunctions();

                    else
                        UnblockUserFunctions();
                }
                else
                {
                    MessageBox.Show("Пароль неверный");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UnblockAdminFunctions()
        {
            changeUserItem.Enabled = true;
            allUsersItem.Enabled = true;
            changePasswordItem.Enabled = true;
            addUserItem.Enabled = true;
            logInButton.Enabled = false;
        }

        private void UnblockUserFunctions()
        {
            changePasswordItem.Enabled = true;
            logInButton.Enabled = false;
        }

        private void changeUserItem_Click(object sender, EventArgs e)
        {
            LogInForm Enter = new LogInForm();
            string username, password;
            Enter.ShowDialog();
            username = Enter.GetUserName();
            password = Enter.GetPassword();
            try
            {
                Account account = _reg.FindAccount(username);
                string checkpass = account.GetPassword();

                if (checkpass == password)
                {
                    currentUser = account;
                    if (username == "ADMIN")
                        UnblockAdminFunctions();

                    else
                        UnblockUserFunctions();
                }
                else
                {
                    MessageBox.Show("Пароль неверный");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addUserItem_Click(object sender, EventArgs e)
        {          
            NewUserForm New = new NewUserForm();
            New.ShowDialog();
            string username = New.GetUserName();

            _reg.AddAccount(username);
            FileStream File = new FileStream(RegFileName, FileMode.Open);
            _reg.WriteAccounts(File);
            File.Close(); 
        }

        private void changePasswordItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm Change = new ChangePasswordForm(currentUser);
            Change.ShowDialog();

            string pass1 = Change.GetPassword();
            string pass2 = Change.GetRepeatPassword();
            bool restr = currentUser.HasPasswordRestrictions();
            if (pass1 == pass2)
            {
                if (restr)
                {
                    bool check = Change.CheckPassword();
                    if (check)
                        currentUser = _reg.ChangePassword(currentUser.GetUsername(), pass1);
                    else
                        Change.ShowDialog();
                }
                else
                    currentUser = _reg.ChangePassword(currentUser.GetUsername(), pass1);
            }
             FileStream File = new FileStream(RegFileName, FileMode.Open);
             _reg.WriteAccounts(File);
             File.Close(); 
        }

        private void allUsersItem_Click(object sender, EventArgs e)
        {
            ListOfUsersForm All = new ListOfUsersForm(_reg);
            All.ShowDialog();
            bool Ban = All.GetBan();
            bool Restrictions = All.GetRestrictions();
           currentUser = _reg.SetBanState(currentUser.GetUsername(), Ban);
           currentUser = _reg.SetPasswordRestrictions(currentUser.GetUsername(), Restrictions);
           FileStream File = new FileStream(RegFileName, FileMode.Open);
           _reg.WriteAccounts(File);
           File.Close(); 
        }
    }
}
