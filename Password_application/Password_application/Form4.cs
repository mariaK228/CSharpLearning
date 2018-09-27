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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                if (UserName.Text == "")
                {
                    MessageBox.Show("Имя не может быть пустым!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // завершение обработки события
                    e.Cancel = true;
                }
                else
                {
                    // получение ссылки на объект учетной записи главной формы
                    Account Acc = ((Form1) (Application.OpenForms[0])).Acc;
                    // смещение к началу файла с учетными записями 
                    Acc.AccFile.Seek(0, SeekOrigin.Begin);
                    // чтение учетных записей из файла для проверки 
                    // уникальности введенного имени
                    while (Acc.AccFile.Position < Acc.AccFile.Length)
                    {
                        Acc.ReadAccount();
                        // если учетная запись с введенным именем уже существует,
                        // то прекращение чтения
                        if (UserName.Text == Encoding.Unicode.GetString(Acc.UserAcc.UserName,
                                0, Acc.UserAcc.UserName.Length).Substring(0,
                                Encoding.Unicode.GetString(Acc.UserAcc.UserName, 0,
                                    Acc.UserAcc.UserName.Length).IndexOf('\0')))
                            break;
                    }
                    // если учетная запись с введенным именем уже существует 
                    // (не достигнут конец файла)
                    if (UserName.Text == Encoding.Unicode.GetString(Acc.UserAcc.UserName,
                            0, Acc.UserAcc.UserName.Length).Substring(0, Encoding.Unicode.GetString(
                            Acc.UserAcc.UserName, 0,
                            Acc.UserAcc.UserName.Length).IndexOf('\0')))
                    {
                        // вывод сообщения об ошибке 
                        MessageBox.Show("Пользователь " + UserName.Text +
                                        "\nуже зарегистрирован!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // завершение обработки события
                        e.Cancel = true;
                    }
                    else
                    {
                        AddDefaultAccount(Acc, UserName.Text);
                    }
                }

        }

        private void AddDefaultAccount(Account Acc, string name)
        {
            AccountType backup = Acc.UserAcc;

            Acc.UserAcc.NameLength = name.Length;
            Acc.UserAcc.Block = false;
            Acc.UserAcc.Restrict = false;
            Acc.UserAcc.PassLen = 0;

            byte[] nameBytes = Encoding.Unicode.GetBytes(name);
            nameBytes.CopyTo(Acc.UserAcc.UserName, 0);
            byte[] passBytes = new byte[Account.MAXPASS * 2];
            passBytes.CopyTo(Acc.UserAcc.UserPass, 0);

            Acc.WriteAccount();

            Acc.UserAcc = backup;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
