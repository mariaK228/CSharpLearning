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
    public partial class ChangePasswordForm : Form
    {
        private Account account;
        private bool aborted;
<<<<<<< HEAD
<<<<<<< HEAD
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        public ChangePasswordForm(Account acc)
        {
            account = acc;
            InitializeComponent();
        }
        public string GetPassword()
        {
            return Edit1.Text;
        }

        public string GetRepeatPassword()
        {
            return Edit2.Text;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            string pass = account.GetPassword();

            if (pass == Edit1.Text)
                MessageBox.Show("Новый пароль должен отличаться от предыдущего");
            else
            {
                GetPassword();
                GetRepeatPassword();

                Close();
            }
        }

        public bool CheckPassword()
        {
            bool UpLetter = false, DownLetter = false, Punctuation = false;
            for (int i = 0; i < Edit1.Text.Length; i++)
            {
                UpLetter |= Char.IsUpper(Edit1.Text[i]);
                DownLetter |= Char.IsLower(Edit1.Text[i]);

                Punctuation |= Char .IsPunctuation(Edit1.Text[i]);
            }
            return (UpLetter && DownLetter && Punctuation);
        }

        public bool IsOperationAborted()
        {
            return aborted;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            aborted = true;
            Close();
        }
    }
}
