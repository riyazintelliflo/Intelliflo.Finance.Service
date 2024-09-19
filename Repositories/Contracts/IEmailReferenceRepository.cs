using Intelliflo.Finance.Service.Models;

namespace Intelliflo.Finance.Service.Repositories.Contracts
{
    namespace YourNamespace.Interfaces
    {
        public interface IEmailReferenceRepository
        {
            Task<IEnumerable<TEmailReference>> GetEmailReferenceAsync();
            Task<TEmailReference> AddEmailReferenceAsync(TEmailReference emailReference);
        }
    }

}
