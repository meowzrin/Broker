using BrokerAPI.bl;
using BrokerAPI.dal.ProviderOne;
using BrokerAPI.dal.ProviderTwo;
using BrokerAPI.dal.Quality;
using BrokerAPI.domain;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using IpInfo;
using System.Threading.Tasks;

namespace BrokerAPITest
{
    public class Tests
    {
        private Mock<IIPInfoDal> _ipInfoDal;
        private Mock<ISlowIpInfoDal> _slowIpInfoDal;
        private Mock<IQualityDal> _qualityDal;  
        [SetUp]
        public void Setup()
        {
            _ipInfoDal = new Mock<IIPInfoDal>();
            _slowIpInfoDal = new Mock<ISlowIpInfoDal>();
            _qualityDal = new Mock<IQualityDal>();
        }

        [Test]
        public void Test1()
        {
            FullResponse fullResponse;
            List<ProviderQuality> providerQuality;
            BrokerBl bl = new BrokerBl(_ipInfoDal.Object, _qualityDal.Object, _slowIpInfoDal.Object);
            using (StreamReader r = new StreamReader(@"C:\Users\Trinita\source\repos\BrokerAPI\BrokerAPITest\UnitTest\ProviderTestResponse.json"))
            {
                string json = r.ReadToEnd();
                fullResponse = JsonConvert.DeserializeObject<FullResponse>(json);
            }

            using (StreamReader r = new StreamReader(@"C:\Users\Trinita\source\repos\BrokerAPI\BrokerAPITest\UnitTest\QualityTestData.json"))
            {
                string json = r.ReadToEnd();
                providerQuality = JsonConvert.DeserializeObject<List<ProviderQuality>>(json);
            }
            _qualityDal.Setup(x => x.GetQuality()).Returns(providerQuality);
            _ipInfoDal.Setup(x => x.getIPdetails(providerQuality[0])).Returns(Task.FromResult(fullResponse));
           
            
            var res = bl.processData();
            Assert.AreEqual("Bengaluru", res.Result.City);
        }
    }
}