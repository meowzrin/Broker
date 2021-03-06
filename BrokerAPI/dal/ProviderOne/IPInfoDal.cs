using System.Threading.Tasks;
using IpInfo;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Net;
using System.Diagnostics;
using BrokerAPI.domain;

namespace BrokerAPI.dal.ProviderOne
{
    public class IPInfoDal : IIPInfoDal
    {
        private readonly HttpClient _httpClient;
        private readonly Uri url = new Uri("https://ipinfo.io/");
        public IPInfoDal(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<FullResponse> getIPdetails(ProviderQuality p1)
        {
            FullResponse response = new FullResponse();
            try
            {
                HttpResponseMessage httpResult = await _httpClient.GetAsync(url.AbsoluteUri);

                Stopwatch stopwatch = new Stopwatch();

                p1.requestCount++;
                if (httpResult.IsSuccessStatusCode)
                {

                    stopwatch.Reset();
                    stopwatch.Start();
                    string data = await httpResult.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<FullResponse>(data);
                    stopwatch.Stop();
                    p1.avgResponseTime += stopwatch.ElapsedMilliseconds / 2;
                }
                else
                {
                    p1.errorCount++;
                }


            }
            catch (Exception e)
            {
                //log exception
            }

            return response;


        }
    }
}
