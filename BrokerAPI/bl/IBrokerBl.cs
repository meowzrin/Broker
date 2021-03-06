using BrokerAPI.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerAPI.bl
{
    public interface IBrokerBl
    {
        Task<BrokerResponse> processData();
    }
}
