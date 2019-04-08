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
    public delegate void NetCallback(byte[] pkg, IPAddress sender);
    class NetworkHelper
    {
        public const int Port = 25565;
        void SendPackage(byte[] pkg, IPAddress destination)
        {
            UdpClient udp = new UdpClient();
            udp.ExclusiveAddressUse = false;
            IPEndPoint endPoint = new IPEndPoint(destination, Port);
            udp.Send(pkg, pkg.Length);
        }

        void SetSyncReceiveCallback(byte[] callback)
        {
            UdpClient udp = new UdpClient();

            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Port);
                callback = udp.Receive(ref endPoint);
            }

            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex);
            }
        }
    }
}
