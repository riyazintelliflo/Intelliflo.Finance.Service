using Intelliflo.Finance.Service.Repositories.Contracts;
using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Models.Response;
using Intelliflo.Finance.Service.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intelliflo.Finance.Service.Repositories.Services
{
    public class CreditProfile : ICreditProfile
    {
        private FactfindDbContext _factfindDbContext;
        public CreditProfile(FactfindDbContext factfindDbContext)
        {
            _factfindDbContext = factfindDbContext;
        }
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

        public IOClientPortfolio GetUserPortfolio(int clientId)
        {
            var assets = _factfindDbContext.TAssets
                .Include(a => a.TAssetCategory)
                .Where(x => x.CRMContactId.Equals(clientId)).AsNoTracking().ToList();
            var liabilities = _factfindDbContext.TLiabilities.Where(x => x.CRMContactId.Equals(clientId)).AsNoTracking().ToList();

            return new IOClientPortfolio()
            {
                CRMContactId = clientId,
                Asset = assets,
                Liability = liabilities
            };
        }
    }
}
