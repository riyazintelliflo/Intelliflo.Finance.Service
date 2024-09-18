using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Models.Response;
using Intelliflo.Finance.Service.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intelliflo.Finance.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditProfileController(ICreditProfile creditprofile) : ControllerBase
    {
        private readonly ICreditProfile _creditprofile = creditprofile;

        [HttpPost("GetProfileInfo", Name = "GetCreditProfileByID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserCreditProfile))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult GetCreditProfileByID([FromBody]CreditProfileRequest request) 
        {
            var userCreditProfile = _creditprofile.GetUserCreditProfile(request);
            if (userCreditProfile == null)
            {
                return NotFound("User credit profile not found.");
            }
            return Ok(userCreditProfile);
        }

        [HttpGet("GetClientPortfolio", Name = "GetFactFind")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IOClientPortfolio))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetFactFind(int clientId)
        {
            if(clientId <= 0)
            {
                BadRequest("Client Id is required");
            }

            var result = _creditprofile.GetUserPortfolio(clientId);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No data found for the given client");
            }
            return Ok(result);
        }

        [HttpGet("GetAssetsInfo", Name = "GetAssetsInfoByID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FinicityVerificationOfAssets))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult GetAssetsInfoByID(int clientId)
        {
            var userCreditProfile = _creditprofile.GetAssetsInfoByID(clientId);
            if (userCreditProfile == null)
            {
                return NotFound("User Assets profile not found.");
            }
            return Ok(userCreditProfile);
        }

    }

}
