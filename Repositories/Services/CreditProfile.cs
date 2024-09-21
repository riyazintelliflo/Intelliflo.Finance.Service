using Intelliflo.Finance.Service.Repositories.Contracts;
using Intelliflo.Finance.Service.Models;
using Intelliflo.Finance.Service.Models.Response;
using Intelliflo.Finance.Service.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Intelliflo.Finance.Service.DBContext;

namespace Intelliflo.Finance.Service.Repositories.Services
{
    public class CreditProfile(FactfindDbContext factfindDbContext, CRMDbContext crmDbContext) : ICreditProfile
    {
        private readonly FactfindDbContext _factfindDbContext = factfindDbContext;
        private readonly CRMDbContext _crmDbContext = crmDbContext;

        public UserCreditProfile GetUserCreditProfile(CreditProfileRequest request)
        {
            string ssn = request.NumericInquiry.Ssn;
            //https://sandbox-us-api.experian.com/eits/gdp/v1/request?targeturl=https%3A%2F%2Fsandbox-us-api.experian.com%2Fconsumerservices%2Fcredit-profile%2Fv2%2Fcredit-report
            var response = DataGenerator.GenerateFakeUserCreditProfile(request?.NumericInquiry?.IdType);
            response.Assets = DataGenerator.GenerateVerificationOfAssets(request?.NumericInquiry?.IdType);
            string? phoneNo = response.ConsumerIdentity.Phone.FirstOrDefault()?.Number; 
            if(phoneNo != null)
            {
                var contact = _crmDbContext.Contact.Where(c => c.Value == phoneNo)?.AsNoTracking()?.FirstOrDefault();
                if(contact != null)
                {
                    response.IOClientPortfolio = GetUserPortfolio(Convert.ToInt32(contact.CrmContactId));
                    response.IsIOClient = true;
                }
            }
            response.Ssn = ssn;
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
