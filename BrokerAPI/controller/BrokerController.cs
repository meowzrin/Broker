using System.Threading.Tasks;
using BrokerAPI.bl;
using BrokerAPI.domain;
using Microsoft.AspNetCore.Mvc;

namespace BrokerAPI.controller
{
    [ApiController]
    [Route("[controller]")]
    public class BrokerController: ControllerBase
    {
        private readonly IBrokerBl _brokerBl;

        public BrokerController(IBrokerBl brokerBl)
        {
            _brokerBl=brokerBl;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(BrokerResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BrokerResponse>> ProcessPayment()
        {

            BrokerResponse response = new BrokerResponse();
            

            response = await _brokerBl.processData();

            return Ok(response);
        }


    }
}
