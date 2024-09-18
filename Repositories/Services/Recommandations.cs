using Intelliflo.Finance.Service.Repositories.Contracts;
using OoplesFinance.YahooFinanceAPI;
using OoplesFinance.YahooFinanceAPI.Models;

namespace Intelliflo.Finance.Service.Repositories.Services
{
    public class Recommandation : IRecommandation
    {
        public Recommandation() { }

        public async Task<ScreenerResult> GetRecommandations()
        { 
        YahooClient yahooClient = new YahooClient();
        return  await yahooClient.GetUndervaluedLargeCapStocksAsync(5);
        }


    }
}
