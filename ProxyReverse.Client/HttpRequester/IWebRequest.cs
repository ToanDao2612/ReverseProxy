using ProxyReverse.Client.HttpRequester.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProxyReverse.Client.HttpRequester
{
    public interface IWebRequest
    {
        Task<ConnectionResponse> NewRequestConnectionAsync(ConnectionRequest connectionRequest);
    }
}
