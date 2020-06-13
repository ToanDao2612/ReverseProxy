using ProxyReverse.Web.Core.InternalyImplementedServices.Request;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace ProxyReverse.Web.Services.Orchestrator
{
    public interface IRequestsDictionaryAccesor
    {
        void AddRequest(ApplicationRequest applicationRequest, ApplicationRequestTask applicationRequestTask);
        void CompleteRequest(Guid requestId, string response);
    }
    public class RequestsDictionaryAccesor : IRequestsDictionaryAccesor
    {
        protected ConcurrentDictionary<Guid, ApplicationRequestTask> Requests { get; }

        public RequestsDictionaryAccesor()
        {
            Requests = new ConcurrentDictionary<Guid, ApplicationRequestTask>();
        }

        public void AddRequest(ApplicationRequest applicationRequest, ApplicationRequestTask applicationRequestTask)
        {
            Requests.GetOrAdd(applicationRequest.RequestId, applicationRequestTask);
        }

        public void CompleteRequest(Guid requestId, string response)
        {
            if (Requests.TryGetValue(requestId,out ApplicationRequestTask element))
            {
                element.FinishRequest(response);
            }
        }
    }
}
