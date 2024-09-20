using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Repositories.Contracts;
using OoplesFinance.YahooFinanceAPI;
using OoplesFinance.YahooFinanceAPI.Enums;
using OoplesFinance.YahooFinanceAPI.Models;

namespace Intelliflo.Finance.Service.Repositories.Services
{
    public class Recommandation : IRecommandation
    {
        public Recommandation() { }

        public async Task<List<AssetRecommandation>> GetRecommandations(Country country, RiskLevel riskCapacity, RiskLevel riskTolerancey)
        { 
            List<AssetRecommandation> recommandations =[];
            YahooClient yahooClient = new YahooClient(country);
            var riskAllocation = RiskProfile.GetRiskProfile(riskCapacity, riskTolerancey);

            int realEstatePec = riskAllocation.Allocation[0];
            int debtPec = riskAllocation.Allocation[1];
            int mfPec = riskAllocation.Allocation[2];
            int equityPec = riskAllocation.Allocation[3];
            int GoldPec = riskAllocation.Allocation[4];
            if(realEstatePec>0)
            {
                recommandations.Add(new AssetRecommandation { AssetType = AssetType.RealEstate, Asset = null, Allocation = realEstatePec });
            }
            if (debtPec > 0)
            {
                var debtFunds = await yahooClient.GetConservativeForeignFundsAsync(2);
                recommandations.Add(new AssetRecommandation { AssetType = AssetType.Debt, Asset = debtFunds, Allocation =debtPec });
            }
            if (mfPec > 0)
            {
                var MutualfudsData = await yahooClient.GetTopMutualFundsAsync(3);
                recommandations.Add(new AssetRecommandation { AssetType = AssetType.MF, Asset = MutualfudsData, Allocation = mfPec });
            }

            if (GoldPec > 0)
            {
                recommandations.Add(new AssetRecommandation { AssetType = AssetType.Gold, Asset = null , Allocation = GoldPec });
            }

            if (riskCapacity == RiskLevel.High && riskTolerancey == RiskLevel.High && equityPec> 0)
            {
                var highRiskEquity = await yahooClient.GetSolidMidcapGrowthFundsAsync(5);
                recommandations.Add(new AssetRecommandation { AssetType = AssetType.Equity, Asset = highRiskEquity, Allocation = equityPec });
            }
            else if (riskCapacity == RiskLevel.ExtremeHigh && riskTolerancey == RiskLevel.ExtremeHigh && equityPec > 0)
            {
                var extemlyHighRiskEquity = await yahooClient.GetAggressiveSmallCapStocksAsync(5);
                recommandations.Add(new AssetRecommandation { AssetType = AssetType.Equity, Asset = extemlyHighRiskEquity, Allocation = equityPec });
            }
            else if (riskCapacity == RiskLevel.Moderate && riskTolerancey == RiskLevel.Moderate && equityPec > 0)
            {
                var moderateRiskEquity = await yahooClient.GetSolidLargeGrowthFundsAsync(5);
                recommandations.Add(new AssetRecommandation { AssetType = AssetType.Equity, Asset = moderateRiskEquity, Allocation = equityPec });
            }
            else
            {
                if (equityPec > 0)
                {
                    var lowRiskEquity = await yahooClient.GetUndervaluedLargeCapStocksAsync(5);
                    recommandations.Add(new AssetRecommandation { AssetType = AssetType.Equity, Asset = lowRiskEquity, Allocation = equityPec });
                }
            }
            return recommandations;


        }


    }
}
