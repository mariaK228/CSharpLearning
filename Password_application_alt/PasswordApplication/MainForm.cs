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

namespace PasswordApplication
{
    public partial class MainForm : Form
    {
        private const string RegFileName = "accounts.db";

        private AccountRegistry _reg;

        private Random _rnd;

        public MainForm()
        {
            InitializeComponent();

            _rnd = new Random();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _reg = new AccountRegistry();

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

                GenerateAccounts(6);
                _reg.WriteAccounts(stream);
            }

            stream.Close();
        }

        private string GetRandomString(int len, string postfix)
        {
            string result = "";
            for (int i = 0; i < len; i++)
            {
                result += (char)_rnd.Next('a', 'z');
            }

            return result + postfix;
        }

        private void GenerateAccounts(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string username = GetRandomString(AccountRegistry.MaxNameLenght - "_user".Length, "_user");
                string password = GetRandomString(AccountRegistry.MaxPasswordLength - "_pass".Length, "_pass");

                _reg.AddAccount(username);
                _reg.ChangePassword(username, password);
            }
        }
    }
}
