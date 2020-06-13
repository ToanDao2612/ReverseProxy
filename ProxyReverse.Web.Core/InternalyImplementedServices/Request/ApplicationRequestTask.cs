using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyReverse.Web.Core.InternalyImplementedServices.Request
{
    public class ApplicationRequestTask
    {
        public ApplicationRequestTask(string request)
        {
            Semaphore = new SemaphoreSlim(1);
            Request = request;
            RequestTask = Task.Run(async () => {
                await Semaphore.WaitAsync();
                return Response;
            });
        }

        public void FinishRequest(string response)
        {
            Response = response;
            Semaphore.Release();
        }

        public string Request { get; }
        private string Response { get; set; }
        private SemaphoreSlim Semaphore { get; }
        public Task<string> RequestTask { get; }
    }
}
