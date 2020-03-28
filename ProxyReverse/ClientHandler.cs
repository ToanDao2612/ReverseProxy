using System;
using System.Threading.Tasks;

namespace ProxyReverse
{
    internal class ClientHandler :IDisposable
    {
        private ProxyClient proxyClient;

        public ClientHandler(ProxyClient generatedClient)
        {
            this.proxyClient = generatedClient;
        }

        internal async Task HandleClient()
        {
            var response = await GenerateResponse();
            await proxyClient.SendResponseAsync(response);
        }

        private async Task<string> GenerateResponse()
        {
            var proxyClientRequest = await proxyClient.GetRequest();
            var response = await GetRequestFromLocalNetwork(proxyClientRequest);
            return response;
        }

        private async Task<string> GetRequestFromLocalNetwork(string proxyClientRequest)
        {
            return @$"HTTP/1.1 200 OK
Date: Mon, 23 May 2005 22:38:34 GMT
Content - Type: text / html; charset = UTF - 8
Content - Length: 138
Last - Modified: Wed, 08 Jan 2003 23:11:55 GMT
  Server: Apache / 1.3.3.7(Unix)(Red - Hat / Linux)
Accept - Ranges: bytes
  Connection: close


  <html>
    < head >
      < title > An Example Page</ title >
       </ head >
       < body >
         < p > Hello World, this is a very simple HTML document.</ p >
          </ body >
        </ html > ";
        }

        public void Dispose()
        {
            proxyClient.Dispose();
        }

    }
}