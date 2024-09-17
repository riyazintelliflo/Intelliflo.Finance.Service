using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Intelliflo.Finance.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialDetailsController : ControllerBase
    {
        HttpClient client = new HttpClient();

        private readonly ILogger<FinancialDetailsController> _logger;
        private readonly HttpClientHelper _httpClientHelper;
        private static readonly string ApiKey = "489e7a66632291ecfbd90ebe08c6192aed42dfe9";

        public FinancialDetailsController(ILogger<FinancialDetailsController> logger)
        {
            _logger = logger;
            _httpClientHelper = new HttpClientHelper();
        }

        /// <summary>
        /// Get income details.
        /// eg: filter = "NAME,B19013_001E,B06010_004E"
        /// </summary>
        /// <param name="filter">Filter should be comma separated values used in API</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetIncome(string filter, int year)
        {            
            if(string.IsNullOrEmpty(filter))
            {
                filter = $"?get=NAME,B01001_001E&for=county:*&in=state:*&key={ApiKey}";
            }
            else
            {
                filter = $"?get={filter}&for=county:*&in=state:*&key={ApiKey}";
            }

            var response = await _httpClientHelper.GetAsync(filter, year);

            if(response == null) 
            {
                return NotFound();
            }
            var json = JObject.Parse(response);
            Console.WriteLine(json.ToString());
            return Ok(response);            
        }

    }
}
