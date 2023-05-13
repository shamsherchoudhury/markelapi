using System;
using Models.Entities;

namespace MarkelApi.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompany(int companyId);
    }
}

