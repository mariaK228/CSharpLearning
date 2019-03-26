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
    public partial class Form1 : Form
    {
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
                    MessageBox.Show("Message from " + sender + "\n" + Encoding.Unicode.GetString(data));
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

            }
        }

        void SendingMessage(byte[] data, IPAddress destination)
        {
            UdpClient udp = new UdpClient(Port);
            IPEndPoint IPEP = new IPEndPoint(destination, Port);
            udp.Send(data, data.Length, IPEP);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread listenerThread = new Thread(Listener);
            listenerThread.Start();

        }
    }
}
