using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PodLabs.Core
{
    public class MySocket
    {
        ClientWebSocket wb;
        byte[] message = new byte[0];
        WebSocketReceiveResult result;

        public MySocket()
        {
            wb = new ClientWebSocket();
        }

        public void Connect(Uri uri)
        {
            wb.ConnectAsync(uri, CancellationToken.None);
        }

        public WebSocketState GetState()
        {
            return wb.State;
        }

        public bool Subscribe(string cmd)
        {
            Task.Run(async () =>
            {
                await wb.SendAsync(Encoding.ASCII.GetBytes(cmd), WebSocketMessageType.Text, true, CancellationToken.None);
            }).Wait();

            return true;
        }

        public void Receive()
        {
            byte[] newBuffer = new byte[message.Length];
            byte[] buffer = new byte[1024];
            Task.Run(async () =>
            {
                result = await wb.ReceiveAsync(buffer, CancellationToken.None);
            }).Wait();

            newBuffer = new byte[message.Length + buffer.Length];
            Array.Copy(message, 0, newBuffer, 0, message.Length);
            Array.Copy(buffer, 0, newBuffer, message.Length, buffer.Length);

            message = new byte[newBuffer.Length];
            message = newBuffer;
        }

        public bool IsEndOfMessage()
        {
            if (result == null)
            {
                return false;
            }

            return result.EndOfMessage;
        }

        public string GetMessage()
        {
            var msg = message;
            message = new byte[0];
            result = null;
            return Encoding.ASCII.GetString(msg);
        }
    }
}
