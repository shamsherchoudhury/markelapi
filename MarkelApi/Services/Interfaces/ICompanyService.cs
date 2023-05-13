using System;
using Models.External;

namespace MarkelApi.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> GetCompany(int companyId);
    }
}

