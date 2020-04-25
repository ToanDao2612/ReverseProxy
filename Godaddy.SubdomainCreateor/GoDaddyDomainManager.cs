using Newtonsoft.Json;
using ProxyReverse.SubdomainCreator;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GoDaddy.SubdomainCreator
{
    public class GoDaddyDomainManager : IDomainManager
    {
        public GoDaddyDomainManager()
        {

        }

        public async Task<IDomainOperationResponse> CreateSubdomainAsnyc(CreateDomainModel createDomainModel)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var godaddySubdomainModel = new GodaddySubdomainModel()
                {
                    Ip = createDomainModel.Ip,
                    SubdomainName = createDomainModel.SubdomainName,
                    RefreshRate = createDomainModel.RefresRate,
                    Type = createDomainModel.Type
                };
                var godaddyArrayModel = new GodaddySubdomainModel[]
                {
                    godaddySubdomainModel
                };
                var jsonObject = JsonConvert.SerializeObject(godaddyArrayModel);
                var httpContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("sso-key",$"{createDomainModel.DomainAuthorizationKey}");
                httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var response = await httpClient.PatchAsync($"https://api.godaddy.com/v1/domains/{createDomainModel.Domain}/records", httpContent);
                if(response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return new FailResponse();

                }
            }
            catch(Exception ex)
            {
                return new FailResponse();
            }

            return new SuccessResponse();
        }
    }
}
