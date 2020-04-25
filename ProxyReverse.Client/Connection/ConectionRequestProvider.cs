using ProxyReverse.Client.HttpRequester.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyReverse.Client.Connection
{
    public class ConectionRequestProvider : IConectionRequestProvider
    {
        public ConnectionRequest GetConnectionRequest()
        {
            return new ConnectionRequest();
        }
    }

    public interface IConectionRequestProvider
    {
        ConnectionRequest GetConnectionRequest();
    }
}
