using Intelliflo.Finance.Service.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intelliflo.Finance.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("GetByValue/{value}")]
        public async Task<IActionResult> GetByValue(string value)
        {
            var contact = await _contactService.GetContactByValueAsync(value);

            if (contact == null)
            {
                return NotFound("Contact not found");
            }

            return Ok(contact);
        }
    }
}
