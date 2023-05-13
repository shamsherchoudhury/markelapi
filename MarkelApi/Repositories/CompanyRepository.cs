using System;
using System.Linq.Expressions;
using Models.Entities;

namespace MarkelApi.Repositories
{
    public class CompanyRepository
    {
        public async Task<Company> GetCompany(int companyId)
        {
            return await Task.Run<Company>(() =>
            new Company
            {
                Id = 1,
                Name = "Colaboy Associates",
                Address1 = "23 Bellfry Street",
                Address2 = "Jewson Quarter",
                Address3 = "Borough Of Turnip",
                Postcode = "HH3 56Y",
                Country = "U.K.",
                Active = true,
                InsuranceEndDate = DateTime.UtcNow.AddYears(1)
            }
            );
        }
    }
}

