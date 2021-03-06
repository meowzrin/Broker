using BrokerAPI.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerAPI.dal.Quality
{
    public interface IQualityDal
    {
        List<ProviderQuality> GetQuality();
    }
}
