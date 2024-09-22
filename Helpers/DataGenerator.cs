using Bogus;
using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Models.Response;

namespace Intelliflo.Finance.Service.Helpers
{
    public static class DataGenerator
    {
        public static UserCreditProfile GenerateFakeUserCreditProfile(IDType? idType)
        {
            var faker = new Faker(idType == IDType.PAN ? "en_IND" : "en_US");
            var predefinedPhoneNumbers = new List<string>
            {
                "01215264164",
                "01584861221",
                "01793692090",
                "01889343495",
                "01905795082",
                "01922631671",
                "01926334735",
                "01926495150",
                "01926855618",
                "7791366274",
                "7814493824",
                "7968852770",
                "7970120948"
            };
            var modeIndicators = new[] { "Experian credit score", "FICO score", "VantageScore 3.0", "II - Industry Specific" };
            var risk = new Faker<RiskModel>()
             .RuleFor(e => e.Evaluation, f => f.PickRandom("N", "P"))
             .RuleFor(e => e.ModelIndicator, f => f.PickRandom(modeIndicators))
             .RuleFor(e => e.Score, f => f.Random.Number(300, 850).ToString("0000"));


            var creditProfile = new UserCreditProfile
            {
                AddressInformation =
                [
                new()
                {
                    CensusGeoCode = faker.Random.Number(1000000, 9999999).ToString(),
                    City = faker.Address.City(),
                    CountyCode = faker.Random.Number(100, 999).ToString(),
                    DwellingType = faker.Random.String2(1),
                    FirstReportedDate = faker.Date.Past().ToString("MMddyyyy"),
                    LastReportingSubscriberCode = faker.Random.Number(1000000, 9999999).ToString(),
                    LastUpdatedDate = faker.Date.Recent().ToString("MMddyyyy"),
                    Source = "1",
                    State = faker.Address.StateAbbr(),
                    StreetName = faker.Address.StreetName(),
                    StreetPrefix = faker.Random.Number(1000, 9999).ToString(),
                    StreetSuffix = faker.Address.StreetSuffix(),
                    TimesReported = faker.Random.Number(0, 99).ToString("00"),
                    ZipCode = faker.Address.ZipCode()
                }
            ],
                ConsumerIdentity = new()
                {
                    Dob = new()
                    {
                        Day = faker.Random.Number(1, 28).ToString("00"),
                        Month = faker.Random.Number(1, 12).ToString("00"),
                        Year = faker.Random.Number(1950, 2000).ToString()
                    },
                    Name = new()
                    {
                        FirstName = faker.Name.FirstName(),
                        Surname = faker.Name.LastName()
                    },
                    Phone =
                    [
                        new()
                        {
                            Number = faker.Random.Bool() ? faker.PickRandom(predefinedPhoneNumbers) : faker.Phone.PhoneNumber("##########"),
                            Source = faker.Random.String2(1),
                            Type = faker.Random.String2(1)
                        }
                ],
                    Gender = faker.PickRandom<Gender>()
                },
                EmploymentInformation =
            [
                new()
                {
                    AddressFirstLine = faker.Address.StreetAddress(),
                    AddressSecondLine = $"{faker.Address.City()} {faker.Address.StateAbbr()}",
                    FirstReportedDate = faker.Date.Past().ToString("MMddyyyy"),
                    LastUpdatedDate = faker.Date.Recent().ToString("MMddyyyy"),
                    Name = faker.Company.CompanyName(),
                    Source = "2",
                    ZipCode = faker.Address.ZipCode()
                }
            ],
                Summaries =
            [
                new Summary
                {
                    SummaryType = "Profile Summary",
                    Attributes =
                    [
                        new() { Id = "disputedAccountsExcluded", Value = faker.Random.Number(0, 10).ToString("000") },
                        new() { Id = "PublicRecordsCount", Value = faker.Random.Number(0, 999).ToString("000") },
                        new() { Id = "InstallmentBalance", Value = faker.Random.Number(0, 99999999).ToString("00000000") },
                        new() { Id = "RevolvingBalance", Value = faker.Random.Number(0, 99999999).ToString("00000000") },
                        new() { Id = "PastDueAmount", Value = faker.Random.Number(0, 99999).ToString("00000000") },
                        new() { Id = "MonthlyPayment", Value = faker.Random.Number(0, 9999).ToString("00000000") },
                        new()  { Id = "RevolvingAvailablePercent", Value = faker.Random.Number(0, 100).ToString() },
                        new() { Id = "TotalInquiries", Value = faker.Random.Number(0, 999).ToString("000") },
                        new()  { Id = "TotalTradeItems", Value = faker.Random.Number(0, 999).ToString("000") },
                        new() { Id = "SatisfactoryAccounts", Value = faker.Random.Number(0, 20).ToString("000") },
                        new()  { Id = "OldestTradeDate", Value = faker.Date.Past().ToString("MMddyyyy") }
                    ]
                }
            ],
              
                RiskModel = risk.Generate(4),
                Tradeline = GenerateFakeTradelines(2)
            };

            return creditProfile;
        }


        public static List<Tradeline> GenerateFakeTradelines(int count = 1)
        {
            var enhancedPaymentDataFaker = new Faker<EnhancedPaymentData>()
                .RuleFor(e => e.ChargeoffAmount, f => f.Finance.Amount(0, 10000).ToString("0000000000"))
                .RuleFor(e => e.CreditLimitAmount, f => f.Random.Bool() ? "UNKNOWN" : f.Finance.Amount(0, 10000).ToString("0000000000"))
                .RuleFor(e => e.EnhancedAccountCondition, f => f.Random.Number(10, 99).ToString())
                .RuleFor(e => e.EnhancedAccountType, f => f.Random.Number(10, 99).ToString())
                .RuleFor(e => e.EnhancedPaymentHistory84, f => f.Random.String2(14, "L54321CCC"))
                .RuleFor(e => e.EnhancedPaymentStatus, f => f.Random.Number(10, 99).ToString())
                .RuleFor(e => e.EnhancedSpecialComment, f => f.Random.Number(10, 99).ToString())
                .RuleFor(e => e.EnhancedTerms, f => f.Random.String2(3, "REV"))
                .RuleFor(e => e.EnhancedTermsFrequency, f => f.Random.String2(1, "M"))
                .RuleFor(e => e.FirstDelinquencyDate, f => f.Date.Future().ToString("MMddyyyy"))
                .RuleFor(e => e.HighBalanceAmount, f => f.Finance.Amount(0, 10000).ToString("0000000000"))
                .RuleFor(e => e.PaymentLevelDate, f => f.Date.Past().ToString("MMddyyyy"))
                .RuleFor(e => e.SecondDelinquencyDate, f => f.Date.Future().ToString("MMddyyyy"));

            var tradelineFaker = new Faker<Tradeline>()
                .RuleFor(t => t.AccountNumber, f => f.Finance.Account())
                .RuleFor(t => t.AccountType, f => f.PickRandom<AccountType>())
                .RuleFor(t => t.Amount1, f => f.Finance.Amount(0, 10000).ToString("0000000000"))
                .RuleFor(t => t.Amount1Qualifier, f => f.Random.String2(1, "HC"))
                .RuleFor(t => t.Amount2, f => f.Finance.Amount(0, 10000).ToString("0000000000"))
                .RuleFor(t => t.Amount2Qualifier, f => f.Random.String2(1, "HC"))
                .RuleFor(t => t.AmountPastDue, f => f.Finance.Amount(0, 10000).ToString("0000000000"))
                .RuleFor(t => t.BalanceAmount, f => f.Finance.Amount(0, 10000).ToString("0000000000"))
                .RuleFor(t => t.BalanceDate, f => f.Date.Future().ToString("MMddyyyy"))
                .RuleFor(t => t.Delinquencies30Days, f => f.Random.Number(0, 9).ToString("00"))
                .RuleFor(t => t.Delinquencies60Days, f => f.Random.Number(0, 9).ToString("00"))
                .RuleFor(t => t.Delinquencies90to180Days, f => f.Random.Number(0, 9).ToString("00"))
                .RuleFor(t => t.DerogCounter, f => f.Random.Number(0, 9).ToString("00"))
                .RuleFor(t => t.Ecoa, f => f.Random.Number(1, 9).ToString())
                .RuleFor(t => t.EnhancedPaymentData, f => enhancedPaymentDataFaker.Generate())
                .RuleFor(t => t.Evaluation, f => f.PickRandom("P","N"))
                .RuleFor(t => t.Kob, f => f.Random.String2(2, "BC"))
                .RuleFor(t => t.LastPaymentDate, f => f.Date.Past().ToString("MMddyyyy"))
                .RuleFor(t => t.MonthsHistory, f => f.Random.Number(1, 99).ToString())
                .RuleFor(t => t.OpenDate, f => f.Date.Past().ToString("MMddyyyy"))
                .RuleFor(t => t.OpenOrClosed, f => f.PickRandom("O", "C"))
                .RuleFor(t => t.PaymentHistory, f => f.Random.String2(14, "99999954321CCC"))
                .RuleFor(t => t.RevolvingOrInstallment, f => f.Random.String2(1, "R"))
                .RuleFor(t => t.SpecialComment, f => f.Random.Number(10, 99).ToString())
                .RuleFor(t => t.Status, f => f.Random.Number(10, 99).ToString())
                .RuleFor(t => t.StatusDate, f => f.Date.Past().ToString("MMddyyyy"))
                .RuleFor(t => t.SubscriberCode, f => f.Random.Number(1000000, 9999999).ToString())
                .RuleFor(t => t.SubscriberName, f => f.Company.CompanyName())
                .RuleFor(t => t.Terms, f => f.Random.String2(3, "REV"));

            return tradelineFaker.Generate(count);
        }
        
        public static FinicityVerificationOfAssets GenerateVerificationOfAssets(IDType? idType)
        {
            var faker = new Faker(idType == IDType.PAN ? "en_IND" : "en_US");

            return new FinicityVerificationOfAssets
            {
                Id = faker.Random.AlphaNumeric(12),
                RequestId = faker.Random.AlphaNumeric(10),
                Title = "Finicity Verification of Assets",
                ConsumerId = faker.Random.Hexadecimal(32),
                ConsumerSsn = faker.Random.Replace("####"),
                RequesterName = faker.Company.CompanyName(),
                Type = "voa",
                Status = "success",              
                Days = faker.Random.Number(30, 365),
                Seasoned = faker.Random.Bool(),
                Institutions =
            [
                new Institution
                {
                    Id = faker.Random.Number(100000, 999999),
                    Name = faker.Company.CompanyName(),
                    Accounts = GenerateAccounts(faker)
                }
            ],
                Assets = new BaseAsset
                {
                    CurrentBalance = faker.Finance.Amount(1000, 100000, 2),
                    TwoMonthAverage = faker.Finance.Amount(1000, 100000, 2),
                    SixMonthAverage = faker.Finance.Amount(1000, 100000, 2),
                    BeginningBalance = faker.Finance.Amount(1000, 100000, 2)
                },
                ConsolidatedAvailableBalance = faker.Finance.Amount(1000, 100000, 2)
            };
        }

        private static List<Account> GenerateAccounts(Faker faker)
        {
            var accounts = new List<Account>();
            var accountTypes = new[] { "investment", "checking", "savings" };

            for (int i = 0; i < faker.Random.Number(1, 5); i++)
            {
                accounts.Add(new Account
                {
                    Id = faker.Random.Long(10000000, 99999999),
                    Number = faker.Finance.Account(8),
                    OwnerName = faker.Name.FullName(),
                    OwnerAddress = faker.Address.FullAddress(),
                    Name = faker.Finance.AccountName(),
                    Type = faker.PickRandom(accountTypes),
                    AvailableBalance = faker.Finance.Amount(0, 10000, 2),
                    AggregationStatusCode = 0,
                    Balance = faker.Finance.Amount(0, 10000, 2),
                    AverageMonthlyBalance = faker.Finance.Amount(0, 10000, 2),
                    Transactions = GenerateTransactions(faker),
                    Asset = new Asset
                    {
                        Type = faker.PickRandom(accountTypes),
                        CurrentBalance = faker.Finance.Amount(0, 10000, 2),
                        TwoMonthAverage = faker.Finance.Amount(0, 10000, 2),
                        SixMonthAverage = faker.Finance.Amount(0, 10000, 2),
                        BeginningBalance = faker.Finance.Amount(0, 10000, 2)
                    },
                    Details = new AccountDetails
                    {
                        InterestMarginBalance = faker.Random.Bool() ? (decimal?)faker.Finance.Amount(0, 1000, 2) : null,
                        AvailableCashBalance = faker.Random.Bool() ? (decimal?)faker.Finance.Amount(0, 1000, 2) : null,
                        VestedBalance = faker.Random.Bool() ? (decimal?)faker.Finance.Amount(0, 5000, 2) : null,
                        CurrentLoanBalance = faker.Random.Bool() ? (decimal?)faker.Finance.Amount(0, 10000, 2) : null,
                        AvailableBalanceAmount = faker.Random.Bool() ? (decimal?)faker.Finance.Amount(0, 1000, 2) : null
                    }
                });
            }

            return accounts;
        }

        private static List<Intelliflo.Finance.Service.Models.Transaction> GenerateTransactions(Faker faker)
        {
            var transactions = new List<Intelliflo.Finance.Service.Models.Transaction>();

            for (int i = 0; i < faker.Random.Number(1, 20); i++)
            {
                transactions.Add(new Intelliflo.Finance.Service.Models.Transaction
                {
                    Id = faker.Random.Long(1000000000, 9999999999),
                    Amount = faker.Finance.Amount(-1000, 1000, 2),
                    Description = GenerateTransactionDescription(faker),
                    Memo = faker.Lorem.Word(),
                    InstitutionTransactionId = faker.Random.Replace("##########"),
                    Category = faker.Commerce.Categories(1)[0]
                });
            }

            return transactions;
        }

        private static string GenerateTransactionDescription(Faker faker)
        {
            var transactionTypes = new[] { "Purchase", "Payment", "Withdrawal", "Deposit", "Transfer" };
            var merchants = new[] { "Walmart", "Amazon", "Target", "Costco", "Home Depot", "Best Buy" };

            return $"{faker.PickRandom(transactionTypes)} - {faker.PickRandom(merchants)}";
        }
    }

}

