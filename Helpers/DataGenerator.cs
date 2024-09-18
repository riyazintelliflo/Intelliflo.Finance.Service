using Bogus;
using Intelliflo.Finance.Service.Models.Response;
using OoplesFinance.YahooFinanceAPI.Models;

namespace Intelliflo.Finance.Service.Helpers
{
    public static class DataGenerator
    {
        public static UserCreditProfile GenerateFakeUserCreditProfile()
        {
            var faker = new Faker();

            var creditProfile = new UserCreditProfile
            {
                AddressInformation = new List<AddressInformation>
                {
                new AddressInformation()
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
            },
                ConsumerIdentity = new ConsumerIdentity
                {
                    Dob = new Dob
                    {
                        Day = faker.Random.Number(1, 28).ToString("00"),
                        Month = faker.Random.Number(1, 12).ToString("00"),
                        Year = faker.Random.Number(1950, 2000).ToString()
                    },
                    Name = new Name
                    {
                        FirstName = faker.Name.FirstName(),
                        Surname = faker.Name.LastName()
                    },
                    Phone = new List<Phone>
                    {
                        new Phone()
                        {
                            Number = faker.Phone.PhoneNumber("##########"),
                            Source = faker.Random.String2(1),
                            Type = faker.Random.String2(1)
                        }
                }
                },
                EmploymentInformation = new List<EmploymentInformation>
            {
                new EmploymentInformation()
                {
                    AddressFirstLine = faker.Address.StreetAddress(),
                    AddressSecondLine = $"{faker.Address.City()} {faker.Address.StateAbbr()}",
                    FirstReportedDate = faker.Date.Past().ToString("MMddyyyy"),
                    LastUpdatedDate = faker.Date.Recent().ToString("MMddyyyy"),
                    Name = faker.Company.CompanyName(),
                    Source = "2",
                    ZipCode = faker.Address.ZipCode()
                }
            },
                Summaries = new List<Summary>
            {
                new Summary
                {
                    SummaryType = "Profile Summary",
                    Attributes = new List<UserAttribute>
                    {
                        new UserAttribute{ Id = "disputedAccountsExcluded", Value = faker.Random.Number(0, 999).ToString("000") },
                        new  UserAttribute{ Id = "PublicRecordsCount", Value = faker.Random.Number(0, 999).ToString("000") },
                        new  UserAttribute{ Id = "InstallmentBalance", Value = faker.Random.Number(0, 99999999).ToString("00000000") },
                        new UserAttribute{ Id = "RevolvingBalance", Value = faker.Random.Number(0, 99999999).ToString("00000000") },
                        new UserAttribute{ Id = "PastDueAmount", Value = faker.Random.Number(0, 99999999).ToString("00000000") },
                        new UserAttribute{ Id = "MonthlyPayment", Value = faker.Random.Number(0, 99999999).ToString("00000000") },
                        new UserAttribute { Id = "RevolvingAvailablePercent", Value = faker.Random.Number(0, 100).ToString() },
                        new UserAttribute{ Id = "TotalInquiries", Value = faker.Random.Number(0, 999).ToString("000") },
                        new UserAttribute { Id = "TotalTradeItems", Value = faker.Random.Number(0, 999).ToString("000") },
                        new UserAttribute{ Id = "SatisfactoryAccounts", Value = faker.Random.Number(0, 999).ToString("000") },
                        new UserAttribute { Id = "OldestTradeDate", Value = faker.Date.Past().ToString("MMddyyyy") }
                    }
                }
            },
                RiskModel = new List<RiskModel>
            {
                new RiskModel
                {
                    Evaluation = "P",
                    ModelIndicator = faker.Random.String2(2),
                    Score = faker.Random.Number(300, 850).ToString("0000"),
                    ScoreFactors = new List<ScoreFactor>
                    {
                        new ScoreFactor{ Importance = "1", Code = faker.Random.Number(10, 99).ToString() },
                        new ScoreFactor { Importance = "2", Code = faker.Random.Number(10, 99).ToString() },
                        new ScoreFactor{ Importance = "3", Code = faker.Random.Number(10, 99).ToString() },
                        new ScoreFactor { Importance = "4", Code = faker.Random.Number(10, 99).ToString() }
                    }
                }
            },
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
                .RuleFor(t => t.Evaluation, f => f.Random.String2(1, "N"))
                .RuleFor(t => t.Kob, f => f.Random.String2(2, "BC"))
                .RuleFor(t => t.LastPaymentDate, f => f.Date.Past().ToString("MMddyyyy"))
                .RuleFor(t => t.MonthsHistory, f => f.Random.Number(1, 99).ToString())
                .RuleFor(t => t.OpenDate, f => f.Date.Past().ToString("MMddyyyy"))
                .RuleFor(t => t.OpenOrClosed, f => f.Random.String2(1, "C"))
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


    }
}
