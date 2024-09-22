using Newtonsoft.Json;
using System;
namespace Intelliflo.Finance.Service.Models.Request
{
    public class Person
    {
        [JsonProperty("person.work")]
        public Work Work { get; set; }

        [JsonProperty("person.gender")]
        public int Gender { get; set; }

        [JsonProperty("person.birthdate")]
        public DateTime Birthdate { get; set; }

        [JsonProperty("person.household")]
        public Household Household { get; set; }
    }

    public class Work
    {
        [JsonProperty("person.work.income.gross.monthly")]
        public decimal IncomeGrossMonthly { get; set; }

        [JsonProperty("person.work.hours.weekly")]
        public double HoursWeekly { get; set; }
    }

    public class Household
    {
        [JsonProperty("person.household.net-income")]
        public decimal NetIncome { get; set; }

        [JsonProperty("person.household.adults.number")]
        public int AdultsNumber { get; set; }

        [JsonProperty("person.household.children.number")]
        public int ChildrenNumber { get; set; }
    }
}