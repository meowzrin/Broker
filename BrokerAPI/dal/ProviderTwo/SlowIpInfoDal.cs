using System.Threading.Tasks;
using IpInfo;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Net;
using BrokerAPI.domain;
using System.Diagnostics;

namespace BrokerAPI.dal.ProviderTwo
{
    public class SlowIpInfoDal : ISlowIpInfoDal
    { 
        private readonly HttpClient _httpClient;
       
        public SlowIpInfoDal(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<FullResponse> getIPdetails(ProviderQuality p1)
        {
            FullResponse response = new FullResponse();
            Stopwatch stopwatch = new Stopwatch();
            try
            {
                var client = new HttpClient();
                var api = new IpInfoApi(client);
                p1.requestCount++;
                stopwatch.Reset();
                stopwatch.Start();
                response = await api.GetCurrentInformationAsync();
                stopwatch.Stop();
                p1.avgResponseTime += stopwatch.ElapsedMilliseconds/2;

            }
            catch (Exception e)
            {
                //log exception
            }

            return response;


        }
    }
}
