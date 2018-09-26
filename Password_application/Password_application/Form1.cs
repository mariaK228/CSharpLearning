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

                Acc.WriteAccount();
                Acc.AccFile.Close();
                Acc.AccFile = null; 
                EnterCount = 0; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // запрос и проверка имени уч записи и пароля 

            byte[] tmp; // временный буфер для паролей 
            try
            {
                Enter.Login.Clear();
                Enter.Password.Clear();
                // отображение формы для ввода логина и пароля 
                if (Enter.ShowDialog() == DialogResult.OK)
                {
                    if (Acc.AccFile != null) // если переменная (поток) не инициализирована
                        Acc.AccFile.Close();

                    // открытие файла для чтения и записи 
                    Acc.AccFile = new FileStream(Account.SECFILE, FileMode.Open);

                    // сброс номера уч записи 
                    Acc.RecCount = 0; 

                    // чтение уч записей и сравнение имен с введенным пользователем именем 
                    while (Acc.AccFile.Position < Acc.AccFile.Length)
                    {
                        Acc.ReadAccount(); // чтение очередной уч записи
                        Acc.RecCount++; // чтение относительного номера учетной записи 
                        // прекращение чтения файла, если обнаружено совпадение имен 
                        if (Enter.Login.Text == Encoding.Unicode.GetString
                            (Acc.UserAcc.UserName, 0, Enter.Login.Text.Length * 2))
                            break;

                        // совпадения не найдено (достигнут конец файла)
                        if (Enter.Login.Text != Encoding.Unicode.GetString
                           (Acc.UserAcc.UserName, 0, Enter.Login.Text.Length * 2))
                            // генерация исключительной ситуации (пользователь не зарегистрирован)
                            throw new Exception("Вы не зарегистрированы!");

                        else if (Acc.UserAcc.PassLen == 0)
                        {
                            // очистка редакторов ввода пароля 

                            ChangePass.Edit1.Clear();
                            ChangePass.Edit2.Clear();

                            // отображение формы для ввода (смены) пользователем пароля
                            if(ChangePass.ShowDialog() == DialogResult.OK)
                            {
                                // смещение к началу текущей уч записи в файле
                                Acc.AccFile.Seek((Acc.RecCount - 1) * Acc.AccLen, SeekOrigin.Begin);

                                // добавление введенного пароля и его длины в учетную запись
                                Encoding.Unicode.GetBytes(ChangePass.Edit1.Text).CopyTo(Acc.UserAcc.UserPass, 0);
                                Acc.UserAcc.PassLen = ChangePass.Edit1.Text.Length;



                            }
                        }

                    }
                }
            }
        }

    }
}
