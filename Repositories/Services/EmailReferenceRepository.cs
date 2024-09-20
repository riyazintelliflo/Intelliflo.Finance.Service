using Intelliflo.Finance.Service.DBContext;
using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Repositories.Contracts.YourNamespace.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intelliflo.Finance.Service.Repositories.Services
{


    public class EmailReferenceRepository : IEmailReferenceRepository
    {
        private readonly CRMDbContext _context;

        public EmailReferenceRepository(CRMDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEmailReference>> GetEmailReferenceAsync()
        {
            return await _context.EmailReference.ToListAsync();
        }

        public async Task<TEmailReference> AddEmailReferenceAsync(TEmailReference myEntity)
        {
            _context.EmailReference.Add(myEntity);
            await _context.SaveChangesAsync();
            return myEntity;
        }
    }
}

