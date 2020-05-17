using Newtonsoft.Json;
using ProxyReverse.Client.ConfigReader;
using ProxyReverse.Client.Exceptions;
using ProxyReverse.Client.HttpRequester.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProxyReverse.Client.HttpRequester
{
    public class WebRequest : IWebRequest
    {
        public IApplicationConfigReader ApplicationConfigReader { get; }
        public WebRequest(IApplicationConfigReader applicationConfigReader)
        {
            ApplicationConfigReader = applicationConfigReader;
        }

        public async Task<ConnectionResponse> NewRequestConnectionAsync(ConnectionRequest connectionRequest)
        {
            try
            {
                var config = ApplicationConfigReader.GetWebApi();
                var handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                HttpClient httpClient = new HttpClient(handler);
                HttpResponseMessage result = await httpClient.GetAsync($"https://{config.RequestConnectionUrl}/Communicator");
                string httpResponse = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ConnectionResponse>(httpResponse);
            }
            catch (Exception ex)
            {
                //throw new NetworkException();
                return null;
            }
        }
    }
}
