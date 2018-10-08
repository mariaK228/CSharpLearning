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
<<<<<<< HEAD
<<<<<<< HEAD
using System.Security.Cryptography;


=======
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da

using System.Security.Cryptography;



<<<<<<< HEAD
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
namespace PasswordApplication
{
    public partial class MainForm : Form
    {
<<<<<<< HEAD
<<<<<<< HEAD
        // имя файла
        private const string RegFileName = "accounts.db";
        // объект класса, в котором хранится массив аккаунтов 
        private AccountRegistry _reg;
        // генератор случайных чисел
        private Random _rnd;
        // структура, объекты которой хранят сведения об аккаунте 
        private Account currentUser;

        private Account[] accMass;

=======
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da

        private const string RegFileName = "accounts.db";

        private AccountRegistry _reg;

        private Random _rnd;

        private Account[] accMass;

        private Account currentUser;

<<<<<<< HEAD
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        public MainForm()
        {
            InitializeComponent();

            _rnd = new Random();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            // открытие формы с паролем 
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            EncryptionForm encryptionForm = new EncryptionForm();
            encryptionForm.ShowDialog();
            var password = encryptionForm.GetPassword();

            try
            {
                _reg = new AccountRegistry(password);

                FileStream stream;
<<<<<<< HEAD
<<<<<<< HEAD
                // если файл существует
                if (File.Exists(RegFileName))
                {
                    // открыть файл 
                    stream = new FileStream(RegFileName, FileMode.Open);
                    // считать аккаунты из файла
=======
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da

                if (File.Exists(RegFileName))
                {
                    stream = new FileStream(RegFileName, FileMode.Open);
<<<<<<< HEAD
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
                    _reg.ReadAccounts(stream);
                }
                else
                {
<<<<<<< HEAD
<<<<<<< HEAD
                    // иначе создать новый файл
                    stream = new FileStream(RegFileName, FileMode.CreateNew);
                    // добавить админа 
=======
                    stream = new FileStream(RegFileName, FileMode.CreateNew);
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
                    stream = new FileStream(RegFileName, FileMode.CreateNew);
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
                    _reg.CreateDefaulRegistry(stream);

                    _reg.WriteAccounts(stream);
                }

                stream.Close();
            }
<<<<<<< HEAD
<<<<<<< HEAD
              // ошибки, связанные с расшифрованием   
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            catch (InvalidDecryptionException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
<<<<<<< HEAD
<<<<<<< HEAD
                // не удалось расшифровать 
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            catch (CryptographicException ex)
            {
                MessageBox.Show("Ошибка расшифровывания.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            catch (Exception ex)
            {
<<<<<<< HEAD
<<<<<<< HEAD
                MessageBox.Show("Ошибка обработки расшифрованных данных. Возможно, неверный или пустой ключ", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
=======
                MessageBox.Show("Ошибка обработки расшифрованных данных. Возможно, неверный ключ", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
                MessageBox.Show("Ошибка обработки расшифрованных данных. Возможно, неверный ключ", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
                Application.Exit();
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD
        // метод для входа 
        private void Login()
        {
            // количество попыток
            int countTries = 0;
            bool ok = false;
            bool wasCanceled = false;

            do
            {
                // открытие формы для входа 
                LogInForm Enter = new LogInForm();
                string username, password;
                bool ban;
                Enter.ShowDialog();
                // получание логина и пароля из этой формы 
                username = Enter.GetUserName();
                password = Enter.GetPassword();
                
                try
                {
                    // поиск аккаунта в файле
                    Account account = _reg.FindAccount(username);
                    // получение правильного пароля 
                    string checkpass = account.GetPassword();
                    ban = account.IsBanned();
                    // проверка правильности пароля 
                    if (checkpass == password)
                    {
                        ok = true;
                        // вывод пользователя в строку состояния 
                        currentUsernameLabel.Text = "Вошел как: " + username;
                        currentUser = account;
                        // администраторские права доступа 
                        if (username == "ADMIN")
                            UnblockAdminFunctions();
                            // в случае бана уч записи 
                        else if (username != "ADMIN" && ban)
                        {
                            MessageBox.Show("Ваша учетная запись заблокирована");
                            BanFunctions();
                            Enter.Close();
                        }
                            // если ввод был отменен 
                        else if (username.Length == 0)
                        {
                            NoUser();
                        }
                            // права доступа простого пользователя 
                        else
                            UnblockUserFunctions();
                    }
                    // если пароль неверный 
=======
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
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
<<<<<<< HEAD
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
                    else
                    {
                        MessageBox.Show("Пароль неверный");
                    }
                }
<<<<<<< HEAD
<<<<<<< HEAD
                    
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
<<<<<<< HEAD
<<<<<<< HEAD
                // счет попыток входа 
                countTries++;
                // если количество попыток больше 3 
                wasCanceled = Enter.IsOperationAborted();
            } while (ok == false && countTries < 3 && !wasCanceled);
            if (!ok)
            {
                MessageBox.Show("Слишком много попыток");
                // закрытие приложения 
                Application.Exit();
            }
        }

        private void ChangePassw()
        {
            // имеет ли этот пользователь ограничения на пароль 
            bool restr = currentUser.HasPasswordRestrictions();
            // пароль и подтверждение 
            string pass1;
            string pass2;           
            bool check = false;
            int count = 0;
            bool wasCanceled = false;
            ChangePasswordForm Change = new ChangePasswordForm(currentUser);
            do
            {
                count++;
                
                if (count > 1)
                    // проверка на соответствие требованиям 
                    if (check == false)
                        MessageBox.Show("Пароль не соответствует требованиям - заглавные буквы, строчные буквы, знаки препинания");
                    else
                        MessageBox.Show("Пароли не совпадают");
                
                Change.ShowDialog();
                // метод проверки на соответствие ограничениям 
                check = Change.CheckPassword();
                pass1 = Change.GetPassword();
                pass2 = Change.GetRepeatPassword();

                wasCanceled = Change.IsOperationAborted();
                if (wasCanceled)
                    logInButton.Enabled = true;
            } 
            while ((pass1 != pass2 || !check) && !wasCanceled); // пока пароли не совпадут и не будут соответствовать ограничениям 

            if (!wasCanceled)
            {
                _reg.ChangePassword(currentUser.GetUsername(), pass1);
                FileStream File = new FileStream(RegFileName, FileMode.Open);
                _reg.WriteAccounts(File);
                File.Close();
            }
                logInButton.Enabled = true;
        }

        // кнопка входа 
        private void logInButton_Click(object sender, EventArgs e)
        {
            Login();
            if (currentUser.GetPassword() == "" && currentUser.GetUsername().Length != 0)
                ChangePassw();
            
        }
        // права админа 
=======
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
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

<<<<<<< HEAD
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        private void UnblockAdminFunctions()
        {
            changeUserItem.Enabled = true;
            allUsersItem.Enabled = true;
            changePasswordItem.Enabled = true;
            addUserItem.Enabled = true;
            logInButton.Enabled = false;
        }
<<<<<<< HEAD
<<<<<<< HEAD
        // права пользователя 
        private void UnblockUserFunctions()
        {
            changeUserItem.Enabled = true;
            allUsersItem.Enabled = false;
            addUserItem.Enabled = false;
            changePasswordItem.Enabled = true;
            logInButton.Enabled = false;
        }
        // бан 
        private void BanFunctions()
        {
            changeUserItem.Enabled = true;
            allUsersItem.Enabled = false;
            addUserItem.Enabled = false;
            changePasswordItem.Enabled = false;
            logInButton.Enabled = false;
        }

        private void NoUser()
        {
            changeUserItem.Enabled = false;
            allUsersItem.Enabled = false;
            changePasswordItem.Enabled = false;
            addUserItem.Enabled = false;
            logInButton.Enabled = false;
            logInButton.Enabled = true;
        }

        // смена пользователя 
        private void changeUserItem_Click(object sender, EventArgs e)
        {
            Login();

            if (currentUser.GetPassword() == "")
                ChangePassw(); 
        }

        // добавить пользователя 
        private void addUserItem_Click(object sender, EventArgs e)
        {
            // открыть форму добалвения пользователя 
           
            bool unique = false;
            bool ok = false;
            bool wasCanceled = false;
            
            do
            {
                NewUserForm New = new NewUserForm();   
                New.ShowDialog();
                // получение нового логина из формы 
                string username = New.GetUserName();
                // передача его в метод добаления 
                unique = _reg.IsUnique(username);
                wasCanceled = New.IsOperationAborted();
                if (unique)
                {
                    ok = true;
                    _reg.AddAccount(username);
                }
                else if (!unique && username == "" && !wasCanceled)
                {
                    MessageBox.Show("Поле логина пустое");
                }
                else if (wasCanceled)
                    New.Close();
                else
                    MessageBox.Show("Имя должно быть уникальным");
                
            }
            while (!ok && !wasCanceled);
            // запись в файл 
            if (!wasCanceled)
            {
=======
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da

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
<<<<<<< HEAD
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
                FileStream File = new FileStream(RegFileName, FileMode.Open);
                _reg.WriteAccounts(File);
                File.Close();
            }
        }
<<<<<<< HEAD
<<<<<<< HEAD
        // смена пароля 
        private void changePasswordItem_Click(object sender, EventArgs e)
        {
            ChangePassw();
        }

        // форма просмотра всех пользователей 
        private void allUsersItem_Click(object sender, EventArgs e)
        {
            // вызов формы 
            ListOfUsersForm All = new ListOfUsersForm(_reg);
            All.ShowDialog();
            // получение значения чекбокса бана  
            bool Ban = All.GetBan();
            // и ограничения на пароль 
            bool Restrictions = All.GetRestrictions();
            // добавление новых сведений в аккаунт 
=======
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da

        private void allUsersItem_Click(object sender, EventArgs e)
        {
            ListOfUsersForm All = new ListOfUsersForm(_reg);
            All.ShowDialog();
            bool Ban = All.GetBan();
            bool Restrictions = All.GetRestrictions();

<<<<<<< HEAD
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            _reg.SetBanState(All.GetCurrentName(), Ban);
            _reg.SetPasswordRestrictions(All.GetCurrentName(), Restrictions);

            accMass = _reg.GetAccounts();
<<<<<<< HEAD
<<<<<<< HEAD
            // запись в файл 
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
            FileStream File = new FileStream(RegFileName, FileMode.Open);
            _reg.WriteAccounts(File);
            File.Close();
        }
<<<<<<< HEAD
<<<<<<< HEAD
        // форма О программе 
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxForm about = new AboutBoxForm();
            about.ShowDialog();
        }
<<<<<<< HEAD
<<<<<<< HEAD
        // Кнопка выход 
        private void quitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da

    }

}

<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
