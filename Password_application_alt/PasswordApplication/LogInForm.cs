﻿using System;
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
    public partial class LogInForm : Form
<<<<<<< HEAD
    {
        private bool aborted;
=======
    { 
>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        public string GetUserName()
        {
            return Login.Text; 
        }

        public string GetPassword()
        {
            return Password.Text;
        }

        public LogInForm()
        {
            InitializeComponent();
        }

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

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (Login.Text == "")
                MessageBox.Show("Введен пустой логин");
=======
        private void CancelButton_Click(object sender, EventArgs e)
        {

>>>>>>> 850614c7c8ca3cd0ee83f73b738054ea578055da
        }
    }
}
