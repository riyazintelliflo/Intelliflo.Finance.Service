using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Models.Response;
namespace Intelliflo.Finance.Service.Repositories.Contracts
{
    public interface ICreditProfile
    {
        public UserCreditProfile GetUserCreditProfile(CreditProfileRequest request);

        public TAssetsAndLiabilities GetUserPortfolio(int clientId);
    }
}
