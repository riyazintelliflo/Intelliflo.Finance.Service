using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Repositories.Contracts.YourNamespace.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Intelliflo.Finance.Service.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmailReferenceController : ControllerBase
    {
        private readonly IEmailReferenceRepository _emailReferenceRepository;

        public EmailReferenceController(IEmailReferenceRepository emailReferenceRepository)
        {
            _emailReferenceRepository = emailReferenceRepository;
        }

        // GET: api/MyEntity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEmailReference>>> GetMyEntities()
        {
            var entities = await _emailReferenceRepository.GetEmailReferenceAsync();
            return Ok(entities);
        }

        // POST: api/MyEntity
        [HttpPost]
        public async Task<ActionResult<TEmailReference>> PostMyEntity(TEmailReference emailReference)
        {
            var createdEntity = await _emailReferenceRepository.AddEmailReferenceAsync(emailReference);
            return CreatedAtAction(nameof(GetMyEntities), new { id = createdEntity.Id }, createdEntity);
        }
    }

}
