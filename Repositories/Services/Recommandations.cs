using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Repositories.Contracts;
using OoplesFinance.YahooFinanceAPI;
using OoplesFinance.YahooFinanceAPI.Enums;
using OoplesFinance.YahooFinanceAPI.Models;

namespace Intelliflo.Finance.Service.Repositories.Services
{
    public class Recommendation : IRecommendation
    {
        public Recommendation() { }

        public async Task<List<AssetRecommendation>> GetRecommendations(Country country, RiskLevel riskCapacity, RiskLevel riskTolerance)
        {
            List<AssetRecommendation> recommendations = new();
            YahooClient yahooClient = new(country);
            var riskAllocation = RiskProfile.GetRiskProfile(riskCapacity, riskTolerance);
            
            AddAssetRecommendation(recommendations, AssetType.RealEstate, null, allocationPercentage: riskAllocation.Allocation[0]);
            AddAssetRecommendation(recommendations, AssetType.Gold, null, riskAllocation.Allocation[4]);

            if (riskAllocation.Allocation[1] > 0)
            {
                var debtFunds = await yahooClient.GetConservativeForeignFundsAsync(2);
                AddAssetRecommendation(recommendations, AssetType.Debt, debtFunds, riskAllocation.Allocation[1]);
            }

            if (riskAllocation.Allocation[2] > 0)
            {
                var mutualFunds = await yahooClient.GetTopMutualFundsAsync(3);
                AddAssetRecommendation(recommendations, AssetType.MF, mutualFunds, riskAllocation.Allocation[2]);
            }

            await HandleEquityRecommendations(yahooClient, recommendations, riskCapacity, riskTolerance, riskAllocation.Allocation[3]);

            return recommendations;
        }

        private void AddAssetRecommendation(List<AssetRecommendation> recommendations, AssetType assetType, ScreenerResult? asset, int allocationPercentage)
        {
            if (allocationPercentage > 0)
            {
                recommendations.Add(new AssetRecommendation
                {
                    AssetType = assetType,
                    Asset = asset,
                    Allocation = allocationPercentage
                });
            }
        }

        private async Task HandleEquityRecommendations(YahooClient yahooClient, List<AssetRecommendation> recommendations, RiskLevel riskCapacity, RiskLevel riskTolerance, int equityPercentage)
        {
            if (equityPercentage <= 0) return;

            if (riskCapacity == RiskLevel.High && riskTolerance == RiskLevel.High)
            {
                var highRiskEquity = await yahooClient.GetSolidMidcapGrowthFundsAsync(5);
                AddAssetRecommendation(recommendations, AssetType.Equity, highRiskEquity, equityPercentage);
            }
            else if (riskCapacity == RiskLevel.ExtremeHigh && riskTolerance == RiskLevel.ExtremeHigh)
            {
                var extremelyHighRiskEquity = await yahooClient.GetAggressiveSmallCapStocksAsync(5);
                AddAssetRecommendation(recommendations, AssetType.Equity, extremelyHighRiskEquity, equityPercentage);
            }
            else if (riskCapacity == RiskLevel.Moderate && riskTolerance == RiskLevel.Moderate)
            {
                var moderateRiskEquity = await yahooClient.GetSolidLargeGrowthFundsAsync(5);
                AddAssetRecommendation(recommendations, AssetType.Equity, moderateRiskEquity, equityPercentage);
            }
            else
            {
                var lowRiskEquity = await yahooClient.GetUndervaluedLargeCapStocksAsync(5);
                AddAssetRecommendation(recommendations, AssetType.Equity, lowRiskEquity, equityPercentage);
            }
        }
    }
}
