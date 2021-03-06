using BrokerAPI.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerAPI.dal.ProviderTwo
{
    public interface ISlowIpInfoDal
    {
        Task<IpInfo.FullResponse> getIPdetails(ProviderQuality p1);
    }
}
