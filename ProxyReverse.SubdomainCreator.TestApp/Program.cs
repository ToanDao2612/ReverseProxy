using GoDaddy.SubdomainCreator;
using System;
using System.Threading.Tasks;

namespace ProxyReverse.SubdomainCreator.TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IDomainManager domainManager = new GoDaddyDomainManager();
            
            await domainManager.CreateSubdomainAsnyc(new CreateDomainModel()
            {
                Domain = $"ekumplu.com",
                DomainAuthorizationKey = $"e42s2CCpghZo_DFWLYVb2djwAS2Hd5amRGp:6HzgUC4u9WPv1Pk9QW33Vz",

                Ip = "23.227.38.32",
                SubdomainName = $"misu.mere",
                RefresRate = 1800,
                Type = "A"
            });

            Console.ReadLine();
        }
    }
}
