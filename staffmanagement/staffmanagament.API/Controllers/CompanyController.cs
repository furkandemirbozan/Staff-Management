using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using staffmanagament.CORE.DTOs;
using staffmanagament.CORE.Interfaces;
using staffmanagament.CORE.Models;

namespace staffmanagament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyRepository.GetAllAsync();
            var companiesDto = companies.Select(c => new CreateCompanyDto
            {
                CompanyId = c.Id,
                CompanyName = c.Name,
                CompanyEmail = c.Email,
                CompanyPhoneNumber = c.PhoneNumber,
                CompanyLogoUrl = c.LogoUrl
            });
            return Ok(companiesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            var companyDto = new CreateCompanyDto
            {
                CompanyId = company.Id,
                CompanyName = company.Name,
                CompanyEmail = company.Email,
                CompanyPhoneNumber = company.PhoneNumber,
                CompanyLogoUrl = company.LogoUrl
            };
            return Ok(companyDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto createCompanyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = new Company
            {
                Name = createCompanyDto.CompanyName,
                Email = createCompanyDto.CompanyEmail,
                PhoneNumber = createCompanyDto.CompanyPhoneNumber,
                LogoUrl = createCompanyDto.CompanyLogoUrl,
                Address = new Address
                {
                    StreetAddress = createCompanyDto.createAddressDto.StreetAddress,
                    PostalCode = createCompanyDto.createAddressDto.PostalCode,
                    City = createCompanyDto.createAddressDto.City,
                    State = createCompanyDto.createAddressDto.State,
                    Country = createCompanyDto.createAddressDto.Country,
                }
            };

            await _companyRepository.AddAsync(company);
            return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, createCompanyDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] CreateCompanyDto createCompanyDTO)
        {
            if (id != createCompanyDTO.CompanyId)
            {
                return BadRequest();
            }

            var existingCompany = await _companyRepository.GetByIdAsync(id);
            if (existingCompany == null)
            {
                return NotFound();
            }

            existingCompany.Name = createCompanyDTO.CompanyName;
            existingCompany.Email = createCompanyDTO.CompanyEmail;
            existingCompany.PhoneNumber = createCompanyDTO.CompanyPhoneNumber;
            existingCompany.LogoUrl = createCompanyDTO.CompanyLogoUrl;

            await _companyRepository.UpdateAsync(existingCompany);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            await _companyRepository.DeleteAsync(company);
            return NoContent();
        }
    }
}
