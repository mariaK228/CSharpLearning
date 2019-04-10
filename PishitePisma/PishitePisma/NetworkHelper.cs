using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PishitePisma
{
    struct NetPackage
    {
        public IPAddress Sender;
        public byte[] Data;
    }
    class NetworkHelper
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

        public void SetSyncReceiveCallback()
        {
            UdpClient udp = new UdpClient();
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Port);
                queue.Enqueue(new NetPackage() { Data = udp.Receive(ref endPoint), Sender = endPoint.Address});
            }

            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex);
            }
        }

        public NetPackage Dequeue()
        {
            return queue.Dequeue();
        }

       public int Count()
        {
            return queue.Count();
        }

        public NetPackage Peek()
        {
            return queue.Peek();
        }
    }
}
