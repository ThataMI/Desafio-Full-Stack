using AutoMapper;
using DesafioFullStack.backend.Models.Entities;
using DesafioFullStack.backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFullStack.backend.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {

        private readonly ICompaniesService _companiesService;


        public CompaniesController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;

        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Companies>>> GetAllCompanies()
        {
            return await _companiesService.GetAllCompanies();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Companies>> GetCompanyById(Guid id)
        {
            var result = await _companiesService.GetCompaniesById(id);
            if (result is null)
                return NotFound("Empresa não encontrada.");

            return Ok(result);
        }

        [HttpPost("Post")]
        public async Task<ActionResult<List<Companies>>> AddCompany(Companies companies)
        {
            var result = await _companiesService.AddCompanies(companies);
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<List<Companies>>> UpdateCompany(Guid id, Companies request)
        {
            var result = await _companiesService.UpdateCompanies(id, request);
            if (result is null)
                return NotFound("Empresa não encontrada.");

            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<List<Companies>>> DeleteCompany(Guid id)
        {
            var result = await _companiesService.DeleteCompanies(id);
            if (result is null)
                return NotFound("Empresa não encontrada.");

            return Ok(result);
        }

    }
}
