using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace EventSocket
{
    public class EventClient : UdpClient
    {
        public event EventHandler<PacketReceivedArgs> PacketReceived;
        CancellationTokenSource tokenSource;

        public EventClient(int port) : base(port)
        {
            tokenSource = new CancellationTokenSource();
            Task listenTask =  ListenForPackets(tokenSource.Token);
            listenTask.Start();
        }

        async Task ListenForPackets(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                while (!token.IsCancellationRequested && Available == 0)
                {
                    await Task.Delay(10);
                }
                while (!token.IsCancellationRequested && Available > 0)
                {
                    IPEndPoint endPoint = null;
                    byte[] data = Receive(ref endPoint);
                    PacketReceived?.Invoke(this, new PacketReceivedArgs(data));
                }
            }
        }
        
        public void StopListening()
        {
            tokenSource.Cancel();
        }
    }

    public class PacketReceivedArgs : EventArgs
    {
        public byte[] Packet { get; private set; }
        public PacketReceivedArgs(byte[] packet) : base()
        {
            Packet = packet;
        }
    }
}
