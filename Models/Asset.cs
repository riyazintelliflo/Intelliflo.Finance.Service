using OoplesFinance.YahooFinanceAPI.Enums;
using OoplesFinance.YahooFinanceAPI.Models;
using System;
using System.Collections.Generic;
namespace Intelliflo.Finance.Service.Models
{
    public class AssetRecommendation
    {
        public AssetType AssetType { get; set; }
        public ScreenerResult ? Asset { get; set; }
        public int Allocation { get; set; }
    }

    public class RiskProfile
    {
        public RiskLevel RiskCapacity { get; set; }
        public RiskLevel RiskTolerance { get; set; }
        public List<int>? Allocation { get; set; }

        public static RiskProfile GetRiskProfile(RiskLevel riskCapacity, RiskLevel riskTolerance)
        {
            var riskProfiles = new List<RiskProfile>
            {
               new() { RiskCapacity= RiskLevel.Low, RiskTolerance =RiskLevel.Low, Allocation = [0, 80, 10, 0, 10] },
               new() { RiskCapacity= RiskLevel.Moderate, RiskTolerance =RiskLevel.Low, Allocation =[ 0, 60, 25, 5, 10 ] },
               new() { RiskCapacity= RiskLevel.High, RiskTolerance =RiskLevel.Low, Allocation =[ 0, 50, 30, 10, 10 ] },
               new() { RiskCapacity= RiskLevel.ExtremeHigh, RiskTolerance =RiskLevel.Low, Allocation =[0, 45, 30, 20, 5 ] },
               new() { RiskCapacity= RiskLevel.Low, RiskTolerance =RiskLevel.Moderate, Allocation =[  0, 70, 20, 10, 0 ] },
               new() { RiskCapacity= RiskLevel.Moderate, RiskTolerance =RiskLevel.Moderate, Allocation =[0, 50, 30, 10, 10 ] },
               new() { RiskCapacity= RiskLevel.High, RiskTolerance =RiskLevel.Moderate, Allocation =[ 0, 45, 40, 10, 5 ] },
               new() { RiskCapacity= RiskLevel.ExtremeHigh, RiskTolerance =RiskLevel.Moderate, Allocation = [ 20, 35, 40, 5, 0 ] },
               new() { RiskCapacity= RiskLevel.Low, RiskTolerance =RiskLevel.High, Allocation = [10, 50, 30, 10, 0 ] },
               new() { RiskCapacity= RiskLevel.Moderate, RiskTolerance =RiskLevel.High, Allocation = [ 20, 40, 30, 10, 0 ] },
               new() { RiskCapacity= RiskLevel.High, RiskTolerance =RiskLevel.High, Allocation = [ 15, 30, 45, 5, 5 ] },
               new() { RiskCapacity= RiskLevel.ExtremeHigh, RiskTolerance =RiskLevel.High, Allocation = [25, 20, 45, 0, 10 ] },
               new() { RiskCapacity= RiskLevel.Low, RiskTolerance =RiskLevel.ExtremeHigh, Allocation = [  10, 45, 35, 5, 5 ] },
               new() { RiskCapacity= RiskLevel.Moderate, RiskTolerance =RiskLevel.ExtremeHigh, Allocation = [25, 30, 35, 5, 5 ] },
               new() { RiskCapacity= RiskLevel.High, RiskTolerance =RiskLevel.ExtremeHigh, Allocation = [ 25, 20, 45, 0, 10] },
               new() { RiskCapacity= RiskLevel.ExtremeHigh, RiskTolerance =RiskLevel.ExtremeHigh, Allocation = [ 30, 0, 55, 0, 15 ] }

            };
            var allocation = riskProfiles.Find(x => x.RiskCapacity == riskCapacity && x.RiskTolerance == riskTolerance);

            return allocation ?? throw new ArgumentException("Invalid risk capacity or risk tolerance level");
        }
    }
   
    public class Enity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
    }

    public class  AssetAllocation
    {
        public int Percentage { get; set; }
        public ScreenerType AssetType { get; set; }

    }
    public class FinicityVerificationOfAssets
    {
        public string? Id { get; set; }
        public string? RequestId { get; set; }
        public string? Title { get; set; }
        public string? ConsumerId { get; set; }
        public string? ConsumerSsn { get; set; }
        public string? RequesterName { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public long CreatedDate { get; set; }
        public long StartDate { get; set; }
        public long EndDate { get; set; }
        public int Days { get; set; }
        public bool Seasoned { get; set; }
        public List<Institution>? Institutions { get; set; }
        public BaseAsset? Assets { get; set; }
        public decimal ConsolidatedAvailableBalance { get; set; }
    }

    public class Institution : Enity
    {
        public required List<Account> Accounts { get; set; }
    }

    public class Account : Enity
    {
        public string? Number { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerAddress { get; set; }
        public string? Type { get; set; }
        public decimal? AvailableBalance { get; set; }
        public int AggregationStatusCode { get; set; }
        public decimal Balance { get; set; }
        public long BalanceDate { get; set; }
        public decimal AverageMonthlyBalance { get; set; }
        public List<Transaction>? Transactions { get; set; }
        public Asset? Asset { get; set; }
        public AccountDetails? Details { get; set; }
    }

    public class Transaction : Enity
    {
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public string? Memo { get; set; }
        public string? InstitutionTransactionId { get; set; }
        public string? Category { get; set; }
    }

    public class BaseAsset
    {
        public decimal CurrentBalance { get; set; }
        public decimal TwoMonthAverage { get; set; }
        public decimal SixMonthAverage { get; set; }
        public decimal BeginningBalance { get; set; }
    }

    public class Asset : BaseAsset
    {
        public string? Type { get; set; }        
    }

    public class AccountDetails
    {
        public decimal? InterestMarginBalance { get; set; }
        public decimal? AvailableCashBalance { get; set; }
        public decimal? VestedBalance { get; set; }
        public decimal? CurrentLoanBalance { get; set; }
        public decimal? AvailableBalanceAmount { get; set; }
    }   
}