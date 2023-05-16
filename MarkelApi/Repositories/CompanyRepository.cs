using MarkelApi.Repositories.Interfaces;
using Models.Entities;

namespace MarkelApi.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private static readonly List<Company> _companies;

        static CompanyRepository()
        {
            _companies = new List<Company>
            {
                new Company
                {
                    Id = 1,
                    Name = "Colaboy Associates",
                    Address1 = "23 Bellfry Street",
                    Address2 = "Jewson Quarter",
                    Address3 = "Borough Of Turnip",
                    Postcode = "HH3 56Y",
                    Country = "Land Of Make-Believe",
                    Active = true,
                    InsuranceEndDate = DateTime.UtcNow.AddYears(-1)
                },
                new Company
                {
                    Id = 2,
                    Name = "Prudential",
                    Address1 = "1 Madonna Square",
                    Address2 = "Jaja",
                    Address3 = string.Empty,
                    Postcode = string.Empty,
                    Country = "Land Of Make-Believe",
                    Active = true,
                    InsuranceEndDate = DateTime.UtcNow.AddYears(2)
                },
                new Company
                {
                    Id = 3,
                    Name = "MoreThan",
                    Address1 = "74 The Avenue",
                    Address2 = "Neverland",
                    Address3 = string.Empty,
                    Postcode = string.Empty,
                    Country = "Land Of Make-Believe",
                    Active = true,
                    InsuranceEndDate = DateTime.UtcNow.AddYears(3)
                }
            };
        }

        public async Task<Company?> GetCompany(int companyId)
        {
            var company = await Task.Run(() => _companies.SingleOrDefault(x => x.Id == companyId));

            return company;
        }
    }
}
