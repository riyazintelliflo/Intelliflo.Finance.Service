namespace Intelliflo.Finance.Service.Models.Response
{
    public class ConsumerIdentity
    {
        public Dob Dob { get; set; }
        public List<Name> Name { get; set; }
        public List<Phone> Phone { get; set; }
    }

    public class Dob
    {
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }

    public class Name
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }

    public class Phone
    {
        public string Number { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }
    }

}
