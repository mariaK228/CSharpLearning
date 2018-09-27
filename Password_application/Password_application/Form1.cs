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

namespace Password_application
{
    public partial class Form1 : Form
    {
        Form2 Enter;
        Form3 List;
        Form4 Add;
        Form5 ChangePass;

        public Account Acc; // учетная запись пользователя 

        static int EnterCount; // счетчик попыток входа в программу 


        public Form1()
        {
            InitializeComponent();

            // создание объектов форм и учетной записи 
            Enter = new Form2();
            List = new Form3();
            Add = new Form4();
            ChangePass = new Form5();

            Acc = new Account();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // проверка существования файла с учетными записями 
            if (!File.Exists(Account.SECFILE))
            {
                Acc.AccFile = new FileStream(Account.SECFILE, FileMode.Create);

                // подготовка учетной записи админа 
                Encoding.Unicode.GetBytes("ADMIN").CopyTo(Acc.UserAcc.UserName, 0);
                Encoding.Unicode.GetBytes("").CopyTo(Acc.UserAcc.UserPass, 0);
                Acc.UserAcc.PassLen = 0;
                Acc.UserAcc.Block = false;
                Acc.UserAcc.Restrict = true;
                Acc.UserAcc.NameLength = "ADMIN".Length;

                Acc.WriteAccount();
                Acc.AccFile.Close();
                Acc.AccFile = null;
                EnterCount = 0;
            }
        }

        private void RequestSetPassword()
        {
            // очистка редакторов ввода пароля 

            ChangePass.Edit1.Clear();
            ChangePass.Edit2.Clear();

            // отображение формы для ввода (смены) пользователем пароля
            if (ChangePass.ShowDialog() == DialogResult.OK)
            {
                // смещение к началу текущей уч записи в файле
                Acc.AccFile.Seek((Acc.RecCount - 1) * Acc.AccLen, SeekOrigin.Begin);

                // добавление введенного пароля и его длины в учетную запись
                Acc.UserAcc.SetNewPassword(ChangePass.Edit1.Text);

                // запись в файл учетной записи с начальным паролем
                Acc.WriteAccount();
            }
        }

        private void LogIn()
        {
            // сравнение пароля из учетной записи и введенного пароля
            if (Enter.Password.Text == "" || Enter.Password.Text != Acc.UserAcc.GetPass())
                // если пароли не совпадают и число попыток превысило 2
                if (++EnterCount > 2)
                {
                    // скрытие кнопки «Вход» 
                    button1.Visible = false;
                    // генерация исключительной ситуации
                    throw new Exception("Вход в программу невозможен!");
                }
                // если пароли не совпадают и число попыток не превысило 2
                else
                    // генерация исключительной ситуации 
                    throw new Exception("Неверный пароль!");
            // если пароли совпадают, то продолжение работы
        }

        private void PressedOk()
        {
            // открытие файла для чтения и записи 
            // сброс номера уч записи 
            Acc.RecCount = 0;

            // чтение уч записей и сравнение имен с введенным пользователем именем 
            while (Acc.AccFile.Position < Acc.AccFile.Length)
            {
                Acc.ReadAccount(); // чтение очередной уч записи
                Acc.RecCount++; // чтение относительного номера учетной записи 
                // прекращение чтения файла, если обнаружено совпадение имен

                string accName = Acc.UserAcc.GetName();

                // совпадения не найдено (достигнут конец файла)

                if (Enter.Login.Text != accName)
                    throw new Exception("Вы не зарегистрированы!");

                if (Acc.UserAcc.PassLen == 0)
                {
                    RequestSetPassword();
                }
                // если пользователь уже имел пароль
                else
                {
                    LogIn();
                }

                // если учетная запись заблокирована администратором
                if (Acc.UserAcc.Block)
                    // генерация исключительной ситуации (пользователь заблокирован)
                    throw new Exception("Вы заблокированы!");
                // проверка полномочий пользователя
                // если пользователь является администратором
                if (Acc.UserAcc.GetName() == "ADMIN")
                {
                    // снятие блокировки с команд меню «Все пользователи» и 
                    // «Новый пользователь» 
                    All.Enabled = true;
                    New.Enabled = true;
                    // закрытие файла с учетными записями
                }
                // снятие блокировки с команды меню «Смена пароля» 
                Change.Enabled = true;
                // скрытие кнопки «Вход»
                button1.Visible = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Acc.AccFile = new FileStream(Account.SECFILE, FileMode.Open);

                Enter.Login.Clear();
                Enter.Password.Clear();
                // отображение формы для ввода логина и пароля 
                if (Enter.ShowDialog() == DialogResult.OK)
                {
                    PressedOk();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(Acc.AccFile != null)
                    Acc.AccFile.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // создание объекта для диалога О программе
            AboutBox1 ab = new AboutBox1();
            // выполнение диалога
            ab.ShowDialog();

        }

        private void Change_Click(object sender, EventArgs e)
        {
            // если программа в режиме администратора (команда «Все пользователи»
            // разблокирована)
            if (All.Enabled)
            {
                // открытие файла с учетными записями для чтения и записи
                Acc.AccFile = new FileStream(Account.SECFILE, FileMode.Open);
                // сброс номера текущей учетной записи
                Acc.RecCount = 0;
                // чтение учетной записи администратора (первой учетной записи)
                Acc.ReadAccount();
                Acc.RecCount++;
            }
            // отображение формы для смены пароля
            if (ChangePass.ShowDialog() == DialogResult.OK)
            {
                // смещение к началу текущей учетной записи в файле 
                Acc.AccFile.Seek((Acc.RecCount - 1) * Acc.AccLen, SeekOrigin.Begin);
                // помещение в учетную запись нового пароля и его длины
                Encoding.Unicode.GetBytes(ChangePass.Edit1.Text).CopyTo(Acc.UserAcc.UserPass, 0);
                Acc.UserAcc.PassLen = ChangePass.Edit1.Text.Length;
                // запись в файл учетной записи с новым паролем
                Acc.WriteAccount();
            }
            // если программа в режиме администратора, то закрытие файла
            if (All.Enabled)
                Acc.AccFile.Close();

        }

        private void New_Click(object sender, EventArgs e)
        {
            // открытие файла учетных записей
            Acc.AccFile = new FileStream(Account.SECFILE, FileMode.Open);
            // отображение формы для добавления пользователя
            if (Add.ShowDialog() == DialogResult.OK)
            {
                // смещение в конец файла
                Acc.AccFile.Seek(0, SeekOrigin.End);
                // сохранение в учетной записи введенного имени пользователя
                // (с очисткой предыдущего имени)
                Array.Clear(Acc.UserAcc.UserName, 0, Acc.UserAcc.UserName.Length);
                Encoding.Unicode.GetBytes(Add.UserName.Text).
                  CopyTo(Acc.UserAcc.UserName, 0);
                // подготовка других полей новой учетной запис
                Encoding.Unicode.GetBytes("").CopyTo(Acc.UserAcc.UserPass, 0);
                Acc.UserAcc.PassLen = 0;
                Acc.UserAcc.Block = false;
                Acc.UserAcc.Restrict = true;
                // запись в файл учетной записи нового пользователя
                Acc.WriteAccount();
            }
            // закрытие файла
            Acc.AccFile.Close();
            // очистка редактора для ввода следующего имени пользователя
            Add.UserName.Clear();

        }

        private void All_Click(object sender, EventArgs e)
        {
            // открытие файла с учетными записями для чтения и записи
            Acc.AccFile = new FileStream(Account.SECFILE, FileMode.Open);
            // сброс номера текущей учетной записи
            Acc.RecCount = 0;
            // чтение первой учетной записи
            Acc.ReadAccount();
            Acc.RecCount++;
            // отображение имени учетной записи
            List.UserName.Text = Encoding.Unicode.GetString
           (Acc.UserAcc.UserName, 0, (int)Acc.UserAcc.UserName.Length);
            // отображение признака блокировки учетной запис
            List.checkBox1.Checked = Acc.UserAcc.Block;
            // отображение признака ограничения на пароль
            List.checkBox2.Checked = Acc.UserAcc.Restrict;
            // если следующей учетной записи нет, то блокирование кнопки «Следующий» в окне 
            //просмотра (редактирования) учетных записей
            if (Acc.AccFile.Length == Acc.RecCount * Acc.AccLen)
            {
                List.Next.Enabled = false;
                // смещение к началу первой учетной записи
                Acc.AccFile.Seek(0, SeekOrigin.Begin);
            }
            // снятие блокировки с кнопки Следующий
            else
                List.Next.Enabled = true;
            // отображение окна просмотра (редактирования) учетных записей
            List.ShowDialog();
            // закрытие файла
            Acc.AccFile.Close();

        }

    }
}
