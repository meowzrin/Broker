using BrokerAPI.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerAPI.dal.Quality
{
    public class QualityDal : IQualityDal
    {
        public List<ProviderQuality> GetQuality()
        {
            //Fetch from data source
            List<ProviderQuality> providerQualities = new List<ProviderQuality>();
            try
            {
                
                ProviderQuality p1 = new ProviderQuality()
                {
                    providerName = "IpInfo",
                    avgResponseTime = 500,
                    requestCount = 7,
                    errorCount = 1
                };
                ProviderQuality p2 = new ProviderQuality()
                {
                    providerName = "slowIpInfo",
                    avgResponseTime = 1800,
                    requestCount = 1,
                    errorCount = 3
                };
                providerQualities.Add(p1);
                providerQualities.Add(p2);
            }
            catch (Exception e)
            {
                //log exception
            }
            
            
            return providerQualities;
        }
    }
}
