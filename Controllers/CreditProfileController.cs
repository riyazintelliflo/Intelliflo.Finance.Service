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

        [HttpGet]
        public IActionResult GetCreditProfileByID()
        {
            return Ok("Credit Profile");
        }
    }
}
