using Intelliflo.Finance.Service.DBContext;
using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Intelliflo.Finance.Service.Repositories.Services
{
    public class ContactService : IContactService
    {
        private readonly CRMDbContext _context;

        public ContactService(CRMDbContext context)
        {
            _context = context;
        }

        public async Task<TContact> GetContactByValueAsync(string value)
        {
            // Find contact by Value (either email or phone)
            return await _context.Contact
                .Where(c => c.Value == value).FirstOrDefaultAsync();
        }
    }

}
