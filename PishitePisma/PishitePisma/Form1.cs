using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PishitePisma
{
    public delegate void InvokeDelegate(IPAddress sender, string text, string process);
    public partial class Form1 : Form
    {
        private string FriendText;
        private string MyText;
        public const int Port = 25565;
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

        void Listener()
        {
            UdpClient udp = new UdpClient(Port);
            
            while (true)
            {
                try
                {
                    IPEndPoint IPEP = new IPEndPoint(IPAddress.Any, Port);
                    byte[] data = udp.Receive(ref IPEP);
                    IPAddress sender = IPEP.Address;
                    FriendText = Encoding.Unicode.GetString(data);
                  //  MessageBox.Show("Message from " + sender);
                    MessageDisplay.BeginInvoke(new InvokeDelegate(AddMessage), sender, FriendText, "получено");
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

            }
        }

        private void AddMessage(IPAddress sender, string text, string process)
        {
            MessageDisplay.Text += sender + process + "\n-----------------\n" + text + "\n \n";
        }

        void SendingMessage(byte[] data, IPAddress destination)
        {
            UdpClient udp = new UdpClient();
            udp.ExclusiveAddressUse = false;
            IPEndPoint IPEP = new IPEndPoint(destination, Port);
            udp.Send(data, data.Length, IPEP);
            MyText = Encoding.Unicode.GetString(data);
            MessageDisplay.BeginInvoke(new InvokeDelegate(AddMessage), destination, MyText, "отправлено");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread listenerThread = new Thread(Listener);
            listenerThread.Start();

        }
    }
}
