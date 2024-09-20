using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Repositories.Contracts;
using Intelliflo.Finance.Service.Repositories.Services;
using Microsoft.AspNetCore.Mvc;
using OoplesFinance.YahooFinanceAPI.Enums;

namespace Intelliflo.Finance.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommondationController(IRecommandation recommandation) :  ControllerBase
    {
        private readonly IRecommandation _recommandation = recommandation;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AssetRecommandation>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Recommandation(Country contry,RiskLevel riskCapacity,RiskLevel riskTolerance)
        {
           var products = await _recommandation.GetRecommandations(contry, riskCapacity, riskTolerance);
           return products == null ? NoContent() : Ok(products);
        }
    }
}
