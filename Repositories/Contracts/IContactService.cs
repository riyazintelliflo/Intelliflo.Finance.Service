using Intelliflo.Finance.Service.Models;

namespace Intelliflo.Finance.Service.Repositories.Contracts
{
    public interface IContactService
    {
        Task<TContact> GetContactByValueAsync(string value);
    }
}
