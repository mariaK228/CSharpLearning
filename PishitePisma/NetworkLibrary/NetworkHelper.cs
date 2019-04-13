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
    public class NetworkHelper
    {
        Queue<NetPackage> queue = new Queue<NetPackage>();
        public const int Port = 25565;
        public void SendPackage(byte[] pkg, IPAddress destination)
        {
            UdpClient udp = new UdpClient();
            udp.ExclusiveAddressUse = false;
            IPEndPoint endPoint = new IPEndPoint(destination, Port);
            udp.Send(pkg, pkg.Length, endPoint);
        }

        public void MessageReceiver()
        {
            //lock (queue)
          //  {
                UdpClient udp = new UdpClient(Port);
                try
                {
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Port);

                    byte[] data = udp.Receive(ref endPoint);
                    IPAddress sender = endPoint.Address;
                    NetPackage package = new NetPackage(){Data =  data, Sender = sender};
                    queue.Enqueue(package);
                    //queue.Enqueue(new NetPackage() { Data = udp.Receive(ref endPoint), Sender = endPoint.Address });
                }

                catch (Exception ex)
                {
                    Debug.WriteLine("Error:" + ex);
                }
            //}            
        }

        public NetPackage Dequeue()
        {
            //lock(queue)
            //{
                return queue.Dequeue();
            //}           
        }

        public int Count()
        {
          //  lock (queue)
          //  {
                return queue.Count();
           // }        
        }

        public NetPackage Peek()
        {
          //  lock (queue)
          //  {
                return queue.Peek();
          //  }
        }
    }
}
