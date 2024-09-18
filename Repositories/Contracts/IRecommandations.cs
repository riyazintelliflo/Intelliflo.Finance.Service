using OoplesFinance.YahooFinanceAPI.Models;

namespace Intelliflo.Finance.Service.Repositories.Contracts
{
    public interface IRecommandation
    {
        public  Task<ScreenerResult> GetRecommandations();
    }
}
