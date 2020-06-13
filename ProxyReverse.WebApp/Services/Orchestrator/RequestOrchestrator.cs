using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using ProxyReverse.Web.Core.InternalyImplementedServices.Request;
using ProxyReverse.Web.Core.InternalyImplementedServices.Tunnel.Models;
using ProxyReverse.Web.Services.SignalRHubs;
using ProxyReverse.Web.Services.WebImplementedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyReverse.Web.Services.Orchestrator
{
    public interface IRequestOrchestrator
    {
        Task RedirectRequestToClient(HttpContext httpContext, ApplicationRequest applicationRequest);
    }
    public class RequestOrchestrator : IRequestOrchestrator
    {
        public IHubContext<TunnelWebSocketHub> TunnelWebSocketHub { get; }
        public IRequestsDictionaryAccesor RequestsDictionaryAccesor { get; }
        public ICurrentTunnelsAccesor CurrentTunnelsAccesor { get; }

        public RequestOrchestrator(
            IHubContext<TunnelWebSocketHub> tunnelWebSocketHub,
            IRequestsDictionaryAccesor requestsDictionaryAccesor,
            ICurrentTunnelsAccesor currentTunnelsAccesor)
        {
            TunnelWebSocketHub = tunnelWebSocketHub;
            RequestsDictionaryAccesor = requestsDictionaryAccesor;
            CurrentTunnelsAccesor = currentTunnelsAccesor;
        }


        public async Task RedirectRequestToClient(HttpContext httpContext, ApplicationRequest applicationRequest)
        {
            string request = RequestHelper.ConvertRequestToString(httpContext);
            ApplicationRequestTask applicationRequestTask = new ApplicationRequestTask(request);
            RequestsDictionaryAccesor.AddRequest(applicationRequest, applicationRequestTask);
            
            Tunnel tunnel = CurrentTunnelsAccesor.GetTunnelByUrl(applicationRequest.ApplicationTenant.Url);

            await TunnelWebSocketHub
                .Clients
                .User(tunnel.UserId.ToString())
                .SendAsync(applicationRequest.RequestId.ToString(),applicationRequestTask.Request);

            var response = await applicationRequestTask.RequestTask;
            await httpContext.Response.WriteAsync(response);
        }
    }

    internal static class RequestHelper
    {
        internal static string ConvertRequestToString(this HttpContext httpContext)
        {
            return httpContext.Request.ToString();
            var request = httpContext.Request;

            StringBuilder stringBuilder = new StringBuilder();
            var headers = string.Join(Environment.NewLine, request.GetHeadersAsString());
            stringBuilder.Append(headers);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(request.Body);
            
            return stringBuilder.ToString();
        }

        private static IEnumerable<string> GetHeadersAsString(this HttpRequest httpRequest)
            => httpRequest.Headers.Select(element => $"{element.Key}:{element.Value}");
    }
}
