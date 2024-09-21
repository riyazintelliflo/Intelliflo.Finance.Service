using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Repositories.Contracts;
using Intelliflo.Finance.Service.Repositories.Services;
using Microsoft.AspNetCore.Mvc;
using OoplesFinance.YahooFinanceAPI.Enums;

namespace Intelliflo.Finance.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommondationController(IRecommendation recommendation) :  ControllerBase
    {
        private readonly IRecommendation _recommendation = recommendation;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AssetRecommendation>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Recommandation(Country contry,RiskLevel riskCapacity,RiskLevel riskTolerance)
        {
           var products = await _recommendation.GetRecommendations(contry, riskCapacity, riskTolerance);
           return products == null ? NoContent() : Ok(products);
        }
    }
}
