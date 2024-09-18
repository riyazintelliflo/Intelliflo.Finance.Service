using Intelliflo.Finance.Service.Repositories.Contracts;
using Intelliflo.Finance.Service.Repositories.Services;
using Microsoft.AspNetCore.Mvc;

namespace Intelliflo.Finance.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommondationController(IRecommandation recommandation) :  ControllerBase
    {
        private readonly IRecommandation _recommandation = recommandation;

        [HttpGet]
        public async Task<IActionResult> Recommandation()
        {
           var products = await _recommandation.GetRecommandations();
            return products == null ? NoContent() : Ok(products);
        }
    }
}
