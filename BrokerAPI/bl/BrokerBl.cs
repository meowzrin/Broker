using BrokerAPI.dal.ProviderOne;
using BrokerAPI.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerAPI.bl
{
    public class BrokerBl : IBrokerBl
    {
        private readonly IIPInfoDal _ipInfoDal;
        public BrokerBl(IIPInfoDal ipInfoDal)
        {
            _ipInfoDal = ipInfoDal;
        }

        public async Task<BrokerResponse> processData(string ip)
        {
            BrokerResponse response = new BrokerResponse();
            var res = await _ipInfoDal.getIPdetails();
            response.Country = res.Country;
            response.City = res.City;
            return response;
        }
    }
}
