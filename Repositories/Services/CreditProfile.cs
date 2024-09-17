using Intelliflo.Finance.Service.Repositories.Contracts;
using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Models.Response;
using Intelliflo.Finance.Service.Helpers;
namespace Intelliflo.Finance.Service.Repositories.Services
{
    public class CreditProfile : ICreditProfile
    {
        public UserCreditProfile GetUserCreditProfile(CreditProfileRequest request)
        {
            UserCreditProfile response = new ();
            string ssn = request.NumericInquiry.Ssn;
            response = DataGenerator.GenerateFakeUserCreditProfile();
            response.Ssn = ssn;
            return response;

        }
    }
}
