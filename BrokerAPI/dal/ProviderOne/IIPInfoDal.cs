using BrokerAPI.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerAPI.dal.ProviderOne
{
    public interface IIPInfoDal
    {
        Task<IpInfo.FullResponse> getIPdetails();
    }
}
