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
            string ssn = request.NumericInquiry.Ssn;
            var response = DataGenerator.GenerateFakeUserCreditProfile();
            response.Ssn = ssn;
            return response;
        }

        public FinicityVerificationOfAssets GetAssetsInfoByID(int clientID)
        {
            var response = DataGenerator.GenerateVerificationOfAssets();
            response.Id = clientID.ToString();
            return response;
        }
    }
}
