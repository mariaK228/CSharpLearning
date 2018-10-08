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
    public partial class NewUserForm : Form
    {
<<<<<<< HEAD
<<<<<<< HEAD
        private bool aborted;
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        public NewUserForm()
        {
            InitializeComponent();
        }
        public string GetUserName()
        {
            return UserName.Text;
        }
<<<<<<< HEAD
<<<<<<< HEAD

        public bool IsOperationAborted()
        {
            return aborted;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            aborted = true;
            Close();
        }

        private void NewUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           // aborted = true;
            if (e.CloseReason == CloseReason.UserClosing)
                aborted = true;
        }
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
=======
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
    }
}
