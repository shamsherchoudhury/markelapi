using MarkelApi.Services.Interfaces;
using MarkelApi.Repositories.Interfaces;
using NSubstitute;
using MarkelApi.Services;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CompanyServiceTests
    {
        private ICompanyRepository _companyRepository;
        private IClaimRepository _claimRepository;
        private ICompanyService _companyService;

        [SetUp]
        public void Setup()
        {
            _companyRepository = Substitute.For<ICompanyRepository>();
            _claimRepository = Substitute.For<IClaimRepository>();

            _companyService = new CompanyService(_companyRepository, _claimRepository);
        }

        [Test]
        public async Task GetCompany_Match_Name()
        {
            const string companyName = "Partners Inc.";
            _companyRepository.GetCompany(Arg.Any<int>()).Returns(new Models.Entities.Company { Name = companyName });

            var company = await _companyService.GetCompany(323);

            Assert.NotNull(company);
            Assert.That(company.Name,Is.EqualTo(companyName));
        }
    }
}
