using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intelliflo.Finance.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditProfileController(ICreditProfile creditprofile) : ControllerBase
    {
        private readonly ICreditProfile _creditprofile = creditprofile;

        [HttpPost]
        public IActionResult GetCreditProfileByID([FromBody]CreditProfileRequest request) 
        {
            var userCreditProfile = _creditprofile.GetUserCreditProfile(request);
            if (userCreditProfile == null)
            {
                return NotFound("User credit profile not found.");
            }
            return Ok(userCreditProfile);
        }
    }
}
