using System;
using System.Collections.Generic;
namespace Intelliflo.Finance.Service.Models
{
    public class Enity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
    }
    public class FinicityVerificationOfAssets
    {
        public string Id { get; set; }
        public string RequestId { get; set; }
        public string Title { get; set; }
        public string ConsumerId { get; set; }
        public string ConsumerSsn { get; set; }
        public string RequesterName { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public long CreatedDate { get; set; }
        public long StartDate { get; set; }
        public long EndDate { get; set; }
        public int Days { get; set; }
        public bool Seasoned { get; set; }
        public List<Institution> Institutions { get; set; }
        public BaseAsset Assets { get; set; }
        public decimal ConsolidatedAvailableBalance { get; set; }
    }

    public class Institution : Enity
    {
        public required List<Account> Accounts { get; set; }
    }

    public class Account : Enity
    {
        public string Number { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public string Type { get; set; }
        public decimal? AvailableBalance { get; set; }
        public int AggregationStatusCode { get; set; }
        public decimal Balance { get; set; }
        public long BalanceDate { get; set; }
        public decimal AverageMonthlyBalance { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Asset Asset { get; set; }
        public AccountDetails Details { get; set; }
    }

    public class Transaction : Enity
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Memo { get; set; }
        public string InstitutionTransactionId { get; set; }
        public string Category { get; set; }
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
        public string Type { get; set; }        
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