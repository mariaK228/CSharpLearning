﻿using System;
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
        static object locker = new object();
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

        void Listener()
        {
            UdpClient udp = new UdpClient(Port);
            
            lock(locker)
            {
                while (true)
                {
                    try
                    {
                        networkHelper.SetSyncReceiveCallback();
                        FriendText = Encoding.Unicode.GetString(networkHelper.Peek().Data);
                        MessageDisplay.BeginInvoke(new InvokeDelegate(AddMessage), networkHelper.Dequeue().Sender, FriendText, " получено");
                    }

                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }

                }
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
    }
}
