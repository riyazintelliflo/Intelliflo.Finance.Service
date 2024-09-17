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
            }
            };

            return creditProfile;
        }

        
    }
}
