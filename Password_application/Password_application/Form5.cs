using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_application
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private bool CheckPassword()
        {
            // 13.	Наличие строчных и прописных букв, а также знаков препинания.
            bool UpLetter = false,
            DownLetter = false,

            Punctuation = false;
            // проверка сложности введенной парольной фразы
            for (int i = 0; i < Edit1.Text.Length; i++)
            {
                // проверка очередного символа парольной фразы
                UpLetter |= Char.IsUpper(Edit1.Text[i]); // |= битовая операция ИЛИ 
                DownLetter |= Char.IsLower(Edit1.Text[i]);
                Punctuation |= Char.IsPunctuation(Edit1.Text[i]);
            }
            return (UpLetter && DownLetter && Punctuation);
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && Edit1.Text == "")
            {
                MessageBox.Show("Пароль не может быть пустым!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                // обработка события завершена
                e.Cancel = true;
            }
            else if (DialogResult == DialogResult.OK && Edit1.Text != Edit2.Text)
            {
                MessageBox.Show("Пароль и подтверждение не совпадают!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                // обработка события завершена
                e.Cancel = true;
            }
            else if (DialogResult == DialogResult.OK &&
            ((Form1)(Application.OpenForms[0])).Acc.UserAcc.Restrict &&
            !CheckPassword())
            {
                MessageBox.Show("Пароль не соответствует ограничениям!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                // обработка события завершена
                e.Cancel = true;

            }

        }
    }
}
