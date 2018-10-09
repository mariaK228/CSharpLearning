using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordApplication
{
    public partial class EncryptionForm : Form
    {
        public EncryptionForm()
        {
            InitializeComponent();
        }

        public string GetPassword()
        {
            return passwordText.Text;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

<<<<<<< HEAD
<<<<<<< HEAD
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
=======
        private void ncelButton_Click(object sender, EventArgs e)
        {
            Close();
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
        private void ncelButton_Click(object sender, EventArgs e)
        {
            Close();
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        }
    }
}
