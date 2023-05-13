using System;
using MarkelApi.Repositories;
using MarkelApi.Services.Interfaces;
using Models.External;

namespace MarkelApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyRepository _companyRepository;

        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> GetCompany(int companyId)
        {
            var entity = await _companyRepository.GetCompany(companyId);

            return new Company
            {
                Name = entity.Name,
                Address1 = entity.Address1,
                Address2 = entity.Address2,
                Address3 = entity.Address3,
                Postcode = entity.Postcode,
                Country = entity.Country,
                InsuranceEndDate = entity.InsuranceEndDate
            };
        }
    }
}

