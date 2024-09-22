using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Models.Response;

namespace Intelliflo.Finance.Service.Helpers
{
    public static class ComparisionProfiler
    {
        public static IncomeStatistics GetIncomeStatistics(Gender gender, int age)
        {
            // Define income data for each age group and gender
            var incomeComparison = new IncomeComparison
            {
                Values = new GenderIncome
                {
                    Male = new AgeGroupIncome
                    {
                        Under18 = new IncomeStatistics { FirstQuartile = 500, Median = 750, ThirdQuartile = 1000, Average = 800 },
                        From18To24 = new IncomeStatistics { FirstQuartile = 1500, Median = 2000, ThirdQuartile = 2500, Average = 2100 },
                        From25To34 = new IncomeStatistics { FirstQuartile = 2000, Median = 2600, ThirdQuartile = 3400, Average = 2800 },
                        From35To44 = new IncomeStatistics { FirstQuartile = 2500, Median = 3200, ThirdQuartile = 4200, Average = 3400 },
                        From45To54 = new IncomeStatistics { FirstQuartile = 2800, Median = 3600, ThirdQuartile = 4800, Average = 3800 },
                        From55To64 = new IncomeStatistics { FirstQuartile = 2600, Median = 3400, ThirdQuartile = 4600, Average = 3600 },
                        Over65 = new IncomeStatistics { FirstQuartile = 2000, Median = 2800, ThirdQuartile = 3800, Average = 3000 }
                    },
                    Female = new AgeGroupIncome
                    {
                        Under18 = new IncomeStatistics { FirstQuartile = 450, Median = 700, ThirdQuartile = 900, Average = 750 },
                        From18To24 = new IncomeStatistics { FirstQuartile = 1400, Median = 1900, ThirdQuartile = 2400, Average = 2000 },
                        From25To34 = new IncomeStatistics { FirstQuartile = 1900, Median = 2500, ThirdQuartile = 3300, Average = 2700 },
                        From35To44 = new IncomeStatistics { FirstQuartile = 2400, Median = 3100, ThirdQuartile = 4100, Average = 3300 },
                        From45To54 = new IncomeStatistics { FirstQuartile = 2700, Median = 3500, ThirdQuartile = 4700, Average = 3700 },
                        From55To64 = new IncomeStatistics { FirstQuartile = 2500, Median = 3300, ThirdQuartile = 4500, Average = 3500 },
                        Over65 = new IncomeStatistics { FirstQuartile = 1900, Median = 2700, ThirdQuartile = 3700, Average = 2900 }
                    }
                }
            };

            // Determine the correct income group based on gender and age
            AgeGroupIncome ageGroupIncome;
            if (gender == Gender.Male)
            {
                ageGroupIncome = incomeComparison.Values.Male;
            }
            else if (gender == Gender.Female)
            {
                ageGroupIncome = incomeComparison.Values.Female;
            }
            else
            {
                throw new ArgumentException("Invalid gender provided");
            }

            // Return income statistics based on age group
            if (age < 18)
            {
                return ageGroupIncome.Under18;
            }
            else if (age >= 18 && age <= 24)
            {
                return ageGroupIncome.From18To24;
            }
            else if (age >= 25 && age <= 34)
            {
                return ageGroupIncome.From25To34;
            }
            else if (age >= 35 && age <= 44)
            {
                return ageGroupIncome.From35To44;
            }
            else if (age >= 45 && age <= 54)
            {
                return ageGroupIncome.From45To54;
            }
            else if (age >= 55 && age <= 64)
            {
                return ageGroupIncome.From55To64;
            }
            else
            {
                return ageGroupIncome.Over65;
            }
        }

    }
}
