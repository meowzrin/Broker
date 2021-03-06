using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerAPI.domain
{
    public class ProviderQuality
    {
        public string providerName { get; set; }
        public int errorCount{ get; set;}

        public long avgResponseTime { get; set; }

        public int requestCount { get; set; }

    }
}
