
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkLibrary
{
    public struct NetPackage
    {
        public IPAddress Sender;
        public byte[] Data;
    }

    public delegate void CallbackDelegate(NetPackage netPackage);
    public delegate void ListenerDelegate();
    public class NetworkHelper
    {
        public const int Port = 25565;
        public void SendPackage(byte[] pkg, IPAddress destination)
        {
            UdpClient udp = new UdpClient();
            udp.ExclusiveAddressUse = false;
            IPEndPoint endPoint = new IPEndPoint(destination, Port);
            udp.Send(pkg, pkg.Length, endPoint);
        }

        public void MessageReceiver(CallbackDelegate Callback, ListenerDelegate Listener)
        {
            //lock (queue)
            //  {
            NetPackage pkg;
            UdpClient udp = new UdpClient(Port);
            while(true)
            {
                try
                {
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Port);

                    byte[] data = udp.Receive(ref endPoint);
                    IPAddress sender = endPoint.Address;
                    NetPackage package = new NetPackage() { Data = data, Sender = sender };
                    pkg = package;
                    break;
                }

                catch (Exception ex)
                {
                    Debug.WriteLine("Error:" + ex);
                }
            }
            ThreadStart threadStart = new ThreadStart(()=>Callback(pkg));
            Thread thread = new Thread(threadStart);
            thread.Start();
          // Task.Factory.StartNew(() => Callback(pkg), TaskCreationOptions.LongRunning);          
        }
    }
}