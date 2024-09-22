using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Models.Response;
using Intelliflo.Finance.Service.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Intelliflo.Finance.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialDetailsController(ICreditProfile creditProfile) : ControllerBase
    {
        private readonly ICreditProfile _creditProfile = creditProfile;

        /// <summary>
        /// Get income details.
        /// eg: filter = "NAME,B19013_001E,B06010_004E"
        /// </summary>
        /// <param name="filter">Filter should be comma separated values used in API</param>
        /// <returns></returns>
        [HttpGet("GetIncomePeerComparision", Name = "GetPeerComparisionIncome")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IncomeStatistics))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPeerComparisionIncome(Gender gender, int age)
        {
            if (age > 0 && gender != null)
            {
                var response = _creditProfile.PeerComparison(age, gender);
                if (response == null)
                {
                    return NotFound("peer comparison data  not found.");
                }
                return Ok(response);
            }

            return BadRequest("Invalid input");
        }

    }
}
