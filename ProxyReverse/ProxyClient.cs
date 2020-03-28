using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProxyReverse
{
    public static class TcpListenerExtension
    {
        public static ProxyClient GetNewClient(this TcpListener tcpListener)
        {
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            return new ProxyClient(tcpClient);
        }
    }

    public class ProxyClient :IDisposable
    {
        protected TcpClient _tcpClient;
        protected NetworkStream _stream;
        public ProxyClient(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
            _stream = _tcpClient.GetStream();
        }

        public void Dispose()
        {
            _stream.Close();
            _stream.Dispose();
        }

        public async Task<string> GetRequest()
        {
            byte[] data = new byte[1024];
            using (MemoryStream memoryStream = new MemoryStream())
            {
                do
                {
                    await _stream.ReadAsync(data, 0, data.Length);
                    await memoryStream.WriteAsync(data, 0, data.Length);
                } while (_stream.DataAvailable);

                return Encoding.ASCII.GetString(memoryStream.ToArray(), 0, (int)memoryStream.Length);
            }
        }

        internal async Task SendResponseAsync(string data)
        {
            try
            {
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                await _stream.WriteAsync(msg, 0, msg.Length);
                await _stream.FlushAsync();
            }catch(Exception ex)
            {

            }
        }
    }
}
