using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Models.Response;
namespace Intelliflo.Finance.Service.Repositories.Contracts
{
    public interface ICreditProfile
    {
        public UserCreditProfile GetUserCreditProfile(CreditProfileRequest request);

        public IOClientPortfolio GetUserPortfolio(int clientId);
        

        public IncomeStatistics PeerComparison(int age, Gender gender);
    }
}
