using Intelliflo.Finance.Service.Models;
using OoplesFinance.YahooFinanceAPI.Enums;
using OoplesFinance.YahooFinanceAPI.Models;

namespace Intelliflo.Finance.Service.Repositories.Contracts
{
    public interface IRecommandation
    {
        public  Task<List<AssetRecommandation>> GetRecommandations(Country contry, RiskLevel riskCapacity, RiskLevel riskTolerance);
    }
}
