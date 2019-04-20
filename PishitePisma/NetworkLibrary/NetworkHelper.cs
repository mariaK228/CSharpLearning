
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;


namespace NetworkLibrary
{
    public struct NetPackage
    {
        public IPAddress Sender;
        public byte[] Data;
    }

    public delegate void CallbackDelegate(NetPackage netPackage);
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

        public void MessageReceiver(CallbackDelegate Callback)
        {
            //lock (queue)
            //  {
            UdpClient udp = new UdpClient(Port);
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Port);

                byte[] data = udp.Receive(ref endPoint);
                IPAddress sender = endPoint.Address;
                NetPackage package = new NetPackage() { Data = data, Sender = sender };
                Callback(package);
                //queue.Enqueue(new NetPackage() { Data = udp.Receive(ref endPoint), Sender = endPoint.Address });
            }

            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex);
            }
            //}            
        }
    }
}