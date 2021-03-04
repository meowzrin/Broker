using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BrokerAPI.domain
{
    public class BrokerResponse
    {
        [JsonPropertyName("Country")]
        public string Country { get; set; }

        [JsonPropertyName("City")]
        public string City { get; set; }
    }
}
