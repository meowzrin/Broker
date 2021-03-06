using BrokerAPI.dal.ProviderOne;
using BrokerAPI.dal.ProviderTwo;
using BrokerAPI.dal.Quality;
using BrokerAPI.domain;
using System;
using System.Threading.Tasks;

namespace BrokerAPI.bl
{
    public class BrokerBl : IBrokerBl
    {
        private readonly IIPInfoDal _ipInfoDal;
        private readonly IQualityDal _qualityDal;
        private readonly ISlowIpInfoDal _slowIpInfoDal;
        public BrokerBl(IIPInfoDal ipInfoDal, IQualityDal qualityDal, ISlowIpInfoDal slowIpInfoDal)
        {
            _ipInfoDal = ipInfoDal;
            _qualityDal = qualityDal;
            _slowIpInfoDal = slowIpInfoDal;
        }

        public async Task<BrokerResponse> processData()
        {
            BrokerResponse response = new BrokerResponse();
            try
            {
                var qualities = _qualityDal.GetQuality();


                if (qualities[0].errorCount < qualities[1].errorCount)
                {
                    var res = await _ipInfoDal.getIPdetails(qualities[0]);
                    response.Country = res.Country;
                    response.City = res.City;
                }
                else
                {
                    if (qualities[0].errorCount != qualities[1].errorCount)
                    {
                        var res = await _slowIpInfoDal.getIPdetails(qualities[1]);
                        response.Country = res.Country;
                        response.City = res.City;
                    }
                    else
                    {
                        if (qualities[0].avgResponseTime < qualities[1].avgResponseTime)
                        {
                            var res = await _ipInfoDal.getIPdetails(qualities[0]);
                            response.Country = res.Country;
                            response.City = res.City;
                        }
                        else
                        {
                            var res = await _slowIpInfoDal.getIPdetails(qualities[1]);
                            response.Country = res.Country;
                            response.City = res.City;
                        }
                    }
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
