using Microsoft.AspNetCore.Mvc;
using MarkelApi.Services.Interfaces;
using Models.External;
using Models.Exceptions;
//using Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarkelApi.Controllers
{
    [Route("api/[controller]")]
    //[Route("[controller]")]
    //[ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("details/{companyId}")]
        [ProducesResponseType(typeof(Company), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Company), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Company>> GetCompany(int companyId)
        {
            var company = await _companyService.GetCompany(companyId);

            if (company is null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpGet("claims/{companyId}")]
        public async Task<IEnumerable<BasicClaim>> GetBasicClaims(int companyId)
        {
            return await _companyService.GetBasicClaims(companyId);
        }

        [HttpGet("claim/{ucr}")]
        [ProducesResponseType(typeof(EnhancedClaim), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(EnhancedClaim), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EnhancedClaim>> GetEnhancedClaim(string ucr)
        {
            var enhancedClaim = await _companyService.GetEnhancedClaim(ucr);

            if (enhancedClaim is null)
            {
                return NotFound();
            }

            return Ok(enhancedClaim);

        }

        [HttpPut("claim")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task UpdateClaim([FromBody] BasicClaim claim)
        {
            try
            {
                //var claim = System.Text.Json.JsonSerializer.Deserialize<BasicClaim>(value);

                if (claim is not null)
                {
                    await _companyService.UpdateClaim(claim);
                    Ok();
                }
            }
            catch (EntityNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                BadRequest();
            }
        }
    }
}

