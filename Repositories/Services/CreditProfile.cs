﻿using Intelliflo.Finance.Service.Repositories.Contracts;
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
            UserCreditProfile response = new ();
            string ssn = request.NumericInquiry.Ssn;
            response = DataGenerator.GenerateFakeUserCreditProfile();
            response.Ssn = ssn;
            return response;

        }

        public TAssetsAndLiabilities GetUserPortfolio(int clientId)
        {
            var assets = _factfindDbContext.TAssets
                .Include(a => a.TAssetCategory)
                .Where(x => x.CRMContactId.Equals(clientId)).ToList();
            var liabilities = _factfindDbContext.TLiabilities.Where(x => x.CRMContactId.Equals(clientId)).AsNoTracking().ToList();

            var assetsAndLiabilities = new TAssetsAndLiabilities()
            {
                CRMContactId = clientId,
                Asset = assets,
                Liability = liabilities
            };
            return assetsAndLiabilities;
        }
    }
}
