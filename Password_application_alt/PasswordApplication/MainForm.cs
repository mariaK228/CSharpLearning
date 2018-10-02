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

using System.Security.Cryptography;



namespace PasswordApplication
{
    public partial class MainForm : Form
    {

        private const string RegFileName = "accounts.db";

        private AccountRegistry _reg;

        private Random _rnd;

        private Account[] accMass;

        private Account currentUser;

        public MainForm()
        {
            InitializeComponent();

            _rnd = new Random();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            EncryptionForm encryptionForm = new EncryptionForm();
            encryptionForm.ShowDialog();
            var password = encryptionForm.GetPassword();

            try
            {
                _reg = new AccountRegistry(password);

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
            catch (InvalidDecryptionException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (CryptographicException ex)
            {
                MessageBox.Show("Ошибка расшифровывания.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обработки расшифрованных данных. Возможно, неверный ключ", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void Login()
        {
            int countTries = 0;
            bool ok = false;

            do
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
                        ok = true;
                        currentUsernameLabel.Text = "Вошел как: " + username;
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
                countTries++;
            } while (ok == false && countTries < 3);
            if (!ok)
            {
                MessageBox.Show("Слишком много попыток");

                Application.Exit();
            }
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            Login();
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
            Login();
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

            bool restr = currentUser.HasPasswordRestrictions();
            string pass1;
            string pass2;
            bool check = false;
            int count = 0;
            bool wasCanceled = false;
            do
            {
                count++;
                if (count > 1)
                    if (check == false)
                        MessageBox.Show(
                            "Пароль не соответствует требованиям - заглавные буквы, строчные буквы, знаки препинания");
                    else
                        MessageBox.Show("Пароли не совпадают");
                ChangePasswordForm Change = new ChangePasswordForm(currentUser);
                Change.ShowDialog();
                check = Change.CheckPassword();
                pass1 = Change.GetPassword();
                pass2 = Change.GetRepeatPassword();

                wasCanceled = Change.IsOperationAborted();

            } while ((pass1 != pass2 || !check) && !wasCanceled);

            if (!wasCanceled)
            {
                _reg.ChangePassword(currentUser.GetUsername(), pass1);
                FileStream File = new FileStream(RegFileName, FileMode.Open);
                _reg.WriteAccounts(File);
                File.Close();
            }
        }

        private void allUsersItem_Click(object sender, EventArgs e)
        {
            ListOfUsersForm All = new ListOfUsersForm(_reg);
            All.ShowDialog();
            bool Ban = All.GetBan();
            bool Restrictions = All.GetRestrictions();

            _reg.SetBanState(All.GetCurrentName(), Ban);
            _reg.SetPasswordRestrictions(All.GetCurrentName(), Restrictions);

            accMass = _reg.GetAccounts();

            FileStream File = new FileStream(RegFileName, FileMode.Open);
            _reg.WriteAccounts(File);
            File.Close();
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxForm about = new AboutBoxForm();
            about.ShowDialog();
        }

    }

}

