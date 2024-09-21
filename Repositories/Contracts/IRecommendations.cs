using Intelliflo.Finance.Service.Models;
using OoplesFinance.YahooFinanceAPI.Enums;
using OoplesFinance.YahooFinanceAPI.Models;

namespace Intelliflo.Finance.Service.Repositories.Contracts
{
    public interface IRecommendation
    {
        public  Task<List<AssetRecommendation>> GetRecommendations(Country contry, RiskLevel riskCapacity, RiskLevel riskTolerance);
    }
}
