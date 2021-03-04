using System.Threading.Tasks;
using IpInfo;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Net;

namespace BrokerAPI.dal.ProviderOne
{
    public class IPInfoDal : IIPInfoDal
    {
        private readonly HttpClient _httpClient;
        public IPInfoDal(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<FullResponse> getIPdetails()
        {
            FullResponse response = new FullResponse(); ;
            try
            {
                Uri url = new Uri("https://ipinfo.io/");
                HttpResponseMessage httpResult= await _httpClient.GetAsync(url.AbsoluteUri);
               if(httpResult.IsSuccessStatusCode)
                {
                    string data  = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<FullResponse>(data);
                    //string code = httpResult.StatusCode.ToString();
                }
                else
                {
                    
                }

                

                
            }
            catch(ApiException e)
            {

            }

            return response;


        }
    }
}
