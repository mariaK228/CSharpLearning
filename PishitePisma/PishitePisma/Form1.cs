using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkLibrary;

namespace PishitePisma
{
    public delegate void InvokeDelegate(IPAddress sender, string text, string process);
    public partial class Form1 : Form
    {
        private string MyText;
        public const int Port = 25565;
        NetPackage callback;
        NetworkHelper networkHelper = new NetworkHelper();
        public Form1()
        {
            InitializeComponent();
        }

        private void SendMessage_Click(object sender, EventArgs e)
        {
            string Text = InputInputbox.Text;
            byte[] data = Encoding.Unicode.GetBytes(Text);

            SendingMessage(data, IPAddress.Parse(UserIP.Text));
        }

        public void Listener()
        {
                try
                {
                networkHelper.MessageReceiver(Callback, Listener);
                    NetPackage AddressMessage = callback;
                    string message = Encoding.Unicode.GetString(AddressMessage.Data);
                    IPAddress iPAddress = AddressMessage.Sender;
                  MessageDisplay.Enabled = true;
                  this.MessageDisplay.BeginInvoke(new InvokeDelegate(AddMessage), iPAddress, message, " получено");
                Listener();
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
        }

        private void AddMessage(IPAddress sender, string text, string process)
        {
            MessageDisplay.Text += sender.ToString() + process + "\n-----------------\n" + text + "\n \n";
        }

        void SendingMessage(byte[] data, IPAddress destination)
        {
            networkHelper.SendPackage(data, destination);
            MyText = Encoding.Unicode.GetString(data);
            MessageDisplay.BeginInvoke(new InvokeDelegate(AddMessage), destination, MyText, " отправлено");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread listenerThread = new Thread(Listener);
            listenerThread.Start();

        }

        public void Callback(NetPackage pkg)
        {
            callback = pkg;
        }
    }
}
